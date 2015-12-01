using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBotApp.Model.Data;

namespace BioBotApp.View.Deck
{
    public class Module
    {
        public int rotation;
        public int height;
        public int width;
        public int deckX;
        public int deckY;

        public Module(int deckX, int deckY, int width, int height, int rotation)
        {
            this.deckX = deckX;
            this.deckY = deckY;
            this.rotation = rotation;
            this.height = height;
            this.width = width;
        }
    }
}
