using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehEvalu8.Data
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; }

        public static void InitializeConnections(bool SQL, bool CSV)
        {
            if (SQL)
            {
                SqlConnector sql = new();
                Connections.Add(sql);
            }

            if (CSV)
            {
                CsvConnector csv = new();
                Connections.Add(csv);
            }
        }
    }
}
