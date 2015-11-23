using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Controls.Option.Options
{
    public partial class abstractDialog : Form
    {
        public abstractDialog()
        {
            InitializeComponent();
        }

        public abstractDialog(String title, String description)
            : this()
        {
            lblDescription.Text = description;
            this.Text = title;
        }

        public void addNamedInputTextBox(namedInputTextBox namedInputTextBox)
        {
            layoutPanel.Controls.Add(namedInputTextBox);
        }

        public void addControl(Control control)
        {
            layoutPanel.Controls.Add(control);
        }
    }
}
