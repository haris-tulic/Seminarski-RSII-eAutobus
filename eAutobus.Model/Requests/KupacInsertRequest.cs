using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eAutobusModel.Requests
{
    public class KupacInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Ime { get; set; }
      
        [Required(AllowEmptyStrings = false)]
        public string Prezime { get; set; }
       
        [Required(AllowEmptyStrings =false)]
        
        public string BrojTelefona { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string AdresaStanovanja { get; set; }

        public int KartaID { get; set; }
        
        [Required]
        public string KorisnickoIme { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        public string PotvrdaPassworda { get; set; }
    }
}
