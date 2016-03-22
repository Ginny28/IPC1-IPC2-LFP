using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Collections;

namespace PRACTIK2
{
    public partial class _Default : System.Web.UI.Page
    {
        String id_aero;
        String name_ae;
        String phone_ae;
        String dirc;
        String id_av;
        String capa;
        String peso;
         String id_cli;
        String nom_cli;
        String fechna;
        String tele;
        String dire;
        String corre;
        String id_r;
        String desti;
        String fecha_res;
        String precio;


        ArrayList idaer;
        ArrayList n_a;
        ArrayList p_a;
        ArrayList di;
        ArrayList id_a;
        ArrayList ca;
        ArrayList pe;
        ArrayList id_clie;
        ArrayList nom_clie;
        ArrayList fenach;
        ArrayList mi;
        ArrayList die;
        ArrayList cor;
        ArrayList reserva;
        ArrayList destino;
        ArrayList fecha;
        ArrayList preci;

        protected void Page_Load(object sender, EventArgs e)
        {
            idaer = new ArrayList();
            n_a = new ArrayList();
            p_a = new ArrayList();
            di = new ArrayList();
            id_a = new ArrayList();
            ca = new ArrayList();
            pe = new ArrayList();
            id_clie = new ArrayList();
            nom_clie = new ArrayList();
            fenach = new ArrayList();
            mi = new ArrayList();
            die = new ArrayList();
            cor = new ArrayList();
            reserva = new ArrayList();
            destino = new ArrayList();
            fecha = new ArrayList();
            preci = new ArrayList();

        }





        protected void Button1_Click1(object sender, EventArgs e)
        {



            XmlDocument xDoc = new XmlDocument();

            //La ruta del documento XML permite rutas relativas
            //respecto del ejecutable!


            xDoc.Load("C:/Users/Andy/Desktop/" + FileUpload1.FileName);


            XmlNodeList av = xDoc.GetElementsByTagName("agencia_viaje");

            XmlNodeList lista =
             ((XmlElement)av[0]).GetElementsByTagName("aerolinea");

            foreach (XmlElement nodo in lista)
            {

                int i = 0;

                XmlNodeList id =
                nodo.GetElementsByTagName("idAerolinea");

                XmlNodeList nombre =
                nodo.GetElementsByTagName("nombre");

                XmlNodeList tele = nodo.GetElementsByTagName("telefono");

                XmlNodeList diri = nodo.GetElementsByTagName("direccion");

                id_aero = id[i].InnerText;
                name_ae = nombre[i].InnerText;

                phone_ae = tele[i].InnerText;
                dirc = diri[i++].InnerText;

                idaer.Add(id_aero);
                n_a.Add(name_ae);
                p_a.Add(phone_ae);
                di.Add(dirc);


            }


            
            XmlNodeList lista1 =
           ((XmlElement)av[0]).GetElementsByTagName("avion");

            foreach (XmlElement nodo1 in lista1)
            {

                int i = 0;

                XmlNodeList ida =
                nodo1.GetElementsByTagName("idAvion");

                XmlNodeList cap =
                nodo1.GetElementsByTagName("capacidad");

                XmlNodeList pes = nodo1.GetElementsByTagName("peso");


                id_av = ida[i].InnerText;
                capa = cap[i].InnerText;
                peso = pes[i++].InnerText;

                id_a.Add(id_av);
                ca.Add(capa);
                pe.Add(peso);


            }

           XmlNodeList lista2 =
          ((XmlElement)av[0]).GetElementsByTagName("reservacion");

            foreach (XmlElement nodo2 in lista2)
            {

                int i = 0;

                XmlNodeList ir =
                nodo2.GetElementsByTagName("idReserva");

                XmlNodeList ds =
                nodo2.GetElementsByTagName("destino");


                XmlNodeList fch =
                nodo2.GetElementsByTagName("fecha");

                XmlNodeList pes = nodo2.GetElementsByTagName("precio");


             
                id_r = ir[i].InnerText;
                desti = ds[i].InnerText;
                fecha_res = fch[i].InnerText;
                precio = pes[i++].InnerText;



                reserva.Add(id_r);
                destino.Add(desti);
                fecha.Add(fecha_res);
                preci.Add(precio);
                
            }

            
            XmlNodeList lista3 =
            ((XmlElement)av[0]).GetElementsByTagName("cliente");

            foreach (XmlElement nodo3 in lista3)
            {

                int i = 0;

                XmlNodeList idc =
                nodo3.GetElementsByTagName("idCliente");

                XmlNodeList nom =
                nodo3.GetElementsByTagName("nombre");

                XmlNodeList fc = nodo3.GetElementsByTagName("fechaNac");

                XmlNodeList telefo = nodo3.GetElementsByTagName("telefono");
                XmlNodeList dir = nodo3.GetElementsByTagName("direccion");
                XmlNodeList corr = nodo3.GetElementsByTagName("correo");


                id_cli = idc[i].InnerText;
                nom_cli= nom[i].InnerText;
                 fechna=  fc[i].InnerText;
                tele= telefo[i].InnerText;
                dire= dir[i].InnerText;
                corre =corr[i++].InnerText;


                id_clie.Add(id_cli);
                nom_clie.Add(nom_cli);
                fenach.Add(fechna);
               mi.Add(tele);
                die.Add(dire);
                cor.Add(corre);



            }         


            for (int p = 0; p < idaer.Count;p++ )
            {
                IPC2.Service ser = new IPC2.Service();
                ser.insert_aeroline(System.Convert.ToString(idaer[p]), System.Convert.ToString(n_a[p]), System.Convert.ToString(p_a[p]), System.Convert.ToString(di[p]));



            }


            for (int J = 0; J < idaer.Count; J++)
            {
                IPC2.Service ser = new IPC2.Service();
                ser.insert_avion(System.Convert.ToString(id_a[J]), System.Convert.ToString(ca[J]), System.Convert.ToString(pe[J]), System.Convert.ToString(idaer[J]));



            }


            for (int s = 0; s < id_clie.Count; s++)
            {
                IPC2.Service ser = new IPC2.Service();
                ser.insert_cliente(System.Convert.ToString(id_clie[s]), System.Convert.ToString(nom_clie[s]), System.Convert.ToString(fenach[s]), System.Convert.ToString(mi[s]), System.Convert.ToString(die[s]), System.Convert.ToString(cor[s]));



            }


            for (int Y = 0; Y < reserva.Count; Y++)
            {
                IPC2.Service ser = new IPC2.Service();
                ser.insert_reservacion(System.Convert.ToString(reserva[Y]),System.Convert.ToString(destino[Y]),System.Convert.ToString(fecha[Y]),System.Convert.ToString(preci[Y]));



            }
            


        }


    }
}




        


           




   

