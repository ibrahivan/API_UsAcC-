using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_UsAcC_.Models
{

    
        [Table(name: "usuarios", Schema ="gbp_operacional")] // Indica el nombre de la tabla
        public class Usuario
        {

            [Key]  //Con el uso de la anotación [Key] indicamos que el atributo es la PK
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Por defecto Autoincrement
            public long id_usuario { get; set; }
            public string dni_usuario { get; set; }
            public string? nombre_usuario { get; set; } // ? indica que puede tener un valor string o null
            public string? apellidos_usuario { get; set; }
            public string? tlf_usuario { get; set; }
            public string? email_usuario { get; set; }
            public string clave_usuario { get; set; }
            public bool? estaBloqueado_usuario { get; set; }
            [Column(TypeName = "timestamp without time zone")] // Indica el tipo de dato que se debe utilizar en la BD para almacenar la propiedad
            public DateTime? fch_fin_bloqueo_usuario { get; set; }
            [Column(TypeName = "timestamp without time zone")]
            public DateTime? fch_alta_usuario { get; set; }
            [Column(TypeName = "timestamp without time zone")]
            public DateTime? fch_baja_usuario { get; set; }

            [ForeignKey(name: "id_acceso")] // Indica con qué tabla se relaciona, en concreto con la PK de acceso
            [Column(name: "id_acceso")] // y el nombre que se le da en la BD
            public long AccesoId { get; set; }
            public Acceso Acceso { get; set; }


            public Usuario(string dni_usuario, string? nombre_usuario, string? apellidos_usuario, string? tlf_usuario
                , string? email_usuario, string clave_usuario, bool? estaBloqueado_usuario, DateTime? fch_fin_bloqueo_usuario
                , DateTime? fch_alta_usuario, DateTime? fch_baja_usuario, long accesoId)
            {
                this.dni_usuario = dni_usuario;
                this.nombre_usuario = nombre_usuario;
                this.apellidos_usuario = apellidos_usuario;
                this.tlf_usuario = tlf_usuario;
                this.email_usuario = email_usuario;
                this.clave_usuario = clave_usuario;
                this.estaBloqueado_usuario = estaBloqueado_usuario;
                this.fch_fin_bloqueo_usuario = fch_fin_bloqueo_usuario;
                this.fch_alta_usuario = fch_alta_usuario;
                this.fch_baja_usuario = fch_baja_usuario;
                AccesoId = accesoId;
            }

        }
    }
 
   
