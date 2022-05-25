using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab05.Models
{
  public class PaisesModel
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "You must enter a name")]
    [DisplayName("Country name:")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "You must select a continent")]
    [DisplayName("Continent:")]
    public string Continente { get; set; }

    [Required(ErrorMessage = "You must enter the spoken language")]
    [DisplayName("Language:")]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "You can not enter numbers")]
    public string Idioma { get; set; }
  }
}
