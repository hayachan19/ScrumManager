namespace ScrumManager
{
    partial class ProjectForm
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
            this.ProjectName_TextBox = new System.Windows.Forms.TextBox();
            this.ProjectStart_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.ProjectEnd_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.ProjectName_Label = new System.Windows.Forms.Label();
            this.ProjectStart_Label = new System.Windows.Forms.Label();
            this.ProjectEnd_Label = new System.Windows.Forms.Label();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProjectNameTextBox
            // 
            this.ProjectName_TextBox.Location = new System.Drawing.Point(108, 9);
            this.ProjectName_TextBox.Name = "ProjectName_TextBox";
            this.ProjectName_TextBox.Size = new System.Drawing.Size(200, 20);
            this.ProjectName_TextBox.TabIndex = 0;
            // 
            // ProjectStartDatePicker
            // 
            this.ProjectStart_DatePicker.Location = new System.Drawing.Point(108, 37);
            this.ProjectStart_DatePicker.Name = "ProjectStart_DatePicker";
            this.ProjectStart_DatePicker.Size = new System.Drawing.Size(200, 20);
            this.ProjectStart_DatePicker.TabIndex = 1;
            // 
            // ProjectEndDatePicker
            // 
            this.ProjectEnd_DatePicker.Location = new System.Drawing.Point(108, 71);
            this.ProjectEnd_DatePicker.Name = "ProjectEnd_DatePicker";
            this.ProjectEnd_DatePicker.Size = new System.Drawing.Size(200, 20);
            this.ProjectEnd_DatePicker.TabIndex = 2;
            // 
            // button4
            // 
            this.OK_Button.Location = new System.Drawing.Point(12, 106);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 23);
            this.OK_Button.TabIndex = 10;
            this.OK_Button.Text = "OK";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // button5
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(233, 106);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 11;
            this.Cancel_Button.Text = "Anuluj";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // label3
            // 
            this.ProjectName_Label.AutoSize = true;
            this.ProjectName_Label.Location = new System.Drawing.Point(9, 12);
            this.ProjectName_Label.Name = "ProjectName_Label";
            this.ProjectName_Label.Size = new System.Drawing.Size(81, 13);
            this.ProjectName_Label.TabIndex = 13;
            this.ProjectName_Label.Text = "Nazwa projektu";
            // 
            // label4
            // 
            this.ProjectStart_Label.AutoSize = true;
            this.ProjectStart_Label.Location = new System.Drawing.Point(9, 43);
            this.ProjectStart_Label.Name = "ProjectStart_Label";
            this.ProjectStart_Label.Size = new System.Drawing.Size(90, 13);
            this.ProjectStart_Label.TabIndex = 14;
            this.ProjectStart_Label.Text = "Data rozpoczęcia";
            // 
            // label5
            // 
            this.ProjectEnd_Label.AutoSize = true;
            this.ProjectEnd_Label.Location = new System.Drawing.Point(9, 77);
            this.ProjectEnd_Label.Name = "ProjectEnd_Label";
            this.ProjectEnd_Label.Size = new System.Drawing.Size(93, 13);
            this.ProjectEnd_Label.TabIndex = 15;
            this.ProjectEnd_Label.Text = "Data zakończenia";
            // 
            // DeleteButton
            // 
            this.Delete_Button.ForeColor = System.Drawing.Color.Red;
            this.Delete_Button.Location = new System.Drawing.Point(125, 106);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(75, 23);
            this.Delete_Button.TabIndex = 16;
            this.Delete_Button.Text = "Usuń";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 142);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.ProjectEnd_Label);
            this.Controls.Add(this.ProjectStart_Label);
            this.Controls.Add(this.ProjectName_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.ProjectEnd_DatePicker);
            this.Controls.Add(this.ProjectStart_DatePicker);
            this.Controls.Add(this.ProjectName_TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectForm";
            this.Text = "ProjectForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ProjectName_TextBox;
        private System.Windows.Forms.DateTimePicker ProjectStart_DatePicker;
        private System.Windows.Forms.DateTimePicker ProjectEnd_DatePicker;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Label ProjectName_Label;
        private System.Windows.Forms.Label ProjectStart_Label;
        private System.Windows.Forms.Label ProjectEnd_Label;
        private System.Windows.Forms.Button Delete_Button;
    }
}