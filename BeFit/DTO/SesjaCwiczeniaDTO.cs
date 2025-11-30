using BeFit.Models;

namespace BeFit.DTOs
{
    public class SesjaCwiczeniaDTO
    {
        public int Id { get; set; }
        public int SesjaId { get; set; }        
        public int CwiczenieId { get; set; }    
        public decimal CiezarKg { get; set; }       
        public int Serie { get; set; }          
        public int Powtorzenia { get; set; }    

        public SesjaCwiczeniaDTO() { }

        public SesjaCwiczeniaDTO(SesjaCwiczenia e)
        {
            Id = e.Id;
            SesjaId = e.SesjaId;
            CwiczenieId = e.CwiczenieId;
            CiezarKg = e.CiezarKg;
            Serie = e.Serie;
            Powtorzenia = e.Powtorzenia;
        }
    }
}