namespace CafeManagementSystem
{
    partial class AdminAddUsers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.adminAddUsers_importBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.adminAddUsers_clearBtn = new System.Windows.Forms.Button();
            this.adminAddUsers_deleteBtn = new System.Windows.Forms.Button();
            this.adminAddUsers_updateBtn = new System.Windows.Forms.Button();
            this.adminAddUsers_addBtn = new System.Windows.Forms.Button();
            this.adminAddUsers_status = new System.Windows.Forms.ComboBox();
            this.adminAddUsers_role = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.adminAddUsers_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.adminAddUsers_username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.adminAddUsers_imageView = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminAddUsers_imageView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.adminAddUsers_importBtn);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.adminAddUsers_clearBtn);
            this.panel1.Controls.Add(this.adminAddUsers_deleteBtn);
            this.panel1.Controls.Add(this.adminAddUsers_updateBtn);
            this.panel1.Controls.Add(this.adminAddUsers_addBtn);
            this.panel1.Controls.Add(this.adminAddUsers_status);
            this.panel1.Controls.Add(this.adminAddUsers_role);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.adminAddUsers_password);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.adminAddUsers_username);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(25, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 712);
            this.panel1.TabIndex = 0;
            // 
            // adminAddUsers_importBtn
            // 
            this.adminAddUsers_importBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(76)))), ((int)(((byte)(62)))));
            this.adminAddUsers_importBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminAddUsers_importBtn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminAddUsers_importBtn.ForeColor = System.Drawing.Color.White;
            this.adminAddUsers_importBtn.Location = new System.Drawing.Point(83, 156);
            this.adminAddUsers_importBtn.Name = "adminAddUsers_importBtn";
            this.adminAddUsers_importBtn.Size = new System.Drawing.Size(112, 41);
            this.adminAddUsers_importBtn.TabIndex = 17;
            this.adminAddUsers_importBtn.Text = "Thêm ảnh";
            this.adminAddUsers_importBtn.UseVisualStyleBackColor = false;
            this.adminAddUsers_importBtn.Click += new System.EventHandler(this.Import_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.adminAddUsers_imageView);
            this.panel3.Location = new System.Drawing.Point(83, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(112, 127);
            this.panel3.TabIndex = 16;
            // 
            // adminAddUsers_clearBtn
            // 
            this.adminAddUsers_clearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(76)))), ((int)(((byte)(62)))));
            this.adminAddUsers_clearBtn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminAddUsers_clearBtn.ForeColor = System.Drawing.Color.White;
            this.adminAddUsers_clearBtn.Location = new System.Drawing.Point(165, 564);
            this.adminAddUsers_clearBtn.Name = "adminAddUsers_clearBtn";
            this.adminAddUsers_clearBtn.Size = new System.Drawing.Size(107, 49);
            this.adminAddUsers_clearBtn.TabIndex = 15;
            this.adminAddUsers_clearBtn.Text = "Xoá sạch";
            this.adminAddUsers_clearBtn.UseVisualStyleBackColor = false;
            this.adminAddUsers_clearBtn.Click += new System.EventHandler(this.adminAddUsers_clearBtn_Click);
            // 
            // adminAddUsers_deleteBtn
            // 
            this.adminAddUsers_deleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(76)))), ((int)(((byte)(62)))));
            this.adminAddUsers_deleteBtn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminAddUsers_deleteBtn.ForeColor = System.Drawing.Color.White;
            this.adminAddUsers_deleteBtn.Location = new System.Drawing.Point(30, 564);
            this.adminAddUsers_deleteBtn.Name = "adminAddUsers_deleteBtn";
            this.adminAddUsers_deleteBtn.Size = new System.Drawing.Size(107, 49);
            this.adminAddUsers_deleteBtn.TabIndex = 14;
            this.adminAddUsers_deleteBtn.Text = "Xoá";
            this.adminAddUsers_deleteBtn.UseVisualStyleBackColor = false;
            this.adminAddUsers_deleteBtn.Click += new System.EventHandler(this.adminAddUsers_deleteBtn_Click);
            // 
            // adminAddUsers_updateBtn
            // 
            this.adminAddUsers_updateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(76)))), ((int)(((byte)(62)))));
            this.adminAddUsers_updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminAddUsers_updateBtn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminAddUsers_updateBtn.ForeColor = System.Drawing.Color.White;
            this.adminAddUsers_updateBtn.Location = new System.Drawing.Point(165, 487);
            this.adminAddUsers_updateBtn.Name = "adminAddUsers_updateBtn";
            this.adminAddUsers_updateBtn.Size = new System.Drawing.Size(107, 49);
            this.adminAddUsers_updateBtn.TabIndex = 13;
            this.adminAddUsers_updateBtn.Text = "Cập nhật";
            this.adminAddUsers_updateBtn.UseVisualStyleBackColor = false;
            this.adminAddUsers_updateBtn.Click += new System.EventHandler(this.adminAddUsers_updateBtn_Click);
            // 
            // adminAddUsers_addBtn
            // 
            this.adminAddUsers_addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(76)))), ((int)(((byte)(62)))));
            this.adminAddUsers_addBtn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminAddUsers_addBtn.ForeColor = System.Drawing.Color.White;
            this.adminAddUsers_addBtn.Location = new System.Drawing.Point(30, 487);
            this.adminAddUsers_addBtn.Name = "adminAddUsers_addBtn";
            this.adminAddUsers_addBtn.Size = new System.Drawing.Size(107, 49);
            this.adminAddUsers_addBtn.TabIndex = 12;
            this.adminAddUsers_addBtn.Text = "Thêm";
            this.adminAddUsers_addBtn.UseVisualStyleBackColor = false;
            this.adminAddUsers_addBtn.Click += new System.EventHandler(this.adminAddUsers_addBtn_Click);
            // 
            // adminAddUsers_status
            // 
            this.adminAddUsers_status.FormattingEnabled = true;
            this.adminAddUsers_status.Items.AddRange(new object[] {
            "Active",
            "Inactive",
            "Approval"});
            this.adminAddUsers_status.Location = new System.Drawing.Point(121, 371);
            this.adminAddUsers_status.Name = "adminAddUsers_status";
            this.adminAddUsers_status.Size = new System.Drawing.Size(151, 21);
            this.adminAddUsers_status.TabIndex = 11;
            // 
            // adminAddUsers_role
            // 
            this.adminAddUsers_role.FormattingEnabled = true;
            this.adminAddUsers_role.Items.AddRange(new object[] {
            "Admin",
            "Cashier"});
            this.adminAddUsers_role.Location = new System.Drawing.Point(121, 336);
            this.adminAddUsers_role.Name = "adminAddUsers_role";
            this.adminAddUsers_role.Size = new System.Drawing.Size(151, 21);
            this.adminAddUsers_role.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 373);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Trạng thái:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Chức vị:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // adminAddUsers_password
            // 
            this.adminAddUsers_password.Location = new System.Drawing.Point(121, 303);
            this.adminAddUsers_password.Name = "adminAddUsers_password";
            this.adminAddUsers_password.Size = new System.Drawing.Size(151, 20);
            this.adminAddUsers_password.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật khẩu:";
            // 
            // adminAddUsers_username
            // 
            this.adminAddUsers_username.Location = new System.Drawing.Point(121, 268);
            this.adminAddUsers_username.Name = "adminAddUsers_username";
            this.adminAddUsers_username.Size = new System.Drawing.Size(151, 20);
            this.adminAddUsers_username.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên đăng nhập:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(332, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(942, 712);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(178)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(359, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(896, 615);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data of Users";
            // 
            // adminAddUsers_imageView
            // 
            this.adminAddUsers_imageView.Location = new System.Drawing.Point(0, 3);
            this.adminAddUsers_imageView.Name = "adminAddUsers_imageView";
            this.adminAddUsers_imageView.Size = new System.Drawing.Size(112, 121);
            this.adminAddUsers_imageView.TabIndex = 0;
            this.adminAddUsers_imageView.TabStop = false;
            this.adminAddUsers_imageView.Click += new System.EventHandler(this.adminAddUsers_imageView_Click);
            // 
            // AdminAddUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AdminAddUsers";
            this.Size = new System.Drawing.Size(1295, 755);
            this.Load += new System.EventHandler(this.AdminAddUsers_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminAddUsers_imageView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox adminAddUsers_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox adminAddUsers_username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button adminAddUsers_addBtn;
        private System.Windows.Forms.ComboBox adminAddUsers_status;
        private System.Windows.Forms.ComboBox adminAddUsers_role;
        private System.Windows.Forms.Button adminAddUsers_clearBtn;
        private System.Windows.Forms.Button adminAddUsers_deleteBtn;
        private System.Windows.Forms.Button adminAddUsers_updateBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox adminAddUsers_imageView;
        private System.Windows.Forms.Button adminAddUsers_importBtn;
    }
}
