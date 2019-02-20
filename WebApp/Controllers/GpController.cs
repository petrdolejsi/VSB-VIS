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
    public class GpController : Controller
    {
        // GET: Gp
        public ActionResult Index()
        {
            return View(new GpMapper().SelectAll());
        }

        public ActionResult Detail(int id)
        {
            var gpMapper = new GpMapper();
            Gp gp = gpMapper.SelectGp(id);
            gp.State = States.FindForGp(gp);
            ViewBag.Name = gp.Name;

            gpMapper.GetPrevNextDriver(id, out int? prev, out int? next);
            ViewBag.Prev = prev;
            ViewBag.Next = next;

            ViewBag.IfGp = User.Identity.IsAuthenticated && ButtonEnable.GpEdit(gp.UserId, new UsersMapper().SelectUser(User.Identity.Name));

            return View(gp);
        }

        public ActionResult Classifications(int id)
        {
            var gpMapper = new GpMapper();
            var gp = gpMapper.SelectGp(id);
            ViewBag.Name = gp.Name;

            gpMapper.GetPrevNextDriver(id, out int? prev, out int? next);
            ViewBag.Prev = prev;
            ViewBag.Next = next;
            ViewBag.Id = id;

            Dictionary<int, Classification> classifications = new ClassificationMapper().SelectAll(id);

            ViewBag.IfGp = User.Identity.IsAuthenticated && ButtonEnable.GpEdit(gp.UserId, new UsersMapper().SelectUser(User.Identity.Name));

            return View(classifications);
        }

        [Authorize(Roles = "Admin, Gp")]
        public ActionResult Edit(int id)
        {
            GpMapper gpMapper = new GpMapper();
            Gp gp = gpMapper.SelectGp(id);

            if (!(User.IsInRole("Admin") || ButtonEnable.TeamsEdit(gp.UserId, new UsersMapper().SelectUser(User.Identity.Name))))
                return RedirectToAction("Detail", "Drivers", new { id = id });

            gp.State = States.FindForGp(gp);

            ViewBag.tName = gp.Name;

            ViewBag.States = new StatesMapper().SelectAll();
            ((Collection<States>)ViewBag.States).Insert(0, new States().EmptyState());

            return View(gp);
        }

        [Authorize(Roles = "Admin, Gp")]
        [HttpPost]
        public ActionResult Edit(Gp gp)
        {
            if (!(User.IsInRole("Admin") || ButtonEnable.TeamsEdit(gp.UserId, new UsersMapper().SelectUser(User.Identity.Name))))
                return RedirectToAction("Detail", "Drivers", new { id = gp.Id });

            GpMapper gpMapper = new GpMapper();

            if (ModelState.IsValid)
            {
                //gpMapper.Edit(team);
                TempData["message-success"] = "Gp byla zmeněna";
                return RedirectToAction("Detail", "Teams", new { id = gp.Id });
            }

            gp.State = States.FindForGp(gp);

            ViewBag.Name = gp.Name;

            ViewBag.States = new StatesMapper().SelectAll();
            ((Collection<States>)ViewBag.States).Insert(0, new States().EmptyState());

            return View(gp);
        }

        [Authorize(Roles = "Admin, Gp")]
        public ActionResult ClassificationsEdit(int id)
        {
            GpMapper gpMapper = new GpMapper();
            Gp gp = gpMapper.SelectGp(id);

            if (!(User.IsInRole("Admin") || ButtonEnable.GpEdit(gp.UserId, new UsersMapper().SelectUser(User.Identity.Name))))
                return RedirectToAction("Classifications", "Gp", new { id = id });

            gp.State = States.FindForGp(gp);

            ViewBag.Name = gp.Name;
            ViewBag.Id = id;

            ViewBag.Points = new PointsMapper().SelectAll();

            ViewBag.Classifications = new ClassificationMapper().SelectAll(id);

            return View(new DriversMapper().SelectAll());
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Gp")]
        public ActionResult ClassificationsEdit(int id, int[] item, int[] driver)
        {
            var classificationMapper = new ClassificationMapper();

            try
            {
                foreach (var row in item)
                {
                    var rowId = Array.IndexOf(item, row);

                    var classification = classificationMapper.SelectGpDriver(id, driver[rowId]);

                    if (row > 0)
                    {
                        if (classification == null)
                        {
                            classificationMapper.Insert(id, driver[rowId], row);
                        }
                        else
                        {
                            classificationMapper.Edit(id, driver[rowId], row);
                        }
                    }
                    
                }
            }
            catch (Exception)
            {
                TempData["message-error"] = "Vyskytla se chyba";
                return RedirectToAction("Classifications", "Gp", new { id = id });
            }

            TempData["message-success"] = "Výslekdy byly zmeněny";
            return RedirectToAction("Classifications", "Gp", new {id = id});
        }
    }
}