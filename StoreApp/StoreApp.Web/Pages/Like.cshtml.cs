using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;

namespace StoreApp.Web.Pages
{
    public class LikeModel : PageModel
    {
        private IStoreRepository _repository;
        public LikeModel(IStoreRepository repository, Like likeService)
        {
            _repository = repository;
            Like = likeService;
        }
        public Like? Like { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(int Id)
        {
            var product = _repository.Products.FirstOrDefault(i => i.Id == Id);

            if(product != null)
            {
                Like?.AddItem(product, 1);
            }

            return RedirectToPage("/like");
        }

        public IActionResult OnPostRemove(int Id)
        {
            Like?.RemoveItem(Like.Items.First(p => p.Product.Id == Id).Product);
            return RedirectToPage("/Like");
        }
    }
}
