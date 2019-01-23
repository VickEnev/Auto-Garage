namespace AutoGarage.ViewModels
{
    public class PartsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Price} BGN.";
        }

        
    }
}
