using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecordWriter.Domain.Service.Interface;
using AttendanceRecordWriter.Domain.Service;
using System.Data.Common;
using System.Configuration;
using AttendanceRecordWriter.Domain.Model.Entity;
using AttendanceRecordWriter.Infstructure.Constants;
using AttendanceRecordWriter.Domain.Model.ValueObjectes;

namespace AttendanceRecordWriter.Infstructure.Repository
{
    public class T_WORKTIMERepository : IRepository
    {
        public T_WORKTIMERepository()
        {
            TableName = Constant.TWORKTIME;
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

        public object FindBySearchCondition(Dictionary<string, object> condition)
        {
            var param = condition as Dictionary<string, object>;
            var searchCondition = new StringBuilder();
            var searchParameter = new Dictionary<string, object>();
            searchCondition.Append("SELECT * FROM " + TableName + " WHERE 1 = 1");

            if (param.Keys.ToList().Any(_ => _ == "USER_CODE"))
            {
                searchCondition.Append(@" and USER_CODE = @USER_CODE");
                searchParameter.Add("@USER_CODE", param["USER_CODE"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "NO"))
            {
                searchCondition.Append(@" and NO = @NO");
                searchParameter.Add("@NO", param["NO"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "DATE"))
            {
                searchCondition.Append(@" and DATE = @DATE");
                searchParameter.Add("@DATE", param["DATE"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "HOUR"))
            {
                searchCondition.Append(@" and HOUR = @HOUR");
                searchParameter.Add("@HOUR", param["HOUR"].ToString());
            }

            using (var com = (OleDbCommand)Command)
            {
                com.Connection = (OleDbConnection)this.Connection;
                com.CommandText = searchCondition.ToString();
                com.Parameters.AddRange(searchParameter.Select(_ => new OleDbParameter() { ParameterName = _.Key, Value = _.Value }).ToArray<OleDbParameter>());

                Reader = com.ExecuteReader();
            }
            return ToEntity();
        }

        public IEnumerable<T_WORKTIME> ToEntity()
        {
            var reader = (OleDbDataReader)Reader;
            var result = new List<T_WORKTIME>();
            if (reader.FieldCount == 0)
            {
                throw new Exception("データベースがロードされていません！");
            }
            while (reader.Read())
            {
                result.Add(new T_WORKTIME()
                {
                    USER_CODE = Reader["USER_CODE"].ToString(),
                    NO = Reader["NO"].ToString(),
                    DATE = Reader["DATE"].ToString(),
                    HOUR = Reader["HOUR"].ToString()
                });
            }
            return result;
        }


        public void Update()
        {
            throw new NotImplementedException();
        }

        #region プロパティ
        public string TableName { get; set; }
        public DbConnection Connection { get; set; }
        public DbCommand Command { get; set; }
        public DbDataReader Reader { get; set; }
        #endregion
    }
}
