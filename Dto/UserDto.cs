using System.ComponentModel.DataAnnotations;

namespace Concert.Dto
{
    public class UserDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? City { get; set; }
        public string? MeansOfTransport { get; set; }
    }
}
