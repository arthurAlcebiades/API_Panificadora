using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Panificadora.Models
{
    [Table("TB_USUARIO")]
    public class UsuarioViewModel
    {
     
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }


        [Column("NOME_USUARIO")]
        public string nome { get; set; }

    }
}
