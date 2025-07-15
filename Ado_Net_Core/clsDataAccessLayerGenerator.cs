using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Ado_Net_Core
{
    public class clsDataAccessLayerGenerator
    {
        private static StringBuilder sb;
        private static List<clsColumnInfo> _Columns;
        private static string _ClassName;
        private static string _TableName;
        private static string _ServerName;
        private static string _DatabaseName;

        public static string GenerateCode(string ServerName, string DatabaseName, string TableName, string ClassName)
        {
            _ClassName = ClassName;
            _TableName = TableName;
            _ServerName = ServerName;
            _DatabaseName = DatabaseName;
            sb = new StringBuilder();
            _Columns = clsDatabaseSettings.GetShcemaDetails(ServerName, DatabaseName, TableName);
            Initialize();
            _ConnectionString();
            GetAll();
            GetByID();
            AddNew();
            Update();
            Delete();
            IsExist();
            UnInitialize();
            return sb.ToString();
        }

        private static clsColumnInfo _GetPkColumn()
        {
            foreach (clsColumnInfo column in _Columns)
                if (column.IsPrimaryKey)
                    return column;
            return null;
        }
        private static string NameFromTableName(string s)
        {
            string res = s;
            return char.ToUpper(res[0]).ToString() + res.Substring(1);
        }

        private static void Initialize()
        {
            sb.AppendLine($"using System;\n");
            sb.AppendLine($"using System.Data;\n");
            sb.AppendLine($"using System.Data.SqlClient;\n");
            sb.AppendLine($"\nnamespace DAL{{\n");
            sb.AppendLine($"\npublic class cls{NameFromTableName(_TableName)}Data\n{{");
        }

        private static void _ConnectionString()
        {
            sb.AppendLine($"\t\t\tprivate static string _ConnectionString = \t" +
            $"\"Server={_ServerName};Database={_DatabaseName};Integrated Security=True\";\n\n");
        }

        private static void GetAll()
        {
            sb.AppendLine($"\t\tpublic static DataTable GetAll{NameFromTableName(_TableName)}Data () {{");
            sb.AppendLine($"\t\t\tDataTable dt = new DataTable();");
            sb.AppendLine($"\t\t\tusing (SqlConnection conn = new SqlConnection(_ConnectionString))");
            sb.AppendLine($"\t\t\t{{");
            sb.AppendLine($"\t\t\t\tstring query = \"SELECT * FROM {_TableName} \";");
            sb.AppendLine($"\t\t\t\tusing (SqlCommand cmd = new SqlCommand(query, conn)) ");
            sb.AppendLine($"\t\t\t\t{{");
            sb.AppendLine($"\t\t\t\t\ttry");
            sb.AppendLine($"\t\t\t\t\t{{");
            sb.AppendLine($"\t\t\t\t\t\tconn.Open();");
            sb.AppendLine($"\t\t\t\t\t\tusing (SqlDataReader reader = cmd.ExecuteReader())");
            sb.AppendLine($"\t\t\t\t\t\t{{");
            sb.AppendLine($"\t\t\t\t\t\t\tif (reader.HasRows)");
            sb.AppendLine($"\t\t\t\t\t\t\t\tdt.Load(reader);");
            sb.AppendLine($"\t\t\t\t\t\t}}");
            sb.AppendLine($"\t\t\t\t\t}}");
            sb.AppendLine($"\t\t\t\t\tcatch(Exception ex)");
            sb.AppendLine($"\t\t\t\t\t{{");
            sb.AppendLine($"\t\t\t\t\t\treturn null;");
            sb.AppendLine($"\t\t\t\t\t}}");
            sb.AppendLine($"\t\t\t\t}}");
            sb.AppendLine($"\t\t\t}}");
            sb.AppendLine($"\t\t\treturn dt;");
            sb.AppendLine($"\t\t}}");
            sb.AppendLine($"");

        }

        private static void GetByID()
        {
            string parameters = $"{_Columns[0].DataType} {_Columns[0].ColumnName}, ";
            foreach (clsColumnInfo column in _Columns.Skip(1))
                parameters += $"ref {column.DataType}{(column.IsNullable ? $"{((column.DataType != "string") ? "?" : "")}" : "")} {column.ColumnName}, ";
            parameters = parameters.Remove(parameters.Length - 2);
            sb.AppendLine($"\t\tpublic static bool Get{NameFromTableName(_ClassName)}ByID (" +
                $"{parameters} ) {{\n\t\t\tbool Is_Found=false;\n");
            sb.AppendLine($"\t\t\tusing (SqlConnection conn = new SqlConnection(_ConnectionString)){{\n" +
                $"\t\t\t\tstring query=\" select *from {_TableName} where {_Columns[0].ColumnName}=@{_Columns[0].ColumnName}; \";\n" +
                $"\t\t\t");
            sb.AppendLine($"\t\t\t\tusing (SqlCommand cmd = new SqlCommand(query, conn)) {{\n" +
                $"\t\t\t\t cmd.Parameters.AddWithValue(\"@{_Columns[0].ColumnName}\",{_Columns[0].ColumnName});\n");
            sb.AppendLine($"try{{\n" +
                $"\t\t\t\t\tconn.Open();\n" +
                $"\t\t\t\t\tusing(SqlDataReader reader = cmd.ExecuteReader()){{\n\t\t\t\t\t");
            sb.AppendLine($"if(reader.Read()){{\n" +
                $"\t\t\t\t\tIs_Found=true;\n");
            string FillParameters = "";
            foreach (clsColumnInfo column in _Columns.Skip(1))
                if (column.IsNullable)
                    FillParameters += $"{column.ColumnName}=" +
                        $"reader.IsDBNull(reader.GetOrdinal(\"{column.ColumnName}\")) ? null :" +
                        $" ({column.DataType}{((column.DataType != "string") ? "?" : "")})reader[\"{column.ColumnName}\"];\n\t\t\t\t\t";
                else
                    FillParameters += $"{column.ColumnName}=({column.DataType})reader[\"{column.ColumnName}\"];\n\t\t\t\t\t";
            sb.AppendLine($"{FillParameters}\n");
            sb.AppendLine($"\n}}");
            sb.AppendLine($"\n}}");
            sb.AppendLine($"\n\t\t\t\t}}catch(Exception ex){{\n" +
                $"\t\t\t\t\t\tIs_Found=false;\n");
            sb.AppendLine($"}}\n\n");
            sb.AppendLine($"\nreturn Is_Found;\n}}\n\n");
            sb.AppendLine($"}}\n\n");
            sb.AppendLine($"}}\n\n");
        }

        private static string _GetColumnsNameForQuery(bool IgnorePkColumn = false)
        {
            string res = "";
            if (IgnorePkColumn)
                foreach (clsColumnInfo col in _Columns.Skip(1))
                    res += "@" + col.ColumnName + ", ";
            else
                foreach (clsColumnInfo col in _Columns)
                    res += "@" + col.ColumnName + ", ";
            return res.Remove(res.Length - 2);
        }

        private static string _GetColumnsNameForUpdate(bool IgnorePkColumn = false)
        {
            string res = "";
            if (IgnorePkColumn)
                foreach (clsColumnInfo col in _Columns.Skip(1))
                    res += "[" + col.ColumnName + "], ";
            else
                foreach (clsColumnInfo col in _Columns)
                    res += "[" + col.ColumnName + "], ";
            return res.Remove(res.Length - 2);
        }

        private static string _CmdParameters(bool IgnorePkColumn = false)
        {
            string res = "";
            if (IgnorePkColumn)
            {
                foreach (clsColumnInfo col in _Columns.Skip(1))
                {
                    if (col.IsNullable)
                        res += $"\nif({col.ColumnName}!=null)\n\t\t\t\t" +
                            $"cmd.Parameters.AddWithValue(\"@{col.ColumnName}\",{col.ColumnName});\n\t\t\t\t\telse\n\t\t\t\t\t" +
                            $"cmd.Parameters.AddWithValue(\"@{col.ColumnName}\", DBNull.Value);";
                    else
                        res += $"cmd.Parameters.AddWithValue(\"@{col.ColumnName}\",{col.ColumnName});\n\t\t\t\t\t";
                }
            }
            else
            {

                foreach (clsColumnInfo col in _Columns)
                {
                    if (col.IsNullable)
                        res += $"\nif({col.ColumnName}!=null)\n\t\t\t\t" +
                            $"cmd.Parameters.AddWithValue(\"@{col.ColumnName}\",{col.ColumnName});\n\t\t\t\t\telse\n\t\t\t\t\t" +
                            $"cmd.Parameters.AddWithValue(\"@{col.ColumnName}\", DBNull.Value);";
                    else
                        res += $"cmd.Parameters.AddWithValue(\"@{col.ColumnName}\",{col.ColumnName});\n\t\t\t\t\t";
                }
            }
            return res;
        }

        private static string _QueryForUpdating()
        {
            string res = "";
            foreach(clsColumnInfo col in _Columns.Skip(1))
            {
                res += $"{col.ColumnName} = @{col.ColumnName}, ";
            }
            return res.Remove(res.Length-2);
        }
       
        private static void AddNew()
        {
            clsColumnInfo PkColumn = _GetPkColumn();

            string parameters = $"";
            foreach (clsColumnInfo column in _Columns.Skip(1))
                parameters += $" {column.DataType}{(column.IsNullable ? $"{((column.DataType != "string") ? "?" : "")}" : "")} {column.ColumnName}, ";
            parameters = parameters.Remove(parameters.Length - 2);
            sb.AppendLine($"\t\tpublic static int AddNew{NameFromTableName(_ClassName)}(" +
            $"{parameters} ) {{\n\t\t\tint rows_affected=0;\n");
            sb.AppendLine($"\t\t\tusing (SqlConnection conn = new SqlConnection(_ConnectionString)){{\n" +
            $"\t\t\t\tstring query=\" insert into {_TableName}({_GetColumnsNameForUpdate()}) values ({_GetColumnsNameForQuery()});select SCOPE_IDENTITY(); \";\n" +
            $"\t\t\t");
            sb.AppendLine($"\t\t\t\tusing (SqlCommand cmd = new SqlCommand(query, conn)) {{\n" +
                $"\t\t\t\t{_CmdParameters(true)}");
            sb.AppendLine($"try{{\n");

            sb.AppendLine($" conn.Open();\r\n             " +
                $"   object obj = cmd.ExecuteScalar();\r\n\r\n         " +
                $"       if (obj != null && int.TryParse(Convert.ToString(obj), out int r))\r\n       " +
                $"             rows_affected = r;");
            sb.AppendLine($"\n\t\t\t\t}}catch(Exception ex){{\n" +
                $"\t\t\t\t\t\nrows_affected=-1;\n");
            sb.AppendLine($"}}\n\n");
            sb.AppendLine($"}}\n\n");
            sb.AppendLine($"}}\n\n");
            sb.AppendLine($"\t\t\t\t\treturn rows_affected;");
            sb.AppendLine($"}}\n\n");
        }

        private static void Update()
        {
            clsColumnInfo PkColumn = _GetPkColumn();

            string parameters = $"";
            foreach (clsColumnInfo column in _Columns)
                parameters += $" {column.DataType}{(column.IsNullable ? $"{((column.DataType != "string") ? "?" : "")}" : "")} {column.ColumnName}, ";
            parameters = parameters.Remove(parameters.Length - 2);
            sb.AppendLine($"\t\tpublic static bool Update{NameFromTableName(_ClassName)}(" +
            $"{parameters} ) {{\n\t\t\tint rows_affected=0;\n");
            sb.AppendLine($"\t\t\tusing (SqlConnection conn = new SqlConnection(_ConnectionString)){{\n" +
            $"\t\t\t\tstring query=\"update {_TableName} set {_QueryForUpdating()} where {PkColumn.ColumnName}=@{PkColumn.ColumnName}; \";\n" +
            $"\t\t\t");
            sb.AppendLine($"\t\t\t\tusing (SqlCommand cmd = new SqlCommand(query, conn)) {{\n" +
                $"\t\t\t\t{_CmdParameters()}");
            sb.AppendLine($"try{{\n");

            sb.AppendLine($"  conn.Open();\r\n            " +
                $"    rows_affected = cmd.ExecuteNonQuery();");
            sb.AppendLine($"\n\t\t\t\t}}catch(Exception ex){{\n" +
                $"\t\t\t\t\t\nrows_affected=-1;\n");
            sb.AppendLine($"}}\n\n");
            sb.AppendLine($"}}\n\n");
            sb.AppendLine($"}}\n\n");
            sb.AppendLine($"\t\t\t\t\treturn rows_affected!=0;");
            sb.AppendLine($"}}\n\n");

        }

        private static void Delete()
        {
            clsColumnInfo PkColumn = _GetPkColumn();
            sb.AppendLine($"\t\tpublic static bool Delete{NameFromTableName(_ClassName)}(" +
           $"{PkColumn.DataType} {PkColumn.ColumnName} ) {{\n\t\t\tint rows_affected=0;\n");
            sb.AppendLine($"\t\t\tusing (SqlConnection conn = new SqlConnection(_ConnectionString)){{\n" +
            $"\t\t\t\tstring query=\"delete from {_TableName} where {PkColumn.ColumnName}=@{PkColumn.ColumnName}; \";\n" +
            $"\t\t\t");
            sb.AppendLine($"\t\t\t\tusing (SqlCommand cmd = new SqlCommand(query, conn)) {{\n" +
                $"\t\t\t\tcmd.Parameters.AddWithValue(\"@{PkColumn.ColumnName}\",{PkColumn.ColumnName});");
            sb.AppendLine($"try{{\n");

            sb.AppendLine($"  conn.Open();\r\n            " +
                $"    rows_affected = cmd.ExecuteNonQuery();");
            sb.AppendLine($"\n\t\t\t\t}}catch(Exception ex){{\n" +
                $"\t\t\t\t\t\nrows_affected=-1;\n");
            sb.AppendLine($"}}\n\n");
            sb.AppendLine($"}}\n\n");
            sb.AppendLine($"}}\n\n");
            sb.AppendLine($"\t\t\t\t\treturn rows_affected!=0;");
            sb.AppendLine($"}}\n\n");
        }

        private static void IsExist()
        {
            clsColumnInfo PkColumn = _GetPkColumn();
            sb.AppendLine($"\t\tpublic static bool IsExist(" +
           $"{PkColumn.DataType} {PkColumn.ColumnName} ) {{\n\t\t\tbool IsFound=false;\n");
            sb.AppendLine($"\t\t\tusing (SqlConnection conn = new SqlConnection(_ConnectionString)){{\n" +
            $"\t\t\t\tstring query=\"select found=1 from {_TableName} where {PkColumn.ColumnName}=@{PkColumn.ColumnName}; \";\n" +
            $"\t\t\t");
            sb.AppendLine($"\t\t\t\tusing (SqlCommand cmd = new SqlCommand(query, conn)) {{\n" +
                $"\t\t\t\tcmd.Parameters.AddWithValue(\"@{PkColumn.ColumnName}\",{PkColumn.ColumnName});");
            sb.AppendLine($"try{{\n");

            sb.AppendLine($" conn.Open();\r\n           " +
                $"     object obj = cmd.ExecuteScalar();\r\n           " +
                $"     if (obj != null)\r\n              " +
                $"      IsFound = true;");
            sb.AppendLine($"\n\t\t\t\t}}catch(Exception ex){{\n" +
                $"\t\t\t\t\t\nIsFound=false;\n");
            sb.AppendLine($"}}\n\n");
            sb.AppendLine($"}}\n\n");
            sb.AppendLine($"}}\n\n");
            sb.AppendLine($"\t\t\t\t\treturn IsFound;");
            sb.AppendLine($"}}\n\n");
        }

        private static void UnInitialize()
        {
            sb.AppendLine($"\n\n}}");
            sb.AppendLine($"\n\n}}");
        }


    }
}
