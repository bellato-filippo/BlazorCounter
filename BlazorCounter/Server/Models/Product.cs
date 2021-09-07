
using System.ComponentModel.DataAnnotations;

namespace BlazorCounter.Server.Models;
public class Product
{
    [Key]
    public int Id {  get; set; }
    public string? Name {  get; set; }
}
