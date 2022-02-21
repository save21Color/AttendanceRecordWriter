using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecordWriter.Domain.Model.Entity;

namespace AttendanceRecordWriter.Domain.Model.ValueObjectes
{
    public class MBusinessVo
    {
        #region コンストラクタ
        public MBusinessVo()
        {

        }

        // コピーコンストラクタ
        public MBusinessVo(M_BUSINESS value)
        {
            No = value.NO;
            BusinessCode = value.BUSINESS_CODE;
            BusinessUserCode = value.BUSINESS_USER_CODE;
            ProjectName = value.PROJECT_NAME;
        }
        #endregion

        #region プロパティ
        public string No { get; set; }

        public string BusinessCode { get; set; }

        public string BusinessUserCode { get; set; }

        public string ProjectName { get; set; }
        #endregion

        #region メソッド
        public MBusinessVo Clone()
        {
            return (MBusinessVo)MemberwiseClone();
        }
        #endregion

    }
}
