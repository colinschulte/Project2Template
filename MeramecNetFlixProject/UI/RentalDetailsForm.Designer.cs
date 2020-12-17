namespace MeramecNetFlixProject.UI
{
    partial class RentalDetailsForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnTrailer = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(25, 67);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(61, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(27, 120);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(49, 17);
            this.lblRating.TabIndex = 1;
            this.lblRating.Text = "Rating";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(80, 119);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(38, 17);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Year";
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(30, 309);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(128, 23);
            this.btnOrder.TabIndex = 4;
            this.btnOrder.Text = "Order Selection";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnTrailer
            // 
            this.btnTrailer.Location = new System.Drawing.Point(30, 338);
            this.btnTrailer.Name = "btnTrailer";
            this.btnTrailer.Size = new System.Drawing.Size(128, 23);
            this.btnTrailer.TabIndex = 5;
            this.btnTrailer.Text = "Preview Trailer";
            this.btnTrailer.UseVisualStyleBackColor = true;
            this.btnTrailer.Click += new System.EventHandler(this.btnTrailer_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(30, 367);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(128, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Go Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(12, 156);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(195, 147);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(213, 92);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(560, 298);
            this.webBrowser1.TabIndex = 8;
            this.webBrowser1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // RentalDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnTrailer);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblTitle);
            this.Name = "RentalDetailsForm";
            this.Text = "RentalSearchForm2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnTrailer;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label1;
    }
}