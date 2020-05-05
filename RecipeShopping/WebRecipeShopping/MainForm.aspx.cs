using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WebRecipeShopping
{
    public partial class MainForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server = tcp:milesaheadproduction.database.windows.net,1433; Initial Catalog = maprecipe; Persist Security Info = False; User ID = mapadmin; Password =3Cx^r^?Nmk^Mm^q@; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            {
                SqlCommand command = new SqlCommand("AddIngredient", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ingredient", TextBoxIng.Text);
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}