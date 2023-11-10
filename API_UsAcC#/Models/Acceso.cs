using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace API_UsAcC_.Models
{
    [Table(name: "accesos", Schema ="gbp_operacional")]
    public class Acceso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_acceso { get; set; }
        public string? codigo_acceso { get; set; }
        public string? descripcion_acceso { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }

        public Acceso(string codigo_acceso, string? descripcion_acceso)
        {
            this.codigo_acceso = codigo_acceso;
            this.descripcion_acceso = descripcion_acceso;
        }

    }
}
