using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Controls.Option.Options
{
    public partial class namedInputTextBox : UserControl
    {
        public namedInputTextBox()
        {
            InitializeComponent();
        }

        public namedInputTextBox(String name) : this()
        {
            setInputName(name);
        }

        public namedInputTextBox(String name, String inputTextValue)
            : this(name)
        {
            edtInputValue.Text = inputTextValue;
        }
        /// <summary>
        /// Sets the left label text
        /// </summary>
        /// <param name="name">The left label text value</param>
        public void setInputName(String name)
        {
            txtInputName.Text = name;
        }

        /// <summary>
        /// Gets the right input textbox value
        /// </summary>
        /// <returns>The value of the textbox</returns>
        public String getInputTextValue()
        {
            return edtInputValue.Text;
        }
    }
}
