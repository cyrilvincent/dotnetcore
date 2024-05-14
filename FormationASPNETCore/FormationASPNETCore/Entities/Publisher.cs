using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationASPNETCore.Entities
{
    public class Publisher : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public virtual ICollection<Media> Medias { get; set; } = [];

    }
}
