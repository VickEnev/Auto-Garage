namespace AutoGarage.ViewModels
{
    public class CarModelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
