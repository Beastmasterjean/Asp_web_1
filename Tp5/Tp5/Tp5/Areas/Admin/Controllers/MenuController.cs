using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp5.Areas.Admin.ViewModels;
using Tp5.DataAccessLayer;

namespace Tp5.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        public IActionResult List()
        {
            DAL dal = new DAL();
            ListMenuViewModel viewModel = new ListMenuViewModel
            {
                menus = dal.MenuFactory.GetAll()
            };

            return View(viewModel);

        }
    }
}
