using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.View.Services
{
    public interface IInformationValueServiceView
    {
        DataGridView InformationValueDataTable { set; }

        int InformationValuePrimaryKey { get; }

        DataRow InformationValueRow { get; }

        int PropertyForeignKey { get; }

        int ObjectForeignKey { get; }

    }
}
