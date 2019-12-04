using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAutomationProject.Models.Security
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı Girmediniz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre Girmediniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre Onay Girmediniz")]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }
        [Required(ErrorMessage = "Mail Adresi Girmediniz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public int Type { get; set; }
        [Required(ErrorMessage = "TC No Girmediniz")]
        public string TCNO { get; set; }
    }
}
