using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RazorUdpChat
{
    public class ExTextBox : TextBox
    {
        string hint;
        [DefaultValue("")]
        public string Hint
        {
            get { return hint; }
            set { hint = value; this.Invalidate(); }
        }

        Color hintColor = SystemColors.GrayText;
        public Color HintColor
        {
            get { return hintColor; }
            set { hintColor = value; Invalidate(); }
        }
        
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xf)
            {
                if (!this.Focused && string.IsNullOrEmpty(this.Text)
                                  && !string.IsNullOrEmpty(this.Hint))
                {
                    using (var g = this.CreateGraphics())
                    {
                        TextRenderer.DrawText(g, this.Hint, new Font(
                                Font.FontFamily, 14, Font.Style),
                            this.ClientRectangle, this.HintColor, this.BackColor,
                            TextFormatFlags.Top | TextFormatFlags.Left);
                    }
                }
            }
        }
        private bool ShouldSerializeHintColor()
        {
            return HintColor != SystemColors.GrayText;
        }
        private void ResetHintColor()
        {
            HintColor = SystemColors.GrayText;
        }
    }

}