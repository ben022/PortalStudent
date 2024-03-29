﻿using PortalStudent.Common.Domain;
using PortalStudent.MVC5.Models;
using PortalStudent.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalStudent.MVC5.Controllers
{
    public class SandwichController : Controller
    {
        // GET: Sandwich
        public ActionResult Index()
        {
            var adminRole = new AdminRole();

            return View(adminRole.GetSandwishes());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Sandwich sandwich)
        {
            var adminRole = new AdminRole();

            adminRole.AddSandwishInMenu(sandwich);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var adminRole = new AdminRole();

            var sandwichToUse = adminRole.GetSandwish(id);
            /*  var listIngredients = adminRole.GetIngredients().ToList<Ingredient>();
              var listIngredientsIn = sandwichToUse.Ingredients.ToList<Ingredient>();
              var listIngredientsOut = listIngredients.Except(listIngredientsIn);*/
            var listIngredientsOut = adminRole.GetMissingIngredients(sandwichToUse);
            return View(new ViewModel_Sandwich_Ingredients(sandwichToUse, listIngredientsOut));
        }


        [HttpPost]
        public ActionResult Edit(Sandwich sandwich)
        {
            var adminRole = new AdminRole();

            adminRole.EditSandwichInMenu(sandwich);

            return RedirectToAction("Index");
        }

    
        [HttpPost]
        public ActionResult addInSandwich(Sandwich sandwich,int selectedItem)
        {
            var adminRole = new AdminRole();

             var sandwich2 = adminRole.GetSandwish(sandwich.SandwichId);
             var ingredient = adminRole.GetIngredient(selectedItem);
            adminRole.ComposeSandwish(sandwich2, ingredient);

            return RedirectToAction("Edit", new { id = sandwich2.SandwichId });
        }




        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        //TODO Not in Benjamin
        [HttpPost]
        public ActionResult Details(int sandwichId)
        {
            var adminRole = new AdminRole();

            return View(adminRole.GetSandwish(sandwichId));
        }


        #region By Benjamin
        [HttpGet]
        public ActionResult Composition(int id)
        {
            var adminRole = new AdminRole();

            return View(adminRole.GetSandwish(id));
        }

        [HttpPost]
        public ActionResult Composition(Sandwich sandwich, ICollection<Ingredient> ingredients)
        {
            var adminRole = new AdminRole();

            adminRole.ComposeSandwish(sandwich, ingredients);

            return View("Index");
        }

        [HttpGet]
        public ActionResult DeleteIngredient(int SandwichId, int IngredientId)
        {
            var adminRole = new AdminRole();
            adminRole.removeIngredientInComposition(adminRole.GetSandwish(SandwichId), adminRole.GetIngredient(IngredientId));
            return RedirectToAction("Edit", new { id = SandwichId });
        }
        #endregion
    }
}