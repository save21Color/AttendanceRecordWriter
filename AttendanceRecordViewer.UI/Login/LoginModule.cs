using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Regions;
using Prism.Ioc;
using Prism.Modularity;
using AttendanceRecordWriter.UI.Views;
using Prism.Unity;
using Unity;

namespace AttendanceRecordWriter.UI
{
    public class LoginModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionMan = containerProvider.Resolve<IRegionManager>();
            regionMan.RegisterViewWithRegion("MainRegion", typeof(LoginShell));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
