using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ejercicio_2___rest.Controllers
{
    public class Camion
    {
        //Del camión se conoce el número, marca, fecha y hora de salida y fecha y hora de destino
        public int Numero { get; set; }
        public string Marca { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int PesoMaximo { get; set; }
    }
    public class Paquete
    {
        //su peso, un número y una ciudad de origen, El peso es el único valor obligatorio.
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Peso { get; set; }
        public int Numero { get; set; }
        public string Origen { get; set; }
        public Camion CamionAsignado { get; set; }

    }

    public class CamionController : ApiController
    {
        private static List<Camion> Lista = new List<Camion>()
        {
            new Camion() {Numero = 1, Marca = "lol", FechaSalida = DateTime.Now, FechaLlegada = DateTime.Now, PesoMaximo = 5}
        };

        private static List<Paquete> ListaPaquetes = new List<Paquete>();


        public IHttpActionResult Get()
        {
            return Ok(Lista);
        }

        public IHttpActionResult Put(int pesoNuevo, Camion camion) //Modificar Camion
        {
            var CamionModificado = Lista.FirstOrDefault(x => x == camion);
            CamionModificado.PesoMaximo = pesoNuevo;

            return Ok(CamionModificado);

        }

        public IHttpActionResult Post(int peso, int numero, string origen) //Dar de alta paquete, hacer paquete controller?
        {
            Paquete paquete = new Paquete() { Peso = peso, Numero = numero, Origen = origen };
            Camion camion = Lista.FirstOrDefault(x => x.PesoMaximo > peso);//Hacer validacion
            paquete.CamionAsignado = camion;

            ListaPaquetes.Add(paquete);
            return Created($"Numero del camion: {camion.Numero} -  Fecha de llegada: {camion.FechaLlegada}",paquete);
        }
    }
}