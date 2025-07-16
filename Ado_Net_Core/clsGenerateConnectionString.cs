using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_Net_Core
{
    public class clsGenerateConnectionString
    {



        private static StringBuilder sb;
        private static string _ServerName;
        private static string _DatabaseName;

        private static void GetConnectionString()
        {
           sb.AppendLine( $"public static string ConnectionString=\"Data Source={_ServerName};Initial Catalog={_DatabaseName};Integrated Security=True;\";");
        }
        private static void Initialize()
        {
            sb.AppendLine($"using System;\n");
            sb.AppendLine($"using System.Data;\n");
            sb.AppendLine($"using System.Data.SqlClient;\n");
            sb.AppendLine($"\npublic class clsDataAccessSetting\n{{");
        }

        public static string GenerateConnectionString(string servername,string databaseName)
        {
            _ServerName=servername;
            _DatabaseName=databaseName;
            sb=new StringBuilder();
            Initialize();
            GetConnectionString();
            UnInitialize();
            return sb.ToString  ();
        }
        private static void UnInitialize()
        {
            sb.AppendLine($"\n\n}}");
            sb.AppendLine($"\n\n}}");
        }



    }
}
