namespace Test
{
    using SkiaSharp;

    public class TestSkiaSharp
    {

        public static SKData CreateImage(string text)
        {
            // create a surface
            var info = new SKImageInfo(256, 256);
            using var surface = SKSurface.Create(info);
            // the canvas and properties
            var canvas = surface.Canvas;

            // make sure the canvas is blank
            canvas.Clear(SKColors.White);

            // draw some text
            var paint = new SKPaint
            {
                Color = SKColors.Black,
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                TextAlign = SKTextAlign.Center,
                TextSize = 24
            };
            var coord = new SKPoint(info.Width / 2, (info.Height + paint.TextSize) / 2);
            canvas.DrawText(text, coord, paint);

            // retrieve the encoded image
            using var image = surface.Snapshot();
            return image.Encode(SKEncodedImageFormat.Png, 100);
        }

    }
}
