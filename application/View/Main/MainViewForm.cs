using BioBotApp.Presenter.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Model.Data;

namespace BioBotApp.View.Main
{
    public partial class MainViewForm : Form, IMainView
    {
        MainPresenter presenter;
        public MainViewForm()
        {
            InitializeComponent();
            presenter = new MainPresenter(this);
        }

        public void setConnectionStatus(string status)
        {
        }

        public void setProjectDataset(BioBotDataSets dataset)
        {
        }

        private void mainView1_Load(object sender, EventArgs e)
        {

        }

        private void MainViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.presenter.onCloseEvent();
        }
    }
}
