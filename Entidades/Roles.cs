using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtroRegistroCompleto.Entidades
{
    public class Roles
    {
        [Key]
        public int RolId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey("RolId")]
        public virtual Roles Rol { get; set; }
    }
}
