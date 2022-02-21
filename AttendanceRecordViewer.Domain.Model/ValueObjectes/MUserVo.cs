using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecordWriter.Domain.Model.Entity;

namespace AttendanceRecordWriter.Domain.Model.ValueObjectes
{
    public class MUserVo
    {
        #region コンストラクタ
        public MUserVo()
        {

        }

        // コピーコンストラクタ
        public MUserVo(M_USER value)
        {
            UserCode = value.USER_CODE;
            UserName = value.USER_NAME;
            DivisionCode = value.DIVISION_CODE;
            PositionName = value.POSITION_NAME;
            EmaillAddress = value.E_MAILL_ADDRESS;
            PostNo = value.POST_NO;
            AddressName = value.ADDRESS_NAME;
            Tel = value.TEL;
        }
        #endregion

        #region プロパティ
        public string UserCode { get; set; }

        public string UserName { get; set; }

        public string BumonCode { get; set; }

        public string DivisionCode { get; set; }

        public string PositionName { get; set; }

        public string EmaillAddress { get; set; }

        public string PostNo { get; set; }

        public string AddressName { get; set; }

        public string Tel { get; set; }
        #endregion

        #region メソッド
        public MUserVo Clone()
        {
            return (MUserVo)MemberwiseClone();
        }
        #endregion

    }
}
