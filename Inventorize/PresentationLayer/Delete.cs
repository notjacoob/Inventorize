/*
 * Jacob Blair
 * CST150
 * 12/11/23
 * Milestone 7
 * This is my own work.
 */
using Inventorize.Models;

namespace Inventorize.PresentationLayer
{
    public partial class Delete : Form
    {
        // declare
        private List<IceCreamScoop> ScoopsToDelete;
        private Home ParentForm;
        /// <summary>
        /// constructor taking the scoop that should be deleted and the home form for callback
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="scoop"></param>
        public Delete(Home parent, List<IceCreamScoop> scoops)
        {
            // initialize
            InitializeComponent();
            ParentForm = parent;
            ScoopsToDelete = scoops;
        }
        /// <summary>
        /// event for if the cancel button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtnClickEvent(object sender, EventArgs e)
        {
            // let the home form know what happened
            ParentForm.GlobalCancelCallback();
            // close self
            Close();
        }
        /// <summary>
        /// event for if the delete button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtnClickEvent(object sender, EventArgs e)
        {
            // let the home form know what to delete
            ParentForm.DeleteFormDeleteCallback(ScoopsToDelete);
            // close self
            Close();
        }
        /// <summary>
        /// load event which loads the data grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLoadEvent(object sender, EventArgs e)
        {
            // for some reason when we load the deleted scoops the list needs to be reversed to be in the same order
            ScoopsToDelete.Reverse();
            // set the dgv to the list of scoops
            dgvToDelete.DataSource = ScoopsToDelete;
            // remove every column but flavor name because we dont need the other ones
            foreach (DataGridViewColumn column in dgvToDelete.Columns)
            {
                switch (column.Index)
                {
                    case 0:
                        column.HeaderText = "Flavor Name";
                        break;
                    default:
                        break;
                }
            }
            while (dgvToDelete.Columns.Count > 1)
            {
                dgvToDelete.Columns.RemoveAt(dgvToDelete.Columns.Count - 1);
            }
        }
    }
}
