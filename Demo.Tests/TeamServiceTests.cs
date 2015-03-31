using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DependencyInjection.Service;
using Demo.DependencyInjection.Service.Interfaces;
using Demo.Infrastructure;
using NUnit.Framework;
using Rhino.Mocks;

namespace Demo.Tests
{
    [TestFixture]
    public class TeamServiceTests
    {
        private ITeamService _teamService;
        private ILogger _logger;
        private IRepository<Team> _teamRepository;

        [SetUp]
        public void Init()
        {
            _teamRepository = MockRepository.GenerateStub<IRepository<Team>>();
            _logger = MockRepository.GenerateStub<ILogger>();

            var teams = new List<Team>()
            {
                new Team { Id = 1, Title = "Спартак", City = Cities.Moscow },
                new Team { Id = 2, Title = "Зенит", City = Cities.StPeterburg },
                new Team { Id = 3, Title = "Урал", City = Cities.Ekb }
            };
            _teamRepository.Expect(x => x.Table).Return(teams.AsQueryable());

            _teamService = new TeamService(_teamRepository, _logger);
        }

        [Test]
        public void CanAddTeam()
        {
            const string teamTitle = "Динамо";
            const Cities teamCity = Cities.Moscow;

            var team = _teamService.CreateTeam(teamTitle, teamCity);

            Assert.IsNotNull(team);
            _teamRepository.AssertWasCalled(x=>x.Insert(Arg<Team>.Is.Anything));
            _logger.AssertWasCalled(x => x.Info(Arg<string>.Is.Anything));
        }

        [Test]
        public void CannotAddTeamWithNullTitle()
        {
            const Cities teamCity = Cities.Moscow;

            Assert.Throws<ArgumentNullException>(() => _teamService.CreateTeam(null, teamCity));
        }

        [Test]
        public void CanGetTeamById()
        {
            const int teamId = 1;

            var team = _teamService.GetTeamById(teamId);

            Assert.IsNotNull(team);
        }

        [Test]
        public void CannnotGetTeamByIdWithUnrealId()
        {
            const int teamId = 1000;

            var team = _teamService.GetTeamById(teamId);

            Assert.IsNull(team);
        }
    }
}