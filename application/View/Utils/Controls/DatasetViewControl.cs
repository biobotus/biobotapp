using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBotApp.Model.Data;
using System.Windows.Forms;
using BioBotApp.Presenter.Utils;

namespace BioBotApp.View.Utils
{
    public class DatasetViewControl : UserControl, IDatasetViewControl
    {
        public Model.Data.BioBotDataSets dataset { get; set; }
        private DatasetPresenter datasetPresenter;

        public DatasetViewControl()
        {
            datasetPresenter = new DatasetPresenter(this);
        }

        public void setProjectDataset(BioBotDataSets dataset)
        {
            this.dataset = dataset;
        }
    }
}
