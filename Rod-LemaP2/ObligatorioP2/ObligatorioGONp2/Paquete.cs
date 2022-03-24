using System;
using System.Collections.Generic;

namespace ObligatorioP2
{
    public abstract class Paquete
    {

        protected static int ultimoId = 1;

        public int Id { get; set; }
        public string Nombre { get; set; }
        private List<Canal> listaCanalesPaquete = new List<Canal>();
        public bool EnPromocion { get; set; }
        public double PrecioBase { get; set; }

        public Paquete(string nombre, bool enPromocion, double precioBase)
        {
            Id = ultimoId;
            ultimoId++;
            Nombre = nombre;
            EnPromocion = enPromocion;
            PrecioBase = precioBase;
        }
        public Paquete() // para utilizar equals
        {

        }

        public List<Canal> GetListaCanalesPaquete()
        {
            return listaCanalesPaquete;
        }
        public Canal SetListaCanalPaquete(Canal c)
        {
            Canal ret = null;

            Canal aux = new Canal();
            aux.Nombre = c.Nombre;

            bool existeCanal = listaCanalesPaquete.Contains(aux);

            if (!existeCanal)
            {
                listaCanalesPaquete.Add(c);
                ret = c;
            }

            return ret;
        }

        public abstract double PrecioFinalPaquete();

        public override string ToString()
        {
            return " Nombre " + Nombre + " En promocion " + EnPromocion + " Precio base " + PrecioBase;
        }
    }
}
