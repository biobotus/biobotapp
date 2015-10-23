using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus
{
    public class Subscribe : Attribute
    {
        /// <summary>
        /// Anotation used by the eventbus to retreive method to be called
        /// </summary>
        public Subscribe() { }
    }
}
