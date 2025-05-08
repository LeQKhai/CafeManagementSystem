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

        private void LoadPagers()
        {
            pagerContainerPanel.Controls.Clear();
            pagerPanels.Clear();
            var pagers = pagerService.GetAllPagers();
            int xPos = 10, yPos = 10;
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
                    ForeColor = Color.White
                };
                panel.Controls.Add(pagerLabel);
                panel.Click += PagerPanel_Click;
                // Đặt màu dựa trên trạng thái
                switch (pager.Status)
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
                pagerContainerPanel.Controls.Add(panel);
                pagerPanels.Add(panel);

                xPos += 90; // Khoảng cách giữa các pager
                if (xPos > pagerContainerPanel.ClientSize.Width - 100)
                {
                    xPos = 10;
                    yPos += 90;
                }
            }
        }

        private void PagerPanel_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            int pagerId = (int)panel.Tag;
            int currentStatus = GetPanelStatus(panel.BackColor);
            int newStatus = (currentStatus + 1) % 3; // Chuyển tuần tự: 0 -> 1 -> 2 -> 0
            SetPanelColor(panel, newStatus);
            pagerService.UpdatePagerStatus(pagerId, newStatus);
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
