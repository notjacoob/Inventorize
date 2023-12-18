/*
 * Jacob Blair
 * CST150
 * 12/11/23
 * Milestone 7
 * This is my own work using outside resources to help.
 * https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to?pivots=dotnet-8-0
 * https://stackoverflow.com/questions/9110724/serializing-a-list-to-json
 * (https://learn.microsoft.com/en-us/dotnet/csharp/linq/
 */
using Inventorize.Models;
using System.Text.Json;

namespace Inventorize.BusinessLayer
{
    internal class JSON
    {
        /// <summary>
        /// convert an ice cream scoop to a json object
        /// </summary>
        /// <param name="scoop"></param>
        /// <returns></returns>
        public string ConvertToJSON(IceCreamScoop scoop)
        {
            return JsonSerializer.Serialize(scoop);
        }
        /// <summary>
        /// convert a list of ice cream scoops to a json list with a bunch of json objects in it
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string ConvertAllToJSON(List<IceCreamScoop> list)
        {
            return JsonSerializer.Serialize(list);
        }
        /// <summary>
        /// read a json file, convert it to a list of ice cream scoops, archive the conversion in a new text file, and return the new list
        /// Proper error handling in case a file or json parsing error occurs
        /// </summary>
        /// <param name="json"></param>
        /// <param name="textFilePath"></param>
        /// <returns></returns>
        public (List<IceCreamScoop>, bool, string) TextFileFromJSON(string jsonFilePath, string textFilePath)
        {
            try
            {
                // read the json file into a string
                string jsonRead = File.ReadAllText(jsonFilePath);
                // deserialize the json into an object using our custom constructor
                List<IceCreamScoop> items = JsonSerializer.Deserialize<List<IceCreamScoop>>(jsonRead);
                // archive the new list into a text file in case we want to overwrite
                File.WriteAllText(textFilePath, string.Join("\n", items.Select(s => s.ToData())));
                // return the list
                return (items, true, "");
            }
            catch (Exception e)
            {
                // in case theres a file error or json parsing error
                return (null, false, $"Error parsing JSON! {e.Message}");
            }
        }
        /// <summary>
        /// save a list of ice cream scoops to a json file
        /// handle errors in case the file has an error
        /// </summary>
        /// <param name="list"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public (bool, string) SaveConvertedJSON(List<IceCreamScoop> list, string path)
        {
            string converted = ConvertAllToJSON(list);
            try
            {
                File.WriteAllText(path, converted);
                return (true, "");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

    }
}
