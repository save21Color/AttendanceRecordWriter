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
    public class T_WORKPLANRepository : IRepository
    {
        #region コンストラクタ
        public T_WORKPLANRepository()
        {
            TableName = Constant.TWORKPLAN;
            Connection = new OleDbConnection() { ConnectionString = ConfigurationManager.ConnectionStrings["WomanDB"].ConnectionString };
            //Command = new OleDbCommand();
        }
        #endregion

        #region メソッド
        public void Connect()
        {
            Connection.Open();
            Command = new OleDbCommand();
        }

        public void DisConnect()
        {
            Connection.Close();
            Command = null;
            Reader = null;
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

            #region パラメータ作成
            if (param.Keys.ToList().Any(_ => _ == "USER_CODE"))
            {
                searchCondition.Append(@" and USER_CD = @USER_CD");
                searchParameter.Add("@USER_CD", param["USER_CD"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "DATE"))
            {
                searchCondition.Append(@" and YMD like @DATE");
                searchParameter.Add("@DATE", "%"+param["DATE"].ToString()+"%");
            }

            if (param.Keys.ToList().Any(_ => _ == "HOLIDAY_FLAG"))
            {
                searchCondition.Append(@" and HOLIDAY_FLAG = @HOLIDAY_FLAG");
                searchParameter.Add("@HOLIDAY_FLG", param["HOLIDAY_FLAG"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "PLAN_SEC_TIME"))
            {
                searchCondition.Append(@" and PLAN_SEC_TIME = @PLAN_SEC_TIME");
                searchParameter.Add("@PLAN_SEC_TIME", param["PLAN_SEC_TIME"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "PLAN_HOUR_TIME "))
            {
                searchCondition.Append(@" and PLAN_HOUR_TIME  = @PLAN_HOUR_TIME");
                searchParameter.Add("@PLAN_HOUR_TIME ", param["PLAN_HOUR_TIME"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "WORKING_SEC_TIME"))
            {
                searchCondition.Append(@" and WORKING_SEC_TIME = @WORKING_SEC_TIME");
                searchParameter.Add("@WORKING_SEC_TIME", param["WORKING_SEC_TIME"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "WORK_FLG"))
            {
                searchCondition.Append(@" and WORK_FLG = @WORK_FLG");
                searchParameter.Add("@WORK_FLG", param["WORK_FLG"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "PLACE_NO"))
            {
                searchCondition.Append(@" and PLACE_NO = @PLACE_NO");
                searchParameter.Add("@PLACE_NO", param["PLACE_NO"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "WORKING_SEC"))
            {
                searchCondition.Append(@" and WORKING_SEC = @WORKING_SEC");
                searchParameter.Add("@WORKING_SEC", param["WORKING_SEC"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "WORKING_HOUR"))
            {
                searchCondition.Append(@" and WORKING_HOUR = @WORKING_HOUR");
                searchParameter.Add("@WORKING_HOUR", param["WORKING_HOUR"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "KINMU_TIME"))
            {
                searchCondition.Append(@" and KINMU_TIME = @KINMU_TIME");
                searchParameter.Add("@KINMU_TIME", param["KINMU_TIME"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "WORK_FLAG"))
            {
                searchCondition.Append(@" and WORK_FLAG = @WORK_FLAG");
                searchParameter.Add("@WORK_FLAG", param["WORK_FLAG"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "SUMMARY"))
            {
                searchCondition.Append(@" and SUMMARY = @SUMMARY");
                searchParameter.Add("@SUMMARY", param["SUMMARY"].ToString());
            }
            #endregion

            using (var com = (OleDbCommand)Command)
            {
                com.Connection = (OleDbConnection)this.Connection;
                com.CommandText = searchCondition.ToString();
                com.Parameters.AddRange(searchParameter.Select(_ => new OleDbParameter() { ParameterName = _.Key, Value = _.Value }).ToArray<OleDbParameter>());

                Reader = com.ExecuteReader();

                com.Parameters.Clear();

                return ToEntity();
            }
        }
    
        public void Update()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T_WORKPLAN> ToEntity()
        {
            var reader = (OleDbDataReader)Reader;
            var result = new List<T_WORKPLAN>();
            if (reader.FieldCount == 0)
            {
                throw new Exception("データベースがロードされていません！");
            }
            while (reader.Read())
            {
                result.Add(new T_WORKPLAN()
                {
                    USER_CODE = Reader["USER_CODE"].ToString(),
                    DATE = Reader["DATE"].ToString(),
                    HOLIDAY_FLAG = Reader["HOLIDAY_FLAG"].ToString(),
                    PLAN_SEC_TIME = Reader["PLAN_SEC_TIME"].ToString(),
                    PLAN_HOUR_TIME = Reader["PLAN_HOUR_TIME"].ToString(),
                    WORKING_SEC_TIME = Reader["WORKING_SEC_TIME"].ToString(),
                    WORK_FLG = Reader["WORK_FLG"].ToString(),
                    PLACE_NO = Reader["PLACE_NO"].ToString(),
                    WORKING_SEC = Reader["WORKING_SEC"].ToString(),
                    WORKING_HOUR = Reader["WORKING_HOUR"].ToString(),
                    KINMU_TIME = Reader["KINMU_TIME"].ToString(),
                    WORK_FLAG = Reader["WORK_FLAG"].ToString(),
                    SUMMARY = Reader["SUMMARY"].ToString()
                });
            }
            return result;
        }

        #endregion

        #region プロパティ
        public string TableName { get; set; }
        public DbConnection Connection { get; set; }
        public DbCommand Command { get; set; }
        public DbDataReader Reader { get; set; }
        #endregion
    }
}
