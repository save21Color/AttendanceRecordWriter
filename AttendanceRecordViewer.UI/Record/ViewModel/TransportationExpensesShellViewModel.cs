using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AttendanceRecordWriter.UI.ViewModels
{
	public class TransportationExpensesShellViewModel : BindableBase
	{
        public TransportationExpensesShellViewModel()
        {
            TestText = "TrasportationExpenses Navigation!";
        }

        private string testText;
        public string TestText
        {
            get { return testText; }
            set { SetProperty(ref testText, value); }
        }
    }
}
