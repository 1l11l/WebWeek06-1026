// 繼承並實作存取Member的Interface
using WebWeek06_1026.Interface;
using WebWeek06_1026.Models;
using Dapper;
using WebWeek06_1026.Dtos;
using WebWeek06_1026.Utilities;

namespace WebWeek06_1026.Repositories
{

    // MemberRepository 類別實作了 IMember 介面，繼承了 MemberRepository 介面的所有方法
    public class MemberRepository : IMember
    {
        // 與資料庫建立連線
        private readonly DbContext _dbContext;
        // 建構子，初始化 DbContext
        public MemberRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 查詢所有 Member 資料的實作
        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            string sqlQuery = "SELECT * FROM Member";
            using (var connection = _dbContext.CreateConnection())
            {
                var members = await connection.QueryAsync<Member>(sqlQuery);
                return members.ToList(); // 將 IEnumerable<Member> 轉換為 List<Member>
            }
        }

        // 查詢單一 Member 資料（依指定 Id）
        public async Task<Member> GetMemberById(Guid id)
        {
            string sqlQuery = "SELECT * FROM Member WHERE Mid = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                // QueryFirstOrDefaultAsync<Member> 用於取得符合條件的第一筆資料
                var member = await connection.QueryFirstOrDefaultAsync<Member>(sqlQuery, new { Id = id });
                return member;
            }
        }

        // 新增 Member 資料
        public async Task<Member> CreateMember(MemberForCreationDto memberDto)
        {
            string sqlQuery = @"
                INSERT INTO Member (Mname, Mage, Mverified, Mphone, MregistrationDate)
                OUTPUT INSERTED.*
                VALUES (@Mname, @Mage, @Mverified, @Mphone, @MregistrationDate)";

            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new
                {
                    Mname = memberDto.Mname,
                    Mage = memberDto.Mage,
                    Mverified = memberDto.Mverified,
                    Mphone = string.IsNullOrWhiteSpace(memberDto.Mphone) ? null : memberDto.Mphone, // 若為空字串，設為 NULL
                    MregistrationDate = memberDto.MregistrationDate 
                };

                // QuerySingleAsync<Member> 回傳新增的 Member 資料
                var newMember = await connection.QuerySingleAsync<Member>(sqlQuery, parameters);
                return newMember;
            }
        }

        // 更新 Member 資料（依指定 id）
        public async Task UpdateMember(Guid id, MemberForUpdateDto memberDto)
        {
            string sqlQuery = @"
                UPDATE Member 
                SET Mname = @Mname, Mage = @Mage, Mphone = @Mphone, MregistrationDate = @MregistrationDate
                WHERE Mid = @Id";

            var parameters = new
            {
                Id = id,
                Mname = memberDto.Mname,
                Mage = memberDto.Mage,
                Mphone = memberDto.Mphone,
                MregistrationDate = memberDto.MregistrationDate // 保留並更新註冊日期
            };

            using (var connection = _dbContext.CreateConnection())
            {
                // ExecuteAsync 執行更新語句，不回傳資料
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }

        // 刪除 Member 資料（依指定 id）
        public async Task DeleteMember(Guid id)
        {
            string sqlQuery = "DELETE FROM Member WHERE Mid = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                // ExecuteAsync 執行刪除語句，不回傳資料
                await connection.ExecuteAsync(sqlQuery, new { Id = id });
            }
        }
    }
}

// QueryAsync   用於查詢資料，回傳 IEnumerable<T>
// ExecuteAsync 用於執行新增、更新、刪除等操作，不回傳資料