using System.ComponentModel.DataAnnotations;

namespace BlazorCounter.Client.Models;

public class Evento
{
    public int Id {  get; set; }

    [Required(ErrorMessage="Nome obbligatorio")]
    public string? Nome {  get; set; }

    [Required(ErrorMessage="Localita obbligatoria")]
    [StringLength(50, ErrorMessage ="lunghezza massima di {1} caratteri")]
    public string? Localita {  get; set; }
    public DateTime Data {  get; set; }
    public string? Descrizione {  get; set; }
    public string? Note {  get; set; }

}
