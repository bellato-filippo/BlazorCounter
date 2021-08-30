using System.ComponentModel.DataAnnotations;

namespace BlazorCounter.Server.Models;
public class ContatoreSer
{
    [Key]
    public int Id {  get; set; }
    public int Valore {  get; set; }
}
