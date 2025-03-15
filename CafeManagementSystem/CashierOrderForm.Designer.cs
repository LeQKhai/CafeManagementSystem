namespace CafeManagementSystem
{
    partial class CashierOrderForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CashierOrderForm_menuTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CashierOrderForm_clearBtn = new System.Windows.Forms.Button();
            this.CashierOrderForm_removeBtn = new System.Windows.Forms.Button();
            this.CashierOrderForm_addBtn = new System.Windows.Forms.Button();
            this.CashierOrderForm_quantity = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.CashierOrderForm_prodName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CashierOrderForm_price = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CashierOrderForm_productID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CashierOrderForm_type = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CashierOrderForm_payBtn = new System.Windows.Forms.Button();
            this.CashierOrderForm_receiptBtn = new System.Windows.Forms.Button();
            this.CashierOrderForm_change = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.CashierOrderForm_amount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CashierOrderForm_orderPrice = new System.Windows.Forms.Label();
            this.CashierOrderForm_orderTable = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CashierOrderForm_menuTable)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CashierOrderForm_quantity)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CashierOrderForm_orderTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.CashierOrderForm_menuTable);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(20, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(769, 358);
            this.panel2.TabIndex = 4;
            // 
            // CashierOrderForm_menuTable
            // 
            this.CashierOrderForm_menuTable.AllowUserToAddRows = false;
            this.CashierOrderForm_menuTable.AllowUserToDeleteRows = false;
            this.CashierOrderForm_menuTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CashierOrderForm_menuTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(178)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CashierOrderForm_menuTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.CashierOrderForm_menuTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CashierOrderForm_menuTable.EnableHeadersVisualStyles = false;
            this.CashierOrderForm_menuTable.Location = new System.Drawing.Point(27, 60);
            this.CashierOrderForm_menuTable.Name = "CashierOrderForm_menuTable";
            this.CashierOrderForm_menuTable.ReadOnly = true;
            this.CashierOrderForm_menuTable.RowHeadersVisible = false;
            this.CashierOrderForm_menuTable.Size = new System.Drawing.Size(708, 272);
            this.CashierOrderForm_menuTable.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menu";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.CashierOrderForm_clearBtn);
            this.panel1.Controls.Add(this.CashierOrderForm_removeBtn);
            this.panel1.Controls.Add(this.CashierOrderForm_addBtn);
            this.panel1.Controls.Add(this.CashierOrderForm_quantity);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.CashierOrderForm_prodName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.CashierOrderForm_price);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CashierOrderForm_productID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CashierOrderForm_type);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(20, 397);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 329);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // CashierOrderForm_clearBtn
            // 
            this.CashierOrderForm_clearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(76)))), ((int)(((byte)(62)))));
            this.CashierOrderForm_clearBtn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierOrderForm_clearBtn.ForeColor = System.Drawing.Color.White;
            this.CashierOrderForm_clearBtn.Location = new System.Drawing.Point(507, 193);
            this.CashierOrderForm_clearBtn.Name = "CashierOrderForm_clearBtn";
            this.CashierOrderForm_clearBtn.Size = new System.Drawing.Size(177, 49);
            this.CashierOrderForm_clearBtn.TabIndex = 24;
            this.CashierOrderForm_clearBtn.Text = "CLEAR";
            this.CashierOrderForm_clearBtn.UseVisualStyleBackColor = false;
            // 
            // CashierOrderForm_removeBtn
            // 
            this.CashierOrderForm_removeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(76)))), ((int)(((byte)(62)))));
            this.CashierOrderForm_removeBtn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierOrderForm_removeBtn.ForeColor = System.Drawing.Color.White;
            this.CashierOrderForm_removeBtn.Location = new System.Drawing.Point(291, 193);
            this.CashierOrderForm_removeBtn.Name = "CashierOrderForm_removeBtn";
            this.CashierOrderForm_removeBtn.Size = new System.Drawing.Size(177, 49);
            this.CashierOrderForm_removeBtn.TabIndex = 23;
            this.CashierOrderForm_removeBtn.Text = "REMOVE";
            this.CashierOrderForm_removeBtn.UseVisualStyleBackColor = false;
            // 
            // CashierOrderForm_addBtn
            // 
            this.CashierOrderForm_addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(76)))), ((int)(((byte)(62)))));
            this.CashierOrderForm_addBtn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierOrderForm_addBtn.ForeColor = System.Drawing.Color.White;
            this.CashierOrderForm_addBtn.Location = new System.Drawing.Point(66, 193);
            this.CashierOrderForm_addBtn.Name = "CashierOrderForm_addBtn";
            this.CashierOrderForm_addBtn.Size = new System.Drawing.Size(177, 49);
            this.CashierOrderForm_addBtn.TabIndex = 22;
            this.CashierOrderForm_addBtn.Text = "ADD";
            this.CashierOrderForm_addBtn.UseVisualStyleBackColor = false;
            // 
            // CashierOrderForm_quantity
            // 
            this.CashierOrderForm_quantity.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierOrderForm_quantity.Location = new System.Drawing.Point(539, 94);
            this.CashierOrderForm_quantity.Name = "CashierOrderForm_quantity";
            this.CashierOrderForm_quantity.Size = new System.Drawing.Size(166, 25);
            this.CashierOrderForm_quantity.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(447, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 22);
            this.label8.TabIndex = 20;
            this.label8.Text = "Quantity:";
            // 
            // CashierOrderForm_prodName
            // 
            this.CashierOrderForm_prodName.AutoSize = true;
            this.CashierOrderForm_prodName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierOrderForm_prodName.Location = new System.Drawing.Point(165, 94);
            this.CashierOrderForm_prodName.Name = "CashierOrderForm_prodName";
            this.CashierOrderForm_prodName.Size = new System.Drawing.Size(114, 22);
            this.CashierOrderForm_prodName.TabIndex = 19;
            this.CashierOrderForm_prodName.Text = "Test Product";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(62, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 22);
            this.label6.TabIndex = 18;
            this.label6.Text = "Price ($):";
            // 
            // CashierOrderForm_price
            // 
            this.CashierOrderForm_price.AutoSize = true;
            this.CashierOrderForm_price.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierOrderForm_price.Location = new System.Drawing.Point(165, 143);
            this.CashierOrderForm_price.Name = "CashierOrderForm_price";
            this.CashierOrderForm_price.Size = new System.Drawing.Size(40, 22);
            this.CashierOrderForm_price.TabIndex = 17;
            this.CashierOrderForm_price.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 22);
            this.label3.TabIndex = 16;
            this.label3.Text = "Product Name:";
            // 
            // CashierOrderForm_productID
            // 
            this.CashierOrderForm_productID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierOrderForm_productID.FormattingEnabled = true;
            this.CashierOrderForm_productID.Location = new System.Drawing.Point(539, 41);
            this.CashierOrderForm_productID.Name = "CashierOrderForm_productID";
            this.CashierOrderForm_productID.Size = new System.Drawing.Size(166, 26);
            this.CashierOrderForm_productID.TabIndex = 15;
            this.CashierOrderForm_productID.SelectedIndexChanged += new System.EventHandler(this.CashierOrderForm_productID_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(427, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 22);
            this.label2.TabIndex = 14;
            this.label2.Text = "Product ID:";
            // 
            // CashierOrderForm_type
            // 
            this.CashierOrderForm_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierOrderForm_type.FormattingEnabled = true;
            this.CashierOrderForm_type.Items.AddRange(new object[] {
            "Meal",
            "Drinks"});
            this.CashierOrderForm_type.Location = new System.Drawing.Point(126, 40);
            this.CashierOrderForm_type.Name = "CashierOrderForm_type";
            this.CashierOrderForm_type.Size = new System.Drawing.Size(162, 26);
            this.CashierOrderForm_type.TabIndex = 13;
            this.CashierOrderForm_type.SelectedIndexChanged += new System.EventHandler(this.CashierOrderForm_type_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(65, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 22);
            this.label4.TabIndex = 12;
            this.label4.Text = "Type:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.CashierOrderForm_payBtn);
            this.panel3.Controls.Add(this.CashierOrderForm_receiptBtn);
            this.panel3.Controls.Add(this.CashierOrderForm_change);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.CashierOrderForm_amount);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.CashierOrderForm_orderPrice);
            this.panel3.Controls.Add(this.CashierOrderForm_orderTable);
            this.panel3.Location = new System.Drawing.Point(818, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(441, 705);
            this.panel3.TabIndex = 6;
            // 
            // CashierOrderForm_payBtn
            // 
            this.CashierOrderForm_payBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(76)))), ((int)(((byte)(62)))));
            this.CashierOrderForm_payBtn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierOrderForm_payBtn.ForeColor = System.Drawing.Color.White;
            this.CashierOrderForm_payBtn.Location = new System.Drawing.Point(64, 569);
            this.CashierOrderForm_payBtn.Name = "CashierOrderForm_payBtn";
            this.CashierOrderForm_payBtn.Size = new System.Drawing.Size(311, 49);
            this.CashierOrderForm_payBtn.TabIndex = 26;
            this.CashierOrderForm_payBtn.Text = "PAY";
            this.CashierOrderForm_payBtn.UseVisualStyleBackColor = false;
            // 
            // CashierOrderForm_receiptBtn
            // 
            this.CashierOrderForm_receiptBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(76)))), ((int)(((byte)(62)))));
            this.CashierOrderForm_receiptBtn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierOrderForm_receiptBtn.ForeColor = System.Drawing.Color.White;
            this.CashierOrderForm_receiptBtn.Location = new System.Drawing.Point(64, 633);
            this.CashierOrderForm_receiptBtn.Name = "CashierOrderForm_receiptBtn";
            this.CashierOrderForm_receiptBtn.Size = new System.Drawing.Size(311, 49);
            this.CashierOrderForm_receiptBtn.TabIndex = 25;
            this.CashierOrderForm_receiptBtn.Text = "RECEIPT";
            this.CashierOrderForm_receiptBtn.UseVisualStyleBackColor = false;
            // 
            // CashierOrderForm_change
            // 
            this.CashierOrderForm_change.AutoSize = true;
            this.CashierOrderForm_change.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierOrderForm_change.Location = new System.Drawing.Point(261, 505);
            this.CashierOrderForm_change.Name = "CashierOrderForm_change";
            this.CashierOrderForm_change.Size = new System.Drawing.Size(20, 22);
            this.CashierOrderForm_change.TabIndex = 24;
            this.CashierOrderForm_change.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(140, 505);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 22);
            this.label13.TabIndex = 23;
            this.label13.Text = "Change ($):";
            // 
            // CashierOrderForm_amount
            // 
            this.CashierOrderForm_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierOrderForm_amount.Location = new System.Drawing.Point(252, 458);
            this.CashierOrderForm_amount.Name = "CashierOrderForm_amount";
            this.CashierOrderForm_amount.Size = new System.Drawing.Size(151, 24);
            this.CashierOrderForm_amount.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(140, 458);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 22);
            this.label11.TabIndex = 21;
            this.label11.Text = "Amount ($):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(161, 415);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 22);
            this.label9.TabIndex = 20;
            this.label9.Text = "Price ($):";
            // 
            // CashierOrderForm_orderPrice
            // 
            this.CashierOrderForm_orderPrice.AutoSize = true;
            this.CashierOrderForm_orderPrice.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashierOrderForm_orderPrice.Location = new System.Drawing.Point(261, 417);
            this.CashierOrderForm_orderPrice.Name = "CashierOrderForm_orderPrice";
            this.CashierOrderForm_orderPrice.Size = new System.Drawing.Size(40, 22);
            this.CashierOrderForm_orderPrice.TabIndex = 19;
            this.CashierOrderForm_orderPrice.Text = "100";
            // 
            // CashierOrderForm_orderTable
            // 
            this.CashierOrderForm_orderTable.AllowUserToAddRows = false;
            this.CashierOrderForm_orderTable.AllowUserToDeleteRows = false;
            this.CashierOrderForm_orderTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CashierOrderForm_orderTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(178)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CashierOrderForm_orderTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.CashierOrderForm_orderTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CashierOrderForm_orderTable.EnableHeadersVisualStyles = false;
            this.CashierOrderForm_orderTable.Location = new System.Drawing.Point(27, 60);
            this.CashierOrderForm_orderTable.Name = "CashierOrderForm_orderTable";
            this.CashierOrderForm_orderTable.ReadOnly = true;
            this.CashierOrderForm_orderTable.RowHeadersVisible = false;
            this.CashierOrderForm_orderTable.Size = new System.Drawing.Size(384, 315);
            this.CashierOrderForm_orderTable.TabIndex = 5;
            // 
            // CashierOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "CashierOrderForm";
            this.Size = new System.Drawing.Size(1295, 755);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CashierOrderForm_menuTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CashierOrderForm_quantity)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CashierOrderForm_orderTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView CashierOrderForm_menuTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CashierOrderForm_type;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CashierOrderForm_productID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown CashierOrderForm_quantity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label CashierOrderForm_prodName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label CashierOrderForm_price;
        private System.Windows.Forms.Button CashierOrderForm_clearBtn;
        private System.Windows.Forms.Button CashierOrderForm_removeBtn;
        private System.Windows.Forms.Button CashierOrderForm_addBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label CashierOrderForm_orderPrice;
        private System.Windows.Forms.DataGridView CashierOrderForm_orderTable;
        private System.Windows.Forms.TextBox CashierOrderForm_amount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button CashierOrderForm_payBtn;
        private System.Windows.Forms.Button CashierOrderForm_receiptBtn;
        private System.Windows.Forms.Label CashierOrderForm_change;
        private System.Windows.Forms.Label label13;
    }
}
