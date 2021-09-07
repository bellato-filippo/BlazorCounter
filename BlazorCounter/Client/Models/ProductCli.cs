
using System.ComponentModel.DataAnnotations;

namespace BlazorCounter.Client.Models;
public class ProductCli
{
    [Key]
    public int Id {  get; set; }
    public string? Name {  get; set; }
    public int Price {  get; set; }
}
