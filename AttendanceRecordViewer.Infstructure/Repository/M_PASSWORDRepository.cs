using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecordWriter.Domain.Service.Interface;
using System.Data.Common;
using AttendanceRecordWriter.Domain.Service;
using System.Configuration;
using AttendanceRecordWriter.Domain.Model.Entity;
using AttendanceRecordWriter.Infstructure.Constants;
using AttendanceRecordWriter.Domain.Model.ValueObjectes;

namespace AttendanceRecordWriter.Infstructure.Repository
{
    public class M_PASSWORDRepository : IRepository
    {

        public M_PASSWORDRepository()
        {
            TableName = Constant.MPASSWORD;
            Connection = new OleDbConnection() { ConnectionString = ConfigurationManager.ConnectionStrings["WomanDB"].ConnectionString };
            Command = new OleDbCommand();
        }



        public void Connect()
        {
            Connection.Open();
        }

        public void DisConnect()
        {
            Reader.Close();
            Connection.Close();
        }

        public object FindAll()
        {
            using (var com = (OleDbCommand)Command)
            {
                com.Connection = (OleDbConnection)this.Connection;
                com.CommandText = "Select * FROM " + TableName;
                Reader = com.ExecuteReader();
                return ToEntity();
            }

        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<M_PASSWORD> ToEntity()
        {
            var reader = (OleDbDataReader)Reader;
            var result = new List<M_PASSWORD>();
            if (reader.FieldCount == 0)
            {
                throw new Exception("データベースがロードされていません！");
            }
            while (reader.Read())
            {
                result.Add(new M_PASSWORD()
                {
                    USER_CODE = reader["USER_CODE"].ToString(),
                    PASSWORD = reader["PASSWORD"].ToString(),
                    USER_LEVEL = reader["USER_LEVEL"].ToString()
                });
            }
            return result;
        }

        public object FindBySearchCondition(Dictionary<string, object> condition)
        {
            throw new NotImplementedException();
        }


        #region プロパティ

        public string TableName { get; set; }

        public DbConnection Connection { get; set; }

        public DbDataReader Reader { get; set; }

        public DbCommand Command { get; set; }
        #endregion
    }
}
