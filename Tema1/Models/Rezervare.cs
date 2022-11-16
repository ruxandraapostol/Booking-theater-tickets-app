using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Tema1.Models
{
    public partial class Rezervare
    {
        public Guid RezervareId { get; set; }
        public Guid OrarId { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public bool? Student { get; set; }
        public bool? Pensionar { get; set; }
    }
}
