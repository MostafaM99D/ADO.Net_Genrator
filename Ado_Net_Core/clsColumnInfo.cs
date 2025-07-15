using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_Net_Core
{
    public class clsColumnInfo
    {
        public string ColumnName { get; set; }
        public string DataType   { get; set; }
        public bool IsNullable   { get; set; }
        public bool IsPrimaryKey { get; set; }

        public clsColumnInfo(string columnName, string dataType, bool isNullable, bool isPrimaryKey)
        {
            ColumnName = columnName;
            DataType = dataType;
            IsNullable = isNullable;
            IsPrimaryKey = isPrimaryKey;
        }
    }
}
