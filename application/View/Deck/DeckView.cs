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
        private double ratioX;
        private double ratioY;
        List<Button> buttons = new List<Button>();
        List<Button> RemovableButtons = new List<Button>();
        private Module _NewObject;
        private bool ObjectCreation;

        public DeckView()
        {
            InitializeComponent();
            this.presenter = new DeckPresenter(this);
            this.bsObject.DataMember = "bbt_object";
            this.bsObject.DataSource = DBManager.Instance.projectDataset;
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

        public Button addObject(BioBotDataSets.bbt_objectRow obj, bool init)
        {
            Button Mod = new Button();
            int[] dim = getRealDimensions(obj);
            Mod.Text = obj.description;
            Mod.Name = obj.description;
            Module _mod = setRotation(obj.deck_x, obj.deck_y, obj.rotation, dim[0], dim[1]);
            int[] coord = getResizedCoord(_mod.deckX, _mod.deckY);
            dim = getResizedDimensions(_mod.width, _mod.height);
            Mod.Location = new Point(deckX - coord[0] - dim[0], coord[1]);
            Mod.Width = dim[0];
            Mod.Height = dim[1];
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
        public Button addObject(BioBotDataSets.bbt_objectRow obj, Panel pnl)
        {
            Button Mod = new Button();
            int[] dim = getRealDimensions(obj);
            Mod.Text = obj.description;
            Mod.Name = obj.description;
            Module _mod = setRotation(obj.deck_x, obj.deck_y, obj.rotation, dim[0], dim[1]);
            int[] coord = getResizedCoord(_mod.deckX, _mod.deckY);
            dim = getResizedDimensions(_mod.width, _mod.height);
            Mod.Location = new Point(deckX - coord[0] - dim[0], coord[1]);
            Mod.Width = dim[0];
            Mod.Height = dim[1];
            Mod.TextAlign = ContentAlignment.MiddleCenter;
            Mod.Click += new System.EventHandler(this.OnClickModule);
            pnl.Controls.Add(Mod);
            return Mod;
        }

        public Button modifyObject(BioBotDataSets.bbt_objectRow obj, int rotation)
        {
            
            Button Mod = new Button();
            int[] dim = getRealDimensions(obj);
            Mod.Text = obj.description;
            Mod.Name = obj.description;
            Module _mod = setRotation(obj.deck_x, obj.deck_y, obj.rotation - rotation, dim[0], dim[1]);
            int[] coord = getResizedCoord(_mod.deckX, _mod.deckY);
            dim = getResizedDimensions(_mod.width,_mod.height);
            Mod.Location = new Point(deckX - coord[0] - dim[0], coord[1]);
            Mod.Width = dim[0];
            Mod.Height = dim[1];
            Mod.TextAlign = ContentAlignment.MiddleCenter;
            Mod.Click += new System.EventHandler(this.OnClickModule);
            buttons.Add(Mod);
            this.Controls.RemoveByKey(Mod.Name);
            this.Controls.Add(Mod);
            return Mod;
        }

        private Module setRotation(int deck_x, int deck_y,int rotation, int width, int height)
        {
            Module obj = new Module(deck_x, deck_y, width, height, int.Parse(rotation.ToString()));
            int tmp;
            switch (obj.rotation)
            {
                case 0:
                    return obj;
                case 90:
                    obj.deckX = obj.deckX - obj.height;
                    tmp = obj.width;
                    obj.width = obj.height;
                    obj.height = tmp;
                    return obj;
                case 180:
                    obj.deckX = obj.deckX - obj.width;
                    obj.deckY = obj.deckY - obj.height;
                    return obj;
                case 270:
                    obj.deckY = obj.deckY - obj.width;
                    tmp = obj.width;
                    obj.width = obj.height;
                    obj.height = tmp;
                    return obj;
                default:
                    MessageBox.Show("Rotation value not allowed");
                    return obj;
            }
        }

        private void modifyObject(BioBotDataSets.bbt_objectRow row, bool dragEvent)
        {
            if (IsLayout(row) == true || dragEvent == false)
            {
                getOffsetSupportParameters(row);
                int[] ModuleSize = getRealDimensions(row);
                UserDeckForm popup = new UserDeckForm(XCount, YCount, OffsetFirstHole, HoleOffsetX, OffsetSupport, row.description, ModuleSize[0], ModuleSize[1], row.activated, row.deck_x, row.deck_y, row.rotation);
                DialogResult result = popup.ShowDialog();

                if (result == DialogResult.OK && popup.FullField() == true)
                {
                    Module _module = popup.setRotation(ModuleSize[0], ModuleSize[1]);
                    // check if it fits the deck
                    if (OnDeck(_module) == true)
                    {

                        if (NotOnOtherModule(row) == true)
                        {
                            this.presenter.addNewObject(_module, row.pk_id, row.fk_object_type, row.description, popup.ChangeActivation());
                            RefreshDeck();
                        }
                        else
                        {
                            MessageBox.Show("There is already an active module on these coordinates");
                        }
                    }
                    else
                    {
                        popup.Refresh();
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

        private void AddNewModuleToDt()
        {

        }

        #region Getter functions from dataset
        public int getPkProperty(string propertyType, string property)
        {
            //BioBotDataSets.bbt_property_typeRow PropType = DBManager.Instance.taManager.bbt_property_typeTableAdapter.FindByDescription(propertyType).First();
            BioBotDataSets.bbt_property_typeRow PropType = dataset.bbt_property_type.Where(p => p.description == propertyType).First();
            //BioBotDataSets.bbt_propertyRow PropPk = DBManager.Instance.taManager.bbt_propertyTableAdapter.FindByFk_Property_Type(PropType.pk_id, property).First();
            BioBotDataSets.bbt_propertyRow prop = dataset.bbt_property.Where(p => (p.description.ToString()).Equals(property, StringComparison.InvariantCultureIgnoreCase) && p.fk_property_type == PropType.pk_id).FirstOrDefault();
            //return PropPk.pk_id;
            return prop.pk_id;
        }

        public int getValueObjectProperty(string propertyType, string objectType, string property)
        {
            BioBotDataSets.bbt_property_typeRow PropType = dataset.bbt_property_type.Where(p => (p.description.ToString()).Equals(propertyType, StringComparison.InvariantCultureIgnoreCase)).First();
            BioBotDataSets.bbt_object_typeRow ObjType = dataset.bbt_object_type.Where(p => (p.description.ToString()).Equals(objectType, StringComparison.InvariantCultureIgnoreCase)).First();
            BioBotDataSets.bbt_propertyRow prop = dataset.bbt_property.Where(p => (p.description.ToString()).Equals(property, StringComparison.InvariantCultureIgnoreCase) && p.fk_property_type == PropType.pk_id).First();
            BioBotDataSets.bbt_object_propertyRow objProp = dataset.bbt_object_property.Where(p => p.fk_object_type_id == ObjType.pk_id && p.fk_properties_id == prop.pk_id).First();
            //BioBotDataSets.bbt_property_typeRow PropType = DBManager.Instance.taManager.bbt_property_typeTableAdapter.FindByDescription(propertyType).First();
            //BioBotDataSets.bbt_object_typeRow ObjType = DBManager.Instance.taManager.bbt_object_typeTableAdapter.FindByDescription(objectType).First();
            //BioBotDataSets.bbt_propertyRow prop = DBManager.Instance.taManager.bbt_propertyTableAdapter.FindByFk_Property_Type(PropType.pk_id, property).First();
            //BioBotDataSets.bbt_object_propertyRow objProp = DBManager.Instance.taManager.bbt_object_propertyTableAdapter.FindByFk_Id(ObjType.pk_id, prop.pk_id).First();
            return int.Parse(objProp.value);
        }
        public int getValueObjectProperty(string propertyType, int objectType, string property)
        {
            BioBotDataSets.bbt_property_typeRow PropType = dataset.bbt_property_type.Where(p => (p.description.ToString()).Equals(propertyType, StringComparison.InvariantCultureIgnoreCase)).First();
            BioBotDataSets.bbt_propertyRow prop = dataset.bbt_property.Where(p => (p.description.ToString()).Equals(property, StringComparison.InvariantCultureIgnoreCase) && p.fk_property_type == PropType.pk_id).First();
            BioBotDataSets.bbt_object_propertyRow objProp = dataset.bbt_object_property.Where(p => p.fk_object_type_id == objectType && p.fk_properties_id == prop.pk_id).First();
            //BioBotDataSets.bbt_property_typeRow PropType = DBManager.Instance.taManager.bbt_property_typeTableAdapter.FindByDescription(propertyType).First();
            //BioBotDataSets.bbt_propertyRow prop = DBManager.Instance.taManager.bbt_propertyTableAdapter.FindByFk_Property_Type(PropType.pk_id, property).First();
            //BioBotDataSets.bbt_object_propertyRow objProp = DBManager.Instance.taManager.bbt_object_propertyTableAdapter.FindByFk_Id(objectType, prop.pk_id).First();
            return int.Parse(objProp.value);
        }

        public void getOffsetParameters()
        {
            HoleOffsetX[0] = getValueObjectProperty("PegHoleOffset", "Deck", "X");
            HoleOffsetX[1] = getValueObjectProperty("PegHoleOffset", "Deck", "Y");
            OffsetFirstHole[0] = getValueObjectProperty("FirstPegHoleOffset", "Deck", "X");
            OffsetFirstHole[1] = getValueObjectProperty("FirstPegHoleOffset", "Deck", "Y");
        }

        public int[] getResizedCoord(int coordX, int coordY)
        {
            decimal x = Math.Floor(decimal.Parse(coordX.ToString()) * (decimal.Parse(deckX.ToString()) / decimal.Parse(deckXReal.ToString())));
            decimal y = Math.Floor(decimal.Parse(coordY.ToString()) * (decimal.Parse(deckY.ToString()) / decimal.Parse(deckYReal.ToString())));
            int[] coord = new int[2];
            coord[0] = int.Parse(x.ToString());
            coord[1] = int.Parse(y.ToString());
            return coord;
        }

        public void getOffsetSupportParameters(BioBotDataSets.bbt_objectRow row)
        {
            BioBotDataSets.bbt_objectRow SupportRow = dataset.bbt_object.FindBypk_id(row.fk_object);
             
            while (SupportRow.fk_object != 0)
            {
                SupportRow = dataset.bbt_object.FindBypk_id(SupportRow.fk_object);
            }
            OffsetSupport[0] = getValueObjectProperty("SupportOffset", SupportRow.fk_object_type, "X");
            OffsetSupport[1] = getValueObjectProperty("SupportOffset", SupportRow.fk_object_type, "Y");
        }
        //Get the dimensions of selected module
        public int[] getResizedDimensions(BioBotDataSets.bbt_objectRow row)
        {
            BioBotDataSets.bbt_object_propertyRow rowX;
            BioBotDataSets.bbt_object_propertyRow rowY;
            //rowX = DBManager.Instance.taManager.bbt_object_propertyTableAdapter.FindByFk_Id(row.bbt_object_typeRow.pk_id, XPk).First();
            //rowY = DBManager.Instance.taManager.bbt_object_propertyTableAdapter.FindByFk_Id(row.bbt_object_typeRow.pk_id, YPk).First();
            rowX = dataset.bbt_object_property.Where(p => p.fk_object_type_id == row.bbt_object_typeRow.pk_id && p.fk_properties_id == XPk).First();
            rowY = dataset.bbt_object_property.Where(p => p.fk_object_type_id == row.bbt_object_typeRow.pk_id && p.fk_properties_id == YPk).First();
            decimal x = Math.Floor(decimal.Parse(rowX.value) * (decimal.Parse(deckX.ToString()) / decimal.Parse(deckXReal.ToString())));
            decimal y = Math.Floor(decimal.Parse(rowY.value) * (decimal.Parse(deckY.ToString()) / decimal.Parse(deckYReal.ToString())));
            int[] dim = new int[2];
            dim[0] = int.Parse(x.ToString());
            dim[1] = int.Parse(y.ToString());
            return dim;
        }
        public int[] getResizedDimensions(BioBotDataSets.bbt_object_typeRow row)
        {
            BioBotDataSets.bbt_object_propertyRow rowX;
            BioBotDataSets.bbt_object_propertyRow rowY;
            //rowX = DBManager.Instance.taManager.bbt_object_propertyTableAdapter.FindByFk_Id(row.pk_id, XPk).First();
            //rowY = DBManager.Instance.taManager.bbt_object_propertyTableAdapter.FindByFk_Id(row.pk_id, YPk).First();
            rowX = dataset.bbt_object_property.Where(p => p.fk_object_type_id == row.pk_id && p.fk_properties_id == XPk).First();
            rowY = dataset.bbt_object_property.Where(p => p.fk_object_type_id == row.pk_id && p.fk_properties_id == YPk).First();
            decimal x = Math.Floor(decimal.Parse(rowX.value) * (decimal.Parse(deckX.ToString()) / decimal.Parse(deckXReal.ToString())));
            decimal y = Math.Floor(decimal.Parse(rowY.value) * (decimal.Parse(deckY.ToString()) / decimal.Parse(deckYReal.ToString())));
            int[] dim = new int[2];
            dim[0] = int.Parse(x.ToString());
            dim[1] = int.Parse(y.ToString());
            return dim;
        }
        public int[] getResizedDimensions(int xCoord, int yCoord)
        {
            decimal x = Math.Floor(decimal.Parse(xCoord.ToString()) * (decimal.Parse(deckX.ToString()) / decimal.Parse(deckXReal.ToString())));
            decimal y = Math.Floor(decimal.Parse(yCoord.ToString()) * (decimal.Parse(deckY.ToString()) / decimal.Parse(deckYReal.ToString())));
            int[] dim = new int[2];
            dim[0] = int.Parse(x.ToString());
            dim[1] = int.Parse(y.ToString());
            return dim;
        }


        public int[] getRealDimensions(BioBotDataSets.bbt_objectRow row)
        {
            BioBotDataSets.bbt_object_propertyRow rowX;
            BioBotDataSets.bbt_object_propertyRow rowY;
            //rowX = DBManager.Instance.taManager.bbt_object_propertyTableAdapter.FindByFk_Id(row.bbt_object_typeRow.pk_id, XPk).First();
            //rowY = DBManager.Instance.taManager.bbt_object_propertyTableAdapter.FindByFk_Id(row.bbt_object_typeRow.pk_id, YPk).First();
            rowX = dataset.bbt_object_property.Where(p => p.fk_object_type_id == row.bbt_object_typeRow.pk_id && p.fk_properties_id == XPk).First();
            rowY = dataset.bbt_object_property.Where(p => p.fk_object_type_id == row.bbt_object_typeRow.pk_id && p.fk_properties_id == YPk).First();
            int X = int.Parse(rowX.value.ToString());
            int Y = int.Parse(rowY.value.ToString());
            int[] dim = new int[2];
            dim[0] = X;
            dim[1] = Y;
            return dim;
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

        private int[] ConvMmToRef(int coordX, int coordY)
        {
            int[] refCoord = new int[2];
            refCoord[0] = int.Parse(Math.Floor(decimal.Parse((coordX + OffsetSupport[0] - OffsetFirstHole[0]).ToString()) / decimal.Parse(HoleOffsetX[0].ToString())).ToString());
            refCoord[1] = int.Parse(Math.Floor(decimal.Parse((coordY + OffsetSupport[1] - OffsetFirstHole[1]).ToString()) / decimal.Parse(HoleOffsetX[1].ToString())).ToString());
            return refCoord;
        }
        private int[] getRefCoordinate(Button btn)
        { 
            int[] newCoord = ConvMmToRef(deckX - btn.Location.X + btn.Width, btn.Location.Y);
            return newCoord;
        }

        private BioBotDataSets.bbt_objectRow CheckIfOnExistingModule(int pkId, Button button)
        {
            //foreach(Button btn in this.Controls)
            //{
            //    if (btn.Location == button.Location)
            //    {
            //        // s'assurer que aie les bonnes dim
            //        BioBotDataSets.bbt_objectRow row = getSupportObjectRow();
            //        return row;   
            //    }
            //}
            return dataset.bbt_object.FindBypk_id(0);
        }
        #endregion

        #region Refresh functions
        //Refresh deck while checking for overlapping active modules
        public void UpdateDeck(bool init)
        {
            List<BioBotDataSets.bbt_objectRow> listActiveObject = getActiveModules();
            foreach (BioBotDataSets.bbt_objectRow module in listActiveObject)
            {
                int[] dim = getRealDimensions(module);
                Module _mod = setRotation(module.deck_x, module.deck_y,module.rotation, dim[0], dim[1]);
                if (NotOnOtherModule(module) == false)
                {
                    this.presenter.deactivateObject(module);
                    MessageBox.Show(module.description + " is overlapping on another module, please change its coordinates.");
                }
                else if (OnDeck(_mod) == false)
                {
                    this.presenter.deactivateObject(module);
                    MessageBox.Show(module.description + " has been deactivated due to wrong location settings");
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

        #endregion 

        #region Check error functions
        private bool OnDeck(Module mod)
        {
         if (deckXReal - mod.deckX <= 0 || mod.deckX < 0 || deckYReal - mod.deckY <= 0 || mod.deckY < 0)
            {
                MessageBox.Show("The point of reference is out of the deck, please relocate the object.");
                return false;
            } 
         else if (mod.deckX + mod.width <= 0 || deckXReal - mod.deckX + mod.width < 0 || mod.deckY + mod.height <= 0 || deckYReal - mod.deckY + mod.height < 0)
            {
                MessageBox.Show("Dimensions of the selected module do not fit the deck at this current position, please relocate the object.");
                return false;
            }
         else if (mod.deckX - OffsetSupport[0] < 0 || mod.deckY - OffsetSupport[1] < 0 || deckXReal - mod.deckX + OffsetSupport[0] < 0 || deckYReal - mod.deckY + OffsetSupport[1] < 0)
            {
                MessageBox.Show("Dimensions of the object support do not agree with the location.");
                return false;
            }
                return true;  
        }

        private bool NotOnOtherModule(BioBotDataSets.bbt_objectRow row)
        {
            List<Button> listButtons = new List<Button>();
            Panel pnl = new Panel();
            pnl.Size = this.Size;
            foreach (Button btn in this.Controls)
            {
                pnl.Controls.Add(btn);
                listButtons.Add(btn);
            }
            Button newButton = addObject(row,pnl);
            listButtons.Remove(newButton);
            listButtons.Remove(listButtons.Find(p => p.Name == newButton.Name));
            foreach (Button btn in listButtons)
            {
                if (newButton.Bounds.IntersectsWith(btn.Bounds) == true)
                {
                    pnl.Controls.Remove(newButton);
                    return false;
                }
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

        private bool IsLayout(BioBotDataSets.bbt_objectRow row)
        {
            if (getValueObjectProperty("Nothing", row.fk_object_type, "CanDeckLayout").ToString() == "1")
            {
                return true;
            }
            return false;
        }
        private bool IsLayout(BioBotDataSets.bbt_object_typeRow row)
        {
            if (getValueObjectProperty("Nothing", row.pk_id, "CanDeckLayout").ToString() == "1")
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Event handlers
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            XPk = getPkProperty("Dimension", "XLength");
            YPk = getPkProperty("Dimension", "YLength");
            XCount = getValueObjectProperty("PegHoleCount", "Deck", "X");
            YCount = getValueObjectProperty("PegHoleCount", "Deck", "Y");
            deckXReal = getValueObjectProperty("Dimension", "Deck", "XLength");
            deckYReal = getValueObjectProperty("Dimension", "Deck", "YLength");
            this.Location = new Point(this.ParentForm.ClientSize.Width - deckX, 0);
            deckX = this.ParentForm.Width;
            deckY = this.ParentForm.Height;
            this.Size = new Size(deckX, deckY);
            getOffsetParameters();
            UpdateDeck(true);
            ObjectCreation = false;
        }

        private void DeckView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(BioBotDataSets.bbt_objectRow)) == true)
            {
                BioBotDataSets.bbt_objectRow row = e.Data.GetData(typeof(BioBotDataSets.bbt_objectRow)) as BioBotDataSets.bbt_objectRow;
                modifyObject(row, true);
            }
            else if (e.Data.GetDataPresent(typeof(BioBotDataSets.bbt_object_typeRow)) == true)
            {
                BioBotDataSets.bbt_object_typeRow row = e.Data.GetData(typeof(BioBotDataSets.bbt_object_typeRow)) as BioBotDataSets.bbt_object_typeRow;
                ObjectCreation = false;
                var p = PointToClient(Cursor.Position);
                Point pnt = new Point(p.X, p.Y);
                Button btn = (Button)GetChildAtPoint(pnt);
                int[] newCoord = getRefCoordinate(btn);
                btn.Location = new Point(newCoord[0], newCoord[1]);
                BioBotDataSets.bbt_objectRow fkRow = CheckIfOnExistingModule(row.pk_id, btn);
                if (fkRow.pk_id != 0)
                {
                    bool IsFk = true;// ValidateSuperposition();
                    if (IsFk == false)
                    {
                        fkRow = dataset.bbt_object.FindBypk_id(0);
                    }
                }
                //AddNewModuleToDt(btn, row, fkRow);
            }

        }

        private void DeckView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(BioBotDataSets.bbt_objectRow)) == true)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else if (e.Data.GetDataPresent(typeof(BioBotDataSets.bbt_object_typeRow)) == true )
            {
                BioBotDataSets.bbt_object_typeRow row = e.Data.GetData(typeof(BioBotDataSets.bbt_object_typeRow)) as BioBotDataSets.bbt_object_typeRow;
                if (IsLayout(row) == true)
                {
                    ObjectCreation = true;
                    int[] dim = getResizedDimensions(row);
                    var p = PointToClient(Cursor.Position);
                    Button btn = new Button();
                    btn.Location = new Point(p.X - (dim[0] / 2), p.Y - (dim[1] / 2));
                    btn.Width = dim[0];
                    btn.Height = dim[1];
                }
            }
        }

        private void OnClickModule(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;
            BioBotDataSets.bbt_objectRow row = dataset.bbt_object.Where(p => p.description == thisButton.Text).First();
            modifyObject(row, false);

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


        private void DeckView_OnMouseDown(object sender, MouseEventArgs e)
        {
            if (ObjectCreation == true)
            {
                Button btn = (Button)GetChildAtPoint(e.Location);
                btn.Location = new Point(e.Location.X, e.Location.Y);
            }
        }

        private void DeckView_MouseMove(object sender, MouseEventArgs e)
        {
            //Console.WriteLine(e.Location);
        }
        #endregion

    }

}

