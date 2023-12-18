namespace Inventorize.PresentationLayer.Search
{
    partial class SearchResults
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
            dgvResults = new DataGridView();
            btnReturn = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // dgvResults
            // 
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(12, 12);
            dgvResults.Name = "dgvResults";
            dgvResults.RowHeadersWidth = 82;
            dgvResults.RowTemplate.Height = 41;
            dgvResults.Size = new Size(1256, 799);
            dgvResults.TabIndex = 0;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(12, 817);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(1256, 59);
            btnReturn.TabIndex = 1;
            btnReturn.Text = "Return Home and Select";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += ReturnBtnClickEvent;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(12, 881);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(1256, 59);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += CancelBtnClickEvent;
            // 
            // SearchResults
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 952);
            Controls.Add(btnCancel);
            Controls.Add(btnReturn);
            Controls.Add(dgvResults);
            Name = "SearchResults";
            Text = "Search";
            FormClosed += FormCloseEvent;
            Load += FormLoadEvent;
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvResults;
        private Button btnReturn;
        private Button btnCancel;
    }
}