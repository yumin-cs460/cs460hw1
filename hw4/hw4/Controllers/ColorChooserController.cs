﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Diagnostics;

namespace hw4.Controllers
{
    public class ColorChooserController : Controller
    {
        // GET: ColorChooser
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ColorChooser()
        {
            ViewBag.hidden = "none";
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hexColor1">Color 1 in Hex input by user</param>
        /// <param name="hexColor2">Color 2 in Hex input by user</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ColorChooser(string hexColor1, string hexColor2)
        {

            //Hex color input from user.
            hexColor1 = Request.Form["inputColor1"];
            hexColor2 = Request.Form["inputColor2"];

            //Create input Color instance from HTML Hex
            Color color1 = ColorTranslator.FromHtml(hexColor1);
            Color color2 = ColorTranslator.FromHtml(hexColor2);

            //Check if user inputs are empty
            if(!(hexColor1 == null || hexColor2 == null))
            {
                ViewBag.hidden = "normal";
            }

            //Initial the four properties of result Color. 
            int newColorA = 0;
            int newColorR = 0;
            int newColorG = 0;
            int newColorB = 0;
       

            //Find the new color
            if(color1.A + color2.A >= 255)
            {
                newColorA = 255;
            }else
            {
                newColorA = color1.A + color2.A;
            }

            if(color1.R + color2.R >= 255)
            {
                newColorR = 255;
            }
            else
            {
                newColorR = color1.R + color2.R;
            }

            if (color1.G + color2.G >= 255)
            {
                newColorG = 255;
            }
            else
            {
                newColorG = color1.G + color2.G;
            }

            if (color1.B + color2.B >= 255)
            {
                newColorB = 255;
            }
            else
            {
                newColorB = color1.B + color2.B;
            }

            //Hex of new Color.
            Color newColor = Color.FromArgb(newColorA, newColorR, newColorG, newColorB);
            string newColorHex = ColorTranslator.ToHtml(newColor);

            //Ready to View
            ViewBag.color1 = hexColor1;
            ViewBag.color2 = hexColor2;
            ViewBag.newColor = newColorHex;
            
 
            return View();
        }
    }
}