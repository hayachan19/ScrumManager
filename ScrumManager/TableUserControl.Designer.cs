namespace ScrumManager
{
    partial class TableUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataTableView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.otwórzWNowejZakładceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.właściwościToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataTableView
            // 
            this.dataTableView.AllowUserToAddRows = false;
            this.dataTableView.AllowUserToDeleteRows = false;
            this.dataTableView.AllowUserToOrderColumns = true;
            this.dataTableView.AllowUserToResizeRows = false;
            this.dataTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableView.ContextMenuStrip = this.contextMenuStrip1;
            this.dataTableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataTableView.Location = new System.Drawing.Point(0, 0);
            this.dataTableView.MultiSelect = false;
            this.dataTableView.Name = "dataTableView";
            this.dataTableView.ReadOnly = true;
            this.dataTableView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataTableView.Size = new System.Drawing.Size(891, 591);
            this.dataTableView.TabIndex = 0;
            this.dataTableView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataTableView_CellMouseDoubleClick);
            this.dataTableView.SelectionChanged += new System.EventHandler(this.dataTableView_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzWNowejZakładceToolStripMenuItem,
            this.właściwościToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(208, 48);
            // 
            // otwórzWNowejZakładceToolStripMenuItem
            // 
            this.otwórzWNowejZakładceToolStripMenuItem.Name = "otwórzWNowejZakładceToolStripMenuItem";
            this.otwórzWNowejZakładceToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.otwórzWNowejZakładceToolStripMenuItem.Text = "Otwórz w nowej zakładce";
            // 
            // właściwościToolStripMenuItem
            // 
            this.właściwościToolStripMenuItem.Name = "właściwościToolStripMenuItem";
            this.właściwościToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.właściwościToolStripMenuItem.Text = "Właściwości";
            // 
            // TableUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataTableView);
            this.Name = "TableUserControl";
            this.Size = new System.Drawing.Size(891, 591);
            this.Load += new System.EventHandler(this.TableUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataTableView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem otwórzWNowejZakładceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem właściwościToolStripMenuItem;
    }
}