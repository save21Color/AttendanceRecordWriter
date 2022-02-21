using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceRecordWriter.Domain.Model.Entity
{
    public class M_HOLIDAY
    {
        public M_HOLIDAY()
        {
            DATE = string.Empty;
            DAY_1 = string.Empty;
            HOLIDAY_FLG_1 = string.Empty;
            DAY_2 = string.Empty;
            HOLIDAY_FLG_2 = string.Empty;
            DAY_3 = string.Empty;
            HOLIDAY_FLG_3 = string.Empty;
            DAY_4 = string.Empty;
            HOLIDAY_FLG_4 = string.Empty;
            DAY_5 = string.Empty;
            HOLIDAY_FLG_5 = string.Empty;
            DAY_6 = string.Empty;
            HOLIDAY_FLG_6 = string.Empty;
            DAY_7 = string.Empty;
            HOLIDAY_FLG_7 = string.Empty;
            DAY_8 = string.Empty;
            HOLIDAY_FLG_8 = string.Empty;
            DAY_9 = string.Empty;
            HOLIDAY_FLG_9 = string.Empty;
            DAY_10 = string.Empty;
            HOLIDAY_FLG_10 = string.Empty;
        }


        public string DATE
        {
            get { return _DATE; }
            set { _DATE = value; }
        }

        public string DAY_1
        {
            get { return _DAY_1; }
            set { _DAY_1 = value; }
        }

        public string HOLIDAY_FLG_1
        {
            get { return _HOLIDAY_FLG_1; }
            set { _HOLIDAY_FLG_1 = value; }
        }

        public string DAY_2
        {
            get { return _DAY_2; }
            set { _DAY_2 = value; }
        }

        public string HOLIDAY_FLG_2
        {
            get { return _HOLIDAY_FLG_2; }
            set { _HOLIDAY_FLG_2 = value; }
        }

        public string DAY_3
        {
            get { return _DAY_3; }
            set { _DAY_3 = value; }
        }

        public string HOLIDAY_FLG_3
        {
            get { return holiday_Flg_3; }
            set { holiday_Flg_3 = value; }
        }

        public string DAY_4
        {
            get { return _DAY_4; }
            set { _DAY_4 = value; }
        }

        public string HOLIDAY_FLG_4
        {
            get { return holiday_Flg_4; }
            set { holiday_Flg_4 = value; }
        }

        public string DAY_5
        {
            get { return _DAY_5; }
            set { _DAY_5 = value; }
        }

        public string HOLIDAY_FLG_5
        {
            get { return holiday_Flg_5; }
            set { holiday_Flg_5 = value; }
        }

        public string DAY_6
        {
            get { return _DAY_6; }
            set { _DAY_6 = value; }
        }

        public string HOLIDAY_FLG_6
        {
            get { return holiday_Flg_6; }
            set { holiday_Flg_6 = value; }
        }


        public string DAY_7
        {
            get { return _DAY_7; }
            set { _DAY_7 = value; }
        }

        public string HOLIDAY_FLG_7
        {
            get { return holiday_Flg_7; }
            set { holiday_Flg_7 = value; }
        }

        public string DAY_8
        {
            get { return _DAY_8; }
            set { _DAY_8 = value; }
        }

        public string HOLIDAY_FLG_8
        {
            get { return holiday_Flg_8; }
            set { holiday_Flg_8 = value; }
        }

        public string HOLIDAY_FLG_9
        {
            get { return holiday_Flg_9; }
            set { holiday_Flg_9 = value; }
        }

        public string DAY_9
        {
            get { return _DAY_9; }
            set { _DAY_9 = value; }
        }

        public string HOLIDAY_FLG_10
        {
            get { return holiday_Flg_10; }
            set { holiday_Flg_10 = value; }
        }

        public string DAY_10
        {
            get { return _DAY_10; }
            set { _DAY_10 = value; }
        }

        #region 非公開メンバー
        private string _DATE;
        private string _DAY_1;
        private string _HOLIDAY_FLG_1;
        private string _DAY_2;
        private string _HOLIDAY_FLG_2;
        private string _DAY_3;
        private string holiday_Flg_3;
        private string _DAY_4;
        private string holiday_Flg_4;
        private string _DAY_5;
        private string holiday_Flg_5;
        private string _DAY_6;
        private string holiday_Flg_6;
        private string _DAY_7;
        private string holiday_Flg_7;
        private string _DAY_8;
        private string holiday_Flg_8;
        private string _DAY_9;
        private string holiday_Flg_9;
        private string _DAY_10;
        private string holiday_Flg_10;

        #endregion

    }
}
