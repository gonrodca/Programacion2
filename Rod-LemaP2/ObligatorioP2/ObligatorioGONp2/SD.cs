using System;
using System.Collections.Generic;

namespace ObligatorioP2
{
    public class SD : Paquete
    {
        public bool MejoraImagen { get; set; }

        public SD(string nombre, bool enPromocion, double precioBase, bool mejoraImagen) : base(nombre, enPromocion, precioBase)
        {
            MejoraImagen = mejoraImagen;
        }

        public SD()
        {

        }
        public override double PrecioFinalPaquete()
        {
            double costoSD = PrecioBase;

            foreach (Canal c in GetListaCanalesPaquete())
            {
                costoSD += c.Precio;
            }

            if (MejoraImagen)
            {
                costoSD *= 1.20;
            }
            if (EnPromocion)
            {
                costoSD *= 0.85;
            }
            return costoSD;
        }



        public override string ToString()
        {
            return base.ToString() + " Mejora imagen " + MejoraImagen + " Costo Final " + PrecioFinalPaquete();
        }

        public override bool Equals(object obj)
        {
            return obj is SD sD &&
                   Nombre == sD.Nombre;
        }
    }
}
