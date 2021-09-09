
using System.ComponentModel.DataAnnotations;

namespace BlazorCounter.Server.Models;
public class ProdottoSer
{
    [Key]
    public int Id {  get; set; }
    public string? Name {  get; set; }
    public string? Description {  get; set; }
    public float Price {  get; set; }
    public DateTime CreationDate {  get; set; }
    public bool IsAvailable {  get; set; }
}
