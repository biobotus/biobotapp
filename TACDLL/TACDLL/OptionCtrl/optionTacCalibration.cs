using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TACDLL.Library;

namespace TACDLL.OptionCtrl
{
    public partial class optionTacCalibration : UserControl
    {
        TacDll tac;
        public optionTacCalibration()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dsModuleStruct"></param>
        /// <param name="tacModel"></param>
        // TODO ajouter en entré la liste des models concerné.
        public optionTacCalibration(DataSets.dsTacCalibration dsModuleStruct, string tacModel, TacDll tacDll) :this()
        {
            tac = tacDll;
            this.dsModuleStructure = dsModuleStruct;
  //          DataView dv = dsModuleStructure.dtModule.DefaultView;
  //          DataView dv2 = dsModuleStructure.dtTacCalibrationData.DefaultView;

  //          dgvTacCalibrationDataView.DataSource = dv2;
  //          dgvTacCalibrationDataView.Columns["fk_module_id"].Visible = false;

   //         var res = (
  //              from module in dsModuleStructure.dtModule.AsEnumerable()
  //              join DataRowView module_type in dsModuleStructure.dtModuleType.AsDataView() 
   //             on module["fk_module_type"] equals module_type["pk_id"]
    //            where (string)module_type["description"] == tacModel
     //           select new { pk_id = module.Field<String>("pk_id"), type = module_type.Row.Field<String>("description") }
      //       ).ToArray();

   //         cmbTacSelector.DataSource = res;
            cmbTacSelector.ValueMember = "pk_id";
            cmbTacSelector.DisplayMember = "pk_id";
        }

        private void crudOptions_AddClickHandler(object sender, EventArgs e)
        {
            abstractDialog dialog = new abstractDialog("Action type", "Add an optical density");

            namedInputTextBox density = new namedInputTextBox("Optical density");
            namedInputTextBox sample = new namedInputTextBox("Tac value","0");
            optionTacSampleCtrl sampleCtrl = new optionTacSampleCtrl(sample, tac);

            dialog.addNamedInputTextBox(density);
            dialog.addNamedInputTextBox(sample);
            dialog.addControl(sampleCtrl);
            
            dialog.ShowDialog();
            
            if (dialog.DialogResult.Equals(DialogResult.OK))
            {
                double opticalDensity = 0.0;
                double tacSample = 0.0;

                DataSets.dsTacCalibration.dtTacCalibrationDataRow row;

                row = dsModuleStructure.dtTacCalibrationData.NewdtTacCalibrationDataRow();

                row.fk_module_id = (string)this.cmbTacSelector.SelectedValue;

                if (!double.TryParse(density.getInputTextValue(), out opticalDensity))
                {
                    MessageBox.Show("The optical density value cannot be parsed", "Input error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!double.TryParse(sample.getInputTextValue(), out tacSample))
                {
                    MessageBox.Show("The tac semple value cannot be parsed","Input error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                row.optical_density = opticalDensity;
                row.tac_sample = tacSample;
                dsModuleStructure.dtTacCalibrationData.AdddtTacCalibrationDataRow(row);
            }
        }

        private void btnValidation_Click(object sender, EventArgs e)
        {
            int rowCount = dsModuleStructure.dtTacCalibrationData.Rows.Count;
            if(rowCount>1)
            { 
                double[] tacSample = dsModuleStructure.dtTacCalibrationData.AsEnumerable().Select(r => r.Field<double>("tac_sample")).ToArray();
                double[] opticalDesityValue = dsModuleStructure.dtTacCalibrationData.AsEnumerable().Select(r => r.Field<double>("optical_density")).ToArray();            

                opticalDesityValue = opticalDesityValue.Select(d => Math.Log(d)).ToArray();

                Matrix res = Matrix.PolyFit(tacSample, opticalDesityValue, 3);
                Console.WriteLine(res);
            }
            else
            {
                MessageBox.Show("Not enough values to calibrate (5 minimum)", "Validation error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
