using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OtroRegistroCompleto.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Alias { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
        
        public int RolID { get; set; }
        [ForeignKey("RolId")]
        public virtual Roles roles { get; set; }
        
    }
}
