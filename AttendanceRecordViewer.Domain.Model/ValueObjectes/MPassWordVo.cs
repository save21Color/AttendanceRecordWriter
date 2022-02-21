using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecordWriter.Domain.Model.Entity;

namespace AttendanceRecordWriter.Domain.Model.ValueObjectes
{
    public class MPassWordVo
    {

        #region コンストラクタ
        public MPassWordVo()
        {

        }

        public MPassWordVo(M_PASSWORD value)
        {
            UserCode = value.USER_CODE;
            Password = value.PASSWORD;
            UserLevel = value.USER_LEVEL;
        }
        #endregion

        #region プロパティ

        public string UserCode { get; set; }

        public string Password { get; set; }

        public string UserLevel { get; set; }

        #endregion

        #region メソッド

        public MUserVo Clone()
        {
            return (MUserVo)MemberwiseClone();
        }

        #endregion
    }
}
