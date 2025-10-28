using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels.IdentityViewModels
{
    public class ForgetPasswordViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email Can't Be Epmty")]
        public string Email { get; set; }
    }
}
