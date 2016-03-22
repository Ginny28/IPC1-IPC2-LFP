using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;
using System.Collections;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace Fase2_IPC2_S2_2011
{
    public partial class EntidadRelacionArchivo : System.Web.UI.Page
    {
        String[] arrayDatos = new String[5];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                llenar_DropArchivos();
            } 
        }

        public void llenar_DropArchivos()
        {
            string cadenaConeccion = "server =(local); Database=Fase2_s2_2011; Integrated Security =SSPI;";
            SqlConnection Coneccion = new SqlConnection(cadenaConeccion);

            try
            {
                Coneccion.Open();
                string consultaNombre = "select nombreArchivo FROM ArchivoXml where usuario_idUsuario ='" + Session["Usuario"] + "'";
                SqlDataAdapter AdapterNombre = new SqlDataAdapter(consultaNombre, cadenaConeccion);
                DataSet ds = new DataSet();
                AdapterNombre.Fill(ds, "ArchivoXml");

                dropER.DataSource = ds.Tables["ArchivoXml"].DefaultView;
                dropER.DataTextField = "nombreArchivo";
                dropER.DataValueField = "nombreArchivo";
                dropER.DataBind();
                Coneccion.Close();
            }
            catch (Exception ex)
            {
                Coneccion.Close();
            }
        }

        protected void VerER_Click(object sender, EventArgs e)
        {

            CrearXml();

            string fichero = MapPath("Archivo/" + "ArchivoAux" + ".XML");
            string fichero2 = MapPath("Archivo/" + "Imagen" + ".PNG");
            
            XmlTextReader rdr = new XmlTextReader(fichero);

            ArrayList nodoXml = new ArrayList();
            ArrayList tablaER = new ArrayList();
            ArrayList Er = new ArrayList();
            ArrayList atributos = new ArrayList();
            ArrayList posnodo = new ArrayList();
            ArrayList cantidad = new ArrayList();


            while (rdr.Read())
            {
                switch (rdr.NodeType)
                {

                    case XmlNodeType.Element:
                        nodoXml.Add(XmlNodeType.Element.ToString());
                        tablaER.Add(rdr.Name);
                        break;

                    case XmlNodeType.EndElement:
                        nodoXml.Add(XmlNodeType.EndElement.ToString());
                        tablaER.Add(rdr.Name);
                        break;

                    case XmlNodeType.Text:
                        nodoXml.Add(XmlNodeType.Text.ToString());
                        tablaER.Add("Texto");
                        break;
                        
                }
            }
            rdr.Close();

            int bandera = 0;
            for (int z = 0; z < nodoXml.Count; z++)
            {
                if (nodoXml[z].ToString() == "Element" && nodoXml[z + 1].ToString() == "Element" && nodoXml[z + 2].ToString() == "Text"
                    && nodoXml[z + 3].ToString() == "EndElement")
                {
                                        for (int sam = 0; sam < Er.Count; sam++)
                                        {
                                            if (tablaER[z] == Er[sam])
                                            {
                                                bandera = 1;
                                            }
                                        }
                                        if (bandera == 0)
                                        {
                                            Er.Add(tablaER[z]);
                                        }
                                        else
                                        {
                                            bandera = 0;
                                        }
                }
            }


            int banderin = 0;
            int aux = 0;
            int aux2 = 0;
            int otro_aux = 0;
            int cantidad_Atributos = 0;


            for (int m = 0; m < Er.Count; m++)
            {
                for (int b = 0; b < nodoXml.Count;  b++)
                {

                    if (Er[m] == tablaER[b])
                    {
                        if(otro_aux != m){
                            banderin = 0;
                            otro_aux = m;
                        }


                        if (banderin == 0)
                        {
                            aux = b;
                            banderin++;
                        }else if(banderin == 1){
                            aux2 = b;
                            otro_aux = m;
                            banderin++;
                        }

                        if(aux != 0 && aux2 != 0 && m == otro_aux){
                            for (int mx = aux + 1; mx < aux2; mx++ )
                            {
                                if (nodoXml[mx].ToString() == "Element")
                                {
                                    cantidad_Atributos++;
                                    atributos.Add(tablaER[mx]);
                                }
                            }
                            cantidad.Add(cantidad_Atributos);
                            cantidad_Atributos = 0;
                            aux = aux2 = 0;
                        }
                    }
                }   
            }


            //for (int m = 0; m < atributos.Count; m++)
            //{
            //    TextBox1.Text = TextBox1.Text + atributos[m] + "\n";
            //}
            //for (int m = 0; m < cantidad.Count; m++)
            //{
            //    TextBox1.Text = TextBox1.Text + cantidad[m] + "\n";
            //}

            //for (int m = 0; m < Er.Count; m++)
            //{
            //    TextBox1.Text = TextBox1.Text + Er[m] + "\n";
            //}

                GeneraImagen(Er, atributos, cantidad);

                Response.Clear();
                imgIma.ImageUrl = "~/Archivo/Imagen.PNG";
        }

        public void CrearXml() {
            byte[] archivoBit = new byte[0];
            string cadenaConeccion = "server=(local); Database=Fase2_s2_2011; Integrated Security =SSPI;";
            SqlConnection Coneccion = new SqlConnection(cadenaConeccion);
            SqlDataAdapter Adapter = new SqlDataAdapter();
            SqlDataReader leer;

            try
            {
                Coneccion.Open();
                Adapter.InsertCommand = new SqlCommand("select nombreArchivo,Archivo,usuario_idUsuario from ArchivoXml where nombreArchivo = '" + dropER.Text + "'", Coneccion);
                leer = Adapter.InsertCommand.ExecuteReader();

                leer.Read();
                arrayDatos[0] = leer["nombreArchivo"].ToString();
                archivoBit = (byte[])leer["Archivo"];
                arrayDatos[2] = leer["usuario_idUsuario"].ToString();
                leer.Close();

                Adapter.InsertCommand.ExecuteNonQuery();
                Coneccion.Close();


                ASCIIEncoding convertidor = new ASCIIEncoding();
                String ContenidoArchivo = convertidor.GetString(archivoBit);
                crearAlCargar(ContenidoArchivo);
            }
            catch (Exception ex)
            {
                Coneccion.Close();
            }
        }


        public void crearAlCargar(String mandado)
        {
            string fichero = MapPath("Archivo/" + "ArchivoAux" + ".XML");
            StreamWriter escribirFichero = new StreamWriter(fichero);
            escribirFichero.WriteLine(mandado);
            escribirFichero.Close();
        }



        public void GeneraImagen(ArrayList tabla, ArrayList atributos, ArrayList cantidadAtri){
           
            string fichero = MapPath("Archivo/" + "Imagen" + ".PNG");
            Bitmap Imagen = new Bitmap(600,600);
            Graphics g = Graphics.FromImage(Imagen);
            g.FillRectangle(new SolidBrush(Color.GhostWhite), 0, 0, 600, 600);
            Pen penJoin = new Pen(Color.Black, 2);        

            for (int px = 0; px < tabla.Count; px++ )
            {

                switch (px)
                {
                    case 0:
                            g.DrawRectangle(penJoin, 10, 10, 70, 100);
                            g.DrawString(tabla[px].ToString(), new Font("Verdana", 8, GraphicsUnit.Pixel), new SolidBrush(Color.Red), 11, 12);
                            
                            int z = 26;
                            int ca = Convert.ToInt32(cantidadAtri[0]);
                            cantidadAtri.RemoveAt(0);
                            for (int m = 0; m < ca; m++ )
                            {
                                g.DrawString(atributos[0].ToString(), new Font("Verdana", 8, GraphicsUnit.Pixel), new SolidBrush(Color.Blue), 13, z);
                                atributos.RemoveAt(0);
                                z = z + 10;
                            }
                        break;
                    case 1:
                            g.DrawRectangle(penJoin, 159, 10, 70, 100);
                            g.DrawString(tabla[px].ToString(), new Font("Verdana", 8, GraphicsUnit.Pixel), new SolidBrush(Color.Red), 160, 12);

                            int zz = 26;
                            int ca2 = Convert.ToInt32(cantidadAtri[0]);
                            cantidadAtri.RemoveAt(0);
                            for (int m = 0; m < ca2; m++ )
                            {
                                g.DrawString(atributos[0].ToString(), new Font("Verdana", 8, GraphicsUnit.Pixel), new SolidBrush(Color.Blue), 162, zz);
                                atributos.RemoveAt(0);
                                zz = zz + 10;
                            }
                        break;
                    case 2:
                            g.DrawRectangle(penJoin, 308, 10, 70, 100);
                            g.DrawString(tabla[px].ToString(), new Font("Verdana", 8, GraphicsUnit.Pixel), new SolidBrush(Color.Red), 310, 12);

                            int zzz = 26;
                            int ca22 = Convert.ToInt32(cantidadAtri[0]);
                            cantidadAtri.RemoveAt(0);
                            for (int m = 0; m < ca22; m++ )
                            {
                                g.DrawString(atributos[0].ToString(), new Font("Verdana", 8, GraphicsUnit.Pixel), new SolidBrush(Color.Blue), 312, zzz);
                                atributos.RemoveAt(0);
                                zzz = zzz + 10;
                            }
                        break;
                    case 3:
                            g.DrawRectangle(penJoin, 457, 10, 70, 100);
                            g.DrawString(tabla[px].ToString(), new Font("Verdana", 8, GraphicsUnit.Pixel), new SolidBrush(Color.Red), 462, 12);

                            int zzzz = 26;
                            int ca222 = Convert.ToInt32(cantidadAtri[0]);
                            cantidadAtri.RemoveAt(0);
                            for (int m = 0; m < ca222; m++ )
                            {
                                g.DrawString(atributos[0].ToString(), new Font("Verdana", 8, GraphicsUnit.Pixel), new SolidBrush(Color.Blue), 464, zzzz);
                                atributos.RemoveAt(0);
                                zzzz = zzzz + 10;
                            }
                            break;
                    case 4:
                            g.DrawRectangle(penJoin, 10, 146, 70, 100);
                            g.DrawString(tabla[px].ToString(), new Font("Verdana", 8, GraphicsUnit.Pixel), new SolidBrush(Color.Red), 11, 148);

                            int z5 = 168;
                            int c5 = Convert.ToInt32(cantidadAtri[0]);
                            cantidadAtri.RemoveAt(0);
                            for (int m = 0; m < c5; m++ )
                            {
                                g.DrawString(atributos[0].ToString(), new Font("Verdana", 8, GraphicsUnit.Pixel), new SolidBrush(Color.Blue), 13, z5);
                                atributos.RemoveAt(0);
                                z5 = z5 + 10;
                            }
                            break;
                    case 5:
                            g.DrawRectangle(penJoin, 159, 146, 70, 100);
                            g.DrawString(tabla[px].ToString(), new Font("Verdana", 8, GraphicsUnit.Pixel), new SolidBrush(Color.Red), 161, 148);

                            int z6 = 168;
                            int c6 = Convert.ToInt32(cantidadAtri[0]);
                            cantidadAtri.RemoveAt(0);
                            for (int m = 0; m < c6; m++ )
                            {
                                g.DrawString(atributos[0].ToString(), new Font("Verdana", 8, GraphicsUnit.Pixel), new SolidBrush(Color.Blue), 163, z6);
                                atributos.RemoveAt(0);
                                z6 = z6 + 10;
                            }
                            break;
                    case 6:
                            g.DrawRectangle(penJoin, 308, 146, 70, 100);
                            g.DrawString(tabla[px].ToString(), new Font("Verdana", 8, GraphicsUnit.Pixel), new SolidBrush(Color.Red), 310, 148);

                            int z7 = 168;
                            int c7 = Convert.ToInt32(cantidadAtri[0]);
                            cantidadAtri.RemoveAt(0);
                            for (int m = 0; m < c7; m++ )
                            {
                                g.DrawString(atributos[0].ToString(), new Font("Verdana", 8, GraphicsUnit.Pixel), new SolidBrush(Color.Blue), 312, z7);
                                atributos.RemoveAt(0);
                                z7 = z7 + 10;
                            }
                            break;
                    case 7:
                            g.DrawRectangle(penJoin, 457, 146, 70, 100);
                            g.DrawString(tabla[px].ToString(), new Font("Verdana", 8, GraphicsUnit.Pixel), new SolidBrush(Color.Red), 459, 148);

                            int z8 = 168;
                            int c8 = Convert.ToInt32(cantidadAtri[0]);
                            cantidadAtri.RemoveAt(0);
                            for (int m = 0; m < c8; m++ )
                            {
                                g.DrawString(atributos[0].ToString(), new Font("Verdana", 8, GraphicsUnit.Pixel), new SolidBrush(Color.Blue), 461, z8);
                                atributos.RemoveAt(0);
                                z8 = z8 + 10;
                            }
                            break;
                }
            }

            Imagen.Save(fichero);
        }
    }
}