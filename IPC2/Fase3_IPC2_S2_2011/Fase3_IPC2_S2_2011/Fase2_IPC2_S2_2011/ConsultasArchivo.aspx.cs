using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace Fase2_IPC2_S2_2011
{
    public partial class ConsultasArchivo : System.Web.UI.Page
    {
        String[] arrayDatos = new String[5];
        String[] arrayDatos2 = new String[5];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                llenar_DropArchivos();
            }
        }

        //Llena el Drop con los Archivos de cada Usuario
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

                dropArchivos.DataSource = ds.Tables["ArchivoXml"].DefaultView;
                dropArchivos.DataTextField = "nombreArchivo";
                dropArchivos.DataValueField = "nombreArchivo";
                dropArchivos.DataBind();
                Coneccion.Close();
            }
            catch (Exception ex)
            {
                Coneccion.Close();
            }
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            byte[] archivoBit = new byte[0];
            string cadenaConeccion = "server=(local); Database=Fase2_s2_2011; Integrated Security =SSPI;";
            SqlConnection Coneccion = new SqlConnection(cadenaConeccion);
            SqlDataAdapter Adapter = new SqlDataAdapter();
            SqlDataReader leer;

            try
            {
                Coneccion.Open();
                Adapter.InsertCommand = new SqlCommand("select nombreArchivo,Archivo,usuario_idUsuario from ArchivoXml where nombreArchivo = '" + dropArchivos.Text + "'", Coneccion);
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
                txtNombre.Text = arrayDatos[0];
                txtEditor.Text = ContenidoArchivo;
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

        public void crearPrueba(String mandado)
        {
            string fichero = MapPath("Archivo/" + "ArchivoAux" + ".XML");
            StreamWriter escribirFichero = new StreamWriter(fichero);
            escribirFichero.WriteLine(mandado);
            escribirFichero.Close();
        }

        protected void txtEditor_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnAceptar_Click1(object sender, EventArgs e)
        {
            crearPrueba(txtEditor.Text);

            EditorConsulta.Text = "";

            XPathNavigator navegador;
            XPathDocument documento;
            XPathNodeIterator iterador;
            XPathExpression exprecion;

            string exp = txtConsulta.Text;

            string fichero = MapPath("Archivo/" + "ArchivoAux" + ".XML");
            documento = new XPathDocument(fichero);
            navegador = documento.CreateNavigator();
            exprecion = navegador.Compile(exp+"/node()");
            iterador = navegador.Select(exprecion);

            while (iterador.MoveNext())
            {
                EditorConsulta.Text = EditorConsulta.Text + iterador.Current.Value+"\n";   
            }
        }
    }
}