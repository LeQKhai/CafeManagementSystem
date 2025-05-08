namespace CafeManagementSystem
{
    partial class AdminManageCustomersForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveCustomers = new System.Windows.Forms.Button();
            this.btnUpdateCustomers = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.btnDeleteCustomers = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin khách hàng";
            // 
            // btnSaveCustomers
            // 
            this.btnSaveCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveCustomers.Location = new System.Drawing.Point(31, 419);
            this.btnSaveCustomers.Name = "btnSaveCustomers";
            this.btnSaveCustomers.Size = new System.Drawing.Size(115, 56);
            this.btnSaveCustomers.TabIndex = 1;
            this.btnSaveCustomers.Text = "Lưu ";
            this.btnSaveCustomers.UseVisualStyleBackColor = true;
            this.btnSaveCustomers.Click += new System.EventHandler(this.btnSaveCustomers_Click);
            // 
            // btnUpdateCustomers
            // 
            this.btnUpdateCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCustomers.Location = new System.Drawing.Point(235, 419);
            this.btnUpdateCustomers.Name = "btnUpdateCustomers";
            this.btnUpdateCustomers.Size = new System.Drawing.Size(115, 56);
            this.btnUpdateCustomers.TabIndex = 2;
            this.btnUpdateCustomers.Text = "Cập nhật";
            this.btnUpdateCustomers.UseVisualStyleBackColor = true;
            this.btnUpdateCustomers.Click += new System.EventHandler(this.btnUpdateCustomers_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dgvCustomers);
            this.panel1.Location = new System.Drawing.Point(440, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 645);
            this.panel1.TabIndex = 3;
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(0, 0);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.Size = new System.Drawing.Size(717, 645);
            this.dgvCustomers.TabIndex = 0;
            // 
            // btnDeleteCustomers
            // 
            this.btnDeleteCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCustomers.Location = new System.Drawing.Point(131, 518);
            this.btnDeleteCustomers.Name = "btnDeleteCustomers";
            this.btnDeleteCustomers.Size = new System.Drawing.Size(115, 56);
            this.btnDeleteCustomers.TabIndex = 4;
            this.btnDeleteCustomers.Text = "Xóa";
            this.btnDeleteCustomers.UseVisualStyleBackColor = true;
            this.btnDeleteCustomers.Click += new System.EventHandler(this.btnDeleteCustomers_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Họ và tên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Số điện thoại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Địa chỉ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.Controls.Add(this.txtPhone);
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Controls.Add(this.txtAddress);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnDeleteCustomers);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnUpdateCustomers);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnSaveCustomers);
            this.panel2.Location = new System.Drawing.Point(22, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(393, 645);
            this.panel2.TabIndex = 6;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(152, 194);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(224, 29);
            this.txtPhone.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(115, 248);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(261, 29);
            this.txtEmail.TabIndex = 6;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(115, 309);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(261, 29);
            this.txtAddress.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(115, 135);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(261, 29);
            this.txtName.TabIndex = 6;
            // 
            // AdminManageCustomersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(76)))), ((int)(((byte)(62)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AdminManageCustomersForm";
            this.Size = new System.Drawing.Size(1279, 716);
            this.Load += new System.EventHandler(this.AdminManageCustomersForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveCustomers;
        private System.Windows.Forms.Button btnUpdateCustomers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Button btnDeleteCustomers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtName;
    }
}