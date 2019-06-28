using CoolTable.Core;
using CoolTable.Renderer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Atomic.UI
{
    public class CoolTableReadableRenderer : ARenderer
    {
        public CoolTableReadableRenderer()
        {

        }

        public override void InnerDesign(Graphics g, Bag bag)
        {
            if(bag.Data.GetType() == typeof(CoolTableReadableObject))
            {
                CoolTableReadableObject obj = (CoolTableReadableObject)bag.Data;

                int alpha = Convert.ToInt32(255 * obj.DoCalculation(bag.RowIndex));

                if (alpha > 255) { alpha = 255; }
                if (alpha < 0) { alpha = 0; }

                Color fore = Color.FromArgb(255 - alpha, Color.LimeGreen);

                RectangleF rectf = new RectangleF(bag.X + 2f, bag.Y + 2f, bag.Width - 4f, bag.LineHeight - 4f);
                g.FillRectangle(new SolidBrush(fore), rectf);

                g.DrawString(Convert.ToString(Math.Round(100f - Convert.ToSingle(alpha) * 100f / 255f)), bag.Font, Brushes.Black, rectf);
            }
            else
            {
                RectangleF rectf = new RectangleF(bag.X + 2f, bag.Y + 2f, bag.Width - 4f, bag.LineHeight - 4f);
                g.DrawString("unknown", bag.Font, Brushes.Red, rectf);
            }
            
        }
    }
}
