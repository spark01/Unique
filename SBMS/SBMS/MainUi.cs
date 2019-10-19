using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS
{
    public partial class MainUi : Form
    {
        public MainUi()
        {
            InitializeComponent();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductCategory productCategory = new ProductCategory();
            //productCategory.MdiParent = this;
            productCategory.StartPosition = FormStartPosition.CenterParent;
            productCategory.ShowDialog();
            //productCategory.Show();
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProductInformation productInformation = new ProductInformation();
            //productCategory.MdiParent = this;
            productInformation.StartPosition = FormStartPosition.CenterParent;
            productInformation.ShowDialog();
            //productCategory.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerInformation customerInformation = new CustomerInformation();
            customerInformation.StartPosition = FormStartPosition.CenterParent;
            customerInformation.ShowDialog();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierInformation supplierInformation = new SupplierInformation();
            supplierInformation.StartPosition = FormStartPosition.CenterParent;
            supplierInformation.ShowDialog();
        }
    }
}
