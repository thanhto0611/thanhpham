using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
using BUS;

namespace Presentation
{
    public partial class frmConfig : Form
    {
        public ConfigDTO _cfgDto = new ConfigDTO();
        public bool _changed = false;

        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            _cfgDto = ConfigBUS.GetConfig();

            //Tich Luy Diem
            chbxTichLuyDiem.Checked = _cfgDto.TichLuyDiem;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc là muốn cập nhật cấu hình phần mềm này không?",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    _cfgDto.TichLuyDiem = chbxTichLuyDiem.Checked;

                    ConfigBUS.SaveConfig(_cfgDto);

                    MessageBox.Show("Save config thành công");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main2.frmCfg = null;
        }

        private void chbxTichLuyDiem_CheckedChanged(object sender, EventArgs e)
        {
            _changed = true;
            _cfgDto.TichLuyDiem = chbxTichLuyDiem.Checked;
        }

        private void frmConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_changed == true)
                {
                    DialogResult result = MessageBox.Show("Cấu hình chưa được lưu. Vui lòng lưu cấu hình trước khi đóng",
                        "Question",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        e.Cancel = true;
                        ConfigBUS.SaveConfig(_cfgDto);
                        MessageBox.Show("Save config thành công");
                        _changed = false;
                    }
                    if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
