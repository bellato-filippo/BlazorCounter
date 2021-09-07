
using System.ComponentModel.DataAnnotations;

namespace BlazorCounter.Server.Models;
public class AuthSer
{
    [Key]
    public int Id {  get; set; }
    public string? FirstName {  get; set; }
    public string? LastName {  get; set; }
    public string? Password {  get; set; }
}
