using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Xml;

namespace Fase2_IPC2_S2_2011
{
    public partial class Archivo : System.Web.UI.Page
    {
        String[] arrayDatos = new String[5];
        String[] arrayDatos2 = new String[5];

        protected void Page_Load(object sender, EventArgs e)
        {
            //fecha.Text = DateTime.Now.ToString();
            //fecha.Text = TimeZoneInfo.Local.ToString();
            //fecha.Text = DateTime.Now.ToString();
            FechaHora.Text = DateTime.Now.ToString();


            if (!Page.IsPostBack) {
                llenar_DropArchivos();
                Historial("Ingreso Aplicacion");
            }
        }
//Boton que Almacena Archivo por medio de File Upload
        protected void btnCargar_Click(object sender, EventArgs e)
        {
            Byte[] arrayByte = fuArchivos.FileBytes;

            string cadenaConeccion = "server=(local); Database=Fase2_s2_2011; Integrated Security =SSPI;";
            SqlConnection Coneccion = new SqlConnection(cadenaConeccion);
            SqlDataAdapter adaptador = new SqlDataAdapter();

            try
            {
                Coneccion.Open();
                adaptador.InsertCommand = new SqlCommand("INSERT INTO ArchivoXml VALUES(@nombreArchivo,@Archivo,@usuario_idUsuario)", Coneccion);
                adaptador.InsertCommand.Parameters.Add("@nombreArchivo", SqlDbType.NChar).Value = fuArchivos.FileName;
                adaptador.InsertCommand.Parameters.Add("@Archivo", SqlDbType.VarBinary).Value = arrayByte;
                adaptador.InsertCommand.Parameters.Add("@usuario_idUsuario", SqlDbType.NChar).Value = Session["Usuario"];
                adaptador.InsertCommand.ExecuteNonQuery();
                Coneccion.Close();
            }catch(Exception ex){
                Coneccion.Close();
            }

            llenar_DropArchivos();
        }

//Boton que Carga seleccionando archivo almacenado en la Base de Datos
        protected void btnCargar_Click1(object sender, EventArgs e)
        {
            byte[] archivoBit = new byte[0];
            string cadenaConeccion = "server=(local); Database=Fase2_s2_2011; Integrated Security =SSPI;";
            SqlConnection Coneccion = new SqlConnection(cadenaConeccion);
            SqlDataAdapter Adapter = new SqlDataAdapter();
            SqlDataReader leer;

            try
            {
                Coneccion.Open();
                Adapter.InsertCommand = new SqlCommand("select nombreArchivo,Archivo,usuario_idUsuario from ArchivoXml where nombreArchivo = '" + cargaArchivos.Text + "'", Coneccion);
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
                txtNombreArchivo.Text = arrayDatos[0];
                txtArea.Text = ContenidoArchivo;
                Historial("Cargar Archivo");

            }catch(Exception ex){
                Coneccion.Close();
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

                cargaArchivos.DataSource = ds.Tables["ArchivoXml"].DefaultView;
                cargaArchivos.DataTextField = "nombreArchivo";
                cargaArchivos.DataValueField = "nombreArchivo";
                cargaArchivos.DataBind();
                Coneccion.Close();
            }catch(Exception ex){
                Coneccion.Close();
            }
        }

//Boton que Verifica si el archivo existe si existe lo modifica si no lo guarda
        protected void Crear_Click(object sender, EventArgs e)
        {
            string nombreArch = txtNombreArchivo.Text;

            string cadenaConeccion = "server=(local); Database=Fase2_s2_2011; Integrated Security =SSPI;";
            SqlConnection Coneccion = new SqlConnection(cadenaConeccion);
            SqlDataAdapter Adapter = new SqlDataAdapter();
            SqlDataReader leer;

            try
            {
                Coneccion.Open();
                Adapter.InsertCommand = new SqlCommand("select nombreArchivo FROM ArchivoXml where nombreArchivo ='" +nombreArch+ "' ", Coneccion);
                leer = Adapter.InsertCommand.ExecuteReader();
                leer.Read();
                arrayDatos2[0] = leer["nombreArchivo"].ToString();
                leer.Close();

                Adapter.InsertCommand.ExecuteNonQuery();
                Coneccion.Close();

                crearArchivoAux(2);
            }
            catch (Exception ex)
            {
                Coneccion.Close();
                crearArchivoAux(1);
            }
        }


//Guarda Archivo creado en la aplicacion
        public void GuardarArchivoBD(String nombre, Byte[] datos){

            string cadenaConeccion = "server=(local); Database=Fase2_s2_2011; Integrated Security =SSPI;";
            SqlConnection Coneccion = new SqlConnection(cadenaConeccion);
            SqlDataAdapter adaptador = new SqlDataAdapter();

            try
            {
                Coneccion.Open();
                adaptador.InsertCommand = new SqlCommand("INSERT INTO ArchivoXml VALUES(@nombreArchivo,@Archivo,@usuario_idUsuario)", Coneccion);
                adaptador.InsertCommand.Parameters.Add("@nombreArchivo", SqlDbType.NChar).Value = nombre;
                adaptador.InsertCommand.Parameters.Add("@Archivo", SqlDbType.VarBinary).Value = datos;
                adaptador.InsertCommand.Parameters.Add("@usuario_idUsuario", SqlDbType.NChar).Value = Session["Usuario"];
                adaptador.InsertCommand.ExecuteNonQuery();
                Coneccion.Close();
                Historial("Almacenar Archivo");

            }
            catch (Exception ex)
            {
                Coneccion.Close();
            }

            llenar_DropArchivos();
        }

//Modifica archivo Guardado en la Base de Datos
        public void modificarArchivo(String nombre, Byte[] datos)
        {
            txtArea.Text = nombre;
            string cadenaConeccion = "server=(local); Database=Fase2_s2_2011; Integrated Security =SSPI;";
            SqlConnection Coneccion = new SqlConnection(cadenaConeccion);
            SqlDataAdapter Adapter = new SqlDataAdapter();

            try
            {
                Coneccion.Open();
                Adapter.InsertCommand = new SqlCommand("UPDATE ArchivoXml SET Archivo=@Archivo WHERE nombreArchivo= '" + nombre + "' ", Coneccion);
                Adapter.InsertCommand.Parameters.Add("@Archivo", SqlDbType.VarBinary).Value = datos;
                Adapter.InsertCommand.ExecuteNonQuery();
                Coneccion.Close();
                Historial("Modifiar Archivo");
            }
            catch (Exception ex)
            {

            }
        }

//Crea Archivo Auxiliar para almacenarlo en la Base de Datos
        public void crearArchivoAux(int m) {

            switch(m){
                case 1:
                ///Crear fichero
                        string fichero = MapPath("Archivo/" + "ArchivoAux" + ".XML");
                        string nombreFichero = txtNombreArchivo.Text + ".XML";
                        string textoFichero = txtArea.Text;
                        StreamWriter escribirFichero = new StreamWriter(fichero);
                        escribirFichero.WriteLine(textoFichero);
                        escribirFichero.Close();

                        string ficheroz = Path.GetFullPath("Archivo/ArchivoAux");

                        ///Leer Fichero para Almacenarlo en Base de Datos
                        string abrirFichero = Server.MapPath("Archivo/ArchivoAux.XML");
                        StreamReader leerFichero = new StreamReader(abrirFichero);
                        string contenido = leerFichero.ReadToEnd();
                        ASCIIEncoding codificador = new ASCIIEncoding();
                        Byte[] otrosDatos = codificador.GetBytes(contenido);
                        leerFichero.Close();

                        GuardarArchivoBD(nombreFichero, otrosDatos);
                    break;
                case 2:

                ///Modificar
                        string fichero2 = MapPath("Archivo/" + "ArchivoAux" + ".XML");
                        string nombreFichero2 = txtNombreArchivo.Text;
                        string textoFichero2 = txtArea.Text;
                        StreamWriter escribirFichero2 = new StreamWriter(fichero2);
                        escribirFichero2.WriteLine(textoFichero2);
                        escribirFichero2.Close();

                        ///Leer Fichero para Almacenarlo en Base de Datos
                        string abrirFichero2 = Server.MapPath("Archivo/ArchivoAux.XML");
                        StreamReader leerFichero2 = new StreamReader(abrirFichero2);
                        string contenido2 = leerFichero2.ReadToEnd();
                        ASCIIEncoding codificador2 = new ASCIIEncoding();
                        Byte[] otrosDatos2 = codificador2.GetBytes(contenido2);
                        leerFichero2.Close();

                        modificarArchivo(nombreFichero2, otrosDatos2);
                    break;          
            }
        }

        public void Historial(String Accion)
        {

            string cadenaConeccion = "server=(local); Database=Fase2_s2_2011; Integrated Security =SSPI;";
            SqlConnection Coneccion = new SqlConnection(cadenaConeccion);
            SqlDataAdapter adaptador = new SqlDataAdapter();

            try
            {
                Coneccion.Open();
                adaptador.InsertCommand = new SqlCommand("INSERT INTO HistorialUsuario VALUES(@usuario_idUsuario,@fecha,@Accion)", Coneccion);
                adaptador.InsertCommand.Parameters.Add("@usuario_idUsuario", SqlDbType.NChar).Value = Session["Usuario"];
                adaptador.InsertCommand.Parameters.Add("@fecha", SqlDbType.DateTime).Value = DateTime.Now.ToString();
                adaptador.InsertCommand.Parameters.Add("@Accion", SqlDbType.NChar).Value = Accion;
                adaptador.InsertCommand.ExecuteNonQuery();
                Coneccion.Close();
            }
            catch (Exception ex)
            {
                Coneccion.Close();
            }
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            ValidarXML(txtArea.Text);
        }

        public void ValidarXML(String mandado)
        {
            string fichero = MapPath("Archivo/" + "ArchivoAux" + ".XML");
            StreamWriter escribirFichero = new StreamWriter(fichero);
            escribirFichero.WriteLine(mandado);
            escribirFichero.Close();

            XmlTextReader rdr = new XmlTextReader(fichero);

            try
            {


                while (rdr.Read())
                {

                }
                
                StringBuilder sbMensaje = new StringBuilder();
                sbMensaje.Append("<script type='text/javascript'>");
                sbMensaje.AppendFormat("alert('{0}');", "Archivo Analisado Exitosamente");
                sbMensaje.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Exito", sbMensaje.ToString());

            }catch(Exception ex){

                rdr.Close();
                StringBuilder sbMensaje = new StringBuilder();
                sbMensaje.Append("<script type='text/javascript'>");
                sbMensaje.AppendFormat("alert('{0}');", "Archivo Con Error");
                sbMensaje.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", sbMensaje.ToString());

            }
            rdr.Close();
        }

    }
}