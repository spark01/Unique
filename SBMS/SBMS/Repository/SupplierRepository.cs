using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMS.Model;
using System.Data.SqlClient;


namespace SBMS.Repository
{
    class SupplierRepository
    {
        Supplier supplier = new Supplier();

        public bool Add(Supplier supplier)
        {
            bool isAdded = false;
            try
            {

                string connectionString = @"Server=DESKTOP-K01B49N; Database=SmallBusiness; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);



                string commandString = @"INSERT INTO Suppliers (Code, SupplierName, Address,Email,Contact,ContactPerson) Values ('" + supplier.Code + "', '" + supplier.SupplierName + "', '" + supplier.Address + "', '" + supplier.Email + "','" + supplier.Contact + "', '" + supplier.ContactPerson + "')";
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

        public List<Supplier> Dispaly()
        {
            List<Supplier> Suppliers = new List<Supplier>();

            try
            {
                string connectionString = @"Server=DESKTOP-K01B49N; Database=SmallBusiness; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                string commandString = @"SELECT * FROM Suppliers";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();



                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    Supplier supplie = new Supplier();
                    supplie.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    supplie.Code = sqlDataReader["Code"].ToString();
                    supplie.SupplierName = sqlDataReader["SupplierName"].ToString();
                    supplie.Address = sqlDataReader["Address"].ToString();
                    supplie.Email = sqlDataReader["Email"].ToString();
                    supplie.Contact = sqlDataReader["Contact"].ToString();
                    supplie.ContactPerson =sqlDataReader["ContactPerson"].ToString();

                    Suppliers.Add(supplie);
                }

                sqlConnection.Close();




            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Suppliers;
        }

        public List<Supplier> Search(Supplier supplier)
        {
            List<Supplier> Suppliers = new List<Supplier>();

            try
            {
                string connectionString = @"Server=DESKTOP-K01B49N; Database=SmallBusiness; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                string commandString = @"SELECT * FROM Suppliers WHERE SupplierName='" + supplier.SupplierName + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();



                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Supplier supplie = new Supplier();
                    supplie.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    supplie.Code = sqlDataReader["Code"].ToString();
                    supplie.SupplierName = sqlDataReader["SupplierName"].ToString();
                    supplie.Address = sqlDataReader["Address"].ToString();
                    supplie.Email = sqlDataReader["Email"].ToString();
                    supplie.Contact = sqlDataReader["Contact"].ToString();
                    supplie.ContactPerson = sqlDataReader["ContactPerson"].ToString();

                    Suppliers.Add(supplie);
                }

                sqlConnection.Close();




            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Suppliers;
        }

        public bool Update(Supplier supplier)
        {
            try
            {

                string connectionString = @"Server=DESKTOP-K01B49N; Database=SmallBusiness; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);


                string commandString = @"UPDATE Suppliers SET Code ='" + supplier.Code + "', SupplierName = '" + supplier.SupplierName + "',  Address ='" + supplier.Address + "', Email = '" + supplier.Email + "', Contact ='" + supplier.Contact + "', ContactPerson = '" + supplier.ContactPerson + "'  WHERE Id = " + supplier.Id + "";
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
    }
}
