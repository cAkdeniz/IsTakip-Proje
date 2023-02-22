using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipProject.Entities.DTOs.AppUserDtos
{
    public class AppUserSignInDto
    {
        //[Required(ErrorMessage = "Kullanıcı Adını Giriniz!")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Parolanızı Giriniz!")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
