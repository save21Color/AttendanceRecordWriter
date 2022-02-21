using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecordWriter.UI.Model;
using AttendanceRecordWriter.Domain.Model.ValueObjectes;
using AttendanceRecordWriter.UI.Common;

namespace AttendanceRecordWriter.UI.Extension
{
    public static class Extensions
    {
        public static WorkingPlan PlanCreate(this TWorkPlanVo workPlan)
        {
            switch (workPlan.HolidayFlag)
            {
                // 平日
                case "00":
                    var dateWorkday = DateTime.ParseExact(workPlan.Date, "yyyyMMdd", null);
                    return new WorkingPlan()
                    {
                        Day = dateWorkday.Day,
                        DayOfWeek = dateWorkday.ToDayOfWeek(),
                        IsHoliday = false,
                        WorkPlaceCount = workPlan.PlaceNo,
                        WorkTimeStart = workPlan.PlanSecTime,
                        WorkTimeEnd = workPlan.PlanHourTime,
                        WorkingState = Attendance.Working
                       
                    };

                // 休日
                case "01":
                    var dateHoliday = DateTime.ParseExact(workPlan.Date, "yyyyMMdd", null);
                    return new WorkingPlan()
                    {
                        Day = dateHoliday.Day,
                        DayOfWeek = dateHoliday.ToDayOfWeek(),
                        IsHoliday = true,
                        WorkPlaceCount = workPlan.PlaceNo,
                        WorkTimeStart = "",
                        WorkTimeEnd = "",
                        WorkingState = Attendance.Working,
                        
                    };

                // その他
                case "99":
                    return null;
            }
            return null;
        }

        public static WorkingPlan WorkCreate(this TWorkPlanVo workPlan)
        {
            switch (workPlan.HolidayFlag)
            {
                case "00":
                    var dateWorkday = DateTime.ParseExact(workPlan.Date, "yyyyMMdd", null);
                    return new WorkingPlan()
                    {
                        Day = dateWorkday.Day,
                        DayOfWeek = dateWorkday.ToDayOfWeek(),
                        IsHoliday = false,
                        WorkPlaceCount = workPlan.PlaceNo,
                        WorkTimeStart = workPlan.WorkingSec,
                        WorkTimeEnd = workPlan.WorkingHour,
                        WorkingState = Attendance.Working,
                        Summarry = workPlan.Summary
                    };

                case "01":
                    var dateHoliday = DateTime.ParseExact(workPlan.Date, "yyyyMMdd", null);
                    return new WorkingPlan()
                    {
                        Day = dateHoliday.Day,
                        DayOfWeek = dateHoliday.ToDayOfWeek(),
                        IsHoliday = true,
                        WorkPlaceCount = workPlan.PlaceNo,
                        WorkTimeStart = "",
                        WorkTimeEnd = "",
                        WorkingState = Attendance.Working,
                        Summarry = workPlan.Summary
                    };
            }
            return null;
        }

        public static string ToDayOfWeek(this DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "日";
                case DayOfWeek.Monday:
                    return "月";
                case DayOfWeek.Tuesday:
                    return "火";
                case DayOfWeek.Wednesday:
                    return "水";
                case DayOfWeek.Thursday:
                    return "木";
                case DayOfWeek.Friday:
                    return "金";
                case DayOfWeek.Saturday:
                    return "土";
                
            }
            return "";
        }

        public static string ToState(this Attendance state)
        {
            switch (state)
            {
                case Attendance.Working:
                    return string.Empty;

                case Attendance.HolidayWork:
                    return "休出";

                case Attendance.CompensationVacation:
                    return "代休";

                case Attendance.SummerVacation:
                    return "夏休";

                case Attendance.PaidVacation:
                    return "有給";

                case Attendance.Absence:
                    return "欠勤";

                case Attendance.LeaveWork:
                    return "早退";

                case Attendance.DelayWork:
                    return "遅刻";
            }
            return string.Empty;
        }
    }
}
