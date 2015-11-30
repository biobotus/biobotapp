using BioBotCommunication.Serial.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.DLL.MultiChannel
{
    public class MultiChannelPipette : Model.EventBus.Subscriber
    {
        private ConsumerPool consumerPool;

        public MultiChannelPipette()
        {

        }


        [Model.EventBus.Subscribe]
        public void onExecuteEvent(Model.EventBus.Events.ExecutionService.ExecutionEvent e)
        {
            if (e.billboard == null) return;
            consumerPool = new ConsumerPool(e.billboard);
            consumerPool.newConsumer("OK4");
            consumerPool.newConsumer("OK5");
            consumerPool.startExecution();
        }
    }
}
