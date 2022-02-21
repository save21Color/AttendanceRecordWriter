using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecordWriter.Domain.Model.Entity;

namespace AttendanceRecordWriter.Domain.Model.ValueObjectes
{
    public class TWorkPlanVo
    {
        #region コンストラクタ

        public TWorkPlanVo()
        {
        }

        public TWorkPlanVo(T_WORKPLAN value)
        {
            UserCode = value.USER_CODE;
            Date = value.DATE;
            HolidayFlag = value.HOLIDAY_FLAG;
            PlanSecTime = value.PLAN_SEC_TIME;
            PlanHourTime = value.PLAN_HOUR_TIME;
            WorkingSecTime = value.WORKING_SEC_TIME;
            Work_Flag = value.WORK_FLG;
            PlaceNo = value.PLACE_NO;
            WorkingSec = value.WORKING_SEC;
            WorkingHour = value.WORKING_HOUR;
            Kinmu_Time = value.KINMU_TIME;
            Work_Flag = value.WORK_FLAG;
            Summary = value.SUMMARY;
        }
        #endregion

        #region プロパティ
        public string UserCode { get; set; }
        public string Date { get; set; }
        public string HolidayFlag { get; set; }
        public string PlanSecTime { get; set; }
        public string PlanHourTime { get; set; }
        public string WorkingSecTime { get; set; }
        public string Work_Flag { get; set; }
        public string PlaceNo { get; set; }
        public string WorkingSec { get; set; }
        public string WorkingHour { get; set; }
        public string Kinmu_Time { get; set; }
        public string Summary { get; set; }
        #endregion

        #region メソッド
        public TWorkPlanVo Clone()
        {
            return (TWorkPlanVo)MemberwiseClone();
        }
        #endregion
    }
}
