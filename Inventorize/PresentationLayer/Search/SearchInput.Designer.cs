namespace Inventorize.PresentationLayer.Search
{
    partial class SearchInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            chbIngredients = new CheckBox();
            chbQuantity = new CheckBox();
            chbCost = new CheckBox();
            chbDescription = new CheckBox();
            chbName = new CheckBox();
            txtSearchTerm = new TextBox();
            btnSearch = new Button();
            lblError = new Label();
            btnCancel = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chbIngredients);
            groupBox1.Controls.Add(chbQuantity);
            groupBox1.Controls.Add(chbCost);
            groupBox1.Controls.Add(chbDescription);
            groupBox1.Controls.Add(chbName);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 257);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search By";
            // 
            // chbIngredients
            // 
            chbIngredients.AutoSize = true;
            chbIngredients.Location = new Point(6, 206);
            chbIngredients.Name = "chbIngredients";
            chbIngredients.Size = new Size(166, 36);
            chbIngredients.TabIndex = 4;
            chbIngredients.Text = "Ingredients";
            chbIngredients.UseVisualStyleBackColor = true;
            // 
            // chbQuantity
            // 
            chbQuantity.AutoSize = true;
            chbQuantity.Location = new Point(6, 164);
            chbQuantity.Name = "chbQuantity";
            chbQuantity.Size = new Size(138, 36);
            chbQuantity.TabIndex = 3;
            chbQuantity.Text = "Quantity";
            chbQuantity.UseVisualStyleBackColor = true;
            // 
            // chbCost
            // 
            chbCost.AutoSize = true;
            chbCost.Location = new Point(6, 122);
            chbCost.Name = "chbCost";
            chbCost.Size = new Size(93, 36);
            chbCost.TabIndex = 2;
            chbCost.Text = "Cost";
            chbCost.UseVisualStyleBackColor = true;
            // 
            // chbDescription
            // 
            chbDescription.AutoSize = true;
            chbDescription.Location = new Point(6, 80);
            chbDescription.Name = "chbDescription";
            chbDescription.Size = new Size(167, 36);
            chbDescription.TabIndex = 1;
            chbDescription.Text = "Description";
            chbDescription.UseVisualStyleBackColor = true;
            // 
            // chbName
            // 
            chbName.AutoSize = true;
            chbName.Location = new Point(6, 38);
            chbName.Name = "chbName";
            chbName.Size = new Size(110, 36);
            chbName.TabIndex = 0;
            chbName.Text = "Name";
            chbName.UseVisualStyleBackColor = true;
            // 
            // txtSearchTerm
            // 
            txtSearchTerm.Location = new Point(12, 275);
            txtSearchTerm.Name = "txtSearchTerm";
            txtSearchTerm.Size = new Size(776, 39);
            txtSearchTerm.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(12, 320);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(776, 46);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += SearchBtnClickEvent;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(12, 417);
            lblError.Name = "lblError";
            lblError.Size = new Size(64, 32);
            lblError.TabIndex = 4;
            lblError.Text = "Error";
            lblError.TextAlign = ContentAlignment.MiddleLeft;
            lblError.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(12, 372);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(776, 46);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += CancelBtnClickEvent;
            // 
            // SearchInput
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 458);
            Controls.Add(btnCancel);
            Controls.Add(lblError);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchTerm);
            Controls.Add(groupBox1);
            Name = "SearchInput";
            Text = "Search";
            FormClosed += FormCloseEvent;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox chbIngredients;
        private CheckBox chbQuantity;
        private CheckBox chbCost;
        private CheckBox chbDescription;
        private CheckBox chbName;
        private TextBox txtSearchTerm;
        private Button btnSearch;
        private Label lblError;
        private Button btnCancel;
    }
}