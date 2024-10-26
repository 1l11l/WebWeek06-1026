using WebWeek06_1026.Interface;
using WebWeek06_1026.Models;
using Dapper;
using WebWeek06_1026.Dtos;
using WebWeek06_1026.Utilities;

namespace WebWeek06_1026.Repositories
{
    public class MemberRepository : IMember
    {
        private readonly DbContext _dbContext;

        // 在建構子中初始化 DbContext 服務
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
                return members.ToList();
            }
        }

        // 查詢單一 Member 資料（依指定 Id）
        public async Task<Member> GetMemberById(Guid id)
        {
            string sqlQuery = "SELECT * FROM Member WHERE Mid = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                var member = await connection.QueryFirstOrDefaultAsync<Member>(sqlQuery, new { Id = id });
                return member;
            }
        }

        // 新增 Member 資料
        public async Task<Member> CreateMember(MemberForCreationDto memberDto)
        {
            string sqlQuery = @"
                INSERT INTO Member (Mname, Mage, Mverified, Mphone)
                OUTPUT INSERTED.*
                VALUES (@Mname, @Mage, @Mverified, @Mphone)";

            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new
                {
                    Mname = memberDto.Mname,
                    Mage = memberDto.Mage,
                    Mverified = memberDto.Mverified,
                    Mphone = string.IsNullOrWhiteSpace(memberDto.Mphone) ? null : memberDto.Mphone // 若為空字串，設為 NULL
                };

                var newMember = await connection.QuerySingleAsync<Member>(sqlQuery, parameters);
                return newMember;
            }
        }

        // 更新 Member 資料（依指定 id）
        public async Task UpdateMember(Guid id, MemberForUpdateDto memberDto)
        {
            string sqlQuery = @"
                UPDATE Member 
                SET Mname = @Mname, Mage = @Mage, Mphone = @Mphone
                WHERE Mid = @Id";

            var parameters = new
            {
                Id = id,
                Mname = memberDto.Mname,
                Mage = memberDto.Mage,
                Mphone = memberDto.Mphone
            };

            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }

        // 刪除 Member 資料（依指定 id）
        public async Task DeleteMember(Guid id)
        {
            string sqlQuery = "DELETE FROM Member WHERE Mid = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(sqlQuery, new { Id = id });
            }
        }
    }
}
