using BioBotApp.View.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Utils
{
    public class DatasetPresenter : Model.EventBus.Subscriber
    {
        IDatasetViewControl datasetViewControl;
        Model.Data.BioBotDataSets dataset;
        public DatasetPresenter(IDatasetViewControl datasetViewControl)
        {
            this.datasetViewControl = datasetViewControl;
            this.dataset = Model.Data.DBManager.Instance.projectDataset;
            datasetViewControl.setProjectDataset(this.dataset);
        }
    }
}
