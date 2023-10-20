using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using TwoWheelTrader.Models.Interfaces;

namespace VehEvalu8.Data
{
    public class SqlConnector : IDataConnection
    {
        public IMotorcycle CreateMotorcycle(IMotorcycle motorcycle)
        {
            return motorcycle;
        }

        //TODO - CHECK ADO.NET AND SQL CONNECTOR MATERIALS.
    }
}
