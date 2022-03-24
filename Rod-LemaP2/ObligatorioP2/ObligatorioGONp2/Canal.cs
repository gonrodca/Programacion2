using System;
using System.Collections.Generic;

namespace ObligatorioP2
{
    public class Canal
    {
        private static int ultimoID = 1;

        public int Id { get; set; }
        public string Nombre { get; set; }
        public Resolucion ResolucionImagen { get; set; }
        public bool Multilenguaje { get; set; }
        public double Precio { get; set; }

        public enum Resolucion
        {
            SD = 576,
            HD = 1080

                 
        }

        public Canal()
        {

        }

        public Canal(string nombre, Resolucion resolucionImagen, bool multilenguaje, double precio)
        {
            Id = ultimoID;
            ultimoID++;
            Nombre = nombre;
            ResolucionImagen = resolucionImagen;
            Multilenguaje = multilenguaje;
            Precio = precio;
        }

        public override string ToString()
        {
            return "   ID " + Id + " Nombre " + Nombre + " Resolucion " + ResolucionImagen + " Multilenguaje " + Multilenguaje + " Precio " + Precio;
        }

        public override bool Equals(object obj)
        {
            return obj is Canal canal &&
                   Nombre == canal.Nombre;
        }

       
    }
}
