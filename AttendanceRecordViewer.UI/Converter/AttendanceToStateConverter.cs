using System.Collections.Generic;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using AttendanceRecordWriter.UI.Model;
using AttendanceRecordWriter.UI.Common;
using AttendanceRecordWriter.UI.Extension;

namespace AttendanceRecordWriter.UI.Converter
{
    // ToDo 工事中
    public class AttendanceToStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Attendance)value).ToState();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "休出":
                    return Attendance.HolidayWork;

                case "代休":
                    return Attendance.CompensationVacation;

                case "夏休":
                    return Attendance.SummerVacation;

                case "有給":
                    return Attendance.PaidVacation;

                case "欠勤":
                    return Attendance.Absence;

                case "早退":
                    return Attendance.LeaveWork;

                case "遅刻":
                    return Attendance.DelayWork;
            }
            return "";
        }
    }
}
