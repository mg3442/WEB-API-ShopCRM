using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMApp.Model;
namespace CRMApp.Business
{
   public class SubscriptionService : EntityProvider<Subscription>
    {

        private const String INSERT_COMMAND =
        @"INSERT INTO Subscription(ProductID, Name, Price, Amount)
            VALUES(@ProductID, @Name, @Price, @Amount)";
        private const String UPDATE_COMMAND =
            @"UPDATE Subscription SET ProductID = @ProductID, Name = @Name,
                Price = @Price, Amount = @Amount
                WHERE SubscriptionID = @SubscriptionID";




        

        public override void Save(Subscription entity)
        {
            SqlCommand command = new SqlCommand("", _connection);

            if (entity.SubscriptionID == null)
            {
                command.CommandText = INSERT_COMMAND;
            }
            else
            {
                command.CommandText = UPDATE_COMMAND;
                command.Parameters.AddWithValue("@SubscriptionID", entity.SubscriptionID);
            }

            command.Parameters.AddWithValue("@ProductID", entity.ProductID);
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@Price", entity.Price);
            command.Parameters.AddWithValue("@Amount", entity.Amount);

            command.ExecuteNonQuery();
        }



        protected override Subscription Load(DataRow row)
        {
            Subscription entity = new Subscription();

            if (!(row["SubscriptionID"] is DBNull))
                entity.SubscriptionID = Convert.ToInt32(row["SubscriptionID"]);
            if (!(row["ProductID"] is DBNull))
                entity.ProductID = Convert.ToInt32(row["ProductID"]);
            if (!(row["Name"] is DBNull))
                entity.Name = Convert.ToString(row["Name"]);
            if (!(row["Price"] is DBNull))
                entity.Price = Convert.ToInt32(row["Price"]);
            if (!(row["Amount"] is DBNull))
                entity.Amount = Convert.ToInt32(row["Amount"]);


            return entity;
        }
    }
}
