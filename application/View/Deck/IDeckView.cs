using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBotApp.Model.Data.Services;
using BioBotApp.Model.Data;

namespace BioBotApp.View.Deck
{
    public interface IDeckView
    {
        void addObject(Model.Data.BioBotDataSets.bbt_objectRow obj);

    }
}
