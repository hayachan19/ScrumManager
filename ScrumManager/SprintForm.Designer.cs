namespace ScrumManager
{
    partial class SprintForm
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
            this.SprintName_TextBox = new System.Windows.Forms.TextBox();
            this.ProjectName_TextBox = new System.Windows.Forms.TextBox();
            this.SprintStart_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.SprintEnd_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Description_Label = new System.Windows.Forms.Label();
            this.Description_TextBox = new System.Windows.Forms.TextBox();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SprintName_TextBox
            // 
            this.SprintName_TextBox.Location = new System.Drawing.Point(121, 6);
            this.SprintName_TextBox.Name = "SprintName_TextBox";
            this.SprintName_TextBox.Size = new System.Drawing.Size(200, 20);
            this.SprintName_TextBox.TabIndex = 0;
            // 
            // ProjectName_TextBox
            // 
            this.ProjectName_TextBox.Enabled = false;
            this.ProjectName_TextBox.Location = new System.Drawing.Point(121, 32);
            this.ProjectName_TextBox.Name = "ProjectName_TextBox";
            this.ProjectName_TextBox.Size = new System.Drawing.Size(200, 20);
            this.ProjectName_TextBox.TabIndex = 1;
            // 
            // SprintStart_DatePicker
            // 
            this.SprintStart_DatePicker.Location = new System.Drawing.Point(121, 84);
            this.SprintStart_DatePicker.Name = "SprintStart_DatePicker";
            this.SprintStart_DatePicker.Size = new System.Drawing.Size(200, 20);
            this.SprintStart_DatePicker.TabIndex = 2;
            // 
            // SprintEnd_DatePicker
            // 
            this.SprintEnd_DatePicker.Location = new System.Drawing.Point(121, 110);
            this.SprintEnd_DatePicker.Name = "SprintEnd_DatePicker";
            this.SprintEnd_DatePicker.Size = new System.Drawing.Size(200, 20);
            this.SprintEnd_DatePicker.TabIndex = 3;
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(12, 143);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 23);
            this.OK_Button.TabIndex = 5;
            this.OK_Button.Text = "OK";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(248, 143);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 6;
            this.Cancel_Button.Text = "Anuluj";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nazwa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Projekt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Data rozpoczęcia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Data zakończenia";
            // 
            // Description_Label
            // 
            this.Description_Label.AutoSize = true;
            this.Description_Label.Location = new System.Drawing.Point(9, 61);
            this.Description_Label.Name = "Description_Label";
            this.Description_Label.Size = new System.Drawing.Size(28, 13);
            this.Description_Label.TabIndex = 11;
            this.Description_Label.Text = "Opis";
            // 
            // Description_TextBox
            // 
            this.Description_TextBox.Location = new System.Drawing.Point(121, 58);
            this.Description_TextBox.Name = "Description_TextBox";
            this.Description_TextBox.Size = new System.Drawing.Size(200, 20);
            this.Description_TextBox.TabIndex = 12;
            // 
            // Delete_Button
            // 
            this.Delete_Button.ForeColor = System.Drawing.Color.Red;
            this.Delete_Button.Location = new System.Drawing.Point(131, 143);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(75, 23);
            this.Delete_Button.TabIndex = 13;
            this.Delete_Button.Text = "Usuń";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // SprintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 179);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Description_TextBox);
            this.Controls.Add(this.Description_Label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.SprintEnd_DatePicker);
            this.Controls.Add(this.SprintStart_DatePicker);
            this.Controls.Add(this.ProjectName_TextBox);
            this.Controls.Add(this.SprintName_TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SprintForm";
            this.Text = "SprintForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SprintName_TextBox;
        private System.Windows.Forms.TextBox ProjectName_TextBox;
        private System.Windows.Forms.DateTimePicker SprintStart_DatePicker;
        private System.Windows.Forms.DateTimePicker SprintEnd_DatePicker;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Description_Label;
        private System.Windows.Forms.TextBox Description_TextBox;
        private System.Windows.Forms.Button Delete_Button;
    }
}