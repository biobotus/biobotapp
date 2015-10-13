using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Jog
{
    class MoveAxisEvent : EventArgs
    {
        public enum Motor
        {
            X,Y,Z1,Z2,Z3
        }

        public enum PositionType
        {
            Relative, Absolute
        }

        public MoveAxisEvent()
        {

        }
    }
}
