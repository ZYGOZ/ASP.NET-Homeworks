using System.ComponentModel.DataAnnotations;

namespace ASP.NET_HomeWork_3.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        //[Required(ErrorMessage = "Please enter name")]
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
