using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fase2_IPC2_S2_2011
{
    public partial class GestionarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TipoUsuario"].Equals("Usuario_Normal"))
                {
                    Link1.Visible = false;
                }
            }
        }
    }
}