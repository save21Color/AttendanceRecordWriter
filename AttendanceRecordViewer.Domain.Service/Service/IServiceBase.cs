using AttendanceRecordWriter.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceRecordWriter.Domain.Service
{
    /// <summary>
    /// Domain Service層のサービスクラスインターフェースです
    /// </summary>
    public interface IServiceBase
    {
        /// <summary>
        /// サービスを実行します。
        /// </summary>
        /// <param name="table">Infstracture層のリポジトリクラス</param>
        /// <returns></returns>
        object Execute(IRepository table, Dictionary<string, object> parameter);

        /// <summary>
        /// 実行結果です
        /// </summary>
        object Result { get; set; }
    }
}
