using BioBotApp.View.Deck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBotApp.Model.Data;
using BioBotApp.Model.Data.Services;

namespace BioBotApp.Presenter.Deck
{
    public class DeckPresenter
    {
        private IDeckView view;
        private ObjectService objectService;

        public DeckPresenter(IDeckView view)
        {
            objectService = ObjectService.Instance;
            this.view = view;
        }

        public void addNewObject(Module newObject, int pk_id, int fk_type, string description, string activation)
        {
            objectService.modifyObjectRow(pk_id, fk_type, newObject.deckX, newObject.deckY, newObject.rotation, activation, description);
        }

        public void updateDeck()
        {
            DBManager.Instance.taManager.bbt_objectTableAdapter.Update(DBManager.Instance.projectDataset.bbt_object);

        }

        public void deactivateObject(BioBotDataSets.bbt_objectRow row)
        {
            row.activated = "0";
            objectService.modifyObjectRow(row.pk_id, row.activated);
        }
    }
}
