using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMQHelperDLL.MessagesDef
{
    public interface IMessageActions
    {
        void SetupMessageQ(MQConnection connection);
    }
}
