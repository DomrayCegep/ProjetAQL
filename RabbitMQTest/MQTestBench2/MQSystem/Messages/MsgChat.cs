using MQTestBench.MQSystem.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTestBench2.MQSystem.Messages
{
    internal class MsgChat : IMessageActions
    {
        public MsgChat() { MessageName = "ChatMessage"; }

        public string MessageName { get; set; }

        public void DoActions()
        {
            throw new NotImplementedException();
        }
    }
}
