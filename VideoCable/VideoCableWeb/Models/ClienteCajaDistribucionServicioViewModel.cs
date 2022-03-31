using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoCableWeb.Models
{
    public class ClienteCajaDistribucionServicioViewModel : ViewModelBase
    {
        public int ClienteCajaDistribucionServicioId { get; set; }
        public int ClienteId { get; set; }
        public int CajaDistribucionId { get; set; }
        public int ServicioId { get; set; }
        public int UltimoEstadoId { get; set; }

    }
}