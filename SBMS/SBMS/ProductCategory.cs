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
    public partial class ProductCategory : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        CategoryManager _categoryManager = new CategoryManager();
        Category category = new Category();
        int er = 0;
        public ProductCategory()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            category.Code = codeTextBox.Text;
            category.CategoryName = nameTextBox.Text;

            if ((codeTextBox.Text.Equals("") || codeTextBox.Text.Length != 4))
            {
                er++;
                errorProvider.SetError(codeTextBox, "Enter your Id and Id Must be 4 charecter");
                return;

            }
            if ((nameTextBox.Text.Equals("")))
            {
                er++;
                errorProvider.SetError(nameTextBox, "insert name");
                return;

            }

           


            if (addButton.Text == "Add")
            {
                if (_categoryManager.IsNameExist(category))
                {
                    er++;
                    errorProvider.SetError(codeTextBox, "Please Inser  Unique Code");

                    return;
                }


                if (_categoryManager.Add(category))
                {
                    MessageBox.Show("added");
                    addDataGridView.DataSource = _categoryManager.Display();
                    codeTextBox.Clear();
                    nameTextBox.Clear();
                }
            }
            else
            {
                if (_categoryManager.IsCodeExist(category))
                {
                    er++;
                    errorProvider.SetError(codeTextBox, "Please Inser  Unique Code");

                    return;
                }

                category.Id = Convert.ToInt32(idTextBox.Text);
                if (_categoryManager.Update(category))
                {
                    MessageBox.Show("Update");
                    addDataGridView.DataSource = _categoryManager.Display();
                    codeTextBox.Clear();
                    nameTextBox.Clear();
                    
                }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addDataGridView.DataSource = _categoryManager.Display();
        }

        private void addDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            idTextBox.Text = addDataGridView.SelectedRows[0].Cells["colId"].Value.ToString();
            codeTextBox.Text = addDataGridView.SelectedRows[0].Cells["colCode"].Value.ToString();
            nameTextBox.Text = addDataGridView.SelectedRows[0].Cells["colName"].Value.ToString();
            category.Id = Int32.Parse(idTextBox.Text);
            addButton.Text = "Update";
        }

         
    }
}
