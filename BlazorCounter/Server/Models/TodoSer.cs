
using System.ComponentModel.DataAnnotations;

namespace BlazorCounter.Server.Models;
public class TodoSer
{
    [Key]
    public int Id {  get; set; }
    public string? Frase {  get; set; }
}
