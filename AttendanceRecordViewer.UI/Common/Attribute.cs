using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceRecordWriter.UI.Common
{
        /// <summary>
        /// 勤務状態
        /// </summary>
        public  enum Attendance
        {
            /// <summary>
            /// 通常勤務
            /// </summary>
            Working,

            /// <summary>
            /// 休日出勤
            /// </summary>
            HolidayWork,

            /// <summary>
            /// 代理休暇
            /// </summary>
            CompensationVacation,

            /// <summary>
            /// 夏季休暇
            /// </summary>
            SummerVacation,

            /// <summary>
            /// 有給休暇
            /// </summary>
            PaidVacation,

            /// <summary>
            /// 欠勤
            /// </summary>
            Absence,

            /// <summary>
            /// 早退
            /// </summary>
            LeaveWork,

            /// <summary>
            /// 遅刻
            /// </summary>
            DelayWork
        }

    
}
