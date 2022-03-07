using ProyectoFinal.DatosCrud;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class PrincipalController : Controller
    {
        LogicaNegocio logicaNegocio = new LogicaNegocio();
       
        // GET: Principal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }
        public ActionResult RegistroAccion(SESION nuevoRegistro)
        {
            
            try
            {
                logicaNegocio.Registro(nuevoRegistro);
                ViewBag.Mensaje = logicaNegocio.MensajeRegistro();
            }catch(Exception e)
            {
                ViewBag.Mensaje = logicaNegocio.MensajeRegistro();
            }
            
            return View("Index");
        }

        public ActionResult Acceso(SESION acceso)
        {
            SESION nuevo_acceso = logicaNegocio.Acceso(acceso);
            if(nuevo_acceso != null)
            {
              Session["ID"] = nuevo_acceso.ID_SESION;
                return View("IndexSesion");
            
            }
            else
            {
            return View("Index");
            }
            
        }
        public ActionResult IndexSesion()
        {
           
            return View();
        }



      
        public ActionResult EspacioVirtual()
        {
            try
            {
            
            IEnumerable<CATEGORIA> listarCategoria = logicaNegocio.ListarCategoria();
             

            return View(listarCategoria);
         
            }catch(Exception e)
            {
             return View(Session["ID"]);
            }
            
            
        }

        public ActionResult EspacioVirtualAccion(PRODUCTO nuevoProducto)
        {
            try
            {

                logicaNegocio.RegistrarProducto(nuevoProducto);

            }
            catch (Exception e)
            {
                
            }
            return View();

        }

        public ActionResult PublicarUsuario(USUARIO usuario)
        {
            IEnumerable<CATEGORIA> listarCategoria = logicaNegocio.ListarCategoria();
            try
            {
                logicaNegocio.PublicarUsuario(usuario);
                
                ViewBag.Mensaje = logicaNegocio.MensajeRegistro();
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = logicaNegocio.MensajeRegistro();
            }
            return View("EspacioVirtual",listarCategoria);
        }


    }
}