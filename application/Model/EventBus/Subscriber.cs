using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus
{
    public class Subscriber
    {
        /// <summary>
        /// Class used to add current instance to the eventbus
        /// </summary>
        public Subscriber()
        {
            EventBus.Instance.registerSubscriber(this);
        }
    }
}
