//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PEDIDO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PEDIDO()
        {
            this.PRODUCTO = new HashSet<PRODUCTO>();
        }
    
        public int ID_PEDIDO { get; set; }
        public string ESTADO { get; set; }
        public Nullable<double> PRECIO_TOTAL { get; set; }
        public Nullable<System.DateTime> FECHA_ENTREGA { get; set; }
        public Nullable<System.DateTime> FECHA_PEDIDO { get; set; }
        public string DETALLE { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
        public Nullable<int> FK_CLIENTE { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTO> PRODUCTO { get; set; }
    }
}
