using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.FSM
{
    public class FSMManager
    {
        private static FSMManager instance;

        private FSMManager()
        {

        }

        public static FSMManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FSMManager();
                }
                return instance;
            }
        }
    }
}
