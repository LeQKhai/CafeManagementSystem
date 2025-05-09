using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class AdminAddPromotions : UserControl
    {
        public AdminAddPromotions()
        {
            InitializeComponent();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayData();
        }

        public void displayData()
        {
            PromotionData promoData = new PromotionData();
            List<PromotionData> listData = promoData.ListPromotionData();

            dgvPromo.DataSource = listData;

            if (dgvPromo.Columns["StartDate"] != null)
            {
                dgvPromo.Columns["StartDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvPromo.Columns["EndDate"] != null)
            {
                dgvPromo.Columns["EndDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvPromo.Rows.Count > 0)
            {
                dgvPromo.Rows[0].Selected = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PromotionData promo = new PromotionData();
            promo = getInputData();

            if(promo != null)
            {
                if (promo.AddPromotion())
                {
                    displayData();
                    clearInput(false);
                }
                else
                {
                    MessageBox.Show("Thêm khuyến mãi thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPromo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPromo.Rows[e.RowIndex];

                tbPromoCode.Text = row.Cells["Code"].Value.ToString();
                tbPercent.Text = row.Cells["Percent"].Value.ToString();
                tbDesc.Text = row.Cells["Description"].Value.ToString();

                dpStartDate.Value = Convert.ToDateTime(row.Cells["StartDate"].Value);
                dpEndDate.Value = Convert.ToDateTime(row.Cells["EndDate"].Value);

                bool isActive = Convert.ToBoolean(row.Cells["IsActive"].Value);
                rbActive.Checked = isActive;

                tbPromoCode.Enabled = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PromotionData promo = new PromotionData();
            promo = getInputData();

            if (promo != null)
            {
                if (promo.UpdatePromotion())
                {
                    displayData();
                    MessageBox.Show("Cập nhật mã khuyến mãi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật khuyến mãi thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private PromotionData getInputData()
        {
            string code = tbPromoCode.Text.Trim();
            string desc = tbDesc.Text.Trim();
            bool is_active = rbActive.Checked;

            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Vui lòng nhập mã khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (!int.TryParse(tbPercent.Text.Trim(), out int percent) || percent < 0 || percent > 100)
            {
                MessageBox.Show("Phần trăm giảm giá không hợp lệ (0 - 100)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            DateTime startDate = dpStartDate.Value.Date;
            DateTime endDate = dpEndDate.Value.Date;
            if (endDate <= startDate)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            PromotionData promo = new PromotionData
            {
                Code = code,
                Percent = percent,
                Description = desc,
                StartDate = startDate,
                EndDate = endDate,
                IsActive = is_active
            };

            return promo;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearInput(true);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            PromotionData promo = new PromotionData();
            promo = getInputData();

            if (promo != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(result == DialogResult.OK)
                {
                    if (promo.DeletePromotion(promo.Code))
                    {
                        displayData();
                        clearInput(false);
                    }
                    else
                    {
                        MessageBox.Show("Xoá khuyến mãi thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void clearInput(bool enablePromoCode)
        {
            tbPromoCode.Text = "";
            tbPercent.Text = "";
            tbDesc.Text = "";
            dpStartDate.Value = DateTime.Now;
            dpEndDate.Value = DateTime.Now;
            rbActive.Checked = true;
            
            if(enablePromoCode)
                tbPromoCode.Enabled = true;
        }
    }
}
