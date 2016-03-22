using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Fase2_IPC2_S2_2011
{
    public partial class CrearUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Page.IsValid){

                String correo = txtCorreo.Text;
                String contraseña = txtContraseña.Text;
                String nombre = txtNombre.Text;
                String apellido = txtApellido.Text;
                String direccion = txtDireccion.Text;
                String telefono = txtTelefono.Text;

                String opc = opcion.Text;

                String CadenaConeccion = "server =(local); Database=Fase2_s2_2011; Integrated Security =SSPI;";
                SqlConnection coneccion = new SqlConnection(CadenaConeccion);
                SqlDataAdapter adaptador = new SqlDataAdapter();


                coneccion.Open();
                adaptador.InsertCommand = new SqlCommand("INSERT INTO Usuarios VALUES(@idUsuario,@contraseñaUsuario,@nombres,@apellidos,@telefono);INSERT INTO RolUsuario VALUES(@tipoRol,@usuario_idUsuario)", coneccion);
                adaptador.InsertCommand.Parameters.Add("@idUsuario", SqlDbType.NChar).Value = correo;
                adaptador.InsertCommand.Parameters.Add("@contraseñaUsuario",SqlDbType.NChar).Value = contraseña;
                adaptador.InsertCommand.Parameters.Add("@nombres",SqlDbType.NChar).Value = nombre;
                adaptador.InsertCommand.Parameters.Add("@apellidos",SqlDbType.NChar).Value = apellido;
                adaptador.InsertCommand.Parameters.Add("@telefono",SqlDbType.NChar).Value = telefono;

                adaptador.InsertCommand.Parameters.Add("@tipoRol",SqlDbType.NChar).Value = opc;
                adaptador.InsertCommand.Parameters.Add("usuario_idUsuario", SqlDbType.NChar).Value = correo;

                adaptador.InsertCommand.ExecuteNonQuery();
                coneccion.Close();
            }
        }
    }
}