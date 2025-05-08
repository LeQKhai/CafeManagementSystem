namespace CafeManagementSystem.Forms.Cashier
{
    partial class CashierPagerForm
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
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.deletePager_btn = new System.Windows.Forms.Button();
            this.createPager_btn = new System.Windows.Forms.Button();
            this.CashierOrderForm_prodName = new System.Windows.Forms.Label();
            this.CashierOrderForm_price = new System.Windows.Forms.Label();
            this.pagerContainerPanel = new System.Windows.Forms.Panel();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.Color.White;
            this.buttonPanel.Controls.Add(this.deletePager_btn);
            this.buttonPanel.Controls.Add(this.createPager_btn);
            this.buttonPanel.Controls.Add(this.CashierOrderForm_prodName);
            this.buttonPanel.Controls.Add(this.CashierOrderForm_price);
            this.buttonPanel.Location = new System.Drawing.Point(22, 488);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(1251, 122);
            this.buttonPanel.TabIndex = 6;
            // 
            // deletePager_btn
            // 
            this.deletePager_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(76)))), ((int)(((byte)(62)))));
            this.deletePager_btn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletePager_btn.ForeColor = System.Drawing.Color.White;
            this.deletePager_btn.Location = new System.Drawing.Point(684, 47);
            this.deletePager_btn.Name = "deletePager_btn";
            this.deletePager_btn.Size = new System.Drawing.Size(177, 49);
            this.deletePager_btn.TabIndex = 23;
            this.deletePager_btn.Text = "REMOVE";
            this.deletePager_btn.UseVisualStyleBackColor = false;
            this.deletePager_btn.Click += new System.EventHandler(this.deletePager_btn_Click);
            // 
            // createPager_btn
            // 
            this.createPager_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(76)))), ((int)(((byte)(62)))));
            this.createPager_btn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createPager_btn.ForeColor = System.Drawing.Color.White;
            this.createPager_btn.Location = new System.Drawing.Point(459, 47);
            this.createPager_btn.Name = "createPager_btn";
            this.createPager_btn.Size = new System.Drawing.Size(177, 49);
            this.createPager_btn.TabIndex = 22;
            this.createPager_btn.Text = "ADD";
            this.createPager_btn.UseVisualStyleBackColor = false;
            this.createPager_btn.Click += new System.EventHandler(this.createPager_btn_Click);
            // 
            // CashierOrderForm_prodName
            // 
            this.CashierOrderForm_prodName.AutoSize = true;
            this.CashierOrderForm_prodName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierOrderForm_prodName.Location = new System.Drawing.Point(165, 94);
            this.CashierOrderForm_prodName.Name = "CashierOrderForm_prodName";
            this.CashierOrderForm_prodName.Size = new System.Drawing.Size(0, 22);
            this.CashierOrderForm_prodName.TabIndex = 19;
            // 
            // CashierOrderForm_price
            // 
            this.CashierOrderForm_price.AutoSize = true;
            this.CashierOrderForm_price.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierOrderForm_price.Location = new System.Drawing.Point(165, 143);
            this.CashierOrderForm_price.Name = "CashierOrderForm_price";
            this.CashierOrderForm_price.Size = new System.Drawing.Size(0, 22);
            this.CashierOrderForm_price.TabIndex = 17;
            // 
            // pagerContainerPanel
            // 
            this.pagerContainerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.pagerContainerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pagerContainerPanel.Location = new System.Drawing.Point(22, 15);
            this.pagerContainerPanel.Name = "pagerContainerPanel";
            this.pagerContainerPanel.Size = new System.Drawing.Size(1251, 447);
            this.pagerContainerPanel.TabIndex = 7;
            // 
            // CashierPagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pagerContainerPanel);
            this.Controls.Add(this.buttonPanel);
            this.Name = "CashierPagerForm";
            this.Size = new System.Drawing.Size(1295, 755);
            this.buttonPanel.ResumeLayout(false);
            this.buttonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button deletePager_btn;
        private System.Windows.Forms.Button createPager_btn;
        private System.Windows.Forms.Label CashierOrderForm_prodName;
        private System.Windows.Forms.Label CashierOrderForm_price;
        private System.Windows.Forms.Panel pagerContainerPanel;
    }
}
