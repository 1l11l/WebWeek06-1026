﻿// 管理會員的 CRUD 操作
using Microsoft.AspNetCore.Mvc;
using WebWeek06_1026.Dtos;
using WebWeek06_1026.Interface;

namespace WebWeek06_1026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ILogger<MemberController> _logger; // 記錄錯誤和資訊
        private readonly IMember _member;

        public MemberController(ILogger<MemberController> logger, IMember member)
        {
            _logger = logger; // 記錄器(執行中的錯誤)
            _member = member; // 會員資料存取介面(_member 是實際執行資料庫操作的物件，member 是傳入的新會員資料)
        }

        // 查詢所有會員資料
        [HttpGet]
        public async Task<IActionResult> GetAllMembers() // IActionResult 是回傳值
        {
            try
            {
                var members = await _member.GetAllMembers(); // 查詢所有會員資料
                return Ok(new
                {
                    Success = true,
                    Message = "所有會員資料已返回。",
                    members
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "取得所有會員資料時發生錯誤"); // 錯誤日誌
                return StatusCode(500, "取得會員資料時發生錯誤。"); // 回傳伺服器錯誤
            }
        }

        // 依 ID 查詢單一會員資料
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberById(Guid id)
        {
            try
            {
                var member = await _member.GetMemberById(id); // 依 ID 查詢會員資料
                if (member == null)
                {
                    return NotFound(new
                    {
                        Success = false,
                        Message = "查無此會員資料。"
                    });
                }

                return Ok(new
                {
                    Success = true,
                    Message = "會員資料已返回。",
                    member
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"取得 ID 為 {id} 的會員資料時發生錯誤"); 
                return StatusCode(500, "取得會員資料時發生錯誤。");
            }
        }

        // 新增會員
        [HttpPost]
        public async Task<IActionResult> CreateMember(MemberForCreationDto member)
        {
            try
            {
                var newMember = await _member.CreateMember(member); // 新增會員資料
                return Ok(new
                {
                    Success = true,
                    Message = "新會員建置成功！",
                    newMember
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new member"); 
                return StatusCode(500, "建立會員時發生錯誤。");
            }
        }

        // 更新會員資料
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(Guid id, MemberForUpdateDto member)
        {
            try
            {
                var existingMember = await _member.GetMemberById(id); // 先檢查是否存在
                if (existingMember == null)
                {
                    return NotFound(new
                    {
                        Success = false,
                        Message = "查無此會員資料。"
                    });
                }

                await _member.UpdateMember(id, member);
                return Ok(new
                {
                    Success = true,
                    Message = "會員資料已更新。"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"更新 ID 為 {id} 的會員資料時發生錯誤"); 
                return StatusCode(500, "更新會員資料時發生錯誤。");
            }
        }

        // 刪除會員資料
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(Guid id)
        {
            try
            {
                var existingMember = await _member.GetMemberById(id); // 確認會員是否存在
                if (existingMember == null)
                {
                    return NotFound(new
                    {
                        Success = false,
                        Message = "查無此會員資料。"
                    });
                }

                await _member.DeleteMember(id);
                return Ok(new
                {
                    Success = true,
                    Message = "會員資料已刪除。"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"刪除 ID 為 {id} 的會員資料時發生錯誤"); 
                return StatusCode(500, "刪除會員資料時發生錯誤。");
            }
        }
    }
}
