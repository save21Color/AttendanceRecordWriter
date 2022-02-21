using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceRecordWriter.Domain.Model.Entity
{
    public class M_BUSINESS
    {
        public M_BUSINESS()
        {
        }

        public string NO
        {
            get { return _NO; }
            set { _NO = value; }
        }

        public string BUSINESS_CODE
        {
            get { return _BUSINESS_CODE; }
            set { _BUSINESS_CODE = value; }
        }

        public string BUSINESS_USER_CODE
        {
            get { return _BUSINESS_USER_CODE; }
            set { _BUSINESS_USER_CODE = value; }
        }

        public string PROJECT_NAME
        {
            get { return _PROJECT_NAME; }
            set { _PROJECT_NAME = value; }
        }


        #region 非公開メンバー
        private string _NO;
        private string _BUSINESS_CODE;
        private string _BUSINESS_USER_CODE;
        private string _PROJECT_NAME;

        #endregion

    }
}
