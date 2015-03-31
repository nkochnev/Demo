using System.Collections.Generic;
using Demo.Infrastructure;

namespace Demo.DependencyInjection.Service.Interfaces
{
    public interface ITeamService
    {
        Team CreateTeam(string teamName, Cities city);

        Team GetTeamById(int id);

        List<Team> GetTeams();
    }
}