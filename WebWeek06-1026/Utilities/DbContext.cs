using Microsoft.Data.SqlClient;
using System.Data;

namespace WebWeek06_1026.Utilities
{
    public class DbContext
    {
        // 儲存 IConfiguration 介面實例
        private readonly IConfiguration _configuration;

        // 儲存資料庫的連接字串
        private readonly string _connectionString;

        // 接收 IConfiguration 類型的參數 configuration，用於初始化設定檔配置
        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("CalendarContext"); // 使用 _configuration 讀取名稱為 CalendarContext 的連接字串
        }

        // 回傳 IDbConnection 介面實例
        // 使用 _connectionString 建立一個新的 SqlConnection 實例並回傳，用來與 SQL Server 資料庫連線
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
