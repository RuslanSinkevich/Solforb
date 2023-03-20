using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solforb.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string? Name { get; set; }
        [Display(Name = "Количество")]
        [RegularExpression(@"^(\d+),(\d{3})$", ErrorMessage = "Неверный формат данных пример - 0,500 либо 5,125")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public decimal Quantity { get; set; }

        [Display(Name = "Ед. изм.")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string? Unit { get; set; }

    }
}
