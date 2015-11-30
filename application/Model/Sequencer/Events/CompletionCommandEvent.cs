using BioBotApp.Model.Sequencer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Sequencer.Events
{
    public class CompletionCommandEvent : EventArgs
    {
        public ICommand command { get; private set; }

        public CompletionCommandEvent(ICommand command)
        {
            this.command = command;
        }
    }
}
