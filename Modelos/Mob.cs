using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usuarios.Modelos
{
    public class Mob
    {
        //Getters y Setters para las propiedades del Mob
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int PuntosVida { get; set; }
        public int DañoAtaque { get; set; }
        public string ItemSoltado { get; set; }
        public bool EsDomesticable { get; set; }
    }
}