using BioBotApp.Presenter.Utils;
using BioBotApp.View.Execute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Sequencer
{
    public class SequencerPresenter : DatasetPresenter
    {
        private ISequencerView view;

        public SequencerPresenter(ISequencerView view) : base(view)
        {
            this.view = view;
        }

        public void executeProtocol(Model.Data.BioBotDataSets.bbt_save_protocol_referenceDataTable commands)
        {
            Model.Sequencer.ExecuteService.Instance.startExecuteSequence(commands);
        }
    }
}
