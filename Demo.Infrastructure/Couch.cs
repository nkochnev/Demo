using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure
{
    /// <summary>
    /// Сущности - тренеры
    /// </summary>
    public class Couch
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public decimal Salary { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
