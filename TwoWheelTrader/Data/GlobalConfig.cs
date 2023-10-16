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
                // TODO - CREATE SQL CONNECTION
            }

            if (CSV)
            {
                // TODO - CREATE CSV CONNECTION
            }
        }
    }
}
