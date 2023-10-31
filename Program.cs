// Decompiled with JetBrains decompiler
// Type: ProxyDefCreator.Program
// Assembly: ProxyDefCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B9C2A47C-8EB9-45B6-9EF5-13990B30E4AC
// Assembly location: C:\Users\a\Desktop\ProxyDefCreator.exe

using ProxyDefCreator.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ProxyDefCreator
{
    internal class Program
    {
        private static List<Program.Export> Exports = new List<Program.Export>();

        private static void Main(string[] args)
        {
            if (args.Length < 1 || !File.Exists(args[0]))
            {
                Console.WriteLine("Error: you must specify a valid path to a dll file");
                Console.ReadLine();
            }
            else
            {
                string path1 = Path.Combine(Path.GetTempPath(), "ProxyDefCreator") + Path.DirectorySeparatorChar.ToString();
                if (!Directory.Exists(path1))
                    Directory.CreateDirectory(path1);
                if (!File.Exists(path1 + "dumpbin.exe"))
                    File.WriteAllBytes(path1 + "dumpbin.exe", Resources.dumpbin);
                if (!File.Exists(path1 + "link.exe"))
                    File.WriteAllBytes(path1 + "link.exe", Resources.link);
                if (!File.Exists(path1 + "mspdb140.dll"))
                    File.WriteAllBytes(path1 + "mspdb140.dll", Resources.mspdb140);
                Process process = new Process();
                process.StartInfo.FileName = path1 + "dumpbin.exe";
                process.StartInfo.Arguments = "/exports \"" + args[0] + "\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                string end = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                int num1 = 0;
                bool flag1 = false;
                foreach (string str1 in end.Split(Environment.NewLine.ToCharArray()))
                {
                    if (!flag1)
                    {
                        if (str1.Contains("ordinal hint RVA      name"))
                            flag1 = true;
                    }
                    else if (str1.Length > 26)
                    {
                        string str2 = "";
                        string str3 = str1;
                        char[] chArray = new char[1] { ' ' };
                        foreach (string str4 in str3.Split(chArray))
                        {
                            if (str4 != "")
                            {
                                str2 = str4;
                                break;
                            }
                        }
                        string str5 = str1.Substring(26).Split(' ')[0];
                        if (str5.Length > num1)
                            num1 = str5.Length;
                        Program.Export export = new Program.Export();
                        export.Function = str5;
                        export.Ordinal = Convert.ToInt32(str2);
                        bool flag2 = false;
                        for (int index = 0; index < Program.Exports.Count; ++index)
                        {
                            if (export.Ordinal < Program.Exports[index].Ordinal)
                            {
                                Program.Exports.Insert(index, export);
                                flag2 = true;
                                break;
                            }
                        }
                        if (!flag2)
                            Program.Exports.Add(export);
                    }
                }
                string withoutExtension = Path.GetFileNameWithoutExtension(args[0]);
                string fileName = Path.GetFileName(args[0]);
                string pathVS = withoutExtension + Path.DirectorySeparatorChar.ToString();
                Directory.CreateDirectory(pathVS);
                File.WriteAllText(pathVS + "dllmain.c", Resources.dllmain);
                File.WriteAllText(pathVS + "patch.h", Resources.patch);
                File.WriteAllText(pathVS + withoutExtension + ".vcxproj", Resources.template.Replace("##templateUPPER##", withoutExtension.ToUpper()).Replace("##template##", withoutExtension));
                using (StreamWriter streamWriter1 = new StreamWriter(pathVS + "dllmain.c", true))
                {
                    using (StreamWriter streamWriter2 = new StreamWriter(pathVS + withoutExtension + ".def", false))
                    {
                        streamWriter2.WriteLine("LIBRARY " + fileName);
                        streamWriter2.WriteLine();
                        streamWriter2.WriteLine("EXPORTS");
                        foreach (Program.Export export in Program.Exports)
                        {
                            bool flag3 = export.Function == "[NONAME]";
                            int ordinal;
                            string str6;
                            if (!flag3)
                            {
                                str6 = export.Function;
                            }
                            else
                            {
                                ordinal = export.Ordinal;
                                str6 = "exp" + ordinal.ToString();
                            }
                            string str7 = str6;
                            string str8;
                            if (!flag3)
                            {
                                str8 = export.Function;
                            }
                            else
                            {
                                ordinal = export.Ordinal;
                                str8 = "#" + ordinal.ToString();
                            }
                            string str9 = str8;
                            streamWriter1.Write("#pragma comment(linker, \"/export:");
                            streamWriter1.Write(str7 + "=C:\\\\Windows\\\\System32\\\\" + withoutExtension + "." + str9);
                            StreamWriter streamWriter3 = streamWriter1;
                            ordinal = export.Ordinal;
                            string str10 = ",@" + ordinal.ToString() + (flag3 ? ",NONAME" : "") + "\")";
                            streamWriter3.WriteLine(str10);
                            streamWriter2.Write("    " + str7);
                            for (int index = 0; index < num1 - str7.Length; ++index)
                                streamWriter2.Write(" ");
                            streamWriter2.Write(" = C:\\\\Windows\\\\System32\\\\" + withoutExtension + "." + str9 + " ");
                            for (int index = 0; index < num1 - str7.Length; ++index)
                                streamWriter2.Write(" ");
                            StreamWriter streamWriter4 = streamWriter2;
                            ordinal = export.Ordinal;
                            string str11 = "@" + ordinal.ToString() + (flag3 ? " NONAME" : "");
                            streamWriter4.WriteLine(str11);
                        }
                    }
                }


            }
        }

        private struct Export
        {
            public string Function;
            public int Ordinal;
        }
    }
}
