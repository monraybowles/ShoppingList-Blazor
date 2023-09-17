using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebClient.Pages
{
    public class IndexModel : PageModel
    {
        public readonly ApplicationDbContext _context;
        public readonly IShoppingListService _cardResolver;
        public IndexModel(ApplicationDbContext context, IShoppingListService cardResolver)
        {

            // Load Carn=d names data list
            _context = context;
            _cardResolver = cardResolver;
            ShopItems = context.ShopItems.Select(a =>
                                 new SelectListItem
                                 {
                                     Value = a.ItemName.ToString(),
                                     Text = a.ItemName
                                 }).ToList();
        }
        public List<SelectListItem> ShopItems { get; set; }


        public IList<ShoppingListDto> Shoplist { get; set; }  
        [BindProperty]
        public ShoppingListDto Shop { get; set; }
        public void OnGet()
        {
            //-- loads the list and CREDIT CARD TYPES
            Shoplist = Shoplist = Shoplist.ToList();
        }

        public RedirectToPageResult OnPost()
        {
            // check form field and trigger validations

            // TODO ADD A NICE MESSAGE FOR DUPLICATE ENTIRES FOUND -- encryption and decryption on card numbers
            if (!ModelState.IsValid)
            { 
                // ----------
               return RedirectToPage();
            }
            else
            {
                Shoplist = Shoplist = Shoplist.ToList();

                //Check for duplicate entires before inserting data 

                if (Shoplist.Where(x => x.ItemName == Shop.ItemName).ToList().Count == 0)
                {
                    //  todo  - encryption and decryption on card numbers

                    Shop.ItemsID = Guid.NewGuid();
                    Shop.ModifiedDate = DateTime.Now;
                   // _context.ShopItems.Add(Shop);
                    _context.SaveChanges();

                }
                else
                {

                    ModelState.AddModelError("CustomError", "Aready Exists");
                }
               
            }
            return RedirectToPage("./Index");
        }
        private RedirectToPageResult PageResult()
        {
            return PageResult();
        }

    }
}