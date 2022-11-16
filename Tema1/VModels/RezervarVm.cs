using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tema1.VModels
{
    public class RezervarVm
    {
        public List<DropDownItem> Teatre { get; set; }
        public List<DropDownItem> Piese { get; set; }
        public List<DropDownItem> Orare { get; set; }

        [Display(Name = "Teatru")]
        [Required(ErrorMessage = "Este necesara selectia teatrului pentru a putea face rezervarea.")]
        public Guid TeatruAles { get; set; }
 
        [Display(Name = "Piesa de teatru")]
        [Required(ErrorMessage = "Este necesara selectia piesei de teatru pentru a putea face rezervarea.")]
        public Guid PiesaAleasa { get; set; }


        [Display(Name = "Data si ora piesei de teatru")]
        [Required(ErrorMessage = "Este necesara selectia datei si orei piesei de teatru pentru a putea face rezervarea.")]
        public Guid OrarAles { get; set; }

        [Display(Name = "Nume")]
        [Required(ErrorMessage = "Este necesara completarea numelui pentru a putea face rezervarea.")]
        public string Nume { get; set; }
        
        [Display(Name = "Prenume")]
        [Required(ErrorMessage = "Este necesara completarea numelui pentru a putea face rezervarea.")]
        public string Prenume { get; set; }
        
        [Display(Name = "Adresa de email")]
        [Required(ErrorMessage = "Este necesara completarea adresei de email pentru a putea face rezervarea.")]
        public string Email { get; set; }
        
        [Display(Name = "Esti student?")]
        public bool Student { get; set; }
        
        [Display(Name = "Esti pensionar?")]
        public bool Pensionar { get; set; }


        [Display(Name = "Pretul final")]
        public double PretFinal { get; set; }
        public double PretInitial { get; set; }
    }
}
