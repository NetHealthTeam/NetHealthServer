using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Data.Entities
{
    [Table("Action")]
    public class Action
    {
        [Column("id")]

        public int Id { get; set; }
        [Column("name")]

        public string Name { get; set; }
        public List<Meal> Meals { get; set; }
        public List<User> Users { get; set; }
    }
}
