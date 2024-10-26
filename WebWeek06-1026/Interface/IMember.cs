using WebWeek06_1026.Dtos;
using WebWeek06_1026.Models;

namespace WebWeek06_1026.Interface
{
    public interface IMember
    {
        /// 查詢所有 Member 資料
        Task<IEnumerable<Member>> GetAllMembers();

        /// 根據 ID 查詢特定 Member
        Task<Member> GetMemberById(Guid id);

        /// 創建新 Member
        Task<Member> CreateMember(MemberForCreationDto member); // 回傳 Member 以取得完整資料

        /// 更新特定 Member 資料
        Task UpdateMember(Guid id, MemberForUpdateDto member);

        /// 刪除特定 Member
        Task DeleteMember(Guid id);
    }
}
