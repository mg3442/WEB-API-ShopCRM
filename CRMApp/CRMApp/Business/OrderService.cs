using CRMApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMApp.Model;
using CRMApp.Business;

namespace CRMApp.Bussines
{
   public class OrderService : EntityProvider<Order>
    {
        private const string INSERT_COMMAND =
            @"INSERT INTO Order(SubscriptionID, CustomerID, CreateDate)
            VALUES (@SubscriptionID, @CustomerID, @CreateDate)";
        private const string UPDATE_COMMAND =
            @"UPDATE Order SET SubscriptionID = @SubscriptionID, CustomerID = @CustomerID,
            CreateDate = @CreateDate
            WHERE OrderID = @OrderID";

        
        
        public override void Save(Order entity)
        {
            SqlCommand command = new SqlCommand("", _connection);

            if(entity.OrderId == null)
            {
                command.CommandText = INSERT_COMMAND;

            }
            else
            {
                command.CommandText = UPDATE_COMMAND;
                command.Parameters.AddWithValue("@OrderID", entity.OrderId);
            }
            command.Parameters.AddWithValue("@SubscriptionID", entity.SubscriptionID);
            command.Parameters.AddWithValue("@CustomerID", entity.CustomerID);
            command.Parameters.AddWithValue("@CreateDate", entity.CreateDate);

            command.ExecuteNonQuery();
        }

       
     


        protected override Order Load(DataRow row)
        {
            Order entity = new Order();


            if (!(row["SubscriptionID"] is DBNull))
                entity.SubscriptionID = Convert.ToInt32(row["SubscriptionID"]);
            if (!(row["CustomerID"] is DBNull))
                entity.CustomerID = Convert.ToInt32(row["CustomerID"]);
            if (!(row["CreateDate"] is DBNull))
                entity.CreateDate = Convert.ToDateTime(row["CreateDate"]);


            return entity;
        }
    }
}
