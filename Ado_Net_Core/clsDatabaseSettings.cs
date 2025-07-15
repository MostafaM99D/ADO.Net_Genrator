using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.XPath;

namespace Ado_Net_Core
{
    public class clsDatabaseSettings
    {
        public static string GetConnectionString(string ServerName, string DatabaseName)
        {
            return $"Data Source={ServerName};Initial Catalog={DatabaseName};Integrated Security=True;";
        }
        public static bool ConnectedToDatabase(string ServerName, string DatabaseName)
        {
            bool isConnected = false;
            using (SqlConnection conn = new SqlConnection(GetConnectionString(ServerName, DatabaseName)))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Connection Succefully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isConnected = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isConnected = false;
                }
            }
            return isConnected;
        }
        public static List<string> LoadAllTabels(string ServerName, string DatabaseName)
        {
            List<string> tables = new List<string>();
            using (SqlConnection conn = new SqlConnection(GetConnectionString(ServerName, DatabaseName)))
            {
                string query = $"select TABLE_NAME from INFORMATION_SCHEMA.TABLES where TABLE_NAME<>'sysdiagrams' and TABLE_TYPE = 'BASE TABLE'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                tables.Add(reader[0].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return tables;
        }
        public static List<string> LoadAllDatabases(string ServerName, string DatabaseName)
        {
            List<string> dbs = new List<string>();
            using (SqlConnection conn = new SqlConnection(GetConnectionString(ServerName, DatabaseName)))
            {
                string query = $"select Name from sys.databases where database_id>4;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                dbs.Add(reader[0].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return dbs;
        }

        public static string GetDataType(string sqlType)
        {
            switch (sqlType.ToLower())
            {
                case "int": return "int";
                case "bigint": return "long";
                case "smallint": return "short";
                case "tinyint": return "byte";
                case "bit": return "bool";
                case "float": return "float";
                case "real": return "double";
                case "decimal": return "decimal";
                case "numeric": return "decimal";
                case "money": return   "decimal";
                case "smallmoney": return "decimal";
                case "char": return "string";
                case "varchar": return "string";
                case "nchar": return "string";
                case "nvarchar": return "string";
                case "text": return "string";
                case "ntext": return "string";
                case "date": return "DateTime";
                case "datetime": return "DateTime";
                case "smalldatetime": return "DateTime";
                case "datetime2": return "DateTime";
                default: return "object";
            }
        }

        public static List<clsColumnInfo> GetShcemaDetails(string ServerName, string DatabaseName, string TableName)
        {
            List<clsColumnInfo> col_infos = new List<clsColumnInfo>();
            using (SqlConnection conn = new SqlConnection(GetConnectionString(ServerName, DatabaseName)))
            {
                string query = $"SELECT COLUMN_NAME, DATA_TYPE,  IS_NULLABLE, " +
                    $"(SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS " +
                    $"TC  INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KCU   ON " +
                    $"TC.CONSTRAINT_NAME = KCU.CONSTRAINT_NAME WHERE TC.CONSTRAINT_TYPE = 'PRIMARY KEY' " +
                    $"AND KCU.TABLE_NAME = @TableName  AND KCU.COLUMN_NAME = C.COLUMN_NAME) AS IsPrimaryKey " +
                    $" FROM INFORMATION_SCHEMA.COLUMNS AS C WHERE TABLE_NAME = @TableName ORDER BY ORDINAL_POSITION,IsPrimaryKey;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TableName", TableName);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                col_infos.Add(new clsColumnInfo(reader["COLUMN_NAME"].ToString(), 
                                   GetDataType(reader["DATA_TYPE"].ToString()),
                                   reader["IS_NULLABLE"].ToString() == "YES",
                                   reader["IsPrimaryKey"].ToString() == "1"));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return col_infos;
        }


    }
}
