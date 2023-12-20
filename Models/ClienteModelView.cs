
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Panificadora.Models
{
    [Table("TB_CLIENTES")]
    public class ClienteModelView
    {
 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("NOME_CLIENTE")]
        public string nome { get; set; }

        [Column("CPF_CNPJ")]
        public string CPFCNPJ { get; set; }

        [Column("CONTATO_CLIENTE")]
        public long Contato { get; set; }

        [Column("ENDERECO_CLIENTE")]
        public string Endereco { get; set; }

    }
}
