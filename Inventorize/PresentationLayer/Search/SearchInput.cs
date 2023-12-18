/*
 * Jacob Blair
 * CST150
 * Milestone 7
 * 12/11/23
 * This is my own work using other sources to help.
 * https://learn.microsoft.com/en-us/dotnet/csharp/linq/ 
 */
using Inventorize.Models;
using System.Data;

namespace Inventorize.PresentationLayer.Search
{
    /// <summary>
    /// the input form for a search that precedes the datagridview
    /// </summary>
    public partial class SearchInput : Form
    {
        //declare and initialize
        private Inventory Inventory { get; set; }
        private List<SearchResult> SearchResults = new List<SearchResult>();
        private Home HomeForm { get; set; }
        /// <summary>
        /// constructor which takes the inventory model and the root form
        /// </summary>
        /// <param name="inv"></param>
        /// <param name="parent"></param>
        public SearchInput(Inventory inv, Home parent)
        {
            InitializeComponent();
            Inventory = inv;
            HomeForm = parent;
        }

        /// <summary>
        /// click event for the seach button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBtnClickEvent(object sender, EventArgs e)
        {
            // was a search term entered?
            if (txtSearchTerm.Text != "")
            {
                // hide the error message
                lblError.Visible = false;
                // search incrementally based on which check boxes are ticked
                SearchNames();
                SearchDescriptions();
                SearchCosts();
                SearchQtys();
                SearchIngredients();
                // were results found?
                if (SearchResults.Count > 0)
                {
                    // create a new results form
                    SearchResults resultForm = new SearchResults(SearchResults, HomeForm);
                    // close self
                    this.Close();
                    // open results form after closing
                    resultForm.ShowDialog();
                }
                else
                {
                    // error for if there is no results
                    lblError.Text = "No results!";
                    lblError.Visible = true;
                }
            }
            else
            {
                // error for if a search term was not entered
                lblError.Text = "Please enter a search term!";
                lblError.Visible = true;
            }

        }
        /// <summary>
        /// search for names based on the search term
        /// </summary>
        private void SearchNames()
        {
            // is the checkbox ticked?
            if (chbName.Checked)
            {
                // cut down the scoop array to items that match the search term converted to lowercase
                // this is the actual search
                List<IceCreamScoop> results = Inventory.Scoops.Where((s) => s.ScoopName.ToLower().Contains(txtSearchTerm.Text.ToLower())).ToList();
                // loop through the results of the search
                foreach (IceCreamScoop scoop in results)
                {
                    // add the result to an array with the correct column
                    ResultAlreadyFound(scoop, SearchResult.ResultCol.Name);
                }
            }
        }
        /// <summary>
        /// search for descriptions based on the search term
        /// inherits comments from SearchNames
        /// </summary>
        private void SearchDescriptions()
        {
            if (chbDescription.Checked)
            {
                List<IceCreamScoop> results = Inventory.Scoops.Where((s) => s.Description.ToLower().Contains(txtSearchTerm.Text.ToLower())).ToList();
                foreach (IceCreamScoop scoop in results)
                {
                    ResultAlreadyFound(scoop, SearchResult.ResultCol.Description);
                }
            }
        }
        /// <summary>
        /// search for costs based on the search term
        /// inherits comments from SearchNames
        /// </summary>
        private void SearchCosts()
        {
            if (chbCost.Checked)
            {
                List<IceCreamScoop> results = Inventory.Scoops.Where((s) => s.Cost.ToString().ToLower().Contains(txtSearchTerm.Text.ToLower())).ToList();
                foreach (IceCreamScoop scoop in results)
                {
                    ResultAlreadyFound(scoop, SearchResult.ResultCol.Cost);
                }
            }
        }
        /// <summary>
        /// search for quantities based on the search term
        /// inherits comments from SearchNames
        /// </summary>
        private void SearchQtys()
        {
            if (chbQuantity.Checked)
            {
                List<IceCreamScoop> results = Inventory.Scoops.Where((s) => s.Quantity.ToString().ToLower().Contains(txtSearchTerm.Text.ToLower())).ToList();
                foreach (IceCreamScoop scoop in results)
                {
                    ResultAlreadyFound(scoop, SearchResult.ResultCol.Quantity);
                }
            }
        }
        /// <summary>
        /// search for ingredients based on the search term
        /// inherits comments from SearchNames
        /// </summary>
        private void SearchIngredients()
        {
            if (chbIngredients.Checked)
            {
                List<IceCreamScoop> results = Inventory.Scoops.Where((s) => string.Join(' ', s.Ingredients).ToLower().Contains(txtSearchTerm.Text.ToLower())).ToList();
                foreach (IceCreamScoop scoop in results)
                {
                    ResultAlreadyFound(scoop, SearchResult.ResultCol.Ingredients);
                }
            }
        }

        /// <summary>
        /// if multiple checkboxes were ticked, check if an ice cream scoop
        /// has already been found for a different column, and if so combine the search results
        /// </summary>
        /// <param name="scoop"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private SearchResult ResultAlreadyFound(IceCreamScoop scoop, SearchResult.ResultCol col)
        {
            // loop through previous found results
            foreach (SearchResult res in SearchResults)
            {
                // if the item in the loop matches the argument
                if (res.Scoop == scoop)
                {
                    // add the new column to the existing object
                    res.Column.Add(col);
                    // return the updated results
                    return res;
                }
            }
            // only runs if nothing was found in the loop
            // create new object for search result
            SearchResult newResult = new SearchResult(scoop, col);
            // add new result to the array
            SearchResults.Add(newResult);
            // return the result
            return newResult;
        }
        /// <summary>
        /// click event for the cancel button that closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtnClickEvent(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// when cancel or close button are closed, alert the home form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCloseEvent(object sender, FormClosedEventArgs e)
        {
            HomeForm.GlobalCancelCallback();
        }
    }
}
