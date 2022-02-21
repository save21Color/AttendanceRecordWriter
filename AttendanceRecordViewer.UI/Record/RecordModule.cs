using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Regions;
using Prism.Ioc;
using Prism.Modularity;
using AttendanceRecordWriter.UI.Views;
using Prism.Unity;
using Unity;

namespace AttendanceRecordWriter.UI
{
    public class RecordModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AttendanceRecordShell>();
            containerRegistry.RegisterForNavigation<TemporaryPaymentShell>();
            containerRegistry.RegisterForNavigation<TransportationExpensesShell>();
        }
    }
}
