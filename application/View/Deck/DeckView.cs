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

namespace BioBotApp.View.Deck
{
    public partial class DeckView : UserControl, IDeckView
    {
        private int deckWidthReal;
        private int deckWidth;
        private int deckLengthReal;
        private int deckLength;
        private int lengthPk;
        private int widthPk;
        public DeckView()
        {
            InitializeComponent();
            this.bsObject.DataMember = "bbt_object";
            this.bsObject.DataSource = DBManager.Instance.projectDataset;
            lengthPk = DBManager.Instance.projectDataset.bbt_property.Where(p => p.description == "length").First().pk_id;
            widthPk = DBManager.Instance.projectDataset.bbt_property.Where(p => p.description == "width").First().pk_id;
            BioBotDataSets.bbt_objectRow deck = DBManager.Instance.projectDataset.bbt_object.Where(p => p.description == "deck" && p.activated == "1").First();
            deckLengthReal = Int32.Parse(DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == deck.pk_id && p.fk_properties_id == lengthPk).First().value);
            deckWidthReal = Int32.Parse(DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == deck.bbt_object_typeRow.pk_id && p.fk_properties_id == widthPk).First().value);
            deckLength = deckLengthReal;
            deckWidth = deckWidthReal;
            this.Size = new Size(deckLength,deckWidth);
        }

        public void addObject(BioBotDataSets.bbt_objectRow obj)
        {
            if (obj.activated == "1")
            {
                Button Mod = new Button();
                BioBotDataSets.bbt_object_propertyRow rowWidth = DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == obj.bbt_object_typeRow.pk_id && p.fk_properties_id == widthPk).First();
                BioBotDataSets.bbt_object_propertyRow rowLength = DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == obj.bbt_object_typeRow.pk_id && p.fk_properties_id == lengthPk).First();
                int WidthDt = Int16.Parse(rowLength.value);
                int LengthDt = Int16.Parse(rowWidth.value);
                Mod.Text = obj.pk_id.ToString();
                Mod.Location = new Point(obj.deck_x * deckLength / deckLengthReal, obj.deck_y * deckWidth / deckWidthReal);
                setRotation(obj,LengthDt, WidthDt, Mod);
                Mod.Height = LengthDt * deckLength / deckLengthReal ;
                Mod.Width = WidthDt * deckWidth / deckWidthReal;
                Mod.TextAlign = ContentAlignment.MiddleCenter;

                this.Controls.Add(Mod);
            }
        }

        private void setRotation(BioBotDataSets.bbt_objectRow obj, int height, int width, Button button)
        {
            switch (obj.rotation)
            {
                case 0:
                    button.Height = height * deckLength / deckLengthReal;
                    button.Width =  width * deckWidth / deckWidthReal;
                    break;
                case 90:
                    button.Height = width * deckWidth / deckWidthReal;
                    button.Width = - height * deckLength / deckLengthReal;
                    break;
                case 180:
                    button.Height = -height* deckLength / deckLengthReal;
                    button.Width = - width * deckWidth / deckWidthReal;
                    break;
                case 270:
                    button.Height = width * deckWidth / deckWidthReal;
                    button.Width = -height * deckLength / deckLengthReal;
                    break;
                default:
                    MessageBox.Show("Rotation value not allowed");
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public Model.Data.BioBotDataSets.bbt_objectRow getSelectedObjectRow()
        {
            Model.Data.BioBotDataSets.bbt_objectRow objectRow = null;

            if (bsObject.Current == null) return null;
            if (!(bsObject.Current.GetType() == typeof(DataRowView))) return null;
            DataRowView rowView = bsObject.Current as DataRowView;
            if (rowView.Row == null) return null;
            if (!(rowView.Row.GetType() == typeof(Model.Data.BioBotDataSets.bbt_objectRow))) return null;
            objectRow = rowView.Row as Model.Data.BioBotDataSets.bbt_objectRow;
            return objectRow;
        }

        private void DeckView_DragDrop(object sender, DragEventArgs e)
        {
            BioBotDataSets.bbt_objectRow row = e.Data.GetData(typeof(BioBotDataSets.bbt_objectRow)) as BioBotDataSets.bbt_objectRow;
            addObject(row);
        }

        private void DeckView_DragEnter(object sender, DragEventArgs e)
        {
                e.Effect = DragDropEffects.Copy;
        }
    }
}
