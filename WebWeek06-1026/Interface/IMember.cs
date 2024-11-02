// 查詢所有Member資料的介面 
using WebWeek06_1026.Dtos;
using WebWeek06_1026.Models;

namespace WebWeek06_1026.Interface
{
    public interface IMember
    {
        // 查詢所有 Member 資料，回傳 Member 物件集合(IEnumerable 回傳多筆)
        Task<IEnumerable<Member>> GetAllMembers();
        
        // 根據 ID 查詢特定 Member，回傳 Member 物件(單一)
        Task<Member> GetMemberById(Guid id);

        // 創建新 Member，回傳 Member 物件
        Task<Member> CreateMember(MemberForCreationDto member);

        // 更新特定 Member 資料，不回傳資料
        Task UpdateMember(Guid id, MemberForUpdateDto member);

        // 刪除特定 Member，不回傳資料
        Task DeleteMember(Guid id);
    }
}
