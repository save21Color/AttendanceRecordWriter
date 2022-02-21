using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecordWriter.Domain.Model.Entity;

namespace AttendanceRecordWriter.Domain.Model.ValueObjectes
{
    public  class TWorkTimeVo
    {
        #region コンストラクタ
        public TWorkTimeVo(T_WORKTIME value)
        {
            UserCode = value.USER_CODE;
            No = value.NO;
            Date = value.DATE;
            Hour = value.HOUR;
        }

        public TWorkTimeVo()
        {

        }
        #endregion

        #region プロパティ
        public string UserCode { get; set; }

        public string No { get; set; }

        public string Date { get; set; }

        public string Hour { get; set; }
        #endregion

        #region メソッド
        public TWorkTimeVo Clone()
        {
            return (TWorkTimeVo)MemberwiseClone();
        }
        #endregion
    }
}
