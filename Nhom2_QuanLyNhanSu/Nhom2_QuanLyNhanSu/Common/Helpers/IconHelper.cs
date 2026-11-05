using System.Drawing.Imaging;

namespace Nhom2_QuanLyNhanSu.Common.Helpers;

public static class IconHelper
{
    // Trả về bản sao của ảnh, mọi điểm ảnh không trong suốt được tô thành màu 'color'
    public static Bitmap Tint(Image source, Color color)
    {
        var bmp = new Bitmap(source.Width, source.Height);
        using var g = Graphics.FromImage(bmp);

        float r = color.R / 255f, gr = color.G / 255f, b = color.B / 255f;
        var matrix = new ColorMatrix(new[]
        {
            new float[] { 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 1, 0 },   // giữ nguyên độ trong suốt
            new float[] { r, gr, b, 0, 1 }   // gán màu mới
        });

        using var attrs = new ImageAttributes();
        attrs.SetColorMatrix(matrix);
        g.DrawImage(source, new Rectangle(0, 0, bmp.Width, bmp.Height),
                    0, 0, source.Width, source.Height, GraphicsUnit.Pixel, attrs);
        return bmp;
    }
}