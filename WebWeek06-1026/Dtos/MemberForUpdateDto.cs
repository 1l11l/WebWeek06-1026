using System.ComponentModel.DataAnnotations;

namespace WebWeek06_1026.Dtos
{
    public class MemberForUpdateDto
    {
        [Required]
        [StringLength(10, ErrorMessage = "姓名最多 10 個字")] // 名稱限制為 10 個字元
        public string Mname { get; set; }

        [Required]
        public int Mage { get; set; }

        [Required]
        public bool Mverified { get; set; } // 會員身份狀態必填

        [StringLength(10, ErrorMessage = "電話號碼最多 10 個數字")] // 電話號碼限制為 10 個字元
        public string? Mphone { get; set; } // 選填欄位
    }
}
