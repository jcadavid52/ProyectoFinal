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
    
    public partial class PRODUCTO
    {
        public int ID_PRODUCTO { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public Nullable<double> PRECIO { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<int> FK_PEDIDO { get; set; }
        public Nullable<int> FK_CATEGORIA { get; set; }
        public Nullable<int> FK_USUARIO { get; set; }
    
        public virtual CATEGORIA CATEGORIA { get; set; }
        public virtual PEDIDO PEDIDO { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}