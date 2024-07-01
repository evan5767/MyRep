using Microsoft.AspNetCore.Mvc;
using Sushi.Data.Interfaces;
using Sushi.ViewModels;

namespace Sushi.Controllers
{
    public class OffertController : Controller
    {
        private readonly IFood _foodRepository;

        public OffertController(IFood foodRep)
        {
            _foodRepository = foodRep;
        }

        public ViewResult Index()
        {
            var homeFoods = new OffertViewModel
            {
                FavFoods = _foodRepository.GetViewFoods
            };

            return View(homeFoods);
        }
    }
}
