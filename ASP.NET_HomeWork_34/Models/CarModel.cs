using System.ComponentModel.DataAnnotations;

namespace ASP.NET_HomeWork_3.Models
{
    public class CarModel
    {
        [Required(ErrorMessage = "Please enter Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Please enter ConfirmPassword")]
        public string? ConfirmPassword { get; set; }
    }
}
