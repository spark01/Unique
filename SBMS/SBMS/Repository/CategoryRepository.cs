using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SBMS.Model;
using System.Data.SqlClient;

namespace SBMS.Repository
{
    class CategoryRepository
    {
        Category category = new Category();
        public bool Add(Category category)
        {
            bool isAdded = false;
            try
            {

                string connectionString = @"Server=DESKTOP-K01B49N; Database=SmallBusiness; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);



                string commandString = @"INSERT INTO Categories (Code, CategoryName) Values ('" + category.Code+ "', '" + category.CategoryName + "')";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();

                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    isAdded = true;
                }



              
                sqlConnection.Close();


            }
            catch (Exception exeption)
            {
                
            }

            return isAdded;
        }

        public DataTable Display()
        {
            string connectionString = @"Server=DESKTOP-K01B49N; Database=SmallBusiness; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string commandString = @"SELECT * FROM Categories";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            sqlConnection.Close();
            return dataTable;


        }

        public bool Update(Category category)
        {
            try
            {
                
                string connectionString = @"Server=DESKTOP-K01B49N; Database=SmallBusiness; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

               
                string commandString = @"UPDATE Categories SET Code ='"+category.Code + "', CategoryName = '" + category.CategoryName + "'WHERE Id = " + category.Id+ "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

           
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }
       
                sqlConnection.Close();


            }
            catch (Exception exeption)
            {
                 
            }
            return false;
        }

        public bool IsNameExist(Category category)

        {
            bool isExist = false;
            try
            {
            
                string connectionString = @"Server=DESKTOP-K01B49N; Database=SmallBusiness; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                 
                string commandString = @"SELECT * FROM Categories WHERE Code='" + category.Code + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                
                sqlConnection.Open();

              
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    isExist = true;
                }

 
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                
            }
            return isExist;
        }
        public bool IsCodeExist(Category category)

        {
            bool isExist = false;
            try
            {

                string connectionString = @"Server=DESKTOP-K01B49N; Database=SmallBusiness; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);


                string commandString = @"SELECT Id FROM Categories WHERE Code='" + category.Code + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    int codewiseID = 0;
                    codewiseID=Int32.Parse(dataTable.Rows[0]["Id"].ToString());
                    if(category.Id != codewiseID)
                    { 
                    isExist = true;
                    }
                }


                sqlConnection.Close();

            }
            catch (Exception exeption)
            {

            }
            return isExist;
        }

        public List<Category> loadCombo()
        {
            List<Category> Categories = new List<Category>();

            try
            {
                string connectionString = @"Server=DESKTOP-K01B49N; Database=SmallBusiness; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                string commandString = @"SELECT Id, Code, CategoryName FROM Categories";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();



                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Category category = new Category();
                    category.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    category.Code = sqlDataReader["Code"].ToString();
                    category.CategoryName = sqlDataReader["CategoryName"].ToString();

                    Categories.Add(category);
                }

                sqlConnection.Close();




            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Categories;
        }
    }
}
