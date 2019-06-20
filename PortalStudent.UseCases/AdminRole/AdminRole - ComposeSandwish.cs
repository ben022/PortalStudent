using PortalStudent.Common.Domain;
using PortalStudent.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStudent.UseCases
{
    public partial class AdminRole
    {
        public bool ComposeSandwish(Sandwich sandwishToUse, ICollection<Ingredient> ingredientsToAdd)
        {
            foreach (var ing in ingredientsToAdd)
            {
                sandwishToUse.Ingredients.Add(ing);
            }

            using (var ctx = new PortalContext())
            {
                    if (!ctx.Sandwiches.Any(x => x.Name == sandwishToUse.Name))
                    {
                        throw new Exception(nameof(sandwishToUse));
                    }
                    ctx.Sandwiches.Attach(sandwishToUse);

                    ctx.SaveChanges();
                
            }

            return true;
        }

        public bool ComposeSandwish(Sandwich sandwishToUse,Ingredient ingredientsToAdd)
        {
            
            using (var ctx = new PortalContext())
            {
                if (!ctx.Sandwiches.Any(x => x.Name == sandwishToUse.Name))
                {
                    throw new Exception(nameof(sandwishToUse));
                }
                ctx.Sandwiches.Attach(sandwishToUse);

                if (ctx.Entry(ingredientsToAdd).State == EntityState.Detached)
                    ctx.Ingredients.Attach(ingredientsToAdd);

                sandwishToUse.Ingredients.Add(ingredientsToAdd);


                var state = ctx.Entry(sandwishToUse).State;
                var state2 = ctx.Entry(ingredientsToAdd).State;
                ctx.SaveChanges();

            }

            return true;
        }

        public bool removeIngredientInComposition(int SId, int IId)
        {

            return true;
        }
    }
}
