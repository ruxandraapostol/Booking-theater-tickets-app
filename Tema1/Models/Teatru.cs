using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Tema1.Models
{
    public partial class Teatru
    {
        public Teatru()
        {
            Piesa = new HashSet<Piesa>();
        }

        public Guid TeatruId { get; set; }
        public string Nume { get; set; }

        public virtual ICollection<Piesa> Piesa { get; set; }
    }
}
