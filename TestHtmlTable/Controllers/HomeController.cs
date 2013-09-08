using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestHtmlTable.Models;

namespace TestHtmlTable.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult up(long Sort)
        {
            IEnumerable<Product> twoProducts = MvcApplication.products.OrderBy(a => a.Sort).
                Where(a => a.Sort >= Sort).Take(2);
            if (twoProducts != null && twoProducts.Count() == 2)
            {
                Product currentProduct = twoProducts.ToList()[0];
                Product preProduct = twoProducts.ToList()[1];

                long temp = preProduct.Sort;
                preProduct.Sort = currentProduct.Sort;
                currentProduct.Sort = temp;
            }
            IEnumerable<Product> products = MvcApplication.products.OrderByDescending(a => a.Sort);
            return View("HtmlTable", products);
        }

        [HttpPost]
        public ActionResult down(long Sort)
        {
            IEnumerable<Product> twoProducts = MvcApplication.products.OrderByDescending(a => a.Sort).
                Where(a => a.Sort <= Sort).Take(2);
            if (twoProducts != null && twoProducts.Count() == 2)
            {
                Product currentProduct = twoProducts.ToList()[0];
                Product nextProduct = twoProducts.ToList()[1];

                long temp = nextProduct.Sort;
                nextProduct.Sort = currentProduct.Sort;
                currentProduct.Sort = temp;
            }
            IEnumerable<Product> products = MvcApplication.products.OrderByDescending(a => a.Sort);
            return View("HtmlTable", products);
        }

        public ActionResult HtmlTable()
        {
            IEnumerable<Product> products = MvcApplication.products.OrderByDescending(a => a.Sort);
            return View("HtmlTable", products);
        }
    }
}
