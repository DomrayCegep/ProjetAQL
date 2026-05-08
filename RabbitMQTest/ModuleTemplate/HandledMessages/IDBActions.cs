using MySql.Data.MySqlClient;
using RMQHelperDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTemplate.HandledMessages
{
    internal interface IDBActions
    {
        void SetupDB(MySqlConnection db);
    }
}
