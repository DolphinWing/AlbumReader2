using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;
using System.Drawing;

namespace System.Windows.Forms
{
    class FixedTabControl : TabControl
	{
        [DllImportAttribute("uxtheme.dll")]
        private static extern int SetWindowTheme(IntPtr hWnd, string appname, string idlist);

        protected override void OnHandleCreated(EventArgs e)
        {
            SetWindowTheme(this.Handle, "", "");
            base.OnHandleCreated(e);
        }

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			TabPage CurrentTab = this.TabPages[e.Index];
			Rectangle ItemRect = this.GetTabRect(e.Index);
			SolidBrush FillBrush = new SolidBrush(Color.LightGray);
			SolidBrush TextBrush = new SolidBrush(Color.Gray);
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;

			//If we are currently painting the Selected TabItem we'll
			//change the brush colors and inflate the rectangle.
			if (System.Convert.ToBoolean(e.State & DrawItemState.Selected)) {
				FillBrush.Color = Color.Transparent;
				TextBrush.Color = Color.Black;
				ItemRect.Inflate(2, 2);
			}

			//Set up rotation for left and right aligned tabs
			if (this.Alignment == TabAlignment.Left || this.Alignment == TabAlignment.Right) {
				float RotateAngle = 90;
				if (this.Alignment == TabAlignment.Left)
					RotateAngle = 270;
				PointF cp = new PointF(ItemRect.Left + (ItemRect.Width / 2), ItemRect.Top + (ItemRect.Height / 2));
				e.Graphics.TranslateTransform(cp.X, cp.Y);
				e.Graphics.RotateTransform(RotateAngle);
				ItemRect = new Rectangle(-(ItemRect.Height / 2), -(ItemRect.Width / 2), ItemRect.Height, ItemRect.Width);
			}
			//CurrentTab.BackColor = Color.Transparent;	// added @ 2008-11-21 by dolphin

			//Next we'll paint the TabItem with our Fill Brush
			e.Graphics.FillRectangle(FillBrush, ItemRect);

			//Now draw the text.
			e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, RectangleF.FromLTRB(ItemRect.Left, ItemRect.Top, ItemRect.Right, ItemRect.Bottom), sf);

			//Reset any Graphics rotation
			e.Graphics.ResetTransform();

			//Finally, we should Dispose of our brushes.
			FillBrush.Dispose();
			TextBrush.Dispose();

			base.OnDrawItem(e);
		}
	}
}
