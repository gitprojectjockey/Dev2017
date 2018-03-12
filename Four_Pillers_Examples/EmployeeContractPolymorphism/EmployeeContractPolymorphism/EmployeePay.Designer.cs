namespace EmployeeContractPolymorphism
{
    partial class EmployeePay
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
            this.btnPay = new System.Windows.Forms.Button();
            this.listPay = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(12, 139);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(199, 55);
            this.btnPay.TabIndex = 0;
            this.btnPay.Text = "Calculate Weekly Pay";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.BtnPay_Click);
            // 
            // listPay
            // 
            this.listPay.FormattingEnabled = true;
            this.listPay.Location = new System.Drawing.Point(12, 12);
            this.listPay.Name = "listPay";
            this.listPay.Size = new System.Drawing.Size(455, 121);
            this.listPay.TabIndex = 1;
            // 
            // EmployeePay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 199);
            this.Controls.Add(this.listPay);
            this.Controls.Add(this.btnPay);
            this.Name = "EmployeePay";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.ListBox listPay;
    }
}

