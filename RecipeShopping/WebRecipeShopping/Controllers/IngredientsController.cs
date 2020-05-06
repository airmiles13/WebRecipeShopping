using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRecipeShopping.Models;

namespace WebRecipeShopping.Controllers
{
    public class IngredientsController : Controller
    {
        // GET: Ingredients
        public ActionResult IngredientManager()
        {

            List<Ingredient> results = new List<Ingredient>();
            SqlConnection connection = new SqlConnection("Server = tcp:milesaheadproduction.database.windows.net,1433; Initial Catalog = maprecipe; Persist Security Info = False; User ID = mapadmin; Password =3Cx^r^?Nmk^Mm^q@; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
            
            SqlCommand command = new SqlCommand("SELECT * FROM dbo.ingredients", connection);
            //command.CommandType = System.Data.CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@ingredient", TextBoxIng.Text);
            connection.Open();
            try
            {
                SqlDataReader sqlResult = command.ExecuteReader();
                
                while (sqlResult.Read())
                {
                    Ingredient result = new Ingredient();
                    result.id = sqlResult.GetInt32(0);
                    result.ingredient = sqlResult.GetString(1);
                    results.Add(result);
                }

            }
            finally
            {
                connection.Close();
            }

            return View(results);
        }

        [HttpPost]
        public ActionResult IngredientManager(Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                SqlConnection connection = new SqlConnection("Server = tcp:milesaheadproduction.database.windows.net,1433; Initial Catalog = maprecipe; Persist Security Info = False; User ID = mapadmin; Password =3Cx^r^?Nmk^Mm^q@; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
                SqlCommand command = new SqlCommand("addIngredient", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ingredient", ingredient.ingredient);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            return View();
        }

    }
}