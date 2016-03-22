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
    public partial class MostrarHistorial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                string cadenaConeccion = "server =(local); Database=Fase2_s2_2011; Integrated Security =SSPI;";
                SqlConnection Coneccion = new SqlConnection(cadenaConeccion);

                try
                {
                    Coneccion.Open();
                    string consultaNombre = "select idUsuario FROM Usuarios";
                    SqlDataAdapter AdapterNombre = new SqlDataAdapter(consultaNombre, cadenaConeccion);
                    DataSet ds = new DataSet();
                    AdapterNombre.Fill(ds, "Usuarios");

                    dropUsuario.DataSource = ds.Tables["Usuarios"].DefaultView;
                    dropUsuario.DataTextField = "idUsuario";
                    dropUsuario.DataValueField = "idUsuario";
                    dropUsuario.DataBind();
                    Coneccion.Close();
                }
                catch (Exception ex)
                {
                    Coneccion.Close();
                }
            }
        }

        protected void btnMostrarHistorial_Click(object sender, EventArgs e)
        {
            string cadenaConeccion = "server =(local); Database=Fase2_s2_2011; Integrated Security =SSPI;";
            SqlConnection Coneccion = new SqlConnection(cadenaConeccion);

            try
            {
                Coneccion.Open();
                string consultaNombre = "select fecha,Accion FROM HistorialUsuario where usuario_idUsuario = '" + dropUsuario.Text + "' ";
                SqlDataAdapter AdapterNombre = new SqlDataAdapter(consultaNombre, cadenaConeccion);
                DataSet ds = new DataSet();
                AdapterNombre.Fill(ds, "HistorialUsuario");
                GridHistorial.DataSource = ds.Tables["HistorialUsuario"].DefaultView;
                GridHistorial.DataBind();
                Coneccion.Close();
            }
            catch (Exception ex)
            {
                Coneccion.Close();
            }
        }

        protected void brnMostrarGeneral_Click(object sender, EventArgs e)
        {
            string cadenaConeccion = "server =(local); Database=Fase2_s2_2011; Integrated Security =SSPI;";
            SqlConnection Coneccion = new SqlConnection(cadenaConeccion);

            try
            {
                Coneccion.Open();
                string consultaNombre = "select usuario_idUsuario,fecha,Accion FROM HistorialUsuario";
                SqlDataAdapter AdapterNombre = new SqlDataAdapter(consultaNombre, cadenaConeccion);
                DataSet ds = new DataSet();
                AdapterNombre.Fill(ds, "HistorialUsuario");
                GridHistorial.DataSource = ds.Tables["HistorialUsuario"].DefaultView;
                GridHistorial.DataBind();
                Coneccion.Close();
            }
            catch (Exception ex)
            {
                Coneccion.Close();
            }
        }
    }
}