using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoCableWeb.Models
{
    public class ClienteCajaDistribucionServicioEstadoViewModel : ViewModelBase
    {
        public int ClienteCajaDistribucionServicioEstadoId { get; set; }
        public int ClienteCajaDistribucionServicioId { get; set; }
        public int EstadoId { get; set; }

    }
}