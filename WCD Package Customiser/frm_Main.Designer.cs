namespace WCD_Package_Customiser
{
    partial class frm_Main
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
            this.clb_Applications = new System.Windows.Forms.CheckedListBox();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.cbx_ApplicationLists = new System.Windows.Forms.ComboBox();
            this.btn_New = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clb_Applications
            // 
            this.clb_Applications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clb_Applications.FormattingEnabled = true;
            this.clb_Applications.Location = new System.Drawing.Point(12, 55);
            this.clb_Applications.Name = "clb_Applications";
            this.clb_Applications.Size = new System.Drawing.Size(590, 244);
            this.clb_Applications.TabIndex = 0;
            // 
            // btn_Apply
            // 
            this.btn_Apply.Location = new System.Drawing.Point(526, 17);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(75, 23);
            this.btn_Apply.TabIndex = 2;
            this.btn_Apply.Text = "Apply";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // cbx_ApplicationLists
            // 
            this.cbx_ApplicationLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_ApplicationLists.FormattingEnabled = true;
            this.cbx_ApplicationLists.Location = new System.Drawing.Point(12, 18);
            this.cbx_ApplicationLists.Name = "cbx_ApplicationLists";
            this.cbx_ApplicationLists.Size = new System.Drawing.Size(345, 21);
            this.cbx_ApplicationLists.TabIndex = 3;
            this.cbx_ApplicationLists.SelectionChangeCommitted += new System.EventHandler(this.cbx_ApplicationLists_SelectionChangeCommitted);
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(363, 17);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(75, 23);
            this.btn_New.TabIndex = 4;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(444, 17);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 318);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(616, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip";
            // 
            // lbl_Status
            // 
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(0, 17);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 340);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.cbx_ApplicationLists);
            this.Controls.Add(this.btn_Apply);
            this.Controls.Add(this.clb_Applications);
            this.Name = "frm_Main";
            this.ShowIcon = false;
            this.Text = "Package Customiser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clb_Applications;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.ComboBox cbx_ApplicationLists;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Status;
    }
}

