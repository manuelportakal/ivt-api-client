using System.ComponentModel.DataAnnotations;

namespace ivt_test.Models
{
    public class Login
    {
        [Display(Name = "Api Key")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Key required")]
        public string ApiKey { get; set; }

        [Display(Name = "Api Secret")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Secret required")]
        [DataType(DataType.Password)]
        public string ApiSecret { get; set; }

    }
}