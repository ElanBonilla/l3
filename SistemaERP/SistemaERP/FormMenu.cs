using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaERP
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void iniciarSecionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormLogin = new Form1();
            FormLogin.ShowDialog();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            var FormLogin = new Form1();
            FormLogin.ShowDialog();
        }

        private void cotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Cotizaciones = new Cotizaciones();
            Cotizaciones.MdiParent = this;
            Cotizaciones.Show();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Facturas = new Facturas();
            Facturas.MdiParent = this;
            Facturas.Show();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Pedidos = new Pedidos();
            Pedidos.MdiParent = this;
            Pedidos.Show();
        }

        private void reportesDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ReportesFacturas = new ReportesFacturas();
            ReportesFacturas.MdiParent = this;
            ReportesFacturas.Show();
        }

        private void reportesDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ReportePedidos = new ReportePedidos();
            ReportePedidos.MdiParent = this;
            ReportePedidos.Show();
        }
    }
}
