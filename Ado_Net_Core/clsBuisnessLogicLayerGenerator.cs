using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_Net_Core
{
    public class clsBuisnessLogicLayerGenerator
    {
        private static StringBuilder sb;
        private static List<clsColumnInfo> _Columns;
        private static string _SingleTableName;
        private static string _TableName;
        private static string _DatabaseName;



        public static string GenerateCode(string ServerName, string DatabaseName, string TableName, string SingleTableName)
        {
            _SingleTableName = SingleTableName;
            _TableName = TableName;
            _DatabaseName = DatabaseName;
            sb = new StringBuilder();
            _Columns = clsDatabaseSettings.GetShcemaDetails(ServerName, DatabaseName, TableName);
            Initialize();
            _GetProperties();
            PuplicConstructor();
            PrivateConstructor();
            GetAll();
            Find();
            AddNew();
            Update();
            Save();
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
            sb.AppendLine($"using {_DatabaseName}_DAL;\n");
            sb.AppendLine($"\nnamespace BLL{{\n");
            sb.AppendLine($"\npublic class cls{NameFromTableName(_TableName)}\n{{" +
                $"  enum enMode {{ AddNew = 1, Update = 2 }};\r\n        private enMode _Mode;");
        }

        private static void _GetProperties()
        {
            string res = "";
            foreach (clsColumnInfo c in _Columns)
                res += $"public {c.DataType} {c.ColumnName} {{get; set;}}\n";
            sb.AppendLine(res);
        }

        public static void PuplicConstructor()
        {
            sb.AppendLine($"public cls{NameFromTableName(_TableName)}(){{");
            string res = "";
            foreach (clsColumnInfo c in _Columns)
                res += "this." + c.ColumnName + $"=default;\n";
            sb.AppendLine(res);

            sb.AppendLine($" _Mode = enMode.AddNew;" +
                $"}}\n");
        }
        private static void PrivateConstructor()
        {
            clsColumnInfo PkColumn = _GetPkColumn();

            string parameters = $"";
            foreach (clsColumnInfo column in _Columns)
                parameters += $" {column.DataType} {column.ColumnName}, ";
            parameters = parameters.Remove(parameters.Length - 2);

            sb.AppendLine($"private cls{NameFromTableName(_TableName)}({parameters}){{");
            string res = "";
            foreach (clsColumnInfo c in _Columns)
                res += "this." + c.ColumnName + $"={c.ColumnName};\n";
            sb.AppendLine(res);
            sb.AppendLine($"\n _Mode = enMode.Update;}}\n");

        }

        private static void GetAll()
        {
            sb.AppendLine($"public static DataTable GetAll{NameFromTableName(_TableName)}(){{" +
                $"\n\t\t\treturn cls{NameFromTableName(_TableName)}Data.GetAll{NameFromTableName(_TableName)}Data();");
            sb.AppendLine($"}}");
        }

        private static void Find()
        {
            clsColumnInfo PkColumn = _GetPkColumn();
            sb.AppendLine($"public static cls{_TableName} Find({PkColumn.DataType} {PkColumn.ColumnName}){{");
            string res = "";
            foreach (clsColumnInfo column in _Columns.Skip(1))
                res += $"{column.DataType} {column.ColumnName} = default;\n";

            sb.AppendLine($"\t\t\t\n{res}");
            res = "";
            foreach (clsColumnInfo c in _Columns.Skip(1))
                res += $"ref {c.ColumnName}, ";

            sb.AppendLine($"\n\t\t\tif(!cls{NameFromTableName(_TableName)}Data.Get{NameFromTableName(_SingleTableName)}ByID({PkColumn.ColumnName}, {res.Remove(res.Length - 2)}))" +
                $"\n\t\t\t\treturn null;\n" +
                $"\t\t\telse\n");
            res = "";
            foreach (clsColumnInfo c in _Columns.Skip(1))
                res += $"{c.ColumnName}, ";
            sb.AppendLine($"\t\t\treturn new cls{NameFromTableName(_TableName)}({PkColumn.ColumnName}, {res.Remove(res.Length - 2)});");

            sb.AppendLine($"\n}}");

        }

        private static void AddNew()
        {
            clsColumnInfo PkColumn = _GetPkColumn();
            sb.AppendLine($"private bool _AddNew(){{");
            string res = "";
            foreach (clsColumnInfo column in _Columns.Skip(1))
                res += $"this.{column.ColumnName}, ";
            sb.AppendLine($"this.{PkColumn.ColumnName} = cls{NameFromTableName(_TableName)}Data.AddNew{NameFromTableName(_SingleTableName)}({res.Remove(res.Length - 2)});");
            sb.AppendLine($"return {PkColumn.ColumnName}!= -1;\n");
            sb.AppendLine($"\n}}");
        }

        private static void Update()
        {
            clsColumnInfo PkColumn = _GetPkColumn();
            sb.AppendLine($"private bool _Update(){{");
            string res = "";
            foreach (clsColumnInfo column in _Columns)
                res += $"this.{column.ColumnName}, ";
            sb.AppendLine($"return cls{NameFromTableName(_TableName)}Data.Update{NameFromTableName(_SingleTableName)}({res.Remove(res.Length - 2)});");
            sb.AppendLine($"\n}}");
        }
        private static void Save()
        {
            sb.AppendLine($" public bool Save()\r\n        {{\r\n            switch (_Mode)\r\n            {{\r\n                case enMode.AddNew:\r\n                    if (_AddNew())\r\n                    {{\r\n                        _Mode = enMode.Update;\r\n                        return true;\r\n                    }}\r\n                    else\r\n                        return false;\r\n\r\n                case enMode.Update:\r\n                    return _Update();\r\n\r\n            }}\r\n            return false;\r\n        }}");
        }

        private static void Delete()
        {
            clsColumnInfo PkColumn = _GetPkColumn();
            sb.AppendLine($"public static bool DeleteByID({PkColumn.DataType} {PkColumn.ColumnName}){{");
            sb.AppendLine($"return cls{NameFromTableName(_TableName)}Data.Delete{NameFromTableName(_SingleTableName)}({PkColumn.ColumnName});");
            sb.AppendLine($"\n}}");


        }
        private static void IsExist()
        {
            clsColumnInfo PkColumn = _GetPkColumn();
            sb.AppendLine($"public static bool IsExist({PkColumn.DataType} {PkColumn.ColumnName}){{");
            sb.AppendLine($"return cls{NameFromTableName(_TableName)}Data.IsExist({PkColumn.ColumnName});");
            sb.AppendLine($"\n}}");
        }
        private static void UnInitialize()
        {
            sb.AppendLine($"\n\n}}");
            sb.AppendLine($"\n\n}}");
        }
    }
}
