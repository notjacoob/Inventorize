/*
 * Jacob Blair
 * CST150
 * Milestone 7
 * 12/11/23
 * This is my own work.
 */
namespace Inventorize.BusinessLayer
{
    internal class Utilities
    {
        /// <summary>
        /// is a string a decimal? return the number and a bool if it was successful 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public (decimal, bool) IsDecimal(string val)
        {
            decimal d;
            if (decimal.TryParse(val, out d))
            {
                return (d, true);
            }
            else
            {
                return (-1m, false);
            }
        }
        /// <summary>
        /// is a string a int? return the number and a bool if it was successful 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public (int, bool) IsInt(string val)
        {
            int i;
            if (int.TryParse(val, out i))
            {
                return (i, true);
            }
            else
            {
                return (-1, false);
            }
        }

    }
}
