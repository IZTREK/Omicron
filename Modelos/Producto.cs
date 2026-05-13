using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usuarios.Modelos
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string CodigoSKU { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public string Categoria { get; set; } // Ej. Componentes, Periféricos

        public int Cantidad { get; set; }

        public string Distribuidor { get; set; } // Ej. PC'Smart

        public string TipoMovimiento { get; set; } // Entrada o Salida
    }
}