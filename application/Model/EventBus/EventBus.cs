using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus
{
    public class EventBus
    {
        /// <summary>
        /// Instance of EventBus, singleton pattern used
        /// </summary>
        private static EventBus instance;

        /// <summary>
        /// List of subscribers contained in the eventbus
        /// </summary>
        private List<Object> subscribers;

        /// <summary>
        /// Class that contains subscribers and calls the wanted method used by the post function
        /// </summary>
        private EventBus()
        {
            subscribers = new List<Object>();
        }

        /// <summary>
        /// Returns the singleton instance of EventBuss
        /// </summary>
        public static EventBus Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventBus();
                }
                return instance;
            }
        }

        /// <summary>
        /// Adds the subscriber to the eventbuss list
        /// </summary>
        /// <param name="subscriber">Subscriber to be added</param>
        public void registerSubscriber(Object subscriber)
        {
            if (subscribers.Contains(subscriber)) return;
            subscribers.Add(subscriber);
        }

        /// <summary>
        /// Removes the subscriber from the eventbuss list
        /// </summary>
        /// <param name="subscriber"></param>
        public void unregisterSubscriber(Object subscriber)
        {
            if (!subscribers.Contains(subscriber)) return;
            subscribers.Remove(subscriber);
        }

        /// <summary>
        /// Using reflection to call attribute methods of all subscribers
        /// </summary>
        /// <param name="e"></param>
        public void post(object e)
        {
            foreach (object instance in subscribers)
            {
                foreach (MethodInfo method in getSubscribedMethods(instance.GetType(), e))
                {
                    method.Invoke(instance, new object[] { e });
                }
            }
        }

        /// <summary>
        /// Gets the subscriber method type (subscriber must implement the correct type and use the Subscribe annotation)
        /// </summary>
        /// <param name="type">Subscribers instance type</param>
        /// <param name="obj">Mothod to be called</param>
        /// <returns></returns>
        private List<MethodInfo> getSubscribedMethods(Type type, object obj)
        {
            List<MethodInfo> subscribedMethods = new List<MethodInfo>();

            var methods = type.GetRuntimeMethods();
            foreach (MethodInfo info in methods)
            {
                foreach (Attribute attr in info.GetCustomAttributes(typeof(Subscribe)))
                {
                    var paramInfo = info.GetParameters();
                    if (paramInfo.Length == 1 && paramInfo[0].ParameterType == obj.GetType())
                    {
                        subscribedMethods.Add(info);
                    }
                }
            }

            return subscribedMethods;
        }
    }
}
