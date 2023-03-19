using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.Models
{
    public class VisitedHistory
    {
        public Guid Id { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<Furniture> LastVisited { get; set; }
    }
}
