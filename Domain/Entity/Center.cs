using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Center
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City City { get; set; }
    }
}