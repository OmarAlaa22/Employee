using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("GovernateId")]
        public int GovernateId { get; set; }
        public Governorate Governate { get; set; }
        public List<Center> Centers { get; set; }
    }
}
