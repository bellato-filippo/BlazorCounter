
using System.ComponentModel.DataAnnotations;

namespace BlazorCounter.Server.Models;
public class ProductSer
{
    [Key]
    public int Id {  get; set; }
    public string? Name {  get; set; }
    public int Price {  get; set; }
}
