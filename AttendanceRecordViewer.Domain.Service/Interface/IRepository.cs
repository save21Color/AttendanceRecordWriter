using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.Common;
using System.Data;

namespace AttendanceRecordWriter.Domain.Service.Interface
{
    /// <summary>
    /// リポジトリクラスのインターフェースです
    /// </summary>
    public interface IRepository
    {

        /// <summary>
        /// DBに接続します。
        /// </summary>
        void Connect();

        /// <summary>
        /// DB読み込みに使用したDataReaderを破棄し、DBから切断します。
        /// </summary>
        void DisConnect();

        /// <summary>
        /// 全件取得を行います
        /// </summary>
        /// <returns></returns>
        object FindAll();

        /// <summary>
        /// 検索条件を設定してレコードの取得を行います。
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        object FindBySearchCondition(Dictionary<string, object> condition);

        /// <summary>
        /// 特定のレコードを更新します。
        /// </summary>
        void Update();

        /// <summary>
        /// テーブル名です
        /// </summary>
        string TableName { get; set; }

        /// <summary>
        /// 接続情報です。
        /// </summary>
        DbConnection Connection { get; set; }

        /// <summary>
        /// SQLコマンドです。
        /// </summary>
        DbCommand Command { get; set; }

        /// <summary>
        /// 読み込みに使用するデータリーダーです。
        /// </summary>
        DbDataReader Reader { get; set; }


        
    }
}
