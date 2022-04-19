#nullable disable warnings
namespace DucatiWebApi.Model
{
    public class Motorcycle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }

        public string ImagePath { get; set; }
    }
}
