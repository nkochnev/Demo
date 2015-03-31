using System.Collections.Generic;

namespace Demo.Infrastructure
{
    /// <summary>
    /// Сущность - команда
    /// </summary>
    public class Team
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Cities City { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}