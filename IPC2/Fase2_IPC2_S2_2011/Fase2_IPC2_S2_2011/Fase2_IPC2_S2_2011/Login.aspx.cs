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
    public partial class Login : System.Web.UI.Page
    {

        String [] arrayDatos = new String[5];

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            //if(Page.IsValid){


                String usuario = txtUsuario.Text;
                String contraseña = txtContraseña.Text;

                string cadenaConeccion = "server=(local); Database=Fase2_s2_2011; Integrated Security =SSPI;";
                SqlConnection Coneccion = new SqlConnection(cadenaConeccion);
                SqlDataAdapter Adapter = new SqlDataAdapter();
                SqlDataReader leer;

                try
                {
                    Coneccion.Open();
                    Adapter.InsertCommand = new SqlCommand("select idRolUsuario,tipoRol,usuario_idUsuario,contraseñaUsuario from RolUsuario inner join Usuarios ON Usuarios.idUsuario = RolUsuario.usuario_idUsuario where usuario_idUsuario = '" + usuario + "' ", Coneccion);
                    leer = Adapter.InsertCommand.ExecuteReader();
                    leer.Read();
                    arrayDatos[0] = leer["idRolUsuario"].ToString();
                    arrayDatos[1] = leer["tipoRol"].ToString();
                    arrayDatos[2] = leer["usuario_idUsuario"].ToString();
                    arrayDatos[3] = leer["contraseñaUsuario"].ToString();
                    leer.Close();


                    Adapter.InsertCommand.ExecuteNonQuery();
                    Coneccion.Close();

                    if (usuario.Equals(arrayDatos[2]) && contraseña.Equals(arrayDatos[3]))
                    {
                        Session["TipoUsuario"] = arrayDatos[1];
                        Session["Usuario"] = arrayDatos[2];

                        Response.Redirect("Home.aspx");
                        
                    }
                    else
                    {
                        labelMensaje.Text = "Contraseña Equivocada";
                    }
                }
                catch (Exception ex)
                {
                    labelMensaje.Text = "El Usuario no Existe";
                    Coneccion.Close();
                }

                //if (usuario.Equals(arrayDatos[2]) && contraseña.Equals(arrayDatos[3]))
                //{
                //    Session["TipoUsuario"] = arrayDatos[1];
                //    Session["Usuario"] = arrayDatos[2];

                //    //Response.Redirect("CrearUsuario.aspx");
                //    Response.Redirect("Archivo.aspx");
                //}
                //else
                //{
                //    txtPrueba.Text = "Usuario o Contraseña Erroneas";
                //}
 
            //}
        }
    }
}