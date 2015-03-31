using System.Runtime.InteropServices;
using System.Web.Mvc;
using Demo.DependencyInjection.Service;
using Demo.DependencyInjection.Service.Interfaces;
using Demo.Infrastructure;

namespace Demo.DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly ISender _sender;
        private readonly ILogger _logger;

        public HomeController(ITeamService teamService, ISender sender, ILogger logger)
        {
            _teamService = teamService;
            _sender = sender;
            _logger = logger;
        }
        
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var teams = _teamService.GetTeams();
            _logger.Info("Загрузил список команд");
            return View(teams);
        }

        public ActionResult CreateTeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTeam(Team teamModel)
        {
            var team = _teamService.CreateTeam(teamModel.Title, teamModel.City);
            _sender.SendEmail("создан пользователь", team.Title, "n.kochnev@erc.ur.ru");
            return RedirectToAction("List");
        }
    }
}