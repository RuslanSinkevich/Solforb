using System.ComponentModel.DataAnnotations;

namespace Solforb.Models
{
    public class Provider
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string? Name { get; set; }
    }
}
