using CafeManagementSystem.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CafeManagementSystem.Forms.Cashier
{
    public partial class CashierPagerForm : UserControl
    {
        private Pager pagerService = new Pager();
        private List<Panel> pagerPanels = new List<Panel>();

        public CashierPagerForm()
        {
            InitializeComponent();
            LoadPagers();
        }

        public void LoadPagers()
        {
            pagerContainerPanel.Controls.Clear();
            pagerPanels.Clear();
            var pagers = pagerService.GetAllPagers();
            int xPos = 10, yPos = 10;
            int panelCountInRow = 0;

            foreach (var pager in pagers)
            {
                Panel panel = new Panel
                {
                    Size = new Size(80, 80),
                    Location = new Point(xPos, yPos),
                    Tag = pager.PagerID // Lưu PagerID vào Tag
                };
                Label pagerLabel = new Label
                {
                    Text = pager.PagerID.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(80, 80),
                    ForeColor = Color.White,
                    BackColor = Color.Transparent
                };
                // Gán sự kiện Click
                panel.Click += PagerPanel_Click;
                pagerLabel.Click += (s, e) => PagerPanel_Click(panel, e); // Chuyển tiếp sự kiện từ Label đến Panel
                panel.Controls.Add(pagerLabel);

                // Đặt màu dựa trên trạng thái
                switch (pager.Status)
                {
                    case 0: // Chưa có đơn
                        panel.BackColor = Color.Green;
                        pagerLabel.ForeColor = Color.White;
                        break;
                    case 1: // Có đơn, chưa làm xong
                        panel.BackColor = Color.Yellow;
                        pagerLabel.ForeColor = Color.Red;
                        break;
                    case 2: // Đã làm xong
                        panel.BackColor = Color.Red;
                        pagerLabel.ForeColor = Color.White;
                        break;
                }
                pagerContainerPanel.Controls.Add(panel);
                pagerPanels.Add(panel);

                panelCountInRow++;
                if (panelCountInRow < 10)
                {
                    xPos += 130;
                }
                else
                {
                    panelCountInRow = 0;
                    xPos = 10;
                    yPos += 90;
                }
            }
        }

        public void PagerPanel_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            int pagerId = (int)panel.Tag;
            int currentStatus = GetPanelStatus(panel.BackColor);

            // Chỉ mở OrderDetailForm nếu trạng thái là 1 (có đơn, chưa làm xong)
            if (currentStatus == 1)
            {
                CashierOrderDetailForm orderDetail = new CashierOrderDetailForm(pagerId);
                orderDetail.ShowDialog();
                LoadPagers(); // Làm mới để cập nhật trạng thái
            }
            if (currentStatus == 2) {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn reset pager?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True"))
                    {
                        conn.Open();
                        string updateQuery = "UPDATE Pagers SET Status = 0 WHERE PagerID = @PagerID";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@PagerID", pagerId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadPagers();
                }
            }
        }

        private int GetPanelStatus(Color color)
        {
            if (color == Color.Green) return 0;
            if (color == Color.Yellow) return 1;
            if (color == Color.Red) return 2;
            return 0; // Default
        }

        private void SetPanelColor(Panel panel, int status)
        {
            switch (status)
            {
                case 0: // Chưa có đơn
                    panel.BackColor = Color.Green;
                    break;
                case 1: // Có đơn, chưa làm xong
                    panel.BackColor = Color.Yellow;
                    break;
                case 2: // Đã làm xong
                    panel.BackColor = Color.Red;
                    break;
            }
        }

        private void createPager_btn_Click(object sender, EventArgs e)
        {
            pagerService.CreatePager();
            LoadPagers();
        }

        private void deletePager_btn_Click(object sender, EventArgs e)
        {
            if (pagerPanels.Count > 0)
            {
                Panel lastPanel = pagerPanels[pagerPanels.Count - 1];
                int pagerId = (int)lastPanel.Tag;
                pagerService.DeletePager(pagerId);
                pagerPanels.RemoveAt(pagerPanels.Count - 1);
                pagerContainerPanel.Controls.Remove(lastPanel);
                lastPanel.Dispose();
            }
        }

    }
}
