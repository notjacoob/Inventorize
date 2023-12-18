/*
 * Jacob Blair
 * CST150
 * Milestone 7
 * 12/11/23
 * This is my own work using the following resources to learn:
 * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
 * https://stackoverflow.com/questions/3036829/how-do-i-create-a-message-box-with-yes-no-choices-and-a-dialogresult
 * 
 */
using Inventorize.BusinessLayer;
using Inventorize.Models;
using Inventorize.PresentationLayer;
using Inventorize.PresentationLayer.Search;
using static Inventorize.Models.Inventory;

namespace Inventorize
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            btnEdit.Enabled = false;
            btnAddScoop.Enabled = false;
            btnDelete.Enabled = false;
            btnSearch.Enabled = false;
            JSONOpenFileDialog.Filter = "JSON File|*.json";
            JSONOpenFileDialog.Title = "Load Inventory from JSON";
            JSONSaveFileDialog.Filter = "JSON File|*.json";
            JSONSaveFileDialog.Title = "Save Inventory to JSON";
        }
        // declare and initialize
        private TextFile File = null;
        private JSON Json = new JSON();
        private Inventory Inv = null;
        private string Path = $@"{Application.StartupPath}Data/Inventory.txt";
        #region ==================================== GRID VIEW ====================================
        #region PopulateDataGridView(bool): void
        /// <summary>
        /// reload the datagridview using the data stored on the form from the file object
        /// </summary>
        private void PopulateDataGridView(bool sizeChange)
        {
            lblError.Visible = false;
            // only hard refresh everything including the headers if the size of the array is changed. determine using a flag
            if (sizeChange)
            {
                dgvScoops.DataSource = null;
                dgvScoops.DataSource = Inv.Scoops;
                dgvScoops.Columns.Remove(dgvScoops.Columns[dgvScoops.Columns.Count - 1]);
                foreach (DataGridViewColumn column in dgvScoops.Columns)
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
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            column.DefaultCellStyle.Format = "N0";
                            break;
                        case 3:
                            column.HeaderText = "Flavor Ingredients";
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                // otherwise, just refresh the dgv
                dgvScoops.Refresh();
            }
            // make sure all the file specific buttons are enabled
            btnAddScoop.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSearch.Enabled = true;
            dgvScoops.ClearSelection();
        }
        #endregion
        #region ScoopFromFirstSelectedCell(): (IceCreamScoop, bool, string)
        /// <summary>
        /// determine if a cell on the grid view is selected and if so, determine if it's a valid ice cream scoop. if multiple are selected,this will always get the first
        /// </summary>
        /// <returns>found scoop (nullable), was the lookup successful, if it wasnt, what was the error</returns>
        private (IceCreamScoop? scoopFound, bool success, string errorString) ScoopFromFirstSelectedCell()
        {
            // is there a selected row?
            if (dgvScoops.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvScoops.SelectedRows[0];
                // does this row have a value in the first cell (name)
                (IceCreamScoop foundScoop, bool success, string errorMsg) = ScoopFromRow(row);
                if (success)
                {
                    return (foundScoop, true, "");
                }
                else
                {
                    return (null, false, errorMsg);
                }
            }
            else
            {
                return (null, false, "Please select a row!");
            }
        }
        #endregion
        #region ScoopFromCell(DataGridViewRow): (IceCreamScoop, bool, string)
        /// <summary>
        /// generic cell to scoop code for ScoopFromFirstSelectedCell and ScoopFromRow
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private (IceCreamScoop?, bool, string) ScoopFromRow(DataGridViewRow row)
        {
            if (row.Cells[0].Value != null)
            {
                IceCreamScoop scoop = Inv.Find(row.Cells[0].Value.ToString());
                if (scoop != null)
                {
                    return (scoop, true, "");
                }
                else
                {
                    return (null, false, "Please select a valid scoop!");
                }
            }
            else
            {
                return (null, false, "That scoop does not have a name!");
            }
        }
        #endregion
        #region ScoopFromRow(int): (IceCreamScoop, bool, string)
        /// <summary>
        /// get an ice cream scoop from a row, providing the index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private (IceCreamScoop? scoopFound, bool success, string errorString) ScoopFromRow(int index)
        {
            if (dgvScoops.Rows.Count - 1 >= index)
            {
                DataGridViewRow row = dgvScoops.Rows[index];
                (IceCreamScoop foundScoop, bool success, string errorMsg) = ScoopFromRow(row);
                if (success)
                {
                    return (foundScoop, true, "");
                }
                else
                {
                    return (null, false, errorMsg);
                }
            }
            else
            {
                return (null, false, "There is no row by that index!");
            }
        }
        #endregion
        #region RowFromScoop(IceCreamScoop): (DataGridViewRow, bool, string)
        /// <summary>
        /// Take a scoop object and find a row that contains it, if one exists
        /// </summary>
        /// <param name="scoop"></param>
        /// <returns></returns>
        private (DataGridViewRow? rowFound, bool success, string errorMsg) RowFromScoop(IceCreamScoop scoop)
        {
            int index = -1;
            for (int i = 0; i < Inv.Scoops.Count; i++)
            {
                if (Inv.Scoops[i] == scoop)
                {
                    index = i;
                }
            }
            if (index != -1)
            {
                DataGridViewRow assumedRow = dgvScoops.Rows[index];
                // verify
                if (assumedRow.Cells[0].Value.ToString() == scoop.ScoopName)
                {
                    return (assumedRow, true, "");
                }
                else
                {
                    return (assumedRow, false, "Row was found, but it could not be verified!");
                }
            }
            else
            {
                return (null, false, "Could not find row!");
            }

        }
        #endregion
        #endregion
        #region ==================================== QUANTITY =====================================
        #region UpdateQty(IncDec): void
        /// <summary>
        /// either increment or decrement the selected row's scoop
        /// </summary>
        /// <param name="whichWay"></param>
        private void UpdateQty(IncDec whichWay)
        {
            // set label as invisible
            lblError.Visible = false;
            List<IceCreamScoop> toSave = new List<IceCreamScoop>();
            bool continueRun = false;
            foreach (DataGridViewRow row in dgvScoops.SelectedRows)
            {
                int index = row.Index;
                if (index > -1)
                {
                    (IceCreamScoop scoop, bool success, string errorString) = ScoopFromRow(index);
                    if (success)
                    {
                        if (Inv.UpdateQty(scoop, whichWay, File))
                        {
                            continueRun = true;
                        }
                        else
                        {
                            Issue("Cannot subtract to a negative number!", true);
                        }
                    }
                    else
                    {
                        lblError.Text = errorString;
                        lblError.Visible = true;
                    }
                }

            }
            if (continueRun)
            {
                File.Save();
                dgvScoops.Refresh();
            }
        }
        #endregion
        #endregion
        #region ==================================== EVENTS =======================================
        #region INVENTORY CONTROLS
        #region AddScoopBtnClickEvent(object, EventArgs): void
        /// <summary>
        /// Click event for the add button which opens the add edit form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddScoopBtnClickEvent(object sender, EventArgs e)
        {
            AddEdit addForm = new AddEdit(this, AddEdit.DataUpdateMethod.Add);
            addForm.ShowDialog();
        }
        #endregion
        #region BtnEditClickEvent(object, EventArgs): void
        /// <summary>
        /// Click event for the edit button which opens the add edit form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditClickEvent(object sender, EventArgs e)
        {
            // clear the error label
            lblError.Visible = false;
            if (dgvScoops.SelectedRows.Count == 1)
            {
                // get current row
                (IceCreamScoop? scoop, bool success, string errorString) = ScoopFromFirstSelectedCell();
                if (success) // if the row is a valid item
                {
                    // open the edit form to edit the item
                    AddEdit addForm = new AddEdit(this, AddEdit.DataUpdateMethod.Edit, scoop);
                    addForm.ShowDialog();
                }
                else
                {
                    // else display an error
                    lblError.Text = errorString;
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "Please select just one item to edit!";
                lblError.Visible = true;
            }

        }
        #endregion
        #region DeleteBtnClickEvent(object, EventArgs): void
        /// <summary>
        /// click event for the delete button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtnClickEvent(object sender, EventArgs e)
        {
            // clear error label
            lblError.Visible = false;
            List<IceCreamScoop> scoopsToDelete = new List<IceCreamScoop>();
            foreach (DataGridViewRow row in dgvScoops.SelectedRows)
            {
                (IceCreamScoop? scoop, bool success, string errorString) = ScoopFromRow(row.Index);
                if (success)
                {
                    scoopsToDelete.Add(scoop);
                }

            }
            // get current row
            if (scoopsToDelete.Count > 0) // if the row is a valid item
            {
                // open the delete form with the selected scoop
                Delete deleteForm = new Delete(this, scoopsToDelete);
                deleteForm.ShowDialog();
            }
            else // else display an error
            {
                lblError.Text = "Please select something to delete!";
                lblError.Visible = true;
            }
        }
        #endregion
        #region SearchBtnClickEvent(object, EventArgs): void
        /// <summary>
        /// click event for the search button that opens the search input form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBtnClickEvent(object sender, EventArgs e)
        {
            SearchInput input = new SearchInput(Inv, this);
            input.Show();
        }
        #endregion
        #endregion
        #region ENTRY CONTROLS
        #region ReloadBtnClick(object, EventArgs): void
        /// <summary>
        /// Handle click of the reload button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadBtnClick(object sender, EventArgs e)
        {
            // if the file is loaded successfully, continue to populate the label
            bool successful = LoadFile();
            if (successful)
            {
                PopulateDataGridView(true);
            }
        }
        #endregion
        #region BtnIncrementRow(object, EventArgs): void
        /// <summary>
        /// event handler for our increment button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnIncrementRow(object sender, EventArgs e)
        {
            UpdateQty(IncDec.Inc);
        }
        #endregion
        #region BtnDecrementClick(object, EventArgs): void
        /// <summary>
        /// decrement button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDecrementClick(object sender, EventArgs e)
        {
            UpdateQty(IncDec.Dec);
        }
        #endregion
        #endregion
        #region JSON
        #region JSONConvertLinkClick(object, LinkLabelLinkClickedEventArgs): void
        /// <summary>
        /// event for the json convert link which prompts the user to save a file and then exports the current inventory as a json file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JSONConvertLinkClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // is the text file loaded?
            if (File != null)
            {
                // prompt user to save file
                if (JSONSaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // convert current inventory to json and save it to the file that we prompted
                    (bool success, string error) = Json.SaveConvertedJSON(Inv.Scoops, JSONSaveFileDialog.FileName);
                    if (success)
                    {
                        lblError.Text = "File exported!";
                    }
                    else // in case there is a parsing error
                    {
                        lblError.Text = error;
                    }
                    lblError.Visible = true;
                };
            }
        }
        #endregion
        #region JSONImportLinkClick(object, LinkLabelLinkClickedEventArgs): void
        /// <summary>
        /// json import link click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JSONImportLinkClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // prompt the user to open a json file
            if (JSONOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                // create a name for the archive file
                string fileName = $"Inventory_{DateTimeOffset.Now.ToUnixTimeMilliseconds()}.txt";
                // parse json file from the file that we prompted, and save the archive file of the json file
                (List<IceCreamScoop> scoops, bool success, string error) = Json.TextFileFromJSON(JSONOpenFileDialog.FileName, @$"{Application.StartupPath}Data/jsonLoads/{fileName}");
                // make sure the user wants to unload the current inventory
                if (MessageBox.Show("Load file?", "Current file will be saved and closed", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // if the json file successfully loaded
                    if (success)
                    {
                        // save the current text file
                        File.Save();
                        // set the current text file to the archive we saved
                        File = new TextFile(@$"{Application.StartupPath}Data/jsonLoads/{fileName}");
                        // create a new inventory model for the loaded data
                        Inv = new Inventory(scoops);
                        // populate the text file with the loaded scoops
                        foreach (IceCreamScoop scoop in Inv.Scoops)
                        {
                            File.UpdateScoop(scoop);
                        }
                        // save the new text file
                        File.Save();
                        // update data grid view
                        PopulateDataGridView(true);
                        // alert user
                        lblError.Text = $"Loaded and saved new inventory to {fileName}";
                        lblError.Visible = true;
                    }
                    else
                    {
                        // alert user
                        Issue(error, false);
                    }
                }
            }
        }
        #endregion
        #region OverWriteLinkClickEvent(object, LinkLabelLinkClickedEventArgs): void
        /// <summary>
        /// overwrite primary file click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OverwriteLinkClickEvent(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // make sure that the user wants to overwrite their file
            if (MessageBox.Show("Are you sure you want to overwrite the primary text file?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // create new text file object with the current file's lines and the primary file's path
                File = new TextFile(Path, string.Join("\n", File.Lines));
                // create a new inventory with the new text file
                Inv = new Inventory(File.ToScoops());
                // populate data grid view
                PopulateDataGridView(true);
                // alert user
                lblError.Text = "File overwritten!";
            }
            else
            {
                // alert user
                lblError.Text = "Action canceled.";
            }
            lblError.Visible = true;
        }
        #endregion
        #endregion
        #region OTHER
        #region OnFormClose(object, FormClosingEventArgs): void
        /// <summary>
        /// Event handler for form close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormClose(object sender, FormClosingEventArgs e)
        {
            // not async so the form stays open until the file is saved
            try
            {
                // make sure the file was actually loaded
                if (File != null)
                {
                    File.Save();
                }
            }
            catch (IOException ex) // if there was an issue reading / saving / acccessing the file 
            {
                Issue(ex.Message, true);
            }
        }
        #endregion
        #region DGVSelectionChangeEvent(object, EventArgs): void
        /// <summary>
        /// event on selection changed, used to update description gbx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVSelectionChangeEvent(object sender, EventArgs e)
        {
            // clear error label
            lblError.Visible = false;
            if (dgvScoops.SelectedRows.Count == 1)
            {
                (IceCreamScoop scoop, bool success, string errorString) = ScoopFromFirstSelectedCell(); // read current row
                if (success)
                { // if the row is a valid scoop,
                  // populate description box
                    lblDescription.Text = scoop.Description;
                }
                else
                {
                    // else display the error and clear the description box
                    lblError.Text = errorString;
                    lblError.Visible = true;
                    lblDescription.Text = "No object selected!";
                }
            }
            else if (dgvScoops.SelectedRows.Count > 1)
            {
                lblDescription.Text = "Multiple items selected!";
            }
            else
            {
                lblDescription.Text = "No object selected!";
            }
        }
        #endregion
        #region HomeFormLoadEvent(object, EventArgs): void
        /// <summary>
        /// form load event that loads the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeFormLoadEvent(object sender, EventArgs e)
        {
            // if the file is loaded successfully, continue to populate the label
            bool successful = LoadFile();
            if (successful)
            {
                PopulateDataGridView(true);
            }
        }
        #endregion
        #endregion
        #endregion
        #region =============================== OTHER FORM CALLBACKS ===============================
        #region AddEdit
        #region AddFormCreateCallback(IceCreamScoop): void
        /// <summary>
        /// callback for when the create button is clicked on the add edit form
        /// </summary>
        /// <param name="newScoop"></param>
        public void AddFormCreateCallback(IceCreamScoop newScoop)
        {
            // add the new scoop to the form-specific list
            Inv.Scoops.Add(newScoop);
            // save the new scoop to the loaded file
            newScoop.Save(File);
            PopulateDataGridView(true);
        }
        #endregion
        #region AddFormEditCallback(IceCreamScoop): void
        /// <summary>
        /// callback for clicking the submit button on the add edit form
        /// </summary>
        /// <param name="newScoop"></param>
        public void AddFormEditCallback(IceCreamScoop newScoop)
        {
            // find the unedited matching scoop on the form list
            // cite find on lists
            IceCreamScoop? scoopMatch = Inv.Find(newScoop.ScoopName);
            // is there a matching scoop?
            if (scoopMatch != null)
            {
                // change the values of the unedited scoop to match the edited one
                scoopMatch.Adapt(newScoop);
                // save the edited scoop to the file
                scoopMatch.Save(File);
                PopulateDataGridView(false);
            }
        }
        #endregion
        #endregion
        #region Delete
        #region DeleteFormDeleteCallback(List<IceCreamScoop>): void
        /// <summary>
        /// callback for the delete button on the delete form
        /// </summary>
        /// <param name="toDelete"></param>
        public void DeleteFormDeleteCallback(List<IceCreamScoop> toDelete)
        {
            foreach (IceCreamScoop scoop in toDelete)
            {
                // remove scoop from form array
                Inv.Scoops.Remove(scoop);
                // remove scoop from file
                File.Remove(scoop);
            }
            PopulateDataGridView(true);
        }
        #endregion
        #endregion
        #region Search
        #region SearchResultsSelectCallback(List<IceCreamScoop>)
        /// <summary>
        /// Callback that selects items that are searched
        /// </summary>
        /// <param name="toSelect"></param>
        public void SearchResultsSelectCallback(List<IceCreamScoop> toSelect)
        {
            if (toSelect.Count > 0) dgvScoops.ClearSelection();
            foreach (IceCreamScoop scoop in toSelect)
            {
                (DataGridViewRow row, bool success, string error) = RowFromScoop(scoop);
                if (success)
                {
                    row.Selected = true;
                }
                else
                {
                    Issue(error, true);
                }
            }
        }
        #endregion
        #endregion
        #region Global
        #region GlobalCancelCallback(): void
        /// <summary>
        /// cancel callback for all of the forms with a cancel button
        /// </summary>
        public void GlobalCancelCallback()
        {
            lblError.Text = "Operation cancelled!";
            lblError.Visible = true;
        }
        #endregion
        #endregion
        #endregion
        #region =============================== FILE ===============================================
        #region LoadFile(): bool
        /// <summary>
        /// load the file into the form using a textfile object
        /// </summary>
        /// <returns></returns>
        private bool LoadFile()
        {
            // declare and initialize boolean that will handle catching exceptions
            bool continueRunning = false;
            // check if the user clicked a file and continued to open it

            try
            {
                // set the file to a class level variable since we use it to save
                File = new TextFile(Path);
                Inv = new Inventory(File.ToScoops());
                // if it doesn't cause an exception, continue running the program
                continueRunning = true;
            }
            catch (IOException ex)
            {
                // on exception, continue to function
                Issue("Could not read file!", true);
            }
            // only runs if the above lines do not throw exceptions
            return continueRunning;
        }
        #endregion
        #region Issue(string, bool): void
        /// <summary>
        /// if there is any sort of issue reading the file, let the user know
        /// </summary>
        private void Issue(string msg, bool inline)
        {
            // if we instruct the function to interrupt, then it will display the error to the label. Otherwise, it will just be a popup box
            if (inline)
            {
                // set the label
                lblError.Text = msg;
                lblError.Visible = true;
            }
            else
            {
                // show a popup with the error
                MessageBox.Show(msg);
            }
        }
        #endregion
        #endregion
    }
}