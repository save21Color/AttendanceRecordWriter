using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecordWriter.Domain.Service;
using AttendanceRecordWriter.Domain.Service.Interface;
using Prism.Unity;
using Unity;
using Prism.Regions;

namespace AttendanceRecordWriter.Application.Service
{
    /// <summary>
    /// DIコンテナに格納されているDomain層のサービスを呼び出すApplicationServiceクラスです
    /// </summary>
    public  class ApplicationService
    {
        /// <summary>
        /// DIコンテナ
        /// </summary>
        private IUnityContainer container;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container"></param>
        public ApplicationService(IUnityContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// DIコンテナからDomain層のサービスクラスを抽出、実行します
        /// </summary>
        /// <param name="serviceName">実行するサービスクラス名</param>
        /// <param name="tableName">実行対象のテーブル名</param>
        /// <returns></returns>
        public object RepositoryServiceExecute(string serviceName, string tableName)
        {
            try
            {
                var service = container.Resolve<IServiceBase>(serviceName);
                return service.Execute(container.Resolve<IRepository>(tableName) , null);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// DIコンテナからDomain層のサービスクラスを抽出、実行します
        /// </summary>
        /// <param name="serviceName">実行するサービスクラス名</param>
        /// <param name="tableName">実行対象のテーブル名</param>
        /// <param name="parameter">パラメータ</param>
        /// <returns></returns>
        public object RepositoryServiceExecute(string serviceName, string tableName, Dictionary<string, object> parameter)
        {
            try
            {
                var service = container.Resolve<IServiceBase>(serviceName);
                return service.Execute(container.Resolve<IRepository>(tableName), parameter);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }



    }
}
