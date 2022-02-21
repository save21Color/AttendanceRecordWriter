using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecordWriter.Domain.Model;
using AttendanceRecordWriter.Domain.Service.Interface;
using System.Transactions;
using System.Data.Common;
using AttendanceRecordWriter.Domain.Model.Entity;

namespace AttendanceRecordWriter.Domain.Service
{
    /// <summary>
    /// DBの全件取得サービスクラスです。
    /// </summary>
    public class FindAllService: IServiceBase
    {
        public FindAllService()
        {

        }

        public object Result { get; set; }

        public object Execute(IRepository table, Dictionary<string, object> parameter)
        {
            table.Connect();

            using (var tran = table.Connection.BeginTransaction())
            {
                table.Command.Transaction = tran;

                Result = table.FindAll();

                tran.Commit();
            }

            table.DisConnect();

            return Result;
        }
    }
}
