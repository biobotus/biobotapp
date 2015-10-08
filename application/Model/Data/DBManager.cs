using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Data
{
    class DBManager
    {
        private static DBManager instance;
        private Data.BioBotDataset projectDataset { get; set; }

        private DBManager()
        {
            projectDataset = new BioBotDataset();
        }

        public static DBManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBManager();
                }
                return instance;
            }
        }
    }
}
