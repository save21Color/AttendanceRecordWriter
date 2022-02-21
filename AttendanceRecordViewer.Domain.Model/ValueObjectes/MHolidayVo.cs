using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecordWriter.Domain.Model.Entity;

namespace AttendanceRecordWriter.Domain.Model.ValueObjectes
{
    public class MHolidayVo
    {
        public MHolidayVo()
        {

        }

        public MHolidayVo(M_HOLIDAY value)
        {
            Date = value.DATE;
            Day1 = value.DAY_1;
            HOLIDAY_FLG_1 = value.HOLIDAY_FLG_1;
            Day2 = value.DAY_2;
            HOLIDAY_FLG_2 = value.HOLIDAY_FLG_2;
            Day3 = value.DAY_3;
            HOLIDAY_FLG_3 = value.HOLIDAY_FLG_3;
            Day4 = value.DAY_4;
            HOLIDAY_FLG_4 = value.HOLIDAY_FLG_4;
            Day5 = value.DAY_5;
            HOLIDAY_FLG_5 = value.HOLIDAY_FLG_5;
            Day6 = value.DAY_6;
            HOLIDAY_FLG_6 = value.HOLIDAY_FLG_6;
            Day7 = value.DAY_7;
            HOLIDAY_FLG_7 = value.HOLIDAY_FLG_7;
            Day8 = value.DAY_8;
            HOLIDAY_FLG_8 = value.HOLIDAY_FLG_8;
            Day9 = value.DAY_9;
            HOLIDAY_FLG_9 = value.HOLIDAY_FLG_9;
            Day10 = value.DAY_10;
            HOLIDAY_FLG_10 = value.HOLIDAY_FLG_10;
        }

        public string Date { get; set; }
        public string Day1 { get; set; }
        public string HOLIDAY_FLG_1 { get; set; }
        public string Day2 { get; set; }
        public string HOLIDAY_FLG_2 { get; set; }
        public string Day3 { get; set; }
        public string HOLIDAY_FLG_3 { get; set; }
        public string Day4 { get; set; }
        public string HOLIDAY_FLG_4 { get; set; }
        public string Day5 { get; set; }
        public string HOLIDAY_FLG_5 { get; set; }
        public string Day6 { get; set; }
        public string HOLIDAY_FLG_6 { get; set; }
        public string Day7 { get; set; }
        public string HOLIDAY_FLG_7 { get; set; }
        public string Day8 { get; set; }
        public string HOLIDAY_FLG_8 { get; set; }
        public string Day9 { get; set; }
        public string HOLIDAY_FLG_9 { get; set; }
        public string Day10 { get; set; }
        public string HOLIDAY_FLG_10 { get; set; }


        #region メソッド

        public M_HOLIDAY Clone()
        {
            return (M_HOLIDAY)MemberwiseClone();
        }

        #endregion

    }
}
