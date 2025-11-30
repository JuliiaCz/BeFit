using BeFit.Models;

namespace BeFit.DTOs
{
    public class SesjaDTO
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public SesjaDTO() { }

        public SesjaDTO(Sesja sesja)
        {
            Id = sesja.Id;
            Start = sesja.Start;
            End = sesja.End;
        }
    }
}
