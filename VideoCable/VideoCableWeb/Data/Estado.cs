//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VideoCableWeb.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Estado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estado()
        {
            this.ClientesCajasDistribucionesServiciosEstados = new HashSet<ClientesCajasDistribucionesServiciosEstado>();
            this.ClientesCajasDistribucionesServicios = new HashSet<ClientesCajasDistribucionesServicio>();
        }
    
        public int EstadoId { get; set; }
        public string Descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientesCajasDistribucionesServiciosEstado> ClientesCajasDistribucionesServiciosEstados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientesCajasDistribucionesServicio> ClientesCajasDistribucionesServicios { get; set; }
    }
}
