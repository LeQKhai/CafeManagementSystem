namespace CafeManagementSystem
{
    partial class AdminMainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.khachHang_btn = new System.Windows.Forms.Button();
            this.logout_btn = new System.Windows.Forms.Button();
            this.customer_btn = new System.Windows.Forms.Button();
            this.menu_btn = new System.Windows.Forms.Button();
            this.emp_button = new System.Windows.Forms.Button();
            this.dash_button = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.adminDashboardForm1 = new CafeManagementSystem.AdminDashboardForm();
            this.cashierCustomerFrom1 = new CafeManagementSystem.CashierOrderHistoryFrom();
            this.adminAddProducts1 = new CafeManagementSystem.AdminAddProducts();
            this.adminAddUsers1 = new CafeManagementSystem.AdminAddUsersForm();
            this.adminManageCustomersForm1 = new CafeManagementSystem.AdminManageCustomersForm();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1508, 45);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 22);
            this.label1.TabIndex = 13;
            this.label1.Text = "Hệ thống quản lý quán cafe";
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Location = new System.Drawing.Point(1469, 9);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(21, 20);
            this.close.TabIndex = 12;
            this.close.Text = "X";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(76)))), ((int)(((byte)(62)))));
            this.panel2.Controls.Add(this.khachHang_btn);
            this.panel2.Controls.Add(this.logout_btn);
            this.panel2.Controls.Add(this.customer_btn);
            this.panel2.Controls.Add(this.menu_btn);
            this.panel2.Controls.Add(this.emp_button);
            this.panel2.Controls.Add(this.dash_button);
            this.panel2.Controls.Add(this.username);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(205, 755);
            this.panel2.TabIndex = 0;
            // 
            // khachHang_btn
            // 
            this.khachHang_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.khachHang_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khachHang_btn.ForeColor = System.Drawing.Color.White;
            this.khachHang_btn.Location = new System.Drawing.Point(6, 476);
            this.khachHang_btn.Name = "khachHang_btn";
            this.khachHang_btn.Size = new System.Drawing.Size(190, 43);
            this.khachHang_btn.TabIndex = 22;
            this.khachHang_btn.Text = "Khách Hàng";
            this.khachHang_btn.UseVisualStyleBackColor = true;
            this.khachHang_btn.Click += new System.EventHandler(this.khachHang_btn_Click);
            // 
            // logout_btn
            // 
            this.logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout_btn.ForeColor = System.Drawing.Color.White;
            this.logout_btn.Location = new System.Drawing.Point(6, 640);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(190, 43);
            this.logout_btn.TabIndex = 21;
            this.logout_btn.Text = "Đăng xuất";
            this.logout_btn.UseVisualStyleBackColor = true;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // customer_btn
            // 
            this.customer_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customer_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer_btn.ForeColor = System.Drawing.Color.White;
            this.customer_btn.Location = new System.Drawing.Point(7, 415);
            this.customer_btn.Name = "customer_btn";
            this.customer_btn.Size = new System.Drawing.Size(190, 43);
            this.customer_btn.TabIndex = 20;
            this.customer_btn.Text = "Lịch sử đơn hàng";
            this.customer_btn.UseVisualStyleBackColor = true;
            this.customer_btn.Click += new System.EventHandler(this.customer_btn_Click);
            // 
            // menu_btn
            // 
            this.menu_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_btn.ForeColor = System.Drawing.Color.White;
            this.menu_btn.Location = new System.Drawing.Point(7, 354);
            this.menu_btn.Name = "menu_btn";
            this.menu_btn.Size = new System.Drawing.Size(190, 43);
            this.menu_btn.TabIndex = 19;
            this.menu_btn.Text = "Menu";
            this.menu_btn.UseVisualStyleBackColor = true;
            this.menu_btn.Click += new System.EventHandler(this.menu_btn_Click);
            // 
            // emp_button
            // 
            this.emp_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emp_button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emp_button.ForeColor = System.Drawing.Color.White;
            this.emp_button.Location = new System.Drawing.Point(6, 292);
            this.emp_button.Name = "emp_button";
            this.emp_button.Size = new System.Drawing.Size(190, 43);
            this.emp_button.TabIndex = 18;
            this.emp_button.Text = "Thêm nhân viên";
            this.emp_button.UseVisualStyleBackColor = true;
            this.emp_button.Click += new System.EventHandler(this.emp_btn_Click);
            // 
            // dash_button
            // 
            this.dash_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dash_button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dash_button.ForeColor = System.Drawing.Color.White;
            this.dash_button.Location = new System.Drawing.Point(6, 231);
            this.dash_button.Name = "dash_button";
            this.dash_button.Size = new System.Drawing.Size(190, 43);
            this.dash_button.TabIndex = 17;
            this.dash_button.Text = "Trang chủ";
            this.dash_button.UseVisualStyleBackColor = true;
            this.dash_button.Click += new System.EventHandler(this.dash_btn_Click);
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.White;
            this.username.Location = new System.Drawing.Point(99, 190);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(43, 15);
            this.username.TabIndex = 16;
            this.username.Text = "Admin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tên đăng nhập:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Cổng thông tin Admin";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CafeManagementSystem.Properties.Resources.coffee;
            this.pictureBox1.Location = new System.Drawing.Point(32, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.adminDashboardForm1);
            this.panel3.Controls.Add(this.cashierCustomerFrom1);
            this.panel3.Controls.Add(this.adminAddProducts1);
            this.panel3.Controls.Add(this.adminAddUsers1);
            this.panel3.Controls.Add(this.adminManageCustomersForm1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(205, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1303, 755);
            this.panel3.TabIndex = 1;
            // 
            // adminDashboardForm1
            // 
            this.adminDashboardForm1.Location = new System.Drawing.Point(4, 0);
            this.adminDashboardForm1.Name = "adminDashboardForm1";
            this.adminDashboardForm1.Size = new System.Drawing.Size(1295, 755);
            this.adminDashboardForm1.TabIndex = 3;
            // 
            // cashierCustomerFrom1
            // 
            this.cashierCustomerFrom1.Location = new System.Drawing.Point(0, 0);
            this.cashierCustomerFrom1.Name = "cashierCustomerFrom1";
            this.cashierCustomerFrom1.Size = new System.Drawing.Size(1303, 755);
            this.cashierCustomerFrom1.TabIndex = 2;
            // 
            // adminAddProducts1
            // 
            this.adminAddProducts1.Location = new System.Drawing.Point(0, 0);
            this.adminAddProducts1.Name = "adminAddProducts1";
            this.adminAddProducts1.Size = new System.Drawing.Size(1295, 755);
            this.adminAddProducts1.TabIndex = 1;
            // 
            // adminAddUsers1
            // 
            this.adminAddUsers1.Location = new System.Drawing.Point(0, 0);
            this.adminAddUsers1.Name = "adminAddUsers1";
            this.adminAddUsers1.Size = new System.Drawing.Size(1295, 755);
            this.adminAddUsers1.TabIndex = 0;
            // 
            // adminManageCustomersForm1
            // 
            this.adminManageCustomersForm1.BackColor = System.Drawing.SystemColors.Control;
            this.adminManageCustomersForm1.Location = new System.Drawing.Point(0, 0);
            this.adminManageCustomersForm1.Name = "adminManageCustomersForm1";
            this.adminManageCustomersForm1.Size = new System.Drawing.Size(1295, 755);
            this.adminManageCustomersForm1.TabIndex = 4;
            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1508, 800);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminMainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button emp_button;
        private System.Windows.Forms.Button dash_button;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button customer_btn;
        private System.Windows.Forms.Button menu_btn;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Panel panel3;
        private AdminAddUsersForm adminAddUsers1;
        private AdminAddProducts adminAddProducts1;
        private AdminDashboardForm adminDashboardForm1;
        private CashierOrderHistoryFrom cashierCustomerFrom1;
        private System.Windows.Forms.Button khachHang_btn;
        private AdminManageCustomersForm adminManageCustomersForm1;
    }
}