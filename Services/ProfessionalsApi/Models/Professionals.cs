using System.ComponentModel.DataAnnotations;

namespace ProfessionalsApi.Models
{
    public class Professionals
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public DateOnly DOB { get; set; }
        public string? ProfilePic { get; set; } = string.Empty;
        public string? UserName { get; set; }
        public decimal Rating { get; set; } = 0;
        public bool IsAvailable { get; set; }=false;
        public decimal BasePay { get; set; }
        public bool IsConfirmed { get; set; } = false;
        public string? Domain { get; set; }
        public string? DocumentPath { get; set; }=string.Empty;
       
    }
}
