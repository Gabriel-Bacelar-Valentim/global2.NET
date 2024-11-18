using System.ComponentModel.DataAnnotations.Schema;

namespace global2.NET.Database.Models
{
    [Table("usuario")]
    public class PrincipalUser
    {
        public long IdUsua { get; set; }
        public string NomeUsua { get; set; }
        public string EmailUsua { get; set; }
        public string SenhaUsua { get; set; }

        public IncentiveScore? IncentiveScore { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<ContactNumber> ContactNumbers { get; set; } = new List<ContactNumber>();
        public ICollection<Device> Devices { get; set; } = new List<Device>();
    }
}