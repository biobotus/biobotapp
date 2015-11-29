using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Communication
{
    public class CommunicationService
    {
        private static CommunicationService privateInstance;
        private BioBotCommunication.Serial.Movement.ArduinoCommunicationWorker worker;

        private CommunicationService()
        {
            this.worker = BioBotCommunication.Serial.Movement.ArduinoCommunicationWorker.Instance;
            this.worker.OnCompletionEvent += Worker_OnCompletionEvent;
        }

        private void Worker_OnCompletionEvent(object sender, BioBotCommunication.Serial.Movement.OnCompletionEventArgs e)
        {
            EventBus.EventBus.Instance.post(new BioBotCommunication.Serial.Events.OnConnectionStatusChangeEvent(e.message));
        }

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
    }
}
