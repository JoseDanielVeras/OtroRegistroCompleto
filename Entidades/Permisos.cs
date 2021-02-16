using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OtroRegistroCompleto.Entidades
{
    class Permisos
    {
        [Key]
        public int PermisoId { get; set; }
        public string Descripcion { get; set; }
    }
}
