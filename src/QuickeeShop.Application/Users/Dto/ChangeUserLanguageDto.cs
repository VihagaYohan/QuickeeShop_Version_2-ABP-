using System.ComponentModel.DataAnnotations;

namespace QuickeeShop.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}