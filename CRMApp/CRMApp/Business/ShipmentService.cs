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
  public class ShipmentService : EntityProvider<Shipment>
    {
        private const string INSERT_COMMAND =
             @"INSERT INTO Shipment(OrderID, Code, ShipmentDate)
            VALUES (@OrderID, @Code, @ShipmentDate)";
        private const string UPDATE_COMMAND =
            @"UPDATE Shipment SET OrderID = @OrderID, Code = @Code,
            ShipmentDate = @ShipmentDate
            WHERE ShipmentID = @ShipmentID";
       
       

        public override void Save(Shipment entity)
        {
            SqlCommand command = new SqlCommand("", _connection);

            if (entity.ShipmentID == null)
            {
                command.CommandText = INSERT_COMMAND;

            }
            else
            {
                command.CommandText = UPDATE_COMMAND;
                command.Parameters.AddWithValue("@ShipmentID", entity.ShipmentID);
            }
            command.Parameters.AddWithValue("@OrderID", entity.OrderID);
            command.Parameters.AddWithValue("@Code", entity.Code ?? null);
            command.Parameters.AddWithValue("@ShipmentDate", entity.ShipmentDate);

            command.ExecuteNonQuery();
        }

      



        protected override Shipment Load(DataRow row)
        {
            Shipment entity = new Shipment();


            if (!(row["OrderID"] is DBNull))
                entity.OrderID = Convert.ToInt32(row["OrderID"]);
            if (!(row["Code"] is DBNull))
                entity.Code = Convert.ToInt32(row["Code"]);
            if (!(row["ShipmentDate"] is DBNull))
                entity.ShipmentDate = Convert.ToDateTime(row["ShipmentDate"]);


            return entity;
        }
    }
}
