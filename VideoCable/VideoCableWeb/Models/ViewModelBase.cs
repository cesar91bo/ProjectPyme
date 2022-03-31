using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoCableWeb.Models
{
    public class ViewModelBase
    {
        public DateTime FechaUltimaModificacion { get; set; }
        public string UsuarioUltimaModificacion { get; set; }
    }
}