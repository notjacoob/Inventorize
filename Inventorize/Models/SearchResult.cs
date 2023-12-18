/*
 * Jacob Blair
 * CST150
 * Milestone 7
 * 12/11/23
 * This is my own work.
 */
namespace Inventorize.Models
{
    /// <summary>
    /// model class for a search result
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// enum that determines the column that a search result was found based on
        /// </summary>
        public enum ResultCol
        {
            Name,
            Description,
            Quantity,
            Cost,
            Ingredients
        }
        // declare and initialize
        public IceCreamScoop Scoop { get; set; }
        public List<ResultCol> Column { get; set; }
        /// <summary>
        /// constructor with predefined column
        /// </summary>
        /// <param name="scoop"></param>
        /// <param name="column"></param>
        public SearchResult(IceCreamScoop scoop, ResultCol column)
        {
            Scoop = scoop;
            Column = new List<ResultCol>
            {
                column
            };
        }
        /// <summary>
        /// constructor without a predefined column
        /// </summary>
        /// <param name="scoop"></param>
        public SearchResult(IceCreamScoop scoop) {
            Scoop = scoop;
            Column = new List<ResultCol>();
        }
    }
}
