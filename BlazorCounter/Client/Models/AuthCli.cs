
using System.ComponentModel.DataAnnotations;

namespace BlazorCounter.Client.Models;
public class AuthCli
{
    [Key]
    public int Id {  get; set; }
    public string? FirstName {  get; set; }
    public string? LastName {  get; set; }
    public string? Password {  get; set; }
}
