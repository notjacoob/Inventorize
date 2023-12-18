/*
 * Jacob Blair
 * CST150
 * 12/11/23
 * Milestone 7
 * This is my own work using the following resources to learn.
 * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum
 * https://learn.microsoft.com/en-us/dotnet/csharp/linq/
 */
using Inventorize.BusinessLayer;

namespace Inventorize.Models
{
    // this is the model class for the inventory itself. It contains the list of ice cream scoops and relevant search methods. TODO: UML for this
    public class Inventory
    {
        /// <summary>
        /// use to standardize the result of either increment or decrementing on the home form
        /// </summary>
        public enum IncDec
        {
            Inc,
            Dec
        }
        // declare and initialize
        public List<IceCreamScoop> Scoops { get; private set; }
        /// <summary>
        /// parametized constructor
        /// </summary>
        /// <param name="initial"></param>
        public Inventory(List<IceCreamScoop> initial)
        {
            Scoops = initial.ToList();
        }
        /// <summary>
        /// default constructor
        /// </summary>
        public Inventory()
        {
            Scoops = new List<IceCreamScoop>();
        }
        /// <summary>
        /// find a scoop in the list by a provided name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IceCreamScoop? Find(string name)
        {
            return Scoops.Find(s => s.ScoopName == name);
        }
        /// <summary>
        /// update the quantity of a provided scoop in a provided file
        /// </summary>
        /// <param name="scoop"></param>
        /// <param name="whichWay"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool UpdateQty(IceCreamScoop scoop, IncDec whichWay, TextFile file)
        {
            bool continueRun = false;
            // if it is specified to inc
            if (whichWay == IncDec.Inc)
            {
                scoop.Inc();
                continueRun = true;
            }
            // if it is specified to dec
            else if (whichWay == IncDec.Dec)
            {
                // dont go below 0 quantity
                if (scoop.Quantity > 0)
                {
                    scoop.Dec();
                    continueRun = true;
                }
            }
            // save the scoop to file if it was changed
            if (continueRun)
            {
                scoop.Save(file);
            }
            return continueRun;
        }

    }
}
