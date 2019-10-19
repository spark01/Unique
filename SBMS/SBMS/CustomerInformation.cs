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
    public partial class CustomerInformation : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        Customer customer = new Customer();
        public CustomerInformation()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            customer.Code = codeTextBox.Text;
            customer.CustomerName = nameTextBox.Text;
            customer.Address = addresTextBox.Text;
            customer.Email = emailTextBox.Text;
            customer.Contact = contactTextBox.Text;
            customer.LoyaltyPoint = Convert.ToInt32(pointTtextBox.Text);



            if (addButton.Text == "Add")
            { 


                if (_customerManager.Add(customer))
                {
                    MessageBox.Show("added");
                    customerDataGridView.DataSource = _customerManager.Dispaly();
                    Clear();


                }
            }
            else
            {
                

                customer.Id = Convert.ToInt32(idTextBox.Text);
                if (_customerManager.Update(customer))
                {
                    MessageBox.Show("Update");
                    customerDataGridView.DataSource = _customerManager.Dispaly();
                    Clear();

                }
            }

        }
        public void Clear()
        {
            codeTextBox.Text="";
            nameTextBox.Text="";
            addresTextBox.Text="";
            emailTextBox.Text="";
            contactTextBox.Text="";
            contactTextBox.Text="";
            pointTtextBox.Text = "0";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            customer.CustomerName = SearchTextBox.Text;
            customerDataGridView.DataSource = _customerManager.Search(customer);
        }

        private void CustomerInformation_Load(object sender, EventArgs e)
        {
            customerDataGridView.DataSource = _customerManager.Dispaly();
        }

        private void customerDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            idTextBox.Text = customerDataGridView.SelectedRows[0].Cells["Id"].Value.ToString();
            codeTextBox.Text = customerDataGridView.SelectedRows[0].Cells["Code"].Value.ToString();
            nameTextBox.Text = customerDataGridView.SelectedRows[0].Cells["CustomerName"].Value.ToString();
            addresTextBox.Text = customerDataGridView.SelectedRows[0].Cells["Address"].Value.ToString();
            emailTextBox.Text = customerDataGridView.SelectedRows[0].Cells["Email"].Value.ToString();
            contactTextBox.Text = customerDataGridView.SelectedRows[0].Cells["Contact"].Value.ToString();
            pointTtextBox.Text = customerDataGridView.SelectedRows[0].Cells["LoyaltyPoint"].Value.ToString();
            customer.Id = Int32.Parse(idTextBox.Text);
            addButton.Text = "Update";

        }
    }
}
