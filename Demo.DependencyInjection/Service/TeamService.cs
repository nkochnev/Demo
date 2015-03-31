using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Demo.DependencyInjection.Service.Interfaces;
using Demo.Infrastructure;

namespace Demo.DependencyInjection.Service
{
    public class TeamService : ITeamService
    {
        private readonly IRepository<Team> _teamRepository;
        private readonly ILogger _logger;

        public TeamService(IRepository<Team> teamRepository, ILogger logger)
        {
            _teamRepository = teamRepository;
            _logger = logger;
        }

        public Team CreateTeam(string teamName, Cities city)
        {
            if (teamName == null)
            {
                throw new ArgumentNullException("teamName");
            }

            var team = new Team();
            team.Title = teamName;
            team.City = city;

            _teamRepository.Insert(team);
            
            _logger.Info("Пользователь создан");
            return team;
        }

        public Team GetTeamById(int id)
        {
            return _teamRepository.Table.FirstOrDefault(x => x.Id == id);
        }

        public List<Team> GetTeams()
        {
            return _teamRepository.Table.ToList();
        }
    }
}