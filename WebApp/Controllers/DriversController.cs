using System;
using System.Collections.ObjectModel;
using System.Web.Mvc;
using Library.Classes;
using Library.Mapping;
using Library.Models;

namespace WebApp.Controllers
{
    public class DriversController : Controller
    {
        // GET: Drivers
        public ActionResult Index()
        {
            return View(new DriversMapper().SelectAll());
        }

        public ActionResult Detail(int id)
        {
            DriversMapper driverMapper = new DriversMapper();
            Drivers driver = driverMapper.SelectDriver(id);
            driver.State = States.FindForDriver(driver);
            driver.Team = Teams.FindForDriver(driver);

            driverMapper.GetPrevNextDriver(id, out int? prev, out int? next);
            ViewBag.Prev = prev;
            ViewBag.Next = next;

            ViewBag.IfTeam = User.Identity.IsAuthenticated && driver.Team != null && ButtonEnable.TeamsEdit(driver.Team.UserId, new UsersMapper().SelectUser(User.Identity.Name));

            return View(driver);
        }

        [Authorize(Roles = "Admin, Team")]
        public ActionResult Edit(int id)
        {
            DriversMapper driverMapper = new DriversMapper();
            Drivers driver = driverMapper.SelectDriver(id);
            driver.Team = Teams.FindForDriver(driver);

            if (!(User.IsInRole("Admin") || driver.Team != null && ButtonEnable.TeamsEdit(driver.Team.UserId, new UsersMapper().SelectUser(User.Identity.Name))))
                return RedirectToAction("Detail", "Drivers", new {id = id });

            driver.State = States.FindForDriver(driver);

            ViewBag.FirstName = driver.FirstName;
            ViewBag.LastName = driver.LastName;

            ViewBag.States = new StatesMapper().SelectAll();
            ((Collection<States>)ViewBag.States).Insert(0,new States().EmptyState());
            ViewBag.Teams = new TeamsMapper().SelectAll();
            ((Collection<Teams>)ViewBag.Teams).Insert(0, new Teams().EmptyTeam());

            return View(driver);
        }

        [Authorize(Roles = "Admin, Team")]
        [HttpPost]
        public ActionResult Edit(Drivers driver)
        {
            driver.Team = Teams.FindForDriver(driver);

            if (!(User.IsInRole("Admin") || driver.Team != null && ButtonEnable.TeamsEdit(driver.Team.UserId, new UsersMapper().SelectUser(User.Identity.Name))))
                return RedirectToAction("Detail", "Drivers", new { id = driver.Id });

            DriversMapper driverMapper = new DriversMapper();

            if (ModelState.IsValid)
            {
                driverMapper.Edit(driver);
                TempData["message-success"] = "Uživatel byl zmeněn";
                return RedirectToAction("Detail", "Drivers", new { id = driver.Id });
            }

            driver.Team = Teams.FindForDriver(driver);
            driver.State = States.FindForDriver(driver);

            Drivers driverFromDb = driverMapper.SelectDriver(driver.Id);

            ViewBag.FirstName = driverFromDb.FirstName;
            ViewBag.LastName = driverFromDb.LastName;

            ViewBag.States = new StatesMapper().SelectAll();
            ((Collection<States>)ViewBag.States).Insert(0, new States().EmptyState());
            ViewBag.Teams = new TeamsMapper().SelectAll();
            ((Collection<Teams>)ViewBag.Teams).Insert(0, new Teams().EmptyTeam());

            return View(driver);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            ViewBag.States = new StatesMapper().SelectAll();
            ((Collection<States>)ViewBag.States).Insert(0, new States().EmptyState());
            ViewBag.Teams = new TeamsMapper().SelectAll();
            ((Collection<Teams>)ViewBag.Teams).Insert(0, new Teams().EmptyTeam());

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Add(Drivers driver)
        {
            DriversMapper driverMapper = new DriversMapper();

            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                driverMapper.Insert(driver);
                TempData["message-success"] = "Uživatel byl přidán";
                return RedirectToAction("Index", "Drivers");
            }

            ViewBag.States = new StatesMapper().SelectAll();
            ((Collection<States>)ViewBag.States).Insert(0, new States().EmptyState());
            ViewBag.Teams = new TeamsMapper().SelectAll();
            ((Collection<Teams>)ViewBag.Teams).Insert(0, new Teams().EmptyTeam());

            return View(driver);
        }
    }
}