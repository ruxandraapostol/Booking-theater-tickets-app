using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Tema1.Models
{
    public partial class Orar
    {
        public Guid OrarId { get; set; }
        public Guid PiesaId { get; set; }
        public DateTime? DataOra { get; set; }
        public double? Pret { get; set; }

        public virtual Piesa Piesa { get; set; }
    }
}
