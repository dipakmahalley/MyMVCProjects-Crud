using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcDemo4_Crud.Models;
namespace mvcDemo4_Crud.Controllers
{
    public class productController : Controller
    {
        productDal pobj = new productDal();
        // GET: product
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ShowAllProducts()
        {            
            List<product> plist = new List<product>(pobj.GetAllProducts());
            return View(plist);
        }
        public ActionResult GetProduct(int? id)
        {
            product p = pobj.GetProductById(id);             
            return View(p);
        }
        public ActionResult AddProduct()
        {
            product p = new product();
            return View(p);
        }
        [HttpPost]
        public ActionResult AddProduct(product p)
        {
            pobj.AddNewProduct(p);
            return RedirectToAction ("ShowAllProducts", p);
        }
        public ActionResult RemoveProduct(int? id)
        {
            product p = pobj.GetProductById(id);                     
            return View(p);
        }

        [ActionName("RemoveProduct")]
        [HttpPost]
        public ActionResult DeleteProduct(int? id)
        {
            pobj.DeleteProduct(id);
            return RedirectToAction("ShowAllProducts",pobj);
        }
        public ActionResult Edit(int? id)
        {
            product p = pobj.GetProductById(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(product p)
        {
            pobj.UpdateProduct(p);
            return RedirectToAction("ShowAllProducts",pobj);
        }



    }
}