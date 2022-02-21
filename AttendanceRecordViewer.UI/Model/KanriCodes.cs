using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AttendanceRecordWriter.UI.Model
{
    public class KanriCodes : DependencyObject
    {
        public string KanriCode { get; set; }
        public string KanriName  { get; set; }

        public bool IsChecked { get; set; }
    }
}
