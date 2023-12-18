namespace Inventorize.PresentationLayer
{
    partial class AddEdit
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
            txtName = new TextBox();
            gbxAttr = new GroupBox();
            rtbIngredients = new RichTextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            rtbDescription = new RichTextBox();
            txtQuantity = new TextBox();
            txtCost = new TextBox();
            btnCreate = new Button();
            btnCancel = new Button();
            lblError = new Label();
            gbxAttr.SuspendLayout();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(6, 38);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 39);
            txtName.TabIndex = 0;
            // 
            // gbxAttr
            // 
            gbxAttr.Controls.Add(rtbIngredients);
            gbxAttr.Controls.Add(label5);
            gbxAttr.Controls.Add(label4);
            gbxAttr.Controls.Add(label3);
            gbxAttr.Controls.Add(label2);
            gbxAttr.Controls.Add(label1);
            gbxAttr.Controls.Add(rtbDescription);
            gbxAttr.Controls.Add(txtQuantity);
            gbxAttr.Controls.Add(txtCost);
            gbxAttr.Controls.Add(txtName);
            gbxAttr.Location = new Point(12, 12);
            gbxAttr.Name = "gbxAttr";
            gbxAttr.Size = new Size(753, 611);
            gbxAttr.TabIndex = 1;
            gbxAttr.TabStop = false;
            gbxAttr.Text = "Attributes";
            // 
            // rtbIngredients
            // 
            rtbIngredients.Location = new Point(6, 215);
            rtbIngredients.Name = "rtbIngredients";
            rtbIngredients.Size = new Size(741, 164);
            rtbIngredients.TabIndex = 10;
            rtbIngredients.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 382);
            label5.Name = "label5";
            label5.Size = new Size(135, 32);
            label5.TabIndex = 9;
            label5.Text = "Description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 180);
            label4.Name = "label4";
            label4.Size = new Size(134, 32);
            label4.TabIndex = 8;
            label4.Text = "Ingredients";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(212, 131);
            label3.Name = "label3";
            label3.Size = new Size(106, 32);
            label3.TabIndex = 7;
            label3.Text = "Quantity";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(212, 83);
            label2.Name = "label2";
            label2.Size = new Size(61, 32);
            label2.TabIndex = 6;
            label2.Text = "Cost";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(212, 41);
            label1.Name = "label1";
            label1.Size = new Size(78, 32);
            label1.TabIndex = 5;
            label1.Text = "Name";
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(6, 413);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(741, 192);
            rtbDescription.TabIndex = 4;
            rtbDescription.Text = "";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(6, 128);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(200, 39);
            txtQuantity.TabIndex = 2;
            // 
            // txtCost
            // 
            txtCost.Location = new Point(6, 83);
            txtCost.Name = "txtCost";
            txtCost.Size = new Size(200, 39);
            txtCost.TabIndex = 1;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(18, 629);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(747, 67);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += CreateBtnClickEvent;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(18, 702);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(747, 69);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += CancelBtnClickEvent;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(18, 774);
            lblError.Name = "lblError";
            lblError.Size = new Size(78, 32);
            lblError.TabIndex = 4;
            lblError.Text = "label6";
            lblError.Visible = false;
            // 
            // Add
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(777, 816);
            Controls.Add(lblError);
            Controls.Add(btnCancel);
            Controls.Add(btnCreate);
            Controls.Add(gbxAttr);
            Name = "Add";
            Text = "Add";
            FormClosed += OnFormClose;
            Load += OnFormLoad;
            gbxAttr.ResumeLayout(false);
            gbxAttr.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private GroupBox gbxAttr;
        private TextBox txtCost;
        private TextBox txtQuantity;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private RichTextBox rtbDescription;
        private Button btnCreate;
        private Button btnCancel;
        private RichTextBox rtbIngredients;
        private Label lblError;
    }
}