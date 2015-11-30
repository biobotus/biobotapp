using BioBotApp.Model.Sequencer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Sequencer.Events
{
    public class ExecuteCommandEvent : EventArgs
    {
        public ICommand command { get; private set; }

        public ExecuteCommandEvent(ICommand command)
        {
            this.command = command;
        }
    }
}
