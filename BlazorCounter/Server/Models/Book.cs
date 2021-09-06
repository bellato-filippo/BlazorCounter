
using System.ComponentModel.DataAnnotations;

namespace BlazorCounter.Server.Models;
public class Book
{
    [Key]
    public int Id {  get; set; }
    public string Title {  get; set; }
    public string Description {  get; set; }
    public string Author {  get; set; }
    public DateTime Created {  get; set; }
    public int ISBN {  get; set; }
}
