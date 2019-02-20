using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Classes;
using Library.Mapping;
using Library.Models;

namespace WebApp.Controllers
{
    public class TeamsController : Controller
    {
        // GET: Teams
        public ActionResult Index()
        {
            return View(new TeamsMapper().SelectAll());
        }

        public ActionResult Detail(int id)
        {
            TeamsMapper teamsMapper = new TeamsMapper();
            Teams team = teamsMapper.SelectTeam(id);
            team.State = States.FindForTeam(team);
            team.Manufacturer = Manufacturers.FindForTeam(team);

            teamsMapper.GetPrevNextDriver(id, out int? prev, out int? next);
            ViewBag.Prev = prev;
            ViewBag.Next = next;

            ViewBag.IfTeam = User.Identity.IsAuthenticated && ButtonEnable.TeamsEdit(team.UserId, new UsersMapper().SelectUser(User.Identity.Name));

            return View(team);
        }

        [Authorize(Roles = "Admin, Team")]
        public ActionResult Edit(int id)
        {
            TeamsMapper teamsMapper = new TeamsMapper();
            Teams team = teamsMapper.SelectTeam(id);

            if (!(User.IsInRole("Admin") || ButtonEnable.TeamsEdit(team.UserId, new UsersMapper().SelectUser(User.Identity.Name))))
            {
                TempData["message-error"] = "Nemáte oprávnění provádět tyto změny";
                return RedirectToAction("Detail", "Teams", new { id = team.Id });
            }

            team.State = States.FindForTeam(team);
            team.Manufacturer = Manufacturers.FindForTeam(team);

            ViewBag.Name = team.Name;

            ViewBag.States = new StatesMapper().SelectAll();
            ((Collection<States>)ViewBag.States).Insert(0, new States().EmptyState());
            ViewBag.Manufacturers = new ManufacturersMapper().SelectAll();
            ((Collection<Manufacturers>)ViewBag.Manufacturers).Insert(0, new Manufacturers().EmptyManufacturer());

            ViewBag.IfTeam = User.Identity.IsAuthenticated && ButtonEnable.TeamsEdit(team.UserId, new UsersMapper().SelectUser(User.Identity.Name));

            return View(team);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Team")]
        public ActionResult Edit(Teams team)
        {
            TeamsMapper teamsMapper = new TeamsMapper();
            Teams teamFromDb = teamsMapper.SelectTeam(team.Id);

            if (!(User.IsInRole("Admin") || ButtonEnable.TeamsEdit(teamFromDb.UserId, new UsersMapper().SelectUser(User.Identity.Name))))
            {
                TempData["message-error"] = "Nemáte oprávnění provádět tyto změny";
                return RedirectToAction("Detail", "Teams", new { id = team.Id });
            }

            if (ModelState.IsValid)
            {
                teamsMapper.Edit(team);
                TempData["message-success"] = "Tým byl zmeněn";
                return RedirectToAction("Detail", "Teams", new { id = team.Id });
            }

            TempData["message-error"] = "Při zpracování se stala chyba";

            team.State = States.FindForTeam(team);
            team.Manufacturer = Manufacturers.FindForTeam(team);

            ViewBag.Name = team.Name;

            ViewBag.States = new StatesMapper().SelectAll();
            ((Collection<States>)ViewBag.States).Insert(0, new States().EmptyState());
            ViewBag.Manufacturers = new ManufacturersMapper().SelectAll();
            ((Collection<Manufacturers>)ViewBag.Manufacturers).Insert(0, new Manufacturers().EmptyManufacturer());

            return View(team);
        }
    }
}