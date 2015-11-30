using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Communication
{
    public class CommunicationService : Model.EventBus.Subscriber
    {
        private static CommunicationService privateInstance;
        private BioBotCommunication.Serial.Movement.ArduinoCommunicationWorker worker;

        private CommunicationService()
        {
            this.worker = BioBotCommunication.Serial.Movement.ArduinoCommunicationWorker.Instance;
        }

        /*
        private void Worker_OnCompletionEvent(object sender, BioBotCommunication.Serial.Movement.OnCompletionEventArgs e)
        {
            EventBus.EventBus.Instance.post(new BioBotCommunication.Serial.Events.OnCommunicationMessageReceived(e.message));
        }
        */
        public void writeData(String data)
        {
            worker.write(data);
        }

        public static CommunicationService Instance
        {
            get
            {
                if (privateInstance == null)
                {
                    privateInstance = new CommunicationService();
                }
                return privateInstance;
            }
        }

        [Model.EventBus.Subscribe]
        public void onClose(Model.Utils.Events.OnCloseModelEvent e)
        {
            worker.stopWorker();
        }
    }
}
