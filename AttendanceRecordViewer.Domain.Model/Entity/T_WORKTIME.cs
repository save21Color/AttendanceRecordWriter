using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceRecordWriter.Domain.Model.Entity
{          
    public class T_WORKTIME
    {
        public T_WORKTIME()
        {
            USER_CODE = string.Empty;
            NO = string.Empty;
            DATE = string.Empty;
            HOUR = string.Empty;
        }


        public string USER_CODE
        {
            get { return _USER_CODE; }
            set { _USER_CODE = value; }
        }

        public string NO
        {
            get { return _NO; }
            set { _NO = value; }
        }

        public string DATE
        {
            get { return _DATE; }
            set { _DATE = value; }
        }

        public string HOUR
        {
            get { return _HOUR; }
            set { _HOUR = value; }
        }

        #region 非公開メンバー
        private string _USER_CODE;
        private string _NO;
        private string _DATE;
        private string _HOUR;
        #endregion

    }
}
