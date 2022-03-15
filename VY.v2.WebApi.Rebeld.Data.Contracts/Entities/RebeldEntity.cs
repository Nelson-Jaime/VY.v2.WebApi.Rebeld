using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VY.v2.WebApi.Rebeld.Data.Contracts.Entities
{
    public class RebeldEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Planet { get; set; }
        public DateTime Created { get; set; }
    }
}
