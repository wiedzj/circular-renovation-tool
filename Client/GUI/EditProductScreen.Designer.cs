namespace BuildingFutureCities
{
    partial class EditProductScreen
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
            this.labelProductGroup = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelEmbodiedCO2 = new System.Windows.Forms.Label();
            this.labelEmbodiedEnergy = new System.Windows.Forms.Label();
            this.labelProductGroupValue = new System.Windows.Forms.Label();
            this.numericUpDownEmbodiedCO2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEmbodiedEnergy = new System.Windows.Forms.NumericUpDown();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelCategoryValue = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEmbodiedCO2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEmbodiedEnergy)).BeginInit();
            this.SuspendLayout();
            // 
            // labelProductGroup
            // 
            this.labelProductGroup.AutoSize = true;
            this.labelProductGroup.Location = new System.Drawing.Point(23, 22);
            this.labelProductGroup.Name = "labelProductGroup";
            this.labelProductGroup.Size = new System.Drawing.Size(98, 17);
            this.labelProductGroup.TabIndex = 0;
            this.labelProductGroup.Text = "Productgroep:";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(23, 48);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(73, 17);
            this.labelCategory.TabIndex = 1;
            this.labelCategory.Text = "Categorie:";
            // 
            // labelEmbodiedCO2
            // 
            this.labelEmbodiedCO2.AutoSize = true;
            this.labelEmbodiedCO2.Location = new System.Drawing.Point(23, 76);
            this.labelEmbodiedCO2.Name = "labelEmbodiedCO2";
            this.labelEmbodiedCO2.Size = new System.Drawing.Size(107, 17);
            this.labelEmbodiedCO2.TabIndex = 2;
            this.labelEmbodiedCO2.Text = "Embodied CO2:";
            // 
            // labelEmbodiedEnergy
            // 
            this.labelEmbodiedEnergy.AutoSize = true;
            this.labelEmbodiedEnergy.Location = new System.Drawing.Point(23, 103);
            this.labelEmbodiedEnergy.Name = "labelEmbodiedEnergy";
            this.labelEmbodiedEnergy.Size = new System.Drawing.Size(124, 17);
            this.labelEmbodiedEnergy.TabIndex = 3;
            this.labelEmbodiedEnergy.Text = "Embodied Energy:";
            // 
            // labelProductGroupValue
            // 
            this.labelProductGroupValue.AutoSize = true;
            this.labelProductGroupValue.Location = new System.Drawing.Point(152, 22);
            this.labelProductGroupValue.Name = "labelProductGroupValue";
            this.labelProductGroupValue.Size = new System.Drawing.Size(46, 17);
            this.labelProductGroupValue.TabIndex = 4;
            this.labelProductGroupValue.Text = "label1";
            // 
            // numericUpDownEmbodiedCO2
            // 
            this.numericUpDownEmbodiedCO2.DecimalPlaces = 1;
            this.numericUpDownEmbodiedCO2.Location = new System.Drawing.Point(156, 74);
            this.numericUpDownEmbodiedCO2.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownEmbodiedCO2.Name = "numericUpDownEmbodiedCO2";
            this.numericUpDownEmbodiedCO2.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownEmbodiedCO2.TabIndex = 6;
            // 
            // numericUpDownEmbodiedEnergy
            // 
            this.numericUpDownEmbodiedEnergy.DecimalPlaces = 1;
            this.numericUpDownEmbodiedEnergy.Location = new System.Drawing.Point(156, 103);
            this.numericUpDownEmbodiedEnergy.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownEmbodiedEnergy.Name = "numericUpDownEmbodiedEnergy";
            this.numericUpDownEmbodiedEnergy.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownEmbodiedEnergy.TabIndex = 7;
            // 
            // buttonAdd
            // 
            this.buttonAdd.AutoSize = true;
            this.buttonAdd.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonAdd.Location = new System.Drawing.Point(174, 162);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 27);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "Voeg toe";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelCategoryValue
            // 
            this.labelCategoryValue.AutoSize = true;
            this.labelCategoryValue.Location = new System.Drawing.Point(155, 48);
            this.labelCategoryValue.Name = "labelCategoryValue";
            this.labelCategoryValue.Size = new System.Drawing.Size(46, 17);
            this.labelCategoryValue.TabIndex = 9;
            this.labelCategoryValue.Text = "label1";
            // 
            // buttonDelete
            // 
            this.buttonDelete.AutoSize = true;
            this.buttonDelete.Location = new System.Drawing.Point(45, 162);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(76, 27);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Verwijder";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // EditProductScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 214);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelCategoryValue);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.numericUpDownEmbodiedEnergy);
            this.Controls.Add(this.numericUpDownEmbodiedCO2);
            this.Controls.Add(this.labelProductGroupValue);
            this.Controls.Add(this.labelEmbodiedEnergy);
            this.Controls.Add(this.labelEmbodiedCO2);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.labelProductGroup);
            this.Name = "EditProductScreen";
            this.Text = "Nieuw product";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEmbodiedCO2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEmbodiedEnergy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProductGroup;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelEmbodiedCO2;
        private System.Windows.Forms.Label labelEmbodiedEnergy;
        private System.Windows.Forms.Label labelProductGroupValue;
        private System.Windows.Forms.NumericUpDown numericUpDownEmbodiedCO2;
        private System.Windows.Forms.NumericUpDown numericUpDownEmbodiedEnergy;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelCategoryValue;
        private System.Windows.Forms.Button buttonDelete;
    }
}