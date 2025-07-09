using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class TeamController : Controller
    {

        private readonly ITeamService _teamService; //bunun amacı işte sadece burada okunabilir bir service olanı çağırıyor zaten buda ıteamservicede generice bağlanıyor genericde bizim kod tekrarını önlediğimiz crud yapısını içeriyor

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var values = _teamService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            TeamValidator validationRules = new TeamValidator(); //validasyonu çağır
            ValidationResult validationResult = validationRules.Validate(team); //gelen verileri kontrol et

            if (validationResult.IsValid)
            {
                _teamService.Insert(team);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

         
        }

        public IActionResult DeleteTeam(int id)
        {
            var result = _teamService.GetById(id);
            _teamService.Delete(result);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateTeam(int id)
        {
            var result = _teamService.GetById(id);
            return View(result);
        }


        [HttpPost]
        public IActionResult UpdateTeam(Team team)
        {
            TeamValidator validationRules = new TeamValidator();
            ValidationResult validationResult = validationRules.Validate(team);

            if (validationResult.IsValid)
            {
                _teamService.Update(team);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();



        }

    }
}
