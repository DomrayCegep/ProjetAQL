using RMQHelperDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTestBench.MQSystem.Messages
{
    internal interface IMessageActions
    {
        string MessageName { get; set; }

        string GetMessageText();

        IMessageActions GetMessageInstance(RMQEnveloppe msgEnveloppe);

        void DoActions();

    }
}
