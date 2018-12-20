using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CRMApp.Model;

namespace CRMApp.Business
{
    public class CustomerService : EntityProvider<Customer>
    {
        private const string INSERT_COMMAND =
            @"INSERT INTO Customer(FirstName, LastName, Address, City, Email) 
            VALUES(@FirstName, @LastName, @Address, @City, @Email)";
        private const string UPDATE_COMMAND =
            @"UPDATE Customer SET FirstName=@FirstName, LastName=@LastName, 
                Address=@Address, City=@City, Email=@Email 
            WHERE CustomerID=@CustomerID";

        public override void Save(Customer entity)
        {
            SqlCommand command = new SqlCommand("", _connection);

            if (entity.CustomerID == null)
            {
                command.CommandText = INSERT_COMMAND;
            }
            else
            {
                command.CommandText = UPDATE_COMMAND;
                command.Parameters.AddWithValue("@CustomerID", entity.CustomerID);
            }

            command.Parameters.AddWithValue("@FirstName", entity.FirstName ?? "");
            command.Parameters.AddWithValue("@LastName", entity.LastName ?? "");
            command.Parameters.AddWithValue("@Address", entity.Address ?? "");
            command.Parameters.AddWithValue("@City", entity.City ?? "");
            command.Parameters.AddWithValue("@Email", entity.Email ?? "");

            command.ExecuteNonQuery();
        }

        
        protected override Customer Load(DataRow row)
        {
            Customer entity = new Customer();

            if (!(row["CustomerID"] is DBNull))
                entity.CustomerID = Convert.ToInt32(row["CustomerID"]);
            if (!(row["Address"] is DBNull))
                entity.Address = Convert.ToString(row["Address"]);
            if (!(row["City"] is DBNull))
                entity.City = Convert.ToString(row["City"]);
            if (!(row["FirstName"] is DBNull))
                entity.FirstName = Convert.ToString(row["FirstName"]);
            if (!(row["LastName"] is DBNull))
                entity.LastName = Convert.ToString(row["LastName"]);
            if (!(row["Email"] is DBNull))
                entity.Email = Convert.ToString(row["Email"]);

            return entity;
        }
    }
}
