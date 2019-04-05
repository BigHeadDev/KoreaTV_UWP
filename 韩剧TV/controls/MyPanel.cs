using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace 韩剧TV.controls
{
    public class MyPanel:Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (var child in Children)
            {
                child.Measure(availableSize);
            }

            double width = 0d, height = 0d;
            double col_width = 0d, row_height = 0d;
            int end_row_count = -1;

            for (int i = 0; i < Children.Count; i++)
            {
                if (Children[i].DesiredSize.Width + col_width > availableSize.Width)
                {
                    end_row_count = i;
                    height += row_height;
                    width = Math.Max(width, col_width);
                    col_width = 0;
                    row_height = 0;
                }
                col_width += Children[i].DesiredSize.Width;
                row_height = Math.Max(row_height, Children[i].DesiredSize.Height);
            }

            //计算最后一行
            if (end_row_count != -1)
            {
                col_width = 0;
                row_height = 0;
                for (int i = end_row_count; i < Children.Count; i++)
                {
                    row_height = Math.Max(row_height, Children[i].DesiredSize.Height);
                    col_width += Children[i].DesiredSize.Width;
                }
                height += row_height;
                width = Math.Max(width, col_width);
            }

            return new Size(width, height);
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            double x = 0d, y = 0d;
            double items_height = 0d;
            int end_count = -1;
            int row_start_index = 0;

            for (int i = 0; i < Children.Count; i++)
            {
                if (Children[i].DesiredSize.Width + x > finalSize.Width)
                {
                    x = 0;
                    y += items_height;

                    items_height = 0;
                    end_count = i;
                    row_start_index = i;
                }
                Children[i].Arrange(new Rect(x, y, Children[i].DesiredSize.Width, Children[i].DesiredSize.Height));
                x += Children[i].DesiredSize.Width;
                items_height = Math.Max(items_height, Children[i].DesiredSize.Height);
            }
            return finalSize;
        }

    }
}
