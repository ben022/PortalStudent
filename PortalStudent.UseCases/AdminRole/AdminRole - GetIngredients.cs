using PortalStudent.Common.Domain;
using PortalStudent.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStudent.UseCases
{
    public partial class AdminRole
    {
        public List<Ingredient> GetIngredients()
        {
            using (var ctx = new PortalContext())
            {
                return ctx.Ingredients.ToList();
            }
        }

        public List<Ingredient> GetMissingIngredients(Sandwich sandwich)
        {
            using (var ctx = new PortalContext())
            {
                var ingInSand = (from x in ctx.Sandwiches
                                where x.SandwichId == sandwich.SandwichId
                                select x.Ingredients).ToList();
                var alling = (from x in ctx.Ingredients
                              select x).ToList();

                var listOutSandwich = alling.Where(p => ingInSand[0].All(p2 => p2.IngredientId != p.IngredientId));
               
                return listOutSandwich.ToList();
            }
        }

    }
}
