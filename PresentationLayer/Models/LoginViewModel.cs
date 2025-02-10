using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Please Enter your Matric Number")]
    [Display(Name = "Matric Number")]
    public string? MatricNumber { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    public bool RememberMe { get; set; }
    
    
}
