namespace Inventorize.PresentationLayer
{
    partial class Delete
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
            label1 = new Label();
            label2 = new Label();
            btnDelete = new Button();
            btnCancel = new Button();
            dgvToDelete = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvToDelete).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(679, 45);
            label1.TabIndex = 0;
            label1.Text = "Are you sure you want to delete these entries?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 54);
            label2.Name = "label2";
            label2.Size = new Size(417, 32);
            label2.TabIndex = 1;
            label2.Text = "Recovery is not possible once deleted";
            // 
            // btnDelete
            // 
            btnDelete.ForeColor = Color.Red;
            btnDelete.Location = new Point(905, 530);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 46);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += DeleteBtnClickEvent;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(749, 530);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 46);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += CancelBtnClickEvent;
            // 
            // dgvToDelete
            // 
            dgvToDelete.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvToDelete.Location = new Point(12, 89);
            dgvToDelete.Name = "dgvToDelete";
            dgvToDelete.RowHeadersWidth = 82;
            dgvToDelete.RowTemplate.Height = 41;
            dgvToDelete.Size = new Size(1043, 432);
            dgvToDelete.TabIndex = 5;
            // 
            // Delete
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 588);
            Controls.Add(dgvToDelete);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Delete";
            Text = "Delete";
            Load += FormLoadEvent;
            ((System.ComponentModel.ISupportInitialize)dgvToDelete).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnDelete;
        private Button btnCancel;
        private DataGridView dgvToDelete;
    }
}