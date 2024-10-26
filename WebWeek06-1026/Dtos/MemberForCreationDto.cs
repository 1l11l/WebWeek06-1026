using System.ComponentModel.DataAnnotations;

namespace WebWeek06_1026.Dtos
{
    public class MemberForCreationDto
    {
        [Required]
        [StringLength(10, ErrorMessage = "姓名最多 10 個字")]
        public string Mname { get; set; } // 必填名稱欄位

        [Required]
        [Range(0, 120, ErrorMessage = "年齡必須在 0 到 120 之間")]
        public int Mage { get; set; } // 必填年齡欄位

        [Required]
        public bool Mverified { get; set; } // 必填會員身分狀態

        [StringLength(10, ErrorMessage = "電話號碼最多 10 個數字")]
        public string? Mphone { get; set; } // 選填電話號碼
    }
}
