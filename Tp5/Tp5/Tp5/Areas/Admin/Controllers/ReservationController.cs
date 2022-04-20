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
    public class ReservationController : Controller
    {
        public IActionResult List()
        {
            DAL dal = new DAL();
            ListReservationViewModel viewModel = new ListReservationViewModel
            {
                Reservations = dal.reservationFactory.GetAll()
            };

            return View(viewModel);
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
