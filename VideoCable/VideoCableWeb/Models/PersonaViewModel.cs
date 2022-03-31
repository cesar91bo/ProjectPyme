using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoCableWeb.Models
{
    public class PersonaViewModel : ViewModelBase
    {
        public int PersonaId { get; set; }
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        
    }
}