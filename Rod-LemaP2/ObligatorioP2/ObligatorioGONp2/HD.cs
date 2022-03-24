using System;
using System.Collections.Generic;

namespace ObligatorioP2
{
    public class HD : Paquete
    {

        public static double costoFijo = 456.90;

        public bool GrabacionNube { get; set; }

        public HD(string nombre, bool enPromocion, double precioBase, bool grabacionNube) : base(nombre, enPromocion, precioBase)
        {
            GrabacionNube = grabacionNube;
        }
        public HD() // Constructor para utilizar equals
        {

        }

        public override double PrecioFinalPaquete()
        {
            double costoHD = PrecioBase;

            foreach (Canal c in GetListaCanalesPaquete())
            {
                costoHD += c.Precio;
            }

            if (GrabacionNube)
            {
                costoHD += costoFijo;
            }

            if (EnPromocion)
            {
                costoHD *= 0.50;
            }
            return costoHD;

        }

        public override string ToString()
        {
            return base.ToString() + " Grabacion en nube " + GrabacionNube + " Costo Final " + PrecioFinalPaquete();
        }

        public override bool Equals(object obj)
        {
            return obj is HD hD &&
                   Nombre == hD.Nombre;
        }
    }
}
