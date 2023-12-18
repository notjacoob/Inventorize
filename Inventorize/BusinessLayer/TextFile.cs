/*
 * Jacob Blair
 * CST150
 * Milestone 7
 * 12/11/23
 * This is my own work using outside resources to learn.
 * https://www.w3schools.com/cs/cs_switch.php
 */

using Inventorize.Models;

namespace Inventorize.BusinessLayer
{
    public class TextFile
    {
        // declare attributes
        public string Path { get; set; }
        public List<string> Lines { get; set; }

        // constructor
        // move the exception handling up to the presentation layer so that it can be displayed properly
        public TextFile(string path)
        {
            Path = path;
            Load();
        }
        /// <summary>
        /// overwrites the given text file with the provided text, and then loads it
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        public TextFile(string path, string text)
        {
            Path = path;
            File.WriteAllText(path, text);
            Load();
        }
        // load the file lines, private because we don't want forms randomly doing this since its so slow
        private void Load()
        {
            Lines = File.ReadAllLines(Path).ToList();
        }
        /// <summary>
        /// find the provided scoop in the array and update it
        /// if its not there, add it
        /// </summary>
        /// <param name="scoop"></param>
        public void UpdateScoop(IceCreamScoop scoop)
        {
            // flag to check if the array was actually updated
            bool updated = false;
            // loop through every line in the file
            for (int i = 0; i < Lines.Count; i++)
            {
                // convert text line to ice cream scoop
                IceCreamScoop foundScoop = ToScoop(Lines[i]);
                // if the scoop found in the array matches the one provided
                if (foundScoop.ScoopName == scoop.ScoopName)
                {
                    // update the array
                    Lines[i] = scoop.ToData();
                    // mark that the update happened
                    updated = true;
                }
            }
            if (!updated)
            {
                Lines.Add(scoop.ToData()); // add to list
            }
        }
        /// <summary>
        /// convert text line to ice cream scoop instance
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public IceCreamScoop ToScoop(string line)
        {
            // declare and initialize variables that will store data from our file
            string flavorName = "";
            string flavorDescription = "";
            string scoopQuantity = "";
            string scoopCost = "";
            string ingredientsList = "";

            // track how many iterations have occurred
            int iterator = 0;
            // split the line by it's predetermined separator
            string[] split = line.Split(";");
            // loop through the separated strings from the line 
            foreach (string item in split)
            {
                // since the lines from the file will always be ordered in the same way, we can simply check
                // the iterator to see which attribute we are working with
                // and then assign the values to the variable that it corresponds to
                /*
                 * 0 = name
                 * 1 = description
                 * 2 = quantity
                 * 3 = cost
                 * 4 = ingredients
                 */
                switch (iterator)
                {
                    case 0:
                        flavorName = item;
                        // loop through func result to add to combo box
                        break;
                    case 1:
                        flavorDescription = item;
                        break;
                    case 2:
                        scoopQuantity = item;
                        break;
                    case 3:
                        scoopCost = item;
                        break;
                    case 4:
                        ingredientsList = item;
                        break;
                }
                // increment the iterator
                iterator++;
            }
            // data should already be checked before this is run                 vv replace newlines with a safe marker (stolen from HTML)
            return new IceCreamScoop(flavorName, decimal.Parse(scoopCost), flavorDescription.Replace("<br>", "\n"), int.Parse(scoopQuantity), ingredientsList.Split(", "));
        }
        /// <summary>
        /// convert lines array to an array of ice cream scoops
        /// </summary>
        /// <returns></returns>
        public List<IceCreamScoop> ToScoops()
        {
            int len = Lines.Count;
            IceCreamScoop[] scoops = new IceCreamScoop[len];
            int bigIter = 0;
            foreach (string rawItem in Lines)
            {
                scoops[bigIter] = ToScoop(rawItem);
                bigIter++;
            }
            return scoops.ToList();
        }
        /// <summary>
        /// remove scoop from lines array and save file
        /// </summary>
        /// <param name="scoop"></param>
        public void Remove(IceCreamScoop scoop)
        {
            Lines.Remove(scoop.ToData());
            Save();
        }
        /// <summary>
        /// save the file if it wasn't empty and was actually loaded
        /// </summary>
        public void Save()
        {
            // dont save the file if it was never loaded or is empty
            if (Lines.Count > 0)
            {
                // write the lines array to the file
                File.WriteAllText(Path, string.Join("\n", Lines));
            }
        }
    }

}
