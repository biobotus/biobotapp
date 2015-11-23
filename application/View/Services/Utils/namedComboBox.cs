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
    public partial class namedComboBox : UserControl
    {
        public namedComboBox()
        {
            InitializeComponent();
        }

        public namedComboBox(String name) 
            : this()
        {
            setInputName(name);
        }

        public namedComboBox(String name, int selectedIndex)
            : this(name)
        {
            cbData.SelectedIndex = selectedIndex;
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
        public int getSelectedIndex()
        {
            return cbData.SelectedIndex;
        }

        public ComboBox getComboBox()
        {
            return this.cbData;
        }
        
    }
}
