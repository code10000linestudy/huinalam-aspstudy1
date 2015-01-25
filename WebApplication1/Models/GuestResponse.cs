using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "이름을 입력하세요.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "plz enter ur email")]
        //[RegularExpression(".+\\@.+\\..+", ErrorMessage = "틀렸어!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "plz enter ur willAttend")]
        public bool? WillAttend { get; set; }
    }
}