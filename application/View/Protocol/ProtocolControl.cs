using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Presenter.Protocols;
using BioBotApp.Presenter;

namespace BioBotApp.View.Protocol
{
    public partial class ProtocolControl : UserControl, IProtocolView
    {

        private ProtocolPresenter protocolPresenter;
        public ProtocolControl()
        {
            InitializeComponent();
            protocolPresenter = new ProtocolPresenter(this);
        }

        public string GetProtocolName
        {
            get
            {
                if (txtProtocolName.Text == String.Empty)
                {
                    throw new Exception();
                }

                return txtProtocolName.Text;
            }
        }

        public event EventHandler<ProtocolAddEvent> OnProtocolAddEvent;

        public void LoadProtocolName(String protocolName)
        {
            if (protocolName == String.Empty)
            {
                throw new Exception();
            }

            txtSendToPresenter.Text = protocolName;
        }

        private void btnSendToPresenter_Click_1(object sender, EventArgs e)
        {
            if (OnProtocolAddEvent != null)
            {
                OnProtocolAddEvent(this, new ProtocolAddEvent(txtProtocolName.Text));
            }
        }
    }
}
