using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace IRC
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["Users"] == null )
            {
                Application["Users"] = new ArrayList();
            }

            if (Application["Messages"] == null)
            {
                Application["Messages"] = new ArrayList();
            }

            if (! IsPostBack)
            {
                Session["User"] = Session.SessionID;
                LB_Pogovor.Items.Clear();
                LB_Uporabniki.Items.Clear();

                if (! ((ArrayList) Application["Users"]).Contains((string) Session["User"]))
                {
                    ((ArrayList) Application["Users"]).Add((string) Session["User"]);
                }

                for (int a = 0; a < ((ArrayList) Application["Users"]).Count; a++)
                {       
                    LB_Uporabniki.Items.Add((string) ((ArrayList)Application["Users"])[a]);  
                }

                for (int b = 0; b < ((ArrayList) Application["Messages"]).Count; b++)
                {
                    LB_Pogovor.Items.Add((string) ((ArrayList) Application["Messages"])[b]);
                }
            }
        }

        protected void B_Poslji_Click(object sender, EventArgs e)
        {
            LB_Pogovor.Items.Clear();
            string userId = (string) Session["User"];
            string message = TB_Sporocilo.Text;

            if (Session["User"] != null)
            {
                ((ArrayList)Application["Messages"]).Add(userId.Substring(0, 3) + ": " + message);
            }

            TB_Sporocilo.Text = "";
            for (int a = 0; a < ((ArrayList)Application["Messages"]).Count; a++)
            {
                LB_Pogovor.Items.Add((string)((ArrayList)Application["Messages"])[a]);
            }
        }

        protected void B_Osvezi_Click(object sender, EventArgs e)
        {
            LB_Pogovor.Items.Clear();
            LB_Uporabniki.Items.Clear();

            for (int a = 0; a < ((ArrayList)Application["Users"]).Count; a++)
            {
                LB_Uporabniki.Items.Add((string)((ArrayList)Application["Users"])[a]);
            }

            for (int b = 0; b < ((ArrayList)Application["Messages"]).Count; b++)
            {
                LB_Pogovor.Items.Add((string)((ArrayList)Application["Messages"])[b]);
            }
        }
    }
}