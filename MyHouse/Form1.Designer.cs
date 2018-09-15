namespace MyHouse
{
    partial class Form1
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
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.goHereButton = new System.Windows.Forms.Button();
            this.exitsComboBox = new System.Windows.Forms.ComboBox();
            this.goThroughTheDoorButton = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.hideButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.Location = new System.Drawing.Point(12, 12);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(503, 633);
            this.descriptionTextBox.TabIndex = 0;
            // 
            // goHereButton
            // 
            this.goHereButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goHereButton.Location = new System.Drawing.Point(12, 651);
            this.goHereButton.Name = "goHereButton";
            this.goHereButton.Size = new System.Drawing.Size(111, 33);
            this.goHereButton.TabIndex = 1;
            this.goHereButton.Text = "Go Here";
            this.goHereButton.UseVisualStyleBackColor = true;
            this.goHereButton.Click += new System.EventHandler(this.goHereButton_Click);
            // 
            // exitsComboBox
            // 
            this.exitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exitsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitsComboBox.FormattingEnabled = true;
            this.exitsComboBox.Location = new System.Drawing.Point(147, 656);
            this.exitsComboBox.Name = "exitsComboBox";
            this.exitsComboBox.Size = new System.Drawing.Size(368, 28);
            this.exitsComboBox.TabIndex = 2;
            // 
            // goThroughTheDoorButton
            // 
            this.goThroughTheDoorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goThroughTheDoorButton.Location = new System.Drawing.Point(12, 690);
            this.goThroughTheDoorButton.Name = "goThroughTheDoorButton";
            this.goThroughTheDoorButton.Size = new System.Drawing.Size(503, 35);
            this.goThroughTheDoorButton.TabIndex = 3;
            this.goThroughTheDoorButton.Text = "Atraviesa la puerta";
            this.goThroughTheDoorButton.UseVisualStyleBackColor = true;
            this.goThroughTheDoorButton.Click += new System.EventHandler(this.goThroughTheDoorButton_Click);
            // 
            // checkButton
            // 
            this.checkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkButton.Location = new System.Drawing.Point(12, 731);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(503, 33);
            this.checkButton.TabIndex = 4;
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // hideButton
            // 
            this.hideButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hideButton.Location = new System.Drawing.Point(12, 770);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(503, 33);
            this.hideButton.TabIndex = 5;
            this.hideButton.Text = "Escóndete!";
            this.hideButton.UseVisualStyleBackColor = true;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(525, 816);
            this.Controls.Add(this.hideButton);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.goThroughTheDoorButton);
            this.Controls.Add(this.exitsComboBox);
            this.Controls.Add(this.goHereButton);
            this.Controls.Add(this.descriptionTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar al fistro!!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button goHereButton;
        private System.Windows.Forms.ComboBox exitsComboBox;
        private System.Windows.Forms.Button goThroughTheDoorButton;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Button hideButton;
    }
}

