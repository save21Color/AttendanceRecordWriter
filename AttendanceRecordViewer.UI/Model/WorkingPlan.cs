using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecordWriter.Domain.Model.ValueObjectes;
using AttendanceRecordWriter.UI.Common;

namespace AttendanceRecordWriter.UI.Model
{
    public class WorkingPlan : DependencyObject
    {
        public WorkingPlan()
        {

        }

        /// <summary>
        /// 日数
        /// </summary>
        public int Day
        {
            get { return (int)GetValue(DayProperty); }
            set { SetValue(DayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Day.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DayProperty =
            DependencyProperty.Register("Day", typeof(int), typeof(WorkingPlan), new PropertyMetadata(0));


        /// <summary>
        /// 曜日
        /// </summary>
        public string DayOfWeek
        {
            get { return (string)GetValue(DayOfWeekProperty); }
            set { SetValue(DayOfWeekProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DayOfWeek.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DayOfWeekProperty =
            DependencyProperty.Register("DayOfWeek", typeof(string), typeof(WorkingPlan), new PropertyMetadata(""));


        /// <summary>
        /// 休日判定
        /// </summary>
        public bool IsHoliday
        {
            get { return (bool)GetValue(IsHolidayProperty); }
            set { SetValue(IsHolidayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsHoliday.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsHolidayProperty =
            DependencyProperty.Register("IsHoliday", typeof(bool), typeof(WorkingPlan), new PropertyMetadata(false));


        /// <summary>
        /// 場所
        /// </summary>
        public string WorkPlaceCount
        {
            get { return (string)GetValue(WorkPlaceCountProperty); }
            set { SetValue(WorkPlaceCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WorkPlaceCountProperty =
            DependencyProperty.Register("MyProperty", typeof(string), typeof(WorkingPlan), new PropertyMetadata(""));


        /// <summary>
        /// 業務開始日時
        /// </summary>
        public string WorkTimeStart
        {
            get { return (string)GetValue(WorkTimeStartProperty); }
            set { SetValue(WorkTimeStartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DateTime WorkTimeStart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WorkTimeStartProperty =
            DependencyProperty.Register("WorkTimeStart", typeof(string), typeof(WorkingPlan), new PropertyMetadata(""));



        public string WorkTimeEnd
        {
            get { return (string)GetValue(WorkTimeEndProperty); }
            set { SetValue(WorkTimeEndProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WorkingTimeEnd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WorkTimeEndProperty =
            DependencyProperty.Register("WorkingTimeEnd", typeof(string), typeof(WorkingPlan), new PropertyMetadata(""));


        public IEnumerable<AttendanceWork> Workings
        {
            get { return (IEnumerable<AttendanceWork>)GetValue(WorkingTimeProperty); }
            set { SetValue(WorkingTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WorkingTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WorkingTimeProperty =
            DependencyProperty.Register("WorkingTime", typeof(IEnumerable<AttendanceWork>), typeof(WorkingPlan), new PropertyMetadata(null));

        /// <summary>
        /// 業務状態
        /// </summary>
        public Attendance WorkingState
        {
            get { return (Attendance)GetValue(WorkingStateProperty); }
            set { SetValue(WorkingStateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WorkingStateProperty =
            DependencyProperty.Register("WorkingState", typeof(Attendance), typeof(WorkingPlan), new PropertyMetadata(Attendance.Working));




        public string Summarry
        {
            get { return (string)GetValue(SummarryProperty); }
            set { SetValue(SummarryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Tekiyou.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SummarryProperty =
            DependencyProperty.Register("Summarry", typeof(string), typeof(WorkingPlan), new PropertyMetadata(""));



    }

    public class AttendanceWork : DependencyObject
    {

        public AttendanceWork()
        {
        }

        public string KanriName
        {
            get { return (string)GetValue(KanriNameProperty); }
            set { SetValue(KanriNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for KanriName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KanriNameProperty =
            DependencyProperty.Register("KanriName", typeof(string), typeof(AttendanceWork), new PropertyMetadata(""));



        public string KanriCode
        {
            get { return (string)GetValue(KanriCodeProperty); }
            set { SetValue(KanriCodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for KanriCode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KanriCodeProperty =
            DependencyProperty.Register("KanriCode", typeof(string), typeof(AttendanceWork), new PropertyMetadata(""));



        public float WorkingTime
        {
            get { return (float)GetValue(WorkingTimeProperty); }
            set { SetValue(WorkingTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WorkingTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WorkingTimeProperty =
            DependencyProperty.Register("WorkingTime", typeof(float), typeof(AttendanceWork), new PropertyMetadata(0.0F));






    }


}
