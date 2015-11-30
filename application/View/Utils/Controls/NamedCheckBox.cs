using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.View.Utils.Controls
{
    public partial class NamedCheckBox : UserControl
    {
        public NamedCheckBox()
        {
            InitializeComponent();
        }
        public NamedCheckBox(String name) 
            : this()
        {
            setInputName(name);
        }

        public NamedCheckBox(String name, bool selectedvalue)
            : this(name)
        {
            checkBox1.Checked = selectedvalue;
        }
        public void setInputName(String name)
        {
            txtInputName.Text = name;
        }
        public bool getInputValue()
        {
            return checkBox1.Checked;
        }
    }
}
