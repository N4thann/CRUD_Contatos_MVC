using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ContatosMVC.Models
{
    [Table("Contato")]
    public class ContatoModel
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("Email")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Column("Celular")]
        [Display(Name = "Celular")]
        public string Celular { get; set; }

    }
}
