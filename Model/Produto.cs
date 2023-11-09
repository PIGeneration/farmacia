using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace farmacia.Model
{
    public class Produto
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string Descricao { get; set;} = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Laboratorio { get; set;} = string.Empty;

        [Column(TypeName = "decimal(8,2)")]
        public decimal Preco { get; set;}

        [Column(TypeName = "varchar")]
        [StringLength(5000)]
        public string Foto { get; set;} = string.Empty;

        public virtual Categoria? Categoria { get; set; }
    }
}
