using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoCableWeb.Models
{
    public class ClienteViewModel : ViewModelBase
    {
        public int PersonaId { get; set; }
        public int ClienteId { get; set; }

        [DisplayName("Direccion")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Direccion { get; set; }
        public string NumeroPrecinto { get; set; }

        [DisplayName("Razon Social")]
        [Required(ErrorMessage ="Este campo es requerido.")]
        public string RazonSocial { get; set; }

        [DisplayName("CUIT")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Cuit { get; set; }

        [DisplayName("Telefono")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Telefono { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }


    }

}