using Microsoft.Reporting.WinForms;
using SiinErp.Desktop.Controllers;
using SiinErp.Desktop.Reportes.SiinErpDataSetTableAdapters;
using SiinErp.Model.Entities.Inventario;
using SiinErp.Model.Entities.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiinErp.Desktop.Reportes
{
    public partial class FormReporte : Form
    {
        private readonly IControllerBusiness controllerBusiness;

        public FormReporte(IControllerBusiness _controllerBusiness)
        {
            InitializeComponent();
            this.controllerBusiness = _controllerBusiness;
        }

        public void RptNumeroFactura(int IdFactura)
        {
            Sp_NumeroFacturaTableAdapter tableAdapter = new Sp_NumeroFacturaTableAdapter();
            SiinErpDataSet.Sp_NumeroFacturaDataTable dataTable = new SiinErpDataSet.Sp_NumeroFacturaDataTable();
            tableAdapter.Fill(dataTable, IdFactura);

            ReportDataSource reportDataSource = new ReportDataSource("DtNumeroFactura", (DataTable)dataTable);
            this.reportViewer1.LocalReport.ReportPath = (@"C:\Repositorios\SiinErp\SiinErp.Desktop\Reportes\rdlc\NumeroFactura.rdlc");
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
            this.ShowDialog();

            //List<NumeroFactura> Listado = this.controllerBusiness.reporteBusiness.GetNumeroFactura(IdFactura);
            //ReportDataSource reportDataSource = new ReportDataSource("NumeroFacturaDataSet", Listado);
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "NumeroFactura.rdlc";
            //this.reportViewer1.LocalReport.DataSources.Clear();
            //this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            //this.reportViewer1.RefreshReport();
            //this.ShowDialog();
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {

        }
    }
}
