using Microsoft.AspNetCore.Mvc;
using Digitalisation_Funding.Interfaces;
using Digitalisation_Funding.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Digitalisation_Funding.Extensions;
using Digitalisation_Funding.Models;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Web;


namespace Digitalisation_Funding.Controllers
{
    public class CartController: Controller
    {
        //Private Property
        //----------------
        private Cart cart;
        //private readonly IHostEnvironment HostEnvironment; 
        private readonly IWebHostEnvironment HostEnvironment;       
        private IConfiguration Configuration;  

        //Constructor
        //-----------
        public CartController(Cart cartService, IConfiguration _config, IWebHostEnvironment _he)
        {
            cart = cartService;
            Configuration = _config;
            HostEnvironment = _he;
        }

        // Action Methods
        //---------------
        public ViewResult Index(string  ReturnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = ReturnUrl
            });

        }

        [HttpGet]
        public ViewResult AddToCart()
        {            
            FundingViewModel vm = new FundingViewModel();
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddToCart(PortfolioViewModel vm) 
        {           
            var ProjectMember = new ProjectMember()
            {
                FirstName = vm.ProjectMember.FirstName,
                LastName = vm.ProjectMember.LastName
            };        
                 
            try
            {               
                cart.AddItem(ProjectMember);     
                return Redirect("~/");
            }
            catch (System.Exception ex)
            {
                return Content("Error: " + ex.Message);           
            }
           
        }        
       
        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;           
        }

        [HttpPost]
        public IActionResult RemoveFromCart(ProjectMember pm) 
        {                       
            cart.RemoveMember(pm);            
            return Redirect("~/");

        } 
      
    }
}