using System.ComponentModel.DataAnnotations;

namespace MvcModalDialogDemo.Views.Home
{
    public class DemoViewModel
    {
        [Required(ErrorMessage = "{0}必须填写")]
        [Display(Name = "用户名", Prompt = "用户民")]
        public string Username { get; set; }



        [Required(ErrorMessage = "{0}必须填写")]
        [Display(Name = "密码", Prompt = "密码")]
        public string Password { get; set; }

        [Display(Name = "电子邮件", Prompt = "电子邮件")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }

}