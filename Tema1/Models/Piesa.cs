using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Tema1.Models
{
    public partial class Piesa
    {
        public Piesa()
        {
            Orar = new HashSet<Orar>();
        }

        public Guid PiesaId { get; set; }
        public Guid TeatruId { get; set; }
        public string Nume { get; set; }

        public virtual Teatru Teatru { get; set; }
        public virtual ICollection<Orar> Orar { get; set; }
    }
}
