using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.DatosCrud
{
    public class LogicaNegocio
    {
        string mensaje;
        
        private string Mensaje { get => mensaje; set => mensaje = value; }
        //Método que regitra al usuario
        public void Registro(SESION registro)
        {
            using (BD_PROYECTO_FINALEntities1 bd_registro = new BD_PROYECTO_FINALEntities1())
            {
                try
                {
                bd_registro.REGISTRAR_USER(registro.USUARIO,registro.CLAVE);
                bd_registro.SaveChanges();
                    Mensaje = "Se registró con éxito, bienvenido al sistema";
                }catch(Exception e)
                {
                    Mensaje = "Falla con el servidor, intente nuevamente";
                }
               
            }
            
        }
        //Mensaje que informa el éxito que tuvo el registro del usuario
        public string MensajeRegistro()
        {
            return Mensaje;
        }

        public SESION Acceso(SESION VerificarSesion)
        {
            using(BD_PROYECTO_FINALEntities1 bd_VerificarSesion = new BD_PROYECTO_FINALEntities1())
            {
               return bd_VerificarSesion.SESION.FirstOrDefault(S => S.USUARIO == VerificarSesion.USUARIO && S.CLAVE == VerificarSesion.CLAVE);
            }
        }
        //Método que lista las categorías
        public IEnumerable<CATEGORIA> ListarCategoria()
        {
            using (BD_PROYECTO_FINALEntities1 bd_categoria = new BD_PROYECTO_FINALEntities1())
            {
               return bd_categoria.CATEGORIA.ToList();
            }
        }
        //Método que registra el producto del usuario
        public void RegistrarProducto(PRODUCTO nuevoProducto)
        {
            using (BD_PROYECTO_FINALEntities1 bd_nuevoProducto = new BD_PROYECTO_FINALEntities1())
            {
                try
                {
                    Mensaje = "Se registró el producto con éxito";
                    bd_nuevoProducto.PRODUCTO.Add(nuevoProducto);
                    bd_nuevoProducto.SaveChanges();
                }
                catch(Exception e)
                {
                    Mensaje = "Falla con el servidor, intente nuevamente" + e.Message;
                }
            
            }
        }

        //Método que registra la publicación del usuario que ya ha iniciado sesión
        public void PublicarUsuario(USUARIO usuario)
        {
            using (BD_PROYECTO_FINALEntities1 bd_usuario = new BD_PROYECTO_FINALEntities1())
            {
                try
                {
                    string nombre_usuario = usuario.NOMBRE_USUARIO;
                    string apellido_usuario = usuario.APELLIDO_USUARIO;
                    string telefono = usuario.TELEFONO;
                    string celular = usuario.CELULAR;
                    string correo = usuario.CORREO;
                    string pais = usuario.PAIS;
                    int? fk_sesion = usuario.FK_SESION;

                    bd_usuario.USP_PUBLICAR_USER(nombre_usuario,apellido_usuario,telefono,celular,correo,pais,fk_sesion);
                    bd_usuario.SaveChanges();
                    Mensaje = "Te haz publicado exitosamente, ahora puedes mostrar tu talento";
                }
                catch (Exception e)
                {
                    Mensaje = "Falla con el servidor, intente nuevamente :(" + e.Message;
                }
            }
        }

    }
}