using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CodeFormatterApp
{
    public class CustomMenuRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected)
            {
                Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                Color c = Color.FromArgb(0, 112, 60);
                using (SolidBrush brush = new SolidBrush(c))
                {
                    e.Graphics.FillRectangle(brush, rc);
                }
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }
    }
}
