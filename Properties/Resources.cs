// Decompiled with JetBrains decompiler
// Type: ProxyDefCreator.Properties.Resources
// Assembly: ProxyDefCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B9C2A47C-8EB9-45B6-9EF5-13990B30E4AC
// Assembly location: C:\Users\a\Desktop\ProxyDefCreator.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ProxyDefCreator.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (ProxyDefCreator.Properties.Resources.resourceMan == null)
          ProxyDefCreator.Properties.Resources.resourceMan = new ResourceManager("ProxyDefCreator.Properties.Resources", typeof (ProxyDefCreator.Properties.Resources).Assembly);
        return ProxyDefCreator.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => ProxyDefCreator.Properties.Resources.resourceCulture;
      set => ProxyDefCreator.Properties.Resources.resourceCulture = value;
    }

    internal static string dllmain => ProxyDefCreator.Properties.Resources.ResourceManager.GetString(nameof (dllmain), ProxyDefCreator.Properties.Resources.resourceCulture);

    internal static byte[] dumpbin => (byte[]) ProxyDefCreator.Properties.Resources.ResourceManager.GetObject(nameof (dumpbin), ProxyDefCreator.Properties.Resources.resourceCulture);

    internal static byte[] link => (byte[]) ProxyDefCreator.Properties.Resources.ResourceManager.GetObject(nameof (link), ProxyDefCreator.Properties.Resources.resourceCulture);

    internal static byte[] mspdb140 => (byte[]) ProxyDefCreator.Properties.Resources.ResourceManager.GetObject(nameof (mspdb140), ProxyDefCreator.Properties.Resources.resourceCulture);

    internal static string patch => ProxyDefCreator.Properties.Resources.ResourceManager.GetString(nameof (patch), ProxyDefCreator.Properties.Resources.resourceCulture);

    internal static string proxy => ProxyDefCreator.Properties.Resources.ResourceManager.GetString(nameof (proxy), ProxyDefCreator.Properties.Resources.resourceCulture);

    internal static string proxy_forward => ProxyDefCreator.Properties.Resources.ResourceManager.GetString(nameof (proxy_forward), ProxyDefCreator.Properties.Resources.resourceCulture);

    internal static string template => ProxyDefCreator.Properties.Resources.ResourceManager.GetString(nameof (template), ProxyDefCreator.Properties.Resources.resourceCulture);
  }
}
