using System;
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
    public class M_HOLIDAYRepository : IRepository
    {
        #region コンストラクタ
        public M_HOLIDAYRepository()
        {
            TableName = Constant.MHOLIDAY;
            Connection = new OleDbConnection() { ConnectionString = ConfigurationManager.ConnectionStrings["WomanDB"].ConnectionString };
            Command = new OleDbCommand();
        }

        #endregion

        #region メソッド
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
            searchCondition.Append("SELECT * FROM " + TableName + "WHERE 1 = 1");

            #region パラメータ作成
            // ToDo 長すぎ メソッド化できない？
            if (param.Keys.ToList().Any(_ => _ == "YYMM"))
            {
                searchCondition.Append(@" and YYMM = @YYMM");
                searchParameter.Add("@YYMM", param["YYMM"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "DD_1"))
            {
                searchCondition.Append(@" and DD_1 = @DD_1");
                searchParameter.Add("@DD_1", param["DD_1"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "HOLIDAY_FLG_1"))
            {
                searchCondition.Append(@" and HOLIDAY_FLG_1 = @HOLIDAY_FLG_1");
                searchParameter.Add("@HOLIDAY_FLG_1", param["HOLIDAY_FLG_1"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "DD_2"))
            {
                searchCondition.Append(@" and DD_2 = @DD_2");
                searchParameter.Add("@DD_2", param["DD_2"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "HOLIDAY_FLG_2"))
            {
                searchCondition.Append(@" and HOLIDAY_FLG_2 = @HOLIDAY_FLG_2");
                searchParameter.Add("@HOLIDAY_FLG_2", param["HOLIDAY_FLG_2"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "DD_3"))
            {
                searchCondition.Append(@" and DD_3 = @DD_3");
                searchParameter.Add("@DD_3", param["DD_3"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "HOLIDAY_FLG_3"))
            {
                searchCondition.Append(@" and HOLIDAY_FLG_3 = @HOLIDAY_FLG_3");
                searchParameter.Add("@HOLIDAY_FLG_3", param["HOLIDAY_FLG_3"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "DD_4"))
            {
                searchCondition.Append(@" and DD_4 = @DD_4");
                searchParameter.Add("@DD_4", param["DD_4"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "HOLIDAY_FLG_4"))
            {
                searchCondition.Append(@" and HOLIDAY_FLG_4 = @HOLIDAY_FLG_4");
                searchParameter.Add("@HOLIDAY_FLG_4", param["HOLIDAY_FLG_4"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "DD_5"))
            {
                searchCondition.Append(@" and DD_5 = @DD_5");
                searchParameter.Add("@DD_5", param["DD_5"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "HOLIDAY_FLG_5"))
            {
                searchCondition.Append(@" and HOLIDAY_FLG_5 = @HOLIDAY_FLG_5");
                searchParameter.Add("@HOLIDAY_FLG_5", param["HOLIDAY_FLG_5"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "DD_6"))
            {
                searchCondition.Append(@" and DD_6 = @DD_6");
                searchParameter.Add("@DD_6", param["DD_6"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "HOLIDAY_FLG_6"))
            {
                searchCondition.Append(@" and HOLIDAY_FLG_7 = @HOLIDAY_FLG_7");
                searchParameter.Add("@HOLIDAY_FLG_1", param["HOLIDAY_FLG_1"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "DD_7"))
            {
                searchCondition.Append(@" and DD_1 = @DD_7");
                searchParameter.Add("@DD_1", param["DD_1"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "HOLIDAY_FLG_7"))
            {
                searchCondition.Append(@" and HOLIDAY_FLG_7 = @HOLIDAY_FLG_7");
                searchParameter.Add("@HOLIDAY_FLG_7", param["HOLIDAY_FLG_7"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "DD_8"))
            {
                searchCondition.Append(@" and DD_8 = @DD_8");
                searchParameter.Add("@DD_8", param["DD_8"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "HOLIDAY_FLG_8"))
            {
                searchCondition.Append(@" and HOLIDAY_FLG_8 = @HOLIDAY_FLG_8");
                searchParameter.Add("@HOLIDAY_FLG_8", param["HOLIDAY_FLG_8"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "DD_9"))
            {
                searchCondition.Append(@" and DD_9 = @DD_9");
                searchParameter.Add("@DD_9", param["DD_9"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "HOLIDAY_FLG_9"))
            {
                searchCondition.Append(@" and HOLIDAY_FLG_9 = @HOLIDAY_FLG_9");
                searchParameter.Add("@HOLIDAY_FLG_9", param["HOLIDAY_FLG_9"].ToString());
            }
            if (param.Keys.ToList().Any(_ => _ == "DD_10"))
            {
                searchCondition.Append(@" and DD_10 = @DD_10");
                searchParameter.Add("@DD_10", param["DD_10"].ToString());
            }

            if (param.Keys.ToList().Any(_ => _ == "HOLIDAY_FLG_10"))
            {
                searchCondition.Append(@" and HOLIDAY_FLG_10 = @HOLIDAY_FLG_10");
                searchParameter.Add("@HOLIDAY_FLG_10", param["HOLIDAY_FLG_10"].ToString());
            }

            #endregion

            using (var com = (OleDbCommand)Command)
            {
                com.Connection = (OleDbConnection)this.Connection;
                com.CommandText = searchCondition.ToString();
                com.Parameters.AddRange(searchParameter.Select(_ => new OleDbParameter() { ParameterName = _.Key, Value = _.Value }).ToArray<OleDbParameter>());

                Reader = com.ExecuteReader();
                return ToEntity();
            }
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<M_HOLIDAY> ToEntity()
        {
            var reader = (OleDbDataReader)Reader;
            var result = new List<M_HOLIDAY>();
            if (reader.FieldCount == 0)
            {
                throw new Exception("データベースがロードされていません！");
            }
            while (reader.Read())
            {
                result.Add(new M_HOLIDAY()
                {
                    DATE = Reader["YYMM"].ToString(),
                    DAY_1 = Reader["DAY_1"].ToString(),
                    HOLIDAY_FLG_1 = Reader["HOLIDAY_FLG_1"].ToString(),
                    DAY_2 = Reader["DAY_2"].ToString(),
                    HOLIDAY_FLG_2 = Reader["HOLIDAY_FLG_2"].ToString(),
                    DAY_3 = Reader["DAY_3"].ToString(),
                    HOLIDAY_FLG_3 = Reader["HOLIDAY_FLG_3"].ToString(),
                    DAY_4 = Reader["DAY_4"].ToString(),
                    HOLIDAY_FLG_4 = Reader["HOLIDAY_FLG_4"].ToString(),
                    DAY_5 = Reader["DAY_5"].ToString(),
                    HOLIDAY_FLG_5 = Reader["HOLIDAY_FLG_5"].ToString(),
                    DAY_6 = Reader["DAY_6"].ToString(),
                    HOLIDAY_FLG_6 = Reader["HOLIDAY_FLG_6"].ToString(),
                    DAY_7 = Reader["DAY_7"].ToString(),
                    HOLIDAY_FLG_7 = Reader["HOLIDAY_FLG_7"].ToString(),
                    DAY_8 = Reader["DAY_8"].ToString(),
                    HOLIDAY_FLG_8 = Reader["HOLIDAY_FLG_8"].ToString(),
                    DAY_9 = Reader["DAY_9"].ToString(),
                    HOLIDAY_FLG_9 = Reader["HOLIDAY_FLG_9"].ToString(),
                    DAY_10 = Reader["DAY_10"].ToString(),
                    HOLIDAY_FLG_10 = Reader["HOLIDAY_FLG_10"].ToString(),
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

