using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVC5.Models
{
    public class Student
    {
        [Required(ErrorMessage = "ID không được để trống!")]
        [MinLength(10, ErrorMessage = "ID là một chuỗi 10 ký tự!")]
        [MaxLength(10, ErrorMessage = "ID là một chuỗi 10 ký tự!")]
        public string ID { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống!")]
        [MaxLength(50, ErrorMessage = "Họ tên không quá 50 ký tự!")]
        public string Name { get; set; }

        public bool Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        public string EMail { get; set; }

        [Compare(nameof(EMail), ErrorMessage = "Nhập lại Email không khớp!")]
        public string ConfirmEMail { get; set; }

        [RegularExpression("(84|0[3|5|7|8|9])+([0-9]{8})", ErrorMessage = "Số điện thoại không đúng định dạng!")]
        public string PhoneNumber { get; set; }

    }
}