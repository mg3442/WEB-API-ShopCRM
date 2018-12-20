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
   public class ProductService : EntityProvider<Product>
    {
        private const string INSERT_COMMAND =
            @"INSERT INTO Product(Name, Description) 
            VALUES(@Name, @Description)";
        private const string UPDATE_COMMAND =
            @"UPDATE Product SET Name=@Name, Description=@Description               
            WHERE ProductID=@ProductID";

        


        public override void Save(Product entity)
        {
            SqlCommand command = new SqlCommand("", _connection);

            if (entity.ProductID == null)
            {
                command.CommandText = INSERT_COMMAND;
            }
            else
            {
                command.CommandText = UPDATE_COMMAND;
                command.Parameters.AddWithValue("@ProductID", entity.ProductID);
            }

            command.Parameters.AddWithValue("@Name", entity.Name ?? "");
            command.Parameters.AddWithValue("@Description", entity.Description ?? "");
            

            command.ExecuteNonQuery();
        }


        protected override Product Load(DataRow row)
        {
            Product entity = new Product();

            if (!(row["ProductID"] is DBNull))
                entity.ProductID = Convert.ToInt32(row["ProductID"]);
            if (!(row["Name"] is DBNull))
                entity.Name = Convert.ToString(row["Name"]);
            if (!(row["Description"] is DBNull))
                entity.Description= Convert.ToString(row["Description"]);
           

            return entity;
        }
    }
}
