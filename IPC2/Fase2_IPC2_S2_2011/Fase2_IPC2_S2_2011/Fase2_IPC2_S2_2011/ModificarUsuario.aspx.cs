using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Fase2_IPC2_S2_2011
{
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                string[] arrai = new string[6];

                string cadenaConeccion = "server=(local); Database=Fase2_s2_2011; Integrated Security =SSPI;";
                SqlConnection Coneccion = new SqlConnection(cadenaConeccion);
                SqlDataAdapter Adapter = new SqlDataAdapter();
                SqlDataReader leer;

                try
                {
                    Coneccion.Open();
                    Adapter.InsertCommand = new SqlCommand("select nombres,apellidos,telefono from Usuarios where idUsuario = '" + Session["Usuario"] + "'", Coneccion);
                    leer = Adapter.InsertCommand.ExecuteReader();
                    leer.Read();
                    arrai[0] = leer["nombres"].ToString();
                    arrai[1] = leer["apellidos"].ToString();
                    arrai[2] = leer["telefono"].ToString();
                    leer.Close();

                    Adapter.InsertCommand.ExecuteNonQuery();
                    Coneccion.Close();

                }
                catch (Exception ex)
                {
                }
                txtNombre.Text = arrai[0];
                txtApellido.Text = arrai[1];
                txtTelefono.Text = arrai[2];
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string cadenaConeccion = "server=(local); Database=Fase2_s2_2011; Integrated Security =SSPI;";
            SqlConnection Coneccion = new SqlConnection(cadenaConeccion);
            SqlDataAdapter Adapter = new SqlDataAdapter();

            try
            {
                Coneccion.Open();
                Adapter.InsertCommand = new SqlCommand("UPDATE Usuarios SET contraseñaUsuario=@contraseñaUsuario WHERE idUsuario = '" + Session["Usuario"] + "' ", Coneccion);
                Adapter.InsertCommand.Parameters.Add("@contraseñaUsuario", SqlDbType.NChar).Value = txtContraseñaNueva.Text;
                Adapter.InsertCommand.ExecuteNonQuery();
                Coneccion.Close();

                if (Session["TipoUsuario"].Equals("Usuario_Normal"))
                {
                    Historial("Modifico Contraseña");
                }
            }
            catch (Exception ex)
            {

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
    }
}