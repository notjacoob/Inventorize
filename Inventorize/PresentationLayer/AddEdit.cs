/*
 * Jacob Blair
 * CST150
 * 12/11/23
 * Milestone 7
 * This is my own work using the following resources to learn.
 * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum
 * https://learn.microsoft.com/en-us/dotnet/desktop/winforms/forms/how-to-add?view=netdesktop-8.0
 * https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.form?view=windowsdesktop-8.0
 */
using Inventorize.BusinessLayer;
using Inventorize.Models;

namespace Inventorize.PresentationLayer
{
    public partial class AddEdit : Form
    {
        /// <summary>
        /// standard value for which actions this page is on when it opens
        /// </summary>
        public enum DataUpdateMethod
        {
            Add,
            Edit
        }

        // declare and initialize

        private Home ParentForm;
        private bool Success = false;
        private Utilities Util = new Utilities();
        private IceCreamScoop ScoopToUpdate;
        private DataUpdateMethod UpdateMethod;
        /// <summary>
        /// constructor for when the page should add
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="method"></param>
        public AddEdit(Home parentForm, DataUpdateMethod method)
        {
            InitializeComponent();
            ParentForm = parentForm;
            ScoopToUpdate = null;
            UpdateMethod = method;
        }
        /// <summary>
        /// constructor for when the page should edit
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="method"></param>
        /// <param name="toUpdate"></param>
        public AddEdit(Home parentForm, DataUpdateMethod method, IceCreamScoop toUpdate)
        {
            InitializeComponent();
            ParentForm = parentForm;
            ScoopToUpdate = toUpdate;
            UpdateMethod = method;
        }

        /// <summary>
        /// close this form and go back to the home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtnClickEvent(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// check that the data entered in this form is able to be transformed into an IceCreamScoop
        /// </summary>
        /// <returns></returns>
        private (bool, ScoopAdditionArguments) ValidateFormData()
        {
            // model argument for all of the require data for a new ice cream scoop
            ScoopAdditionArguments args = new ScoopAdditionArguments();
            // are all the fields filled out?
            if (txtCost.Text != "" && txtName.Text != "" && txtQuantity.Text != "" && rtbIngredients.Text != "" && rtbDescription.Text != "")
            {
                // set model values
                args.Description = rtbDescription.Text;
                args.Name = txtName.Text;
                args.Ingredients = rtbIngredients.Text.Split("\n");
                // parse numbers
                (decimal costVal, bool costValid) = Util.IsDecimal(txtCost.Text);
                (int qtyVal, bool qtyValid) = Util.IsInt(txtQuantity.Text);
                // are the number fields valid?
                if (costValid && qtyValid)
                {
                    // check that both numbers are positive
                    if (costVal > -1 && qtyVal > -1)
                    {
                        // set model values
                        args.Cost = costVal;
                        args.Quantity = qtyVal;
                        // return the correct values
                        // check for semicolons since we use that as the separator in the file
                        if (!args.Description.Contains(";"))
                        {
                            // clear newlines for file formatting
                            args.Description.ReplaceLineEndings("<br>");
                            return (true, args);
                        } else
                        {
                            args.Error = "Data cannot contain semicolons!";
                            return (false, args);
                        }
                    } else
                    {
                        // return error
                        args.Error = "Field cannot be negative!";
                        return (false, args);
                    }
                }
                else
                {
                    // return error
                    args.Error = "Number field invalid!";
                    return (false, args);
                }
            }
            else
            {
                // return error
                args.Error = "A field is not filled out!";
                return (false, args);
            }
        }
        /// <summary>
        /// create / update button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateBtnClickEvent(object sender, EventArgs e)
        {
            lblError.Visible = false;
            // check that form data is valid
            (bool formValid, ScoopAdditionArguments args) = ValidateFormData();
            if (formValid)
            {
                Success = true; // confirm validity
                if (UpdateMethod == DataUpdateMethod.Add) // if the form is open to add
                {
                    // create new ice cream scoop
                    IceCreamScoop newScoop = new IceCreamScoop(args.Name, args.Cost, args.Description, args.Quantity, args.Ingredients);
                    // send new scoop to main form
                    ParentForm.AddFormCreateCallback(newScoop);
                    // close this form
                    this.Close();
                }
                else
                {
                    // set scoop properties to the values in the form
                    ScoopToUpdate.ScoopName = args.Name;
                    ScoopToUpdate.Cost = args.Cost;
                    ScoopToUpdate.Description = args.Description;
                    ScoopToUpdate.Quantity = args.Quantity;
                    ScoopToUpdate.Ingredients = args.Ingredients;
                    // send updated scoop to main form
                    ParentForm.AddFormEditCallback(ScoopToUpdate);
                    // close this form
                    this.Close();
                }
            }
            else
            {
                // error if the form is not properly filled out
                lblError.Text = args.Error;
                lblError.Visible = true;
            }
        }
        /// <summary>
        /// event for when this form loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormLoad(object sender, EventArgs e)
        {
            // if the form should edit
            if (UpdateMethod == DataUpdateMethod.Edit)
            {
                // if there was a scoop provided
                if (ScoopToUpdate != null)
                {
                    // update UI elements to reflect edit form
                    btnCreate.Text = "Submit";
                    this.Text = "Edit";
                    // update fields to the data from the existing scoop
                    txtName.Text = ScoopToUpdate.ScoopName;
                    txtCost.Text = ScoopToUpdate.Cost.ToString();
                    txtQuantity.Text = ScoopToUpdate.Quantity.ToString();
                    rtbDescription.Text = ScoopToUpdate.Description;
                    rtbIngredients.Text = string.Join("\n", ScoopToUpdate.Ingredients);
                }
                else
                {
                    // if there wasnt a provided scoop, cancel this operation 
                    ParentForm.GlobalCancelCallback();
                    this.Close();
                }
            } // otherwise, since the designer is initially designed for the add function, we dont have to do anything
        }
        /// <summary>
        /// event for when this form closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormClose(object sender, FormClosedEventArgs e)
        {
            // if an update or creation happened, this will be true
            if (!Success)
            {
                // if not, then we can assume the user either closed the form or clicked cancel
                ParentForm.GlobalCancelCallback();
            }
        }
    }
}
