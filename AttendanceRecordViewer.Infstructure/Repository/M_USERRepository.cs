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
    public class M_USERRepository : IRepository
    {

        #region コンストラクタ
        public M_USERRepository()
        {
            TableName = Constant.MUSER;

            // インターフェースで宣言したConnection,Commandを各DBの型に合わせた型名で宣言し直す
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
            //　工事中
            return null;
        }


        public IEnumerable<M_USER> ToEntity()
        {
            var reader = (OleDbDataReader)Reader;
            var result = new List<M_USER>();
            if (reader.FieldCount == 0)
            {
                throw new Exception("データベースがロードされていません！");
            }

            // DataReaderを読み込んでEntityに変換する
            while (reader.Read())
            {
                result.Add(new M_USER()
                {
                    USER_CODE = Reader["USER_CODE"].ToString(),
                    USER_NAME = Reader["USER_NAME"].ToString(),
                    DIVISION_CODE = Reader["DIVISION_CODE"].ToString(),
                    POSITION_NAME = Reader["POSITION_NAME"].ToString(),
                    E_MAILL_ADDRESS = Reader["E_MAILL_ADDRESS"].ToString(),
                    POST_NO = Reader["POST_NO"].ToString(),
                    ADDRESS_NAME = Reader["ADDRESS_NAME"].ToString(),
                    TEL = Reader["TEL"].ToString()
                });
            }
            return result;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region プロパティ
        public string TableName { get; set; }
        public DbConnection Connection { get; set; }
        public DbCommand Command { get; set; }
        public DbDataReader Reader { get; set; }
        #endregion

        #region 非公開メンバー
        #endregion

    }
}
