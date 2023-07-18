using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Forms
{
    public partial class KeyBoardForm : Form
    {
        #region 필드
        private Color _selectedColor;

        private Color _nonSelectedColor;

        private bool _isKorean = false;

        private bool _isCapitalLetter = false;
        #endregion

        #region 속성
        public string KeyValue { get; set; } = string.Empty;

        public string PreviousValue { get; set; }
        #endregion

        #region 생성자
        public KeyBoardForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void chkToggleLanguage_CheckedChanged(object sender, EventArgs e)
        {
            _isKorean = chkToggleLanguage.Checked;

            if (_isKorean)
                chkToggleLanguage.BackColor = _selectedColor;
            else
                chkToggleLanguage.BackColor = _nonSelectedColor;

            ToggleLanguage(_isKorean, _isCapitalLetter);
        }

        private void chkToggleLetter_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            _isCapitalLetter = chk.Checked;

            if (_isCapitalLetter)
            {
                chkCapsLock.Checked = true;
                chkShiftLeft.Checked = true;
                chkShiftRight.Checked = true;
                chkCapsLock.BackColor = _selectedColor;
                chkShiftLeft.BackColor = _selectedColor;
                chkShiftRight.BackColor = _selectedColor;
            }
            else
            {
                chkCapsLock.Checked = false;
                chkShiftLeft.Checked = false;
                chkShiftRight.Checked = false;
                chkCapsLock.BackColor = _nonSelectedColor;
                chkShiftLeft.BackColor = _nonSelectedColor;
                chkShiftRight.BackColor = _nonSelectedColor;
            }

            ToggleLanguage(_isKorean, _isCapitalLetter);
        }

        private void ToggleLanguage(bool isKorean, bool isCapitalLetter)
        {
            bool capitalKor = isKorean && isCapitalLetter;
            bool smallKor = isKorean && !isCapitalLetter;
            bool capitalEng = !isKorean && isCapitalLetter;
            bool smallEng = !isKorean && !isCapitalLetter;

            if (capitalKor)
            {
                btnQuotationMark.Text = "~";
                btn1.Text = "!"; btn2.Text = "@"; btn3.Text = "#"; btn4.Text = "$"; btn5.Text = "%";
                btn6.Text = "^"; btn7.Text = "&"; btn8.Text = "*"; btn9.Text = "("; btn0.Text = ")";
                btnHyphen.Text = "_"; btnEqual.Text = "+";

                btnQ.Text = "ㅃ"; btnW.Text = "ㅉ"; btnE.Text = "ㄸ"; btnR.Text = "ㄲ"; btnT.Text = "ㅆ";
                btnY.Text = "ㅛ"; btnU.Text = "ㅕ"; btnI.Text = "ㅑ"; btnO.Text = "ㅒ"; btnP.Text = "ㅖ";
                btnOpenBracket.Text = "{"; btnCloseBracket.Text = "}"; btnBackSlash.Text = "|";

                btnA.Text = "ㅁ"; btnS.Text = "ㄴ"; btnD.Text = "ㅇ"; btnF.Text = "ㄹ"; btnG.Text = "ㅎ";
                btnH.Text = "ㅗ"; btnJ.Text = "ㅓ"; btnK.Text = "ㅏ"; btnL.Text = "ㅣ";
                btnSemiColon.Text = ":"; btnQuote.Text = "''";

                btnZ.Text = "ㅋ"; btnX.Text = "ㅌ"; btnC.Text = "ㅊ"; btnV.Text = "ㅍ";
                btnB.Text = "ㅠ"; btnN.Text = "ㅜ"; btnM.Text = "ㅡ";
                btnComma.Text = "<"; btnDot.Text = ">"; btnSlash.Text = "?";
            }

            if (smallKor)
            {
                btnQuotationMark.Text = "`";
                btn1.Text = "1"; btn2.Text = "2"; btn3.Text = "3"; btn4.Text = "4"; btn5.Text = "5";
                btn6.Text = "6"; btn7.Text = "7"; btn8.Text = "8"; btn9.Text = "9"; btn0.Text = "0";
                btnHyphen.Text = "-"; btnEqual.Text = "=";

                btnQ.Text = "ㅂ"; btnW.Text = "ㅈ"; btnE.Text = "ㄷ"; btnR.Text = "ㄱ"; btnT.Text = "ㅅ";
                btnY.Text = "ㅛ"; btnU.Text = "ㅕ"; btnI.Text = "ㅑ"; btnO.Text = "ㅐ"; btnP.Text = "ㅔ";
                btnOpenBracket.Text = "["; btnCloseBracket.Text = "]"; btnBackSlash.Text = "\\";

                btnA.Text = "ㅁ"; btnS.Text = "ㄴ"; btnD.Text = "ㅇ"; btnF.Text = "ㄹ"; btnG.Text = "ㅎ";
                btnH.Text = "ㅗ"; btnJ.Text = "ㅓ"; btnK.Text = "ㅏ"; btnL.Text = "ㅣ";
                btnSemiColon.Text = ";"; btnQuote.Text = "'";

                btnZ.Text = "ㅋ"; btnX.Text = "ㅌ"; btnC.Text = "ㅊ"; btnV.Text = "ㅍ";
                btnB.Text = "ㅠ"; btnN.Text = "ㅜ"; btnM.Text = "ㅡ";
                btnComma.Text = ","; btnDot.Text = "."; btnSlash.Text = "/";
            }

            if (capitalEng)
            {
                btnQuotationMark.Text = "~";
                btn1.Text = "!"; btn2.Text = "@"; btn3.Text = "#"; btn4.Text = "$"; btn5.Text = "%";
                btn6.Text = "^"; btn7.Text = "&"; btn8.Text = "*"; btn9.Text = "("; btn0.Text = ")";
                btnHyphen.Text = "_"; btnEqual.Text = "+";

                btnQ.Text = "Q"; btnW.Text = "W"; btnE.Text = "E"; btnR.Text = "R"; btnT.Text = "T";
                btnY.Text = "Y"; btnU.Text = "U"; btnI.Text = "I"; btnO.Text = "O"; btnP.Text = "P";
                btnOpenBracket.Text = "{"; btnCloseBracket.Text = "}"; btnBackSlash.Text = "|";

                btnA.Text = "A"; btnS.Text = "S"; btnD.Text = "D"; btnF.Text = "F"; btnG.Text = "G";
                btnH.Text = "H"; btnJ.Text = "J"; btnK.Text = "K"; btnL.Text = "L";
                btnSemiColon.Text = ":"; btnQuote.Text = "''";

                btnZ.Text = "Z"; btnX.Text = "X"; btnC.Text = "C"; btnV.Text = "V";
                btnB.Text = "B"; btnN.Text = "N"; btnM.Text = "M";
                btnComma.Text = "<"; btnDot.Text = ">"; btnSlash.Text = "?";
            }

            if (smallEng)
            {
                btnQuotationMark.Text = "`";
                btn1.Text = "1"; btn2.Text = "2"; btn3.Text = "3"; btn4.Text = "4"; btn5.Text = "5";
                btn6.Text = "6"; btn7.Text = "7"; btn8.Text = "8"; btn9.Text = "9"; btn0.Text = "0";
                btnHyphen.Text = "-"; btnEqual.Text = "=";

                btnQ.Text = "q"; btnW.Text = "w"; btnE.Text = "e"; btnR.Text = "r"; btnT.Text = "t";
                btnY.Text = "y"; btnU.Text = "u"; btnI.Text = "i"; btnO.Text = "o"; btnP.Text = "p";
                btnOpenBracket.Text = "["; btnCloseBracket.Text = "]"; btnBackSlash.Text = "\\";

                btnA.Text = "a"; btnS.Text = "s"; btnD.Text = "d"; btnF.Text = "f"; btnG.Text = "g";
                btnH.Text = "h"; btnJ.Text = "j"; btnK.Text = "k"; btnL.Text = "l";
                btnSemiColon.Text = ";"; btnQuote.Text = "'";

                btnZ.Text = "z"; btnX.Text = "x"; btnC.Text = "c"; btnV.Text = "v";
                btnB.Text = "b"; btnN.Text = "n"; btnM.Text = "m";
                btnComma.Text = ","; btnDot.Text = "."; btnSlash.Text = "/";
            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            lblTextMessage.Text += btn.Text;
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            string message = lblTextMessage.Text;

            if (message == string.Empty)
                return;

            lblTextMessage.Text = message.Substring(0, message.Length - 1);
        }

        private void btnTab_Click(object sender, EventArgs e)
        {
            lblTextMessage.Text += "\t";
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            lblTextMessage.Text += " ";
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            KeyValue = lblTextMessage.Text;

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblTextMessage.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want cancel?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.No;
                Close();
            }
        }

        private void KeyBoardForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            string message = lblTextMessage.Text;
            btnEnter.Focus();

            if (e.KeyChar == Convert.ToChar(Keys.Back))
            {
                if (message == "")
                    return;

                lblTextMessage.Text = message.Substring(0, message.Length - 1);
                return;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                KeyValue = lblTextMessage.Text;

                this.DialogResult = DialogResult.OK;
                Close();
            }

            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                if (MessageBox.Show("Do you want cancel?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    KeyValue = PreviousValue;
                    this.DialogResult = DialogResult.No;
                    Close();
                }
            }

            lblTextMessage.Text += e.KeyChar.ToString();
        }

        private void KeyBoardForm_Load(object sender, EventArgs e)
        {
            Application.Idle += new EventHandler(Application_Idle);
            InitializeUI();
        }


        private void Application_Idle(object sender, EventArgs e)
        {
            chkCapsLock.Checked = Control.IsKeyLocked(Keys.CapsLock);
        }

        private void InitializeUI()
        {
            _selectedColor = Color.FromArgb(52, 52, 52);
            _nonSelectedColor = Color.FromArgb(104, 104, 104);
        }
        #endregion
    }
}
