namespace Inventorize
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnReload = new Button();
            btnIncrement = new Button();
            dgvScoops = new DataGridView();
            lblError = new Label();
            btnDecrement = new Button();
            gbxDescription = new GroupBox();
            lblDescription = new Label();
            btnAddScoop = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            llJsonConvert = new LinkLabel();
            llImportJSON = new LinkLabel();
            JSONSaveFileDialog = new SaveFileDialog();
            JSONOpenFileDialog = new OpenFileDialog();
            llOverwrite = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)dgvScoops).BeginInit();
            gbxDescription.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnReload
            // 
            btnReload.BackgroundImage = Properties.Resources.Refresh_icon_svg;
            btnReload.BackgroundImageLayout = ImageLayout.Zoom;
            btnReload.Location = new Point(7, 255);
            btnReload.Margin = new Padding(4, 2, 4, 2);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(100, 100);
            btnReload.TabIndex = 3;
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += ReloadBtnClick;
            // 
            // btnIncrement
            // 
            btnIncrement.BackgroundImage = Properties.Resources.plus;
            btnIncrement.BackgroundImageLayout = ImageLayout.Zoom;
            btnIncrement.Font = new Font("Consolas", 36F, FontStyle.Regular, GraphicsUnit.Point);
            btnIncrement.Location = new Point(7, 47);
            btnIncrement.Margin = new Padding(4, 2, 4, 2);
            btnIncrement.Name = "btnIncrement";
            btnIncrement.Size = new Size(100, 100);
            btnIncrement.TabIndex = 5;
            btnIncrement.UseVisualStyleBackColor = true;
            btnIncrement.Click += BtnIncrementRow;
            // 
            // dgvScoops
            // 
            dgvScoops.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvScoops.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvScoops.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvScoops.Location = new Point(13, 11);
            dgvScoops.Margin = new Padding(4, 2, 4, 2);
            dgvScoops.Name = "dgvScoops";
            dgvScoops.RowHeadersWidth = 82;
            dgvScoops.RowTemplate.Height = 41;
            dgvScoops.Size = new Size(1668, 559);
            dgvScoops.TabIndex = 6;
            dgvScoops.SelectionChanged += DGVSelectionChangeEvent;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(13, 823);
            lblError.Margin = new Padding(4, 0, 4, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(78, 32);
            lblError.TabIndex = 7;
            lblError.Text = "label1";
            lblError.Visible = false;
            // 
            // btnDecrement
            // 
            btnDecrement.BackgroundImage = Properties.Resources.minus;
            btnDecrement.BackgroundImageLayout = ImageLayout.Zoom;
            btnDecrement.Location = new Point(7, 151);
            btnDecrement.Margin = new Padding(4, 2, 4, 2);
            btnDecrement.Name = "btnDecrement";
            btnDecrement.Size = new Size(100, 100);
            btnDecrement.TabIndex = 8;
            btnDecrement.UseVisualStyleBackColor = true;
            btnDecrement.Click += BtnDecrementClick;
            // 
            // gbxDescription
            // 
            gbxDescription.Controls.Add(lblDescription);
            gbxDescription.Location = new Point(13, 576);
            gbxDescription.Margin = new Padding(4, 2, 4, 2);
            gbxDescription.Name = "gbxDescription";
            gbxDescription.Padding = new Padding(4, 2, 4, 2);
            gbxDescription.Size = new Size(1668, 245);
            gbxDescription.TabIndex = 9;
            gbxDescription.TabStop = false;
            gbxDescription.Text = "Description";
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(6, 34);
            lblDescription.Margin = new Padding(4, 0, 4, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(1654, 195);
            lblDescription.TabIndex = 0;
            lblDescription.Text = "No object selected!";
            // 
            // btnAddScoop
            // 
            btnAddScoop.Location = new Point(6, 38);
            btnAddScoop.Name = "btnAddScoop";
            btnAddScoop.Size = new Size(395, 74);
            btnAddScoop.TabIndex = 10;
            btnAddScoop.Text = "Add";
            btnAddScoop.UseVisualStyleBackColor = true;
            btnAddScoop.Click += AddScoopBtnClickEvent;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(6, 118);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(395, 73);
            btnEdit.TabIndex = 11;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += BtnEditClickEvent;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(6, 197);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(395, 75);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += DeleteBtnClickEvent;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(6, 278);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(395, 75);
            btnSearch.TabIndex = 13;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += SearchBtnClickEvent;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnIncrement);
            groupBox1.Controls.Add(btnDecrement);
            groupBox1.Controls.Add(btnReload);
            groupBox1.Location = new Point(1697, 445);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(400, 376);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Entry Controls";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(114, 289);
            label3.Name = "label3";
            label3.Size = new Size(281, 32);
            label3.TabIndex = 11;
            label3.Text = "Reload Primary Inventory";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(116, 185);
            label2.Name = "label2";
            label2.Size = new Size(153, 32);
            label2.TabIndex = 10;
            label2.Text = "Dec Selected";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(116, 82);
            label1.Name = "label1";
            label1.Size = new Size(143, 32);
            label1.TabIndex = 9;
            label1.Text = "Inc Selected";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAddScoop);
            groupBox2.Controls.Add(btnEdit);
            groupBox2.Controls.Add(btnSearch);
            groupBox2.Controls.Add(btnDelete);
            groupBox2.Location = new Point(1688, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(409, 383);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Inventory Controls";
            // 
            // llJsonConvert
            // 
            llJsonConvert.AutoSize = true;
            llJsonConvert.Location = new Point(1897, 823);
            llJsonConvert.Name = "llJsonConvert";
            llJsonConvert.Size = new Size(192, 32);
            llJsonConvert.TabIndex = 16;
            llJsonConvert.TabStop = true;
            llJsonConvert.Text = "Convert to JSON";
            llJsonConvert.LinkClicked += JSONConvertLinkClick;
            // 
            // llImportJSON
            // 
            llImportJSON.AutoSize = true;
            llImportJSON.Location = new Point(1741, 823);
            llImportJSON.Name = "llImportJSON";
            llImportJSON.Size = new Size(150, 32);
            llImportJSON.TabIndex = 17;
            llImportJSON.TabStop = true;
            llImportJSON.Text = "Import JSON";
            llImportJSON.LinkClicked += JSONImportLinkClick;
            // 
            // JSONOpenFileDialog
            // 
            JSONOpenFileDialog.FileName = "openFileDialog1";
            // 
            // llOverwrite
            // 
            llOverwrite.AutoSize = true;
            llOverwrite.Location = new Point(1423, 824);
            llOverwrite.Name = "llOverwrite";
            llOverwrite.Size = new Size(312, 32);
            llOverwrite.TabIndex = 1;
            llOverwrite.TabStop = true;
            llOverwrite.Text = "Overwrite Primary Inventory";
            llOverwrite.LinkClicked += OverwriteLinkClickEvent;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2099, 864);
            Controls.Add(llOverwrite);
            Controls.Add(llImportJSON);
            Controls.Add(llJsonConvert);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(gbxDescription);
            Controls.Add(lblError);
            Controls.Add(dgvScoops);
            Margin = new Padding(4, 2, 4, 2);
            Name = "Home";
            Text = "Home";
            FormClosing += OnFormClose;
            Load += HomeFormLoadEvent;
            ((System.ComponentModel.ISupportInitialize)dgvScoops).EndInit();
            gbxDescription.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnReload;
        private Button btnIncrement;
        private DataGridView dgvScoops;
        private Label lblError;
        private Button btnDecrement;
        private GroupBox gbxDescription;
        private Label lblDescription;
        private Button btnAddScoop;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSearch;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private LinkLabel llJsonConvert;
        private LinkLabel llImportJSON;
        private SaveFileDialog JSONSaveFileDialog;
        private OpenFileDialog JSONOpenFileDialog;
        private Label label3;
        private Label label2;
        private Label label1;
        private LinkLabel llOverwrite;
    }
}