using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceRecordWriter.Domain.Model.Entity
{
    public class T_WORKPLAN
    {
        public T_WORKPLAN()
        {
            USER_CODE = string.Empty;
            DATE = string.Empty;
            HOLIDAY_FLAG = string.Empty;
            PLAN_SEC_TIME = string.Empty;
            PLAN_HOUR_TIME = string.Empty;
            WORKING_SEC_TIME = string.Empty;
            WORK_FLG = string.Empty;
            PLACE_NO = string.Empty;
            WORKING_SEC = string.Empty;
            WORKING_HOUR = string.Empty;
            KINMU_TIME = string.Empty;
            WORK_FLAG = string.Empty;
            SUMMARY = string.Empty;
        }

        public string USER_CODE
        {
            get { return _USER_CODE; }
            set { _USER_CODE = value; }
        }

        public string DATE
        {
            get { return _DATE; }
            set { _DATE = value; }
        }

        public string HOLIDAY_FLAG
        {
            get { return holiday_FLG; }
            set { holiday_FLG = value; }
        }

        public string PLAN_SEC_TIME
        {
            get { return _PLAN_SEC_TIME; }
            set { _PLAN_SEC_TIME = value; }
        }

        public string PLAN_HOUR_TIME
        {
            get { return _PLAN_HOUR_TIME; }
            set { _PLAN_HOUR_TIME = value; }
        }

        public string WORKING_SEC_TIME
        {
            get { return _WORKING_SEC_TIME; }
            set { _WORKING_SEC_TIME = value; }
        }

        public string WORK_FLG
        {
            get { return _WORK_FLG; }
            set { _WORK_FLG = value; }
        }

        public string PLACE_NO
        {
            get { return _PLACE_NO; }
            set { _PLACE_NO = value; }
        }

        public string WORKING_SEC
        {
            get { return _WORKING_SEC; }
            set { _WORKING_SEC = value; }
        }

        public string WORKING_HOUR
        {
            get { return _WORKING_HOUR; }
            set { _WORKING_HOUR = value; }
        }

        public string KINMU_TIME
        {
            get { return _KINMU_TIME; }
            set { _KINMU_TIME = value; }
        }

        public string WORK_FLAG
        {
            get { return _WORK_FLAG; }
            set { _WORK_FLAG = value; }
        }

        public string SUMMARY
        {
            get { return _SUMMARY; }
            set { _SUMMARY = value; }
        }

        #region 非公開メンバー
        private string _USER_CODE;
        private string _DATE;
        private string holiday_FLG;
        private string _PLAN_SEC_TIME;
        private string _PLAN_HOUR_TIME;
        private string _WORKING_SEC_TIME;
        private string _WORK_FLG;
        private string _PLACE_NO;
        private string _WORKING_SEC;
        private string _WORKING_HOUR;
        private string _KINMU_TIME;
        private string _WORK_FLAG;
        private string _SUMMARY;
        #endregion

    }
}
