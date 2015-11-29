using BioBotApp.View.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.View.Deck
{
    public partial class UserDeckForm : Form
    {
        private Module _object;
        private bool ObjectDeactivated;
        private bool ObjectActivated;
        private int[] OffsetFirstHole = new int[2];
        private int[] OffsetBoard = new int[2];
        private int[] OffsetSupport = new int[2];
        private int diameter;

        public UserDeckForm()
        {
            InitializeComponent();
            ObjectDeactivated = false;
            ObjectActivated = false;
        }

        public UserDeckForm( int DeckCountX, int DeckCountY, int[] OfstFirstHole, int [] OfstBoard, int[] OfstSupport, int diamtr, string ModName,int ModWidth, int ModHeight,string activation,int deckX, int deckY, int rotation ): this()
        {
            OffsetFirstHole = OfstFirstHole;
            OffsetBoard = OfstBoard;
            OffsetSupport = OfstSupport;
            diameter = diamtr;
            ModuleName.Text = ModName;
            ModuleWidth.Text = ModWidth.ToString();
            ModuleHeight.Text = ModHeight.ToString();
            deck_X_Box.Maximum = DeckCountX;
            deck_X_Box.Minimum = 0;
            deck_Y_Box.Maximum = DeckCountY;
            deck_Y_Box.Minimum = 0;
            int Xcoord = (deckX - OffsetFirstHole[0] - OffsetSupport[0]) / (diameter + OffsetBoard[0]);
            int Ycoord = (deckY - OffsetFirstHole[1] - OffsetSupport[1]) / (diameter + OffsetBoard[1]);
            deck_X_Box.Value = Math.Floor(decimal.Parse(Xcoord.ToString()));
            deck_Y_Box.Value = Math.Floor(decimal.Parse(Ycoord.ToString()));
            Rotation_Box.SelectedItem = rotation.ToString();
            if (activation == "1")
            {
                activatedBox.Checked = true;
            }
            else if (activation == "0")
            {
                DeactivedBox.Checked = true;
            }
        }

        public Module getObjectUserForm(int width, int height)
        {
            Module _mod = new Module(int.Parse(deck_X_Box.Value.ToString()), int.Parse(deck_Y_Box.Value.ToString()),width, height, int.Parse(Rotation_Box.SelectedItem.ToString()));
            return _mod;
        }

        public Boolean FullField()
        {
            if (Rotation_Box.SelectedItem == null || (ObjectActivated == false && ObjectDeactivated == false))
            {
                ErrorLabel.Text = "Please, enter a value for rotation";
                ErrorLabel.Visible = true;
                return false;
            }
            else
            {
            return true;
            }
        }

        public Module setRotation(int width, int height)
        {
            
            int Xref = OffsetFirstHole[0] + int.Parse(deck_X_Box.Value.ToString()) * (OffsetBoard[0] + diameter) - OffsetSupport[0];
            int Yref = OffsetFirstHole[0] + int.Parse(deck_Y_Box.Value.ToString()) * (OffsetBoard[1] + diameter) - OffsetSupport[1];
            Module obj = new Module(Xref, Yref, width, height, int.Parse(Rotation_Box.SelectedItem.ToString()));
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

        public Boolean FitInDeck(int DeckSizeX, int DeckSizeY, Module mod)
        {
            int ModuleSizeX = mod.width;
            int ModuleSizeY = mod.height;
            int ModuleX = mod.deckX;
            int ModuleY = mod.deckY;

            // the x coordinates are inverted in the software compared to the real deck
            if ( ModuleX + ModuleSizeX - DeckSizeX > 0 || ModuleX < 0)
            {
                ErrorLabel.Text = "The module does not fit the deck with its current dimensions (x axis)";
                ErrorLabel.Visible = true;
                return false;
            }
            else if (ModuleY + ModuleSizeY - DeckSizeY > 0 || ModuleY < 0)
            {
                ErrorLabel.Text = "The module does not fit the deck with its current dimensions (x axis)";
                ErrorLabel.Visible = true;
                return false;
            }
            else
            {
                return true;
            }
        }

        public string ChangeActivation()
        {
            if (ObjectActivated == true) return "1";
            else if (ObjectDeactivated == false) return "0";
            return "1";
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
           
        }
       
        private void activatedBox_CheckedChanged(object sender, EventArgs e)
        {
            ObjectActivated = true;
        }

        private void DeactivedBox_CheckedChanged(object sender, EventArgs e)
        {
            ObjectDeactivated = true;
        }

        private void deck_X_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (deck_X_Box.Value > deck_X_Box.Maximum)
            {
                e.Handled = false;
            }
        }

        private void deck_Y_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (deck_Y_Box.Value > deck_Y_Box.Maximum)
            {
                e.Handled = false;
            }
        }
    }
}
