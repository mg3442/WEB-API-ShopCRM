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
    public abstract class EntityProvider<TEntity> where TEntity: Entity
    {
        private const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True";

        private const string SELECT_COMMAND =
            @"SELECT * FROM {0} WHERE {0}ID=@ID";
        private const string DELETE_COMMAND =
            @"DELETE FROM {0} WHERE {0}ID=@ID";
        private const string GETALL_COMMAND =
            @"SELECT * FROM {0}";

        protected SqlConnection _connection;

        // конструктор
        public EntityProvider()
        {
            _connection = new SqlConnection(CONNECTION_STRING);
            _connection.Open();
        }

        // деструктор
        ~EntityProvider()
        {
            _connection.Close();
            _connection = null;
        }

        protected abstract TEntity Load(DataRow row);

        public abstract void Save(TEntity entity);

        protected string GetObjectName()
        {
            return typeof(TEntity).Name;
        }

        public void Delete(int id)
        {
            string sql = string.Format(DELETE_COMMAND, GetObjectName());

            SqlCommand command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@ID", id);

            command.ExecuteNonQuery();
        }


        public TEntity Load(int id)
        {
            string sql = string.Format(SELECT_COMMAND, GetObjectName());

            SqlCommand command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@ID", id);

            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());

            foreach (DataRow row in table.Rows)
            {
                return Load(row);
            }

            return null;
        }

        public List<TEntity> LoadAll()
        {
            string sql = string.Format(GETALL_COMMAND, GetObjectName());

            SqlCommand command = new SqlCommand(sql, _connection);

            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());

            return (from row in table.Rows.Cast<DataRow>()
                    select Load(row)).ToList();
        }
    }
}
