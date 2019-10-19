using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SBMS.BLL;
using SBMS.Model;

namespace SBMS
{
    public partial class SupplierInformation : Form
    {
        SupplierManager _supplierManager = new SupplierManager();
        Supplier supplier = new Supplier();
        public SupplierInformation()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //supplier.Id = Convert.ToInt32(idTextBox.Text);
            supplier.Code = codeTextBox.Text;
            supplier.SupplierName = nameTextBox.Text;
            supplier.Address = addressTextBox.Text;
            supplier.Email = emailTextBox.Text;
            supplier.Contact = contactTextBox.Text;
            supplier.ContactPerson = contactPersonTextBox.Text;


            if (addButton.Text == "Add")
            {
                 


                if (_supplierManager.Add(supplier))
                {
                    MessageBox.Show("added");
                    supplierDataGridView.DataSource = _supplierManager.Dispaly();
                    Clear();
                }
            }
            else
            {


                supplier.Id = Convert.ToInt32(idTextBox.Text);
                if (_supplierManager.Update(supplier))
                {
                    MessageBox.Show("Update");
                    supplierDataGridView.DataSource = _supplierManager.Dispaly();
                    Clear();

                }
            }


        }

        private void SupplierInformation_Load(object sender, EventArgs e)
        {
            supplierDataGridView.DataSource = _supplierManager.Dispaly();
        }

        public void Clear()
        {
            codeTextBox.Text = "";
            nameTextBox.Text = "";
            addressTextBox.Text = "";
            emailTextBox.Text = "";
            contactTextBox.Text = "";
            contactPersonTextBox.Text = "";
            

        }

        private void supplierDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            idTextBox.Text = supplierDataGridView.SelectedRows[0].Cells["Id"].Value.ToString();
            codeTextBox.Text = supplierDataGridView.SelectedRows[0].Cells["Code"].Value.ToString();
            nameTextBox.Text = supplierDataGridView.SelectedRows[0].Cells["SupplierName"].Value.ToString();
            addressTextBox.Text = supplierDataGridView.SelectedRows[0].Cells["Address"].Value.ToString();
            emailTextBox.Text = supplierDataGridView.SelectedRows[0].Cells["Email"].Value.ToString();
            contactTextBox.Text = supplierDataGridView.SelectedRows[0].Cells["Contact"].Value.ToString();
            contactPersonTextBox.Text = supplierDataGridView.SelectedRows[0].Cells["ContactPerson"].Value.ToString();
            supplier.Id = Int32.Parse(idTextBox.Text);
            addButton.Text = "Update";

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            supplier.SupplierName = SearchTextBox.Text;
            supplierDataGridView.DataSource = _supplierManager.Search(supplier);
        }
    }
}
