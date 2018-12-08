using System.Configuration;

namespace SenseFramework.Data.EntityFramework
{
    public static class Schema
    {
        public static string Prefix { get { return ConfigurationManager.AppSettings["TablePrefix"]+"_"; } }
        public static string Name => ConfigurationManager.AppSettings["SchemaName"]; /* { get{ return "xxx";  } } */
    }
}
