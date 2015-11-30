using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Controls.Utils
{
    public partial class crudOptions : UserControl
    {
        [
            Category("Button visibility"),
            Description("Specifies the visibility of buttons."),
            DefaultValue(true)
        ]
        public Boolean ButtonAddVisible {
            set { btnAdd.Visible = value; }
            get { return btnAdd.Visible; }
        }

        [
            Category("Button visibility"),
            Description("Specifies the visibility of buttons."),
            DefaultValue(true)
        ]
        public Boolean ButtonDeleteVisible
        {
            set { btnDelete.Visible = value; }
            get { return btnDelete.Visible; }
        }

        [
            Category("Button visibility"),
            Description("Specifies the visibility of buttons."),
            DefaultValue(true)
        ]
        public Boolean ButtonModifyVisible
        {
            set { btnModify.Visible = value; }
            get { return btnModify.Visible; }
        }

        [
            Category("Button visibility"),
            Description("Specifies the visibility of buttons."),
            DefaultValue(true)
        ]
        public Boolean ButtonRefreshVisible
        {
            set { btnRefresh.Visible = value; }
            get { return btnRefresh.Visible; }
        }

        [
            Category("Appearance"),
            Description("Specifies the button layout."),
            DefaultValue(FlowDirection.LeftToRight)
        ]
        public FlowDirection LayoutLeftToRight
        {
            set { layoutPanel.FlowDirection = value; }
            get { return layoutPanel.FlowDirection; }
        }


        public event EventHandler AddClickHandler;
        public event EventHandler DeleteClickHandler;
        public event EventHandler ModifyClickHandler;
        public event EventHandler RefreshClickHandler;

        public crudOptions()
        {
            InitializeComponent();
        }

        private void btnAddClick(object sender, EventArgs e)
        {
            if(AddClickHandler == null)
            {
                return;
            }

            AddClickHandler(sender, e);
        }

        private void btnDeleteClick(object sender, EventArgs e)
        {
            if(DeleteClickHandler == null)
            {
                return;
            }

            DeleteClickHandler(sender,e);
        }

        private void btnModifyClick(object sender, EventArgs e)
        {
            if (ModifyClickHandler == null)
            {
                return;
            }

            ModifyClickHandler(sender,e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if(RefreshClickHandler == null)
            {
                return;
            }

            RefreshClickHandler(sender,e);
        }
    }
}
