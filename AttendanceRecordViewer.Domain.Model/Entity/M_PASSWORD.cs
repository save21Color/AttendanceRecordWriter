using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceRecordWriter.Domain.Model.Entity
{
    public class M_PASSWORD
    {
        public M_PASSWORD()
        {
            USER_CODE = string.Empty;
            PASSWORD = string.Empty;
            USER_LEVEL = string.Empty;
        }

        
        public string USER_CODE
        {
            get { return _USER_CODE; }
            set { _USER_CODE = value; }
        }

        
        public string PASSWORD
        {
            get { return _PASSWORD; }
            set { _PASSWORD = value; }
        }

        
        public string USER_LEVEL
        {
            get { return _USER_LEVEL; }
            set { _USER_LEVEL = value; }
        }

        #region 非公開メンバー
        private string _USER_CODE;
        private string _PASSWORD;
        private string _USER_LEVEL;
        #endregion

    }
}
