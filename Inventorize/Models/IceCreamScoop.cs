/*
 * Jacob Blair
 * CST150
 * Milestone 7
 * 12/11/23
 * This is my own work using the following resources.
 * https://stackoverflow.com/questions/23017716/json-net-how-to-deserialize-without-using-the-default-constructor 
 */

using Inventorize.BusinessLayer;
using System.Text.Json.Serialization;

namespace Inventorize.Models
{
    public class IceCreamScoop
    {
        // declare attributes
        public string ScoopName { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public string[] Ingredients { get; set; }
        public string FormattedIngredients { get; private set; }
        public string Description { get; set; }
        /// <summary>
        /// constructor that takes attributes. no default constructor because we cant have this object without added data since its saved to a file
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="description"></param>
        /// <param name="qty"></param>
        /// <param name="ingredients"></param>
        public IceCreamScoop(string name, decimal cost, string description, int qty, string[] ingredients)
        {
            this.ScoopName = name;
            this.Cost = cost;
            this.Ingredients = ingredients;
            this.FormattedIngredients = string.Join(", ", ingredients);
            this.Description = description;
            this.Quantity = qty;
        }
        /// <summary>
        /// constructor with annotation and differently named variables for JSON deserialization
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="description"></param>
        /// <param name="qty"></param>
        /// <param name="ingredients"></param>
        [JsonConstructor]
        public IceCreamScoop(string scoopName, decimal cost, string description, int quantity, string[] ingredients, string formattedIngredients)
        {
            this.ScoopName = scoopName;
            this.Cost = cost;
            this.Ingredients = ingredients;
            this.FormattedIngredients = string.Join(", ", ingredients);
            this.Description = description;
            this.Quantity = quantity;
            this.FormattedIngredients = formattedIngredients;
        }
        /// <summary>
        /// increment the qty
        /// </summary>
        public void Inc()
        {
            Quantity++;
        }
        /// <summary>
        /// decrement the qty
        /// </summary>
        public void Dec()
        {
            Quantity--;
        }
        /// <summary>
        /// save this scoop to the file
        /// </summary>
        /// <param name="file"></param>
        public void Save(TextFile file)
        {
            try
            {
                // update the scoop in the file object array
                file.UpdateScoop(this);
                // save the actual file
                file.Save();
            }
            catch (IOException ex) // incase there are issues saving or reading the file 
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// convert the scoop to the format that our file stores
        /// </summary>
        /// <returns></returns>
        public string ToData()
        {
            // be sure again that there is no line break
            return $"{ScoopName};{Description.ReplaceLineEndings("<br>")};{Quantity};{Cost};{FormattedIngredients}";
        }
        /// <summary>
        /// adapt all of the properties in this object to the properties in the provided object
        /// </summary>
        /// <param name="adaptTo"></param>
        public void Adapt(IceCreamScoop adaptTo)
        {
            this.ScoopName = adaptTo.ScoopName;
            this.Cost = adaptTo.Cost;
            this.Quantity = adaptTo.Quantity;
            this.Description = adaptTo.Description;
            this.Ingredients = adaptTo.Ingredients;
            this.FormattedIngredients = string.Join(", ", this.Ingredients);
        }

    }
}
