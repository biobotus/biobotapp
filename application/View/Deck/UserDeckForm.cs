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

        public UserDeckForm()
        {
            InitializeComponent();
        }

        public UserDeckForm( int DeckSizeX, int DeckSizeY)
        {
            InitializeComponent();
            deck_X_Box.Maximum = DeckSizeX;
            deck_X_Box.Minimum = 0;
            deck_Y_Box.Maximum = DeckSizeY;
            deck_Y_Box.Minimum = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }



        public Module getObjectUserForm(int width, int height)
        {
            Module _mod = new Module(int.Parse(deck_X_Box.Value.ToString()), int.Parse(deck_Y_Box.Value.ToString()),width, height, int.Parse(Rotation_Box.SelectedItem.ToString()));
            return _mod;
        }

        public Boolean FullField()
        {
            if (Rotation_Box.SelectedItem == null)
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
            Module obj = new Module(int.Parse(deck_X_Box.Value.ToString()), int.Parse(deck_Y_Box.Value.ToString()), width, height, int.Parse(Rotation_Box.SelectedItem.ToString()));
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void deck_X_Box_TextChanged(object sender, EventArgs e)
        {
        }

        private void deck_X_Box_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void deck_Y_Box_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
