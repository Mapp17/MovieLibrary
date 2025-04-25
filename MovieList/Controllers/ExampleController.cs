using Microsoft.AspNetCore.Mvc;

namespace MovieList.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return Content("Example controller, Index action");
        }

        public IActionResult About()
        {
            return Content("Example controller, About action");
        }

        public IActionResult Detail(int id)
        {
            return Content("Example controller, Detail action, id: " + id);
        }

        //public IActionResult List(string id = "All")
        //{
        //    return Content("Example controller, List action, id: " + id);
        //}

        public IActionResult List(string id = "All", int num = 1,
            string sortby = "Price")
        { return Content("id=" + id + ", page=" + num + ", sortby=" + sortby); }

    }
}