using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SBMS.Model;
using SBMS.BLL;


namespace SBMS
{
    public partial class ProductInformation : Form
    {
        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        Product product = new Product();
        public ProductInformation()
        {
            InitializeComponent();
        }

        private void ProductInformation_Load(object sender, EventArgs e)
        {
            productDataGridView.DataSource = _productManager.Display();
            AllComboload();

        }

        public void AllComboload()
        {
            categoryComboBox.DataSource = _categoryManager.loadCombo();
            categoryComboBox.DisplayMember = "CategoryName";
            categoryComboBox.ValueMember = "Id";
            categoryComboBox.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            product.Code = codeTextBox.Text;
            product.ProductName = nameTextBox.Text;
            product.ReorderLevel = Convert.ToInt32(levelTextBox.Text);
            product.Description = descriptionTextBox.Text;
            product.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);


            if (addButton.Text == "Add")
            {
               
                if (_productManager.Add(product))
                {
                    MessageBox.Show("added");
                    //addDataGridView.DataSource = _productManager.Display();
                    clear();
                }
            }
            else
            {
                 

                product.Id = Convert.ToInt32(idTextBox.Text);
                if (_productManager.Update(product))
                {
                    MessageBox.Show("Update");
                    productDataGridView.DataSource = _productManager.Display();
                    clear();

                }
            }








        }

        public void clear()
        {
            codeTextBox.Text = "";
            nameTextBox.Text = "";
            levelTextBox.Text = "";
            descriptionTextBox.Text = "";
            categoryComboBox.Text = "--please Select--";
        }

        private void productDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            idTextBox.Text = productDataGridView.SelectedRows[0].Cells["Id"].Value.ToString();
            codeTextBox.Text = productDataGridView.SelectedRows[0].Cells["Code"].Value.ToString();
            nameTextBox.Text = productDataGridView.SelectedRows[0].Cells["ProductName"].Value.ToString();
            levelTextBox.Text = productDataGridView.SelectedRows[0].Cells["ReorderLevel"].Value.ToString();
            descriptionTextBox.Text = productDataGridView.SelectedRows[0].Cells["Description"].Value.ToString();
            categoryComboBox.SelectedValue = Convert.ToInt32(productDataGridView.SelectedRows[0].Cells["CategoryId"].Value.ToString());

            product.Id = Int32.Parse(idTextBox.Text);
            addButton.Text = "Update";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            product.ProductName = searchTextBox.Text;
            productDataGridView.DataSource = _productManager.Search(product );
        }
    }
}
