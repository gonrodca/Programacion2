using System;
using System.Collections.Generic;

namespace ObligatorioP2
{
    public class Administrador
    {
        private List<Paquete> listaPaquetes = new List<Paquete>();
        private List<Canal> listaCanales = new List<Canal>();


        public Administrador()
        {
            Console.Clear();
            precargaDatos();
        }


        public List<Paquete> GetListaPaquetes()
        {
            return listaPaquetes;
        }

        public HD SetHD(string nom, bool enProm, double preBas, bool grabNub)
        {
            //VALIDACION PARA EVITAR CREAR PAQUETE CON MISMO NOMBRE QUE OTRO
            HD paqueteResultante = null;
            HD aux = new HD();
            aux.Nombre = nom;
            int existeHD = GetListaPaquetes().IndexOf(aux);
            if (existeHD.Equals(-1))
            {
                HD nuevoPaquete = new HD(nom, enProm, preBas, grabNub);
                listaPaquetes.Add(nuevoPaquete);
                paqueteResultante = nuevoPaquete;
            }

            return paqueteResultante;
        }

        public SD SetSD(string nom, bool enProm, double preBas, bool mejIma)
        {
            //VALIDACION PARA EVITAR CREAR PAQUETE CON MISMO NOMBRE QUE OTRO
            SD paqueteResultante = null;
            SD aux = new SD();
            aux.Nombre = nom;
            int existeSD = GetListaPaquetes().IndexOf(aux);
            if (existeSD.Equals(-1))
            {
                SD nuevoPaquete = new SD(nom, enProm, preBas, mejIma);
                listaPaquetes.Add(nuevoPaquete);
                paqueteResultante = nuevoPaquete;
            }

            return paqueteResultante;
        }

        public Canal SetCanal(string nom, Canal.Resolucion resol, bool multi, double pre)
        {
            Canal nuevoCanal = null;
            if (pre > 0 && !nom.Equals("") && (resol == Canal.Resolucion.HD || resol == Canal.Resolucion.SD) && !multi.Equals(null))
            {
                //VALIDACION QUE EL NOMBRE DEL CANAL NO EXISTA
                Canal aux = new Canal();
                aux.Nombre = nom;

                int existeCanal = GetListaCanales().IndexOf(aux);

                if (existeCanal.Equals(-1))
                {
                    nuevoCanal = new Canal(nom, resol, multi, pre);
                    listaCanales.Add(nuevoCanal);
                }
            }
            return nuevoCanal;

        }

        public List<Canal> GetListaCanales()
        {
            return listaCanales;
        }

        public bool IngresarCanalAdmin(string nombre, int resol, int multi, double pre)
        {
            bool ingresado = false;

            Canal.Resolucion definicion = 0;
            if (resol.Equals(1))
            {

                definicion = Canal.Resolucion.HD;
            }
            else if (resol.Equals(2))
            {

                definicion = Canal.Resolucion.SD;
            }

            bool esMulti = false;
            if (multi.Equals(1))
            {
                esMulti = true;
            }

            Canal nuevoCanal = SetCanal(nombre, definicion, esMulti, pre);
            if (nuevoCanal != null)
            {

                ingresado = true;
            }

            return ingresado;
        }
        public void CambiarCostoFijo(double nuevoCF)
        {
            if (nuevoCF > 0)
            {

                HD.costoFijo = nuevoCF;

            }
        }

        public List<Paquete> GetPaquetesConMasCanales()
        {
            List<Paquete> listaRet = new List<Paquete>();
            double minCant = double.MinValue;
            foreach (Paquete p in GetListaPaquetes())
            {
                if (p.GetListaCanalesPaquete().Count > minCant)
                {
                    minCant = p.GetListaCanalesPaquete().Count;
                    listaRet.Clear();
                    listaRet.Add(p);
                }
                else if (p.GetListaCanalesPaquete().Count == minCant)
                {
                    listaRet.Add(p);
                }
            }

            return listaRet;
        }

        public List<Paquete> FiltrarPaquetePorPrecio(double precio)
        {
            List<Paquete> paquetesFiltrados = new List<Paquete>();

            foreach (Paquete p in GetListaPaquetes())
            {
                if (p.PrecioBase > precio)
                {
                    paquetesFiltrados.Add(p);
                }
            }
            return paquetesFiltrados;
        }

        public void precargaDatos()
        {

            //CANALES HD
            Canal canalHD1 = SetCanal("Discovery Kids HD", Canal.Resolucion.HD, true, 55);
            Canal canalHD2 = SetCanal("FOX HD", Canal.Resolucion.HD, false, 45);
            Canal canalHD3 = SetCanal("Warner HD", Canal.Resolucion.HD, true, 35);
            Canal canalHD4 = SetCanal("History HD", Canal.Resolucion.HD, true, 59);
            Canal canalHD5 = SetCanal("HBO HD", Canal.Resolucion.HD, false, 34);
            Canal canalHD6 = SetCanal("HBO HD", Canal.Resolucion.SD, true, 44); //ESTE NO DEBERIA CREARSE
            //CANALES SD
            Canal canalSD1 = SetCanal("Discovery Home", Canal.Resolucion.SD, false, 54);
            Canal canalSD2 = SetCanal("ESPN", Canal.Resolucion.SD, true, 99);
            Canal canalSD3 = SetCanal("HOLA TV", Canal.Resolucion.SD, false, 22);
            Canal canalSD4 = SetCanal("VTV", Canal.Resolucion.SD, false, 43.90);
            Canal canalSD5 = SetCanal("Canal 5", Canal.Resolucion.SD, false, 24);
            Canal canalSD6 = SetCanal("Canal 4", Canal.Resolucion.SD, true, 74);
            Canal canalSD7 = SetCanal("Canal 5", Canal.Resolucion.HD, true, 26); // NO DEBERIA CREARSE

            //PAQUETES HD
            HD paqueteHD1 = SetHD("Entretenimiento", false, 567, true);
            HD paqueteHD5 = SetHD("Entretenimiento", false, 567, true); // NO SE CREA PORQUE YA EXISTE
            paqueteHD1.SetListaCanalPaquete(canalHD1);
            paqueteHD1.SetListaCanalPaquete(canalHD2);
            paqueteHD1.SetListaCanalPaquete(canalHD3);
            paqueteHD1.SetListaCanalPaquete(canalHD4);
            paqueteHD1.SetListaCanalPaquete(canalHD4); // ESTE CANAL NO SE AGREGA PORQUE YA EXISTE
            paqueteHD1.SetListaCanalPaquete(canalHD5);
            paqueteHD1.SetListaCanalPaquete(canalHD5); // ESTE CANAL NO SE AGREGA PORQUE YA EXISTE


            HD paqueteHD2 = SetHD("Deporte", true, 990, false);
            paqueteHD2.SetListaCanalPaquete(canalHD1);
            paqueteHD2.SetListaCanalPaquete(canalHD2);
            paqueteHD2.SetListaCanalPaquete(canalHD3);
            paqueteHD2.SetListaCanalPaquete(canalHD5);

            HD paqueteHD3 = SetHD("Dibujitos", false, 340, true);
            paqueteHD3.SetListaCanalPaquete(canalHD1);
            paqueteHD3.SetListaCanalPaquete(canalHD2);
            paqueteHD3.SetListaCanalPaquete(canalHD3);
            paqueteHD3.SetListaCanalPaquete(canalHD4);

            HD paqueteHD4 = SetHD("Historia", true, 758, false);
            paqueteHD4.SetListaCanalPaquete(canalHD1);
            paqueteHD4.SetListaCanalPaquete(canalHD2);
            paqueteHD4.SetListaCanalPaquete(canalHD3);
            paqueteHD4.SetListaCanalPaquete(canalHD4);


            //PAQUETES SD
            SD paqueteSD1 = SetSD("Peliculas", true, 100, true);
            paqueteSD1.SetListaCanalPaquete(canalSD1);
            paqueteSD1.SetListaCanalPaquete(canalSD2);
            paqueteSD1.SetListaCanalPaquete(canalSD3);
            paqueteSD1.SetListaCanalPaquete(canalSD4);

            SD paqueteSD2 = SetSD("Series", false, 124, false);
            paqueteSD2.SetListaCanalPaquete(canalSD1);
            paqueteSD2.SetListaCanalPaquete(canalSD2);
            paqueteSD2.SetListaCanalPaquete(canalSD3);
            paqueteSD2.SetListaCanalPaquete(canalSD4);

            SD paqueteSD3 = SetSD("Novelas Turcas", true, 543, true);
            paqueteSD3.SetListaCanalPaquete(canalSD1);
            paqueteSD3.SetListaCanalPaquete(canalSD2);
            paqueteSD3.SetListaCanalPaquete(canalSD3);
            paqueteSD3.SetListaCanalPaquete(canalSD4);
            paqueteSD3.SetListaCanalPaquete(canalSD5);
            paqueteSD3.SetListaCanalPaquete(canalSD6);

            SD paqueteSD4 = SetSD("Boxeo", false, 590, true);
            SD paqueteSD5 = SetSD("Boxeo", false, 590, true); // NO DEBERIA CREARSE PORQUE YA EXISTE
            paqueteSD4.SetListaCanalPaquete(canalSD1);
            paqueteSD4.SetListaCanalPaquete(canalSD2);
            paqueteSD4.SetListaCanalPaquete(canalSD3);
            paqueteSD4.SetListaCanalPaquete(canalSD4);
            paqueteSD4.SetListaCanalPaquete(canalSD5);
            paqueteSD4.SetListaCanalPaquete(canalSD6);
        }

    }
}
