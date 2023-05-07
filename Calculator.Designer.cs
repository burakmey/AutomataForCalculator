using System.Drawing;
using System.Windows.Forms;

namespace AutomataForCalculator
{
    partial class Calculator
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
            this.inputLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputLabel
            // 
            this.inputLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.inputLabel.Location = new System.Drawing.Point(0, 0);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.inputLabel.Size = new System.Drawing.Size(345, 80);
            this.inputLabel.TabIndex = 0;
            this.inputLabel.Text = "0";
            this.inputLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 440);
            this.Controls.Add(this.inputLabel);
            this.Name = "Calculator";
            this.Text = "Calculator";
            this.ResumeLayout(false);

        }

        #endregion

        private Label inputLabel;
    }
}