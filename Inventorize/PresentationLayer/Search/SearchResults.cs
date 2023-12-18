/*
 * Jacob Blair
 * CST150
 * Milestone 7
 * 12/11/23
 * This is my own work using the following resources.
 * https://learn.microsoft.com/en-us/dotnet/csharp/linq/
 */
using Inventorize.Models;
using System.Data;

namespace Inventorize.PresentationLayer.Search
{
    public partial class SearchResults : Form
    {
        // declare and initialize
        public List<SearchResult> InvSearchResult { get; set; }
        private Home HomeForm { get; set; }
        /// <summary>
        /// constructor which includes the results found in the preceding input page, and the parent form
        /// </summary>
        /// <param name="searchResults"></param>
        /// <param name="parent"></param>
        public SearchResults(List<SearchResult> searchResults, Home parent)
        {
            InitializeComponent();
            InvSearchResult = searchResults;
            HomeForm = parent;
        }

        /// <summary>
        /// populate the form when it finishes loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLoadEvent(object sender, EventArgs e)
        {
            // clear the data source just in case
            dgvResults.DataSource = null;
            // extract the ice cream scoops from the array of results and set it as the data source
            dgvResults.DataSource = InvSearchResult.Select((s) => s.Scoop).ToList();
            // format the data grid view in the same way that we do in the home form
            foreach (DataGridViewColumn column in dgvResults.Columns)
            {
                switch (column.Index)
                {
                    case 0:
                        column.HeaderText = "Flavor Name";
                        break;
                    case 1:
                        column.HeaderText = "Scoop Cost";
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        column.DefaultCellStyle.Format = "$#,#.00";
                        break;
                    case 2:
                        column.HeaderText = "Scoop Quantity";
                        column.DefaultCellStyle.Format = "N0";
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                    case 3:
                        column.HeaderText = "Flavor Ingredients";
                        break;
                    case 4:
                        column.HeaderText = "Flavor Description";
                        break;
                    default:
                        break;
                }
            }
            // loop through the results and highlight cells that came back positive in a search
            foreach (DataGridViewRow row in dgvResults.Rows)
            {
                foreach (SearchResult.ResultCol res in InvSearchResult[row.Index].Column)
                {
                    switch (res)
                    {
                        case SearchResult.ResultCol.Name:
                            row.Cells[0].Style.BackColor = Color.Yellow; break;
                        case SearchResult.ResultCol.Cost:
                            row.Cells[1].Style.BackColor = Color.Yellow; break;
                        case SearchResult.ResultCol.Quantity:
                            row.Cells[2].Style.BackColor = Color.Yellow; break;
                        case SearchResult.ResultCol.Ingredients:
                            row.Cells[3].Style.BackColor = Color.Yellow; break;
                        case SearchResult.ResultCol.Description:
                            row.Cells[4].Style.BackColor = Color.Yellow; break;
                        default:
                            break;
                    }
                }
            }
            // the dgv automatically selects a cell when it's refreshed so clear that
            dgvResults.ClearSelection();
        }

        /// <summary>
        /// click event for the return button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnBtnClickEvent(object sender, EventArgs e)
        {
            // send a list of the scoops found in the search back to the home form
            HomeForm.SearchResultsSelectCallback(InvSearchResult.Select((s) => s.Scoop).ToList());
            // close this form
            this.Close();
        }
        /// <summary>
        /// cancel button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtnClickEvent(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// form close event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCloseEvent(object sender, FormClosedEventArgs e)
        {
            HomeForm.GlobalCancelCallback();
        }
    }
}
