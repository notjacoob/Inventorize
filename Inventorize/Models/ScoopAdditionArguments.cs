/*
 * Jacob Blair
 * CST150
 * 12/11/23
 * Milestone 7
 * This is my own work.
 */
namespace Inventorize.Models
{
    public class ScoopAdditionArguments
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public string[] Ingredients { get; set; }
        public string Error { get; set; }


    }
}
