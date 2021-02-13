using System.ComponentModel.DataAnnotations;

namespace Micro.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}