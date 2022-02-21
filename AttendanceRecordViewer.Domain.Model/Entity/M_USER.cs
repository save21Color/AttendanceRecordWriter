using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceRecordWriter.Domain.Model.Entity
{
    public class M_USER 
    {
        public M_USER()
        {
            USER_CODE = string.Empty;
            USER_NAME = string.Empty;
            DIVISION_CODE = string.Empty;
            POSITION_NAME = string.Empty;
            E_MAILL_ADDRESS = string.Empty;
            POST_NO = string.Empty;
            ADDRESS_NAME = string.Empty;
            TEL = string.Empty;
        }

        public string USER_CODE
        {
            get { return _USER_CODE; }
            set { _USER_CODE = value; }
        }

        public string USER_NAME
        {
            get { return _USER_NAME; }
            set { _USER_NAME = value; }
        }

        public string DIVISION_CODE
        {
            get { return _DIVISION_CODE; }
            set { _DIVISION_CODE = value; }
        }

        public string POSITION_NAME
        {
            get { return _POSITION_NAME; }
            set { _POSITION_NAME = value; }
        }

        public string E_MAILL_ADDRESS
        {
            get { return _E_MAILL_ADDRESS; }
            set { _E_MAILL_ADDRESS = value; }
        }


        public string POST_NO
        {
            get { return _POST_NO; }
            set { _POST_NO = value; }
        }


        public string ADDRESS_NAME
        {
            get { return _ADDRESS_NAME; }
            set { _ADDRESS_NAME = value; }
        }

        public string TEL
        {
            get { return _TEL; }
            set { _TEL = value; }
        }

        #region 非公開メンバー
        private string _USER_CODE;
        private string _USER_NAME;
        private string _BU_CD;
        private string _DIVISION_CODE;
        private string _POSITION_NAME;
        private string _E_MAILL_ADDRESS;
        private string _POST_NO;
        private string _ADDRESS_NAME;
        private string _TEL;
        #endregion

    }
}
