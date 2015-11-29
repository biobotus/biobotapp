using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Model.Data.Services;
using BioBotApp.Model.Data;
using BioBotApp.View.Utils;
using BioBotApp.Presenter.Deck;

namespace BioBotApp.View.Deck
{
    public partial class DeckView : DatasetViewControl, IDeckView
    {
        private DeckPresenter presenter;
        private int deckYReal;
        private int deckY;
        private int deckXReal;
        private int deckX;
        private int XPk;
        private int YPk;
        private int XCount;
        private int YCount;
        private int[] HoleOffsetX = new int[2];
        private int[] OffsetSupport = new int[2];
        private int[] OffsetFirstHole = new int[2];
        private int diameter;
        private double ratioX;
        private double ratioY;
        List<Button> buttons = new List<Button>();
        List<Button> RemovableButtons = new List<Button>();
        private Module _NewObject;


        public DeckView()
        {
            InitializeComponent();
            this.presenter = new DeckPresenter(this);
            this.bsObject.DataMember = "bbt_object";
            this.bsObject.DataSource = DBManager.Instance.projectDataset;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            XPk = getPkProperty("dimension", "xlength");
            YPk = getPkProperty("dimension", "ylength");
            XCount = getValueObjectProperty("pegholecount", "deck", "X");
            YCount = getValueObjectProperty("pegholecount", "deck", "Y");
            deckXReal = getValueObjectProperty("dimension", "deck", "xlength");
            deckYReal = getValueObjectProperty("dimension", "deck", "ylength");
            this.Location = new Point(this.ParentForm.ClientSize.Width - deckX, 0);
            deckX = this.ParentForm.Width;
            deckY = this.ParentForm.Height;
            this.Size = new Size(deckX, deckY);
            getOffsetParameters();
            UpdateDeck(true);
        }

        public int getPkProperty(string propertyType, string property)
        {
            BioBotDataSets.bbt_property_typeRow PropType = dataset.bbt_property_type.Where(p => (p.description.ToString()).Equals(propertyType, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            BioBotDataSets.bbt_propertyRow prop = dataset.bbt_property.Where(p => (p.description.ToString()).Equals(property, StringComparison.InvariantCultureIgnoreCase) && p.fk_property_type == PropType.pk_id).FirstOrDefault();
            return prop.pk_id;
        }

        public int getValueObjectProperty(string propertyType,string objectType, string property)
        {
            BioBotDataSets.bbt_property_typeRow PropType = dataset.bbt_property_type.Where(p => (p.description.ToString()).Equals(propertyType, StringComparison.InvariantCultureIgnoreCase)).First();
            BioBotDataSets.bbt_object_typeRow ObjType = dataset.bbt_object_type.Where(p => (p.description.ToString()).Equals(objectType, StringComparison.InvariantCultureIgnoreCase)).First();
            BioBotDataSets.bbt_propertyRow prop = dataset.bbt_property.Where(p => (p.description.ToString()).Equals(property, StringComparison.InvariantCultureIgnoreCase) && p.fk_property_type == PropType.pk_id).First();
            BioBotDataSets.bbt_object_propertyRow objProp = dataset.bbt_object_property.Where(p => p.fk_object_type_id == ObjType.pk_id && p.fk_properties_id == prop.pk_id).First();
            return int.Parse(objProp.value);
        }
        public int getValueObjectProperty(string propertyType, int objectType, string property)
        {
            BioBotDataSets.bbt_property_typeRow PropType = dataset.bbt_property_type.Where(p => (p.description.ToString()).Equals(propertyType, StringComparison.InvariantCultureIgnoreCase)).First();
            BioBotDataSets.bbt_propertyRow prop = dataset.bbt_property.Where(p => (p.description.ToString()).Equals(property, StringComparison.InvariantCultureIgnoreCase) && p.fk_property_type == PropType.pk_id).First();
            BioBotDataSets.bbt_object_propertyRow objProp = dataset.bbt_object_property.Where(p => p.fk_object_type_id == objectType && p.fk_properties_id == prop.pk_id).First();
            return int.Parse(objProp.value);
        }

        public void getOffsetParameters()
        {
            HoleOffsetX[0] = getValueObjectProperty("pegholeoffset", "deck", "x");
            HoleOffsetX[1] = getValueObjectProperty("pegholeoffset", "deck", "y");
            OffsetFirstHole[0] = getValueObjectProperty("firstpegholeoffset", "deck", "x");
            OffsetFirstHole[1] = getValueObjectProperty("firstpegholeoffset", "deck", "y");
            diameter = getValueObjectProperty("firstpegholeoffset", "deck", "diameter");
        }

        public void getOffsetSupportParameters(int pkObjectType)
        {
            OffsetSupport[0] = getValueObjectProperty("supportoffset", pkObjectType, "x");
            OffsetSupport[1] = getValueObjectProperty("supportoffset", pkObjectType, "y");
        }
        //Refresh deck while checking for overlapping active modules
        public void UpdateDeck(bool init)
        {
            List<BioBotDataSets.bbt_objectRow> listActiveObject = getActiveModules();
            foreach (BioBotDataSets.bbt_objectRow module in listActiveObject)
            {
                if (NotOnOtherModule(module, init) == false)
                {
                    this.presenter.deactivateObject(module);
                    MessageBox.Show(module.description + " is overlapping on another module, please change its coordinates.");
                    addObject(module, init);
                }
            }
            RefreshDeck();            
        }

        //Default refresh
        public void RefreshDeck()
        {
            this.Controls.Clear();
            List<BioBotDataSets.bbt_objectRow> listActiveObject = getActiveModules();
            foreach (BioBotDataSets.bbt_objectRow module in listActiveObject)
            {
                addObject(module, true);
            }
        }

        //Get the dimensions of selected module
        public int[] getDimensions (BioBotDataSets.bbt_objectRow row)
        {
            BioBotDataSets.bbt_object_propertyRow rowX;
            BioBotDataSets.bbt_object_propertyRow rowY;
            rowX = DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == row.bbt_object_typeRow.pk_id && p.fk_properties_id == XPk).First();
            rowY = DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == row.bbt_object_typeRow.pk_id && p.fk_properties_id == YPk).First();
            int XDt = int.Parse(rowX.value.ToString()) * deckX / deckXReal;
            int YDt = int.Parse(rowY.value.ToString()) * deckY / deckYReal;
            int[] dim = new int[2];
            dim[0] = XDt;
            dim[1] = YDt;
            return dim;
        }

        public Button addObject(BioBotDataSets.bbt_objectRow obj, bool init)
        {
            Button Mod = new Button();
            int[] dim = getDimensions(obj);
            Mod.Text = obj.description;
            Mod.Name = obj.description;
            Mod.Location = new Point(deckX - obj.deck_x * deckX / deckXReal - dim[0], obj.deck_y * deckY / deckYReal);
            setRotation(obj, dim[1], dim[0], Mod);
            Mod.TextAlign = ContentAlignment.MiddleCenter;
            Mod.Click += new System.EventHandler(this.OnClickModule);
            buttons.Add(Mod);

            if (init == false)
            {
                this.Controls.RemoveByKey(Mod.Name);
            }
            this.Controls.Add(Mod);
            return Mod;
        }

        public Button modifyObject(BioBotDataSets.bbt_objectRow obj)
        {
            Button Mod = new Button();
            int[] dim = getDimensions(obj);
            Mod.Text = obj.description;
            Mod.Name = obj.description;
            Mod.Location = new Point(deckX - obj.deck_x * deckX / deckXReal - dim[0], obj.deck_y * deckY / deckYReal);
            setRotation(obj, dim[1], dim[0], Mod);
            Mod.TextAlign = ContentAlignment.MiddleCenter;
            Mod.Click += new System.EventHandler(this.OnClickModule);
            buttons.Add(Mod);
            this.Controls.RemoveByKey(Mod.Name);
            this.Controls.Add(Mod);
            return Mod;
        }
           
        private bool NotOnOtherModule(BioBotDataSets.bbt_objectRow row, bool init)
        {
            List<Button> listButtons = new List<Button>();
            foreach (Button btn in this.Controls)
            {
                listButtons.Add(btn);
            }
            Button newButton = addObject(row, init);
            listButtons.Remove(newButton);
            foreach (Button btn in listButtons)
            {
                if (newButton.Bounds.IntersectsWith(btn.Bounds) == true)
                {
                    RemovableButtons.Add(newButton);
                    return false;
                }
            }
            if (init == false)
            {
                RefreshDeck();
            }
            return true;
        }

        //private List<BioBotDataSets.bbt_objectRow> getValideObjects(BioBotDataSets.bbt_objectDataTable taObject)
        //{
        //    Panel parentCtrl = new Panel();
        //    parentCtrl.Width = deckX;
        //    parentCtrl.Height = deckY;  
        //    List<BioBotDataSets.bbt_objectRow> ListValideObject = new List<BioBotDataSets.bbt_objectRow>();
        //   foreach (BioBotDataSets.bbt_objectRow row in taObject)
        //    {
        //        Button btn = new Button();
        //        int[] dim = getDimensions(row);
        //        btn.Width = dim[0];
        //        btn.Height = dim[1];
        //        btn.Location = new Point(row.deck_x, row.deck_y);
        //        parentCtrl.Controls.Add(btn);

        //        if (parentCtrl.DisplayRectangle.IntersectsWith(btn.Bounds) == true)
        //        {

        //        }
        //    }
        //}

        private bool NotOnOtherModule(BioBotDataSets.bbt_objectRow row)
        {
            List<Button> listButtons = new List<Button>();
            foreach (Button btn in this.Controls)
            {
                listButtons.Add(btn);
            }
            Button newButton = addObject(row,false);
            listButtons.Remove(newButton);
            listButtons.Remove(listButtons.Find(p => p.Name == newButton.Name));
            foreach (Button btn in listButtons)
            {
                if (newButton.Bounds.IntersectsWith(btn.Bounds) == true)
                {
                    this.Controls.Remove(newButton);
                    return false;
                }
            }
                RefreshDeck();
            return true;
        }

        private void setRotation(BioBotDataSets.bbt_objectRow obj, int height, int width, Button button)
        {
            switch (obj.rotation)
            {
                case 0:
                    button.Width = width;
                    button.Height = height;
                    break;
                case 90:
                    button.Location = new Point(button.Location.X - height, button.Location.Y);
                    button.Width = height;
                    button.Height = width;
                    break;
                case 180:
                    button.Location = new Point(button.Location.X - width, button.Location.Y- height);
                    button.Width = width;
                    button.Height = height;
                    break;
                case 270:
                    button.Location = new Point(button.Location.X, button.Location.Y - width);
                    button.Width = height;
                    button.Height = width;
                    break;
                default:
                    MessageBox.Show("Rotation value not allowed");
                    break;
            }
        }

            

        public BioBotDataSets.bbt_objectRow getSelectedObjectRow()
        {
            BioBotDataSets.bbt_objectRow objectRow = null;

            if (bsObject.Current == null) return null;
            if (!(bsObject.Current.GetType() == typeof(DataRowView))) return null;
            DataRowView rowView = bsObject.Current as DataRowView;
            if (rowView.Row == null) return null;
            if (!(rowView.Row.GetType() == typeof(BioBotDataSets.bbt_objectRow))) return null;
            objectRow = rowView.Row as BioBotDataSets.bbt_objectRow;
            return objectRow;
        }

        private List<BioBotDataSets.bbt_objectRow> getActiveModules()
        {
            List<BioBotDataSets.bbt_objectRow> listActivatedObject = dataset.bbt_object.AsEnumerable().Where(p => p.activated == "1").ToList();
            List<BioBotDataSets.bbt_objectRow> listActivatedObject2 = dataset.bbt_object.AsEnumerable().Where(p => p.activated == "1").ToList();
            if (listActivatedObject.Count() == 0) return listActivatedObject; 
            BioBotDataSets.bbt_propertyRow pkPropertyLayout = DBManager.Instance.projectDataset.bbt_property.Where(p => (p.description.ToString()).Equals("CanDeckLayout", StringComparison.InvariantCultureIgnoreCase)).First();

            foreach (BioBotDataSets.bbt_objectRow row in listActivatedObject)
            {
            BioBotDataSets.bbt_object_propertyRow objLayout = DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == row.fk_object_type && p.fk_properties_id == pkPropertyLayout.pk_id).First();
                if (objLayout.value != "1")
                {
                    listActivatedObject2.Remove(row);
                }
            }
            return listActivatedObject2;
        }

        private bool IsLayout(BioBotDataSets.bbt_objectRow row)
        {
            if (getValueObjectProperty("nothing", row.fk_object_type, "CanDeckLayout").ToString() == "1")
            {
                return true;
            }
            return false;
        }

        private void modifyObject(BioBotDataSets.bbt_objectRow row, bool dragEvent)
        {
            getOffsetSupportParameters(row.fk_object_type);
            if (IsLayout(row) == true || dragEvent == false)
            {
                int[] ModuleSize = getDimensions(row);
                UserDeckForm popup = new UserDeckForm(XCount, YCount, OffsetFirstHole, HoleOffsetX, OffsetSupport, diameter, row.description, ModuleSize[0], ModuleSize[1], row.activated, row.deck_x, row.deck_y, row.rotation);
                DialogResult result = popup.ShowDialog();

                if (result == DialogResult.OK && popup.FullField() == true)
                {
                    Module _module = popup.setRotation(ModuleSize[0], ModuleSize[1]);
                    // check if it fits the deck
                    if (popup.FitInDeck(deckXReal, deckYReal, _module) == true)
                    {
                        if (NotOnOtherModule(row) == true)
                        {
                            NewObject = popup.getObjectUserForm(ModuleSize[0], ModuleSize[1]);
                            this.presenter.addNewObject(_NewObject, row.pk_id, row.fk_object_type, row.description, popup.ChangeActivation());
                            RefreshDeck();
                        }
                        else
                        {
                            MessageBox.Show("There is already an active module on these coordinates");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong dimensions");
                    }
                }
                else if (result == DialogResult.Yes)
                {
                    row.activated = "0";
                    this.presenter.deactivateObject(row);
                    RefreshDeck();
                }
                else if (result == DialogResult.Cancel)
                {
                    popup.Close();
                }
                popup.Dispose();
            }
            else
            {
                MessageBox.Show("Object layout is non-existent");
            }
        }

        private void DeckView_DragDrop(object sender, DragEventArgs e)
        {
            BioBotDataSets.bbt_objectRow row = e.Data.GetData(typeof(BioBotDataSets.bbt_objectRow)) as BioBotDataSets.bbt_objectRow;
            modifyObject(row, true);

        }

        private void DeckView_DragEnter(object sender, DragEventArgs e)
        {
           if (e.Data.GetDataPresent(typeof(BioBotDataSets.bbt_objectRow)) == true)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void OnClickModule(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;
            BioBotDataSets.bbt_objectRow row = dataset.bbt_object.Where(p => p.description == thisButton.Text).First();
            modifyObject(row, false);
            
        }

        public Module NewObject
        {
            get
            {
                return _NewObject;
            }

            set
            {
                _NewObject = value;
            }
        }

        private void DeckView_Resize(object sender, EventArgs e)
        {
            if (deckX != 0 || deckY != 0)
            {
                ratioX = Convert.ToDouble(this.Width) / deckX;
                ratioY = Convert.ToDouble(this.Height) / deckY;
                foreach (Button but in buttons)
                {
                    but.Location = new Point(Convert.ToInt32(but.Location.X * ratioX), Convert.ToInt32(but.Location.Y * ratioY));
                    but.Width = Convert.ToInt32(but.Width * ratioX);
                    but.Height = Convert.ToInt32(but.Height * ratioY);
                }
                deckX = this.Width;
                deckY = this.Height;
                this.Size = new Size(deckX, deckY);
                
            }
        }

        
    }
}
