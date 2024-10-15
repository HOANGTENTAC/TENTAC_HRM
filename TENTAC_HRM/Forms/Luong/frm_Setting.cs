using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TENTAC_HRM.CommonModel;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.Luong
{
    public partial class frm_Setting : Form
    {
        public frm_Setting()
        {
            InitializeComponent();
        }

        private void frm_Setting_Load(object sender, EventArgs e)
        {
            var asm = Assembly.GetEntryAssembly();
            string fileMailInfo = $@"{Path.GetDirectoryName(asm.Location)}\Template\InfoMail.txt";
            string infoFile = File.ReadAllText(fileMailInfo);
            List<string> listInfo = new List<string>();
            listInfo = infoFile.Split(';').ToList();

            txt_email.Text = listInfo[0].Replace("EmailAddress: ", "");
            txt_pass.Text = listInfo[1].Replace("Password: ", "");
            txt_subject.Text = listInfo[2].Replace("Subject: ", "");
            txt_textbody.Text = listInfo[3].Replace("TextBody:", "").TrimStart();
            txt_emailtest.Text = listInfo[4].Replace("EmailTest:", "").TrimStart();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var asm = Assembly.GetEntryAssembly();
                string fileMailInfo = $@"{Path.GetDirectoryName(asm.Location)}\Template\InfoMail.txt";
                MailInfo mailInfo = new MailInfo(txt_email.Text, txt_pass.Text, txt_subject.Text, txt_textbody.Text, txt_emailtest.Text);
                System.IO.File.WriteAllText(fileMailInfo, mailInfo.ToString());
                RJMessageBox.Show("Sửa thành công");
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
