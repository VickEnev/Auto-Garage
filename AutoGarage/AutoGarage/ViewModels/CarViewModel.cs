namespace AutoGarage.ViewModels
{
    public class CarViewModel
    {
        public int ID { get; set; }
        public string DRN { get; set; }
        public string ModelName { get; set; }

        public override string ToString()
        {
            return $"Reg.#: {DRN} / Vehicle Model: {ModelName}";
        }
    }
}
