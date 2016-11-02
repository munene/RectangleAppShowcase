using System;
using Android.Animation;
using Android.Graphics;
using Android.Views;

namespace AppExtras.Renderers
{
    public class NullRenderer : IRenderer
    {
        private readonly Paint eraserPaint;

        public NullRenderer()
        {
            eraserPaint = RenderingHelpers.CreateEraser();
        }

        public Animator FadeInView(View target, long duration, Action started, Action ended)
        {
            RenderingHelpers.SetAlphaProperty(target, true, started, ended);
            return null;
        }

        public Animator FadeOutView(View target, long duration, Action started, Action ended)
        {
            RenderingHelpers.SetAlphaProperty(target, false, started, ended);
            return null;
        }

        public void DrawMask(View target, Canvas maskCanvas, Color maskColor, Point position, int radius, int top, int bottom, Animator animator)
        {
            // draw solid background
            maskCanvas.DrawColor(maskColor);

            // erase focus area 
            //maskCanvas.DrawCircle(position.X, position.Y, radius, eraserPaint);
			var rectangle = new Rect(target.Left, position.Y - radius / 2 - 10, target.Right, position.Y + radius / 2 + 10);
			maskCanvas.DrawRect(rectangle, eraserPaint);
        }
    }
}
