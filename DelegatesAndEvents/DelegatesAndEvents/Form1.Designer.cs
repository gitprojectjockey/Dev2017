﻿namespace DelegatesAndEvents
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
            this.button1 = new System.Windows.Forms.Button();
            this.listResults = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Func<T, TResult> Delegate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listResults
            // 
            this.listResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listResults.FormattingEnabled = true;
            this.listResults.ItemHeight = 16;
            this.listResults.Location = new System.Drawing.Point(282, 27);
            this.listResults.Name = "listResults";
            this.listResults.Size = new System.Drawing.Size(383, 260);
            this.listResults.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(31, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(232, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Actioin<T> Delegate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 306);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listResults);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Delegates and Events";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listResults;
        private System.Windows.Forms.Button button2;
    }
}

