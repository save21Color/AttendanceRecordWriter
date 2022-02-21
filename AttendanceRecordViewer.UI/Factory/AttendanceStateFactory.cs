using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecordWriter.UI.Common;
using AttendanceRecordWriter.UI.Extension;

namespace AttendanceRecordWriter.UI.Factory
{
    public static class AttendanceStateFactory 
    {
        public static IEnumerable<string> Create()
        {
            return Enum.GetValues(typeof(Attendance)).OfType<Attendance>().Select(_ => _.ToState());   
        }
    }
}
