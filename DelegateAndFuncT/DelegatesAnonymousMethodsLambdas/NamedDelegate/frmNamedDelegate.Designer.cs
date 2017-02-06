namespace DelegatesAnonymousMethodsLambdas.NamedDelegate
{
    partial class frmNamedDelegate
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
            this.listResult = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHr = new System.Windows.Forms.Label();
            this.groupBoxChecked = new System.Windows.Forms.GroupBox();
            this.radFullName = new System.Windows.Forms.RadioButton();
            this.radFirstName = new System.Windows.Forms.RadioButton();
            this.radLastName = new System.Windows.Forms.RadioButton();
            this.radDefault = new System.Windows.Forms.RadioButton();
            this.btnProcess = new System.Windows.Forms.Button();
            this.groupBoxChecked.SuspendLayout();
            this.SuspendLayout();
            // 
            // listResult
            // 
            this.listResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listResult.FormattingEnabled = true;
            this.listResult.ItemHeight = 18;
            this.listResult.Location = new System.Drawing.Point(156, 89);
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(360, 220);
            this.listResult.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Named Delegate";
            // 
            // lblHr
            // 
            this.lblHr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHr.Location = new System.Drawing.Point(12, 56);
            this.lblHr.Name = "lblHr";
            this.lblHr.Size = new System.Drawing.Size(504, 2);
            this.lblHr.TabIndex = 3;
            // 
            // groupBoxChecked
            // 
            this.groupBoxChecked.Controls.Add(this.radFullName);
            this.groupBoxChecked.Controls.Add(this.radFirstName);
            this.groupBoxChecked.Controls.Add(this.radLastName);
            this.groupBoxChecked.Controls.Add(this.radDefault);
            this.groupBoxChecked.Location = new System.Drawing.Point(25, 89);
            this.groupBoxChecked.Name = "groupBoxChecked";
            this.groupBoxChecked.Size = new System.Drawing.Size(125, 126);
            this.groupBoxChecked.TabIndex = 7;
            this.groupBoxChecked.TabStop = false;
            this.groupBoxChecked.Text = "Select A Format";
            // 
            // radFullName
            // 
            this.radFullName.AutoSize = true;
            this.radFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radFullName.Location = new System.Drawing.Point(6, 97);
            this.radFullName.Name = "radFullName";
            this.radFullName.Size = new System.Drawing.Size(96, 20);
            this.radFullName.TabIndex = 3;
            this.radFullName.TabStop = true;
            this.radFullName.Text = "Full Name";
            this.radFullName.UseVisualStyleBackColor = true;
            // 
            // radFirstName
            // 
            this.radFirstName.AutoSize = true;
            this.radFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radFirstName.Location = new System.Drawing.Point(6, 71);
            this.radFirstName.Name = "radFirstName";
            this.radFirstName.Size = new System.Drawing.Size(101, 20);
            this.radFirstName.TabIndex = 2;
            this.radFirstName.TabStop = true;
            this.radFirstName.Text = "First Name";
            this.radFirstName.UseVisualStyleBackColor = true;
            // 
            // radLastName
            // 
            this.radLastName.AutoSize = true;
            this.radLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLastName.Location = new System.Drawing.Point(6, 45);
            this.radLastName.Name = "radLastName";
            this.radLastName.Size = new System.Drawing.Size(100, 20);
            this.radLastName.TabIndex = 1;
            this.radLastName.TabStop = true;
            this.radLastName.Text = "Last Name";
            this.radLastName.UseVisualStyleBackColor = true;
            // 
            // radDefault
            // 
            this.radDefault.AutoSize = true;
            this.radDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDefault.Location = new System.Drawing.Point(6, 19);
            this.radDefault.Name = "radDefault";
            this.radDefault.Size = new System.Drawing.Size(75, 20);
            this.radDefault.TabIndex = 0;
            this.radDefault.TabStop = true;
            this.radDefault.Text = "Default";
            this.radDefault.UseVisualStyleBackColor = true;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(15, 261);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(135, 48);
            this.btnProcess.TabIndex = 8;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // frmNamedDelegate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 323);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.groupBoxChecked);
            this.Controls.Add(this.lblHr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listResult);
            this.Name = "frmNamedDelegate";
            this.Text = "Format Person Names with Named Delegate";
            this.groupBoxChecked.ResumeLayout(false);
            this.groupBoxChecked.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHr;
        private System.Windows.Forms.GroupBox groupBoxChecked;
        private System.Windows.Forms.RadioButton radDefault;
        private System.Windows.Forms.RadioButton radFullName;
        private System.Windows.Forms.RadioButton radFirstName;
        private System.Windows.Forms.RadioButton radLastName;
        private System.Windows.Forms.Button btnProcess;
    }
}

