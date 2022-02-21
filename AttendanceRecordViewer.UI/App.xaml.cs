using AttendanceRecordWriter.UI.Views;
using Prism.Ioc;
using Prism.Modularity;
using AttendanceRecordWriter.Infstructure.Repository;
using AttendanceRecordWriter.Domain.Service;
using MahApps.Metro.Controls;
using AttendanceRecordWriter.Domain.Service.Interface;
using AttendanceRecordWriter.Domain.Model.Entity;
using System.Windows;
using Prism.Unity;
using Unity;
using System.Collections.Generic;
using Unity.Registration;

namespace AttendanceRecordWriter.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainShell>();
        }

        /// <summary>
        /// Domain層のサービスクラス、Infstracture層のリポジトリクラスを登録します
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var container = containerRegistry.GetContainer();

            // Domain Service層
            container.RegisterInstance<IServiceBase>("FindAll", new FindAllService());
            container.RegisterInstance<IServiceBase>("FindBySearchCondition", new FindConditionService());

            // Infstracture層
            container.RegisterInstance<IRepository>("M_HOLIDAY", new M_HOLIDAYRepository());
            container.RegisterInstance<IRepository>("M_USER", new M_USERRepository());
            container.RegisterInstance<IRepository>("M_PASSWORD", new M_PASSWORDRepository());
            container.RegisterInstance<IRepository>("T_WORKTIME", new T_WORKTIMERepository());
            container.RegisterInstance<IRepository>("T_WORKPLAN", new T_WORKPLANRepository());
        }

        /// <summary>
        /// モジュールカタログにモジュールを登録し、読み込みます
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            var catalog = (ModuleCatalog)moduleCatalog;
            catalog.AddModule<LoginModule>();
            catalog.AddModule<RecordModule>();
        }
    }
}
