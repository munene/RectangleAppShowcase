using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;

namespace AppExtras.Showcases
{
    public class ViewShowcaseStep : ShowcaseStep
    {
        private const int DefaultPadding = 10;

        private WeakReference<Activity> parentActivity;
        private int viewId;
        private View view;

        public ViewShowcaseStep(View view)
        {
            this.view = view;

            Setup();
        }

        public ViewShowcaseStep(Activity activity, int viewId)
        {
            this.parentActivity = new WeakReference<Activity>(activity);
            this.viewId = viewId;

            Setup();
        }

        private void Setup()
        {
            Padding = DefaultPadding;
            UseAutoRadius = true;
        }

        public virtual int Padding { get; set; }

        public override Point Position
        {
            get
            {
                var view = GetView();
                if (view != null)
                {
                    int[] location = new int[2];
                    view.GetLocationInWindow(location);
                    int x = location[0] + view.Width / 2;
                    int y = location[1] + view.Height / 2;
                    return new Point(x, y);
                }

                return base.Position;
            }
            set { base.Position = value; }
        }

        public virtual bool UseAutoRadius { get; set; }

        public override int Radius
        {
            get
            {
                var view = GetView();
                if (view != null && UseAutoRadius)
                {
                    var radius = Math.Max(view.MeasuredHeight, view.MeasuredWidth) / 2;
                    radius += Padding; // add a 10 pixel padding to circle
                    return radius;
                }

                return base.Radius;
            }
            set { base.Radius = value; }
        }

		public override int Height
		{
			get
			{
				var view = GetView();
				if (view != null)
				{
					var height = view.MeasuredHeight;
					height += Padding; // add a 10 pixel padding to circle
					return height;
				}

				return base.Height;
			}
			set { base.Height = value; }
		}

		public override int Width
		{
			get
			{
				var view = GetView();
				if (view != null)
				{
					var width = view.MeasuredWidth;
					width += Padding; // add a 10 pixel padding to circle
					return width;
				}

				return base.Width;
			}
			set { base.Width = value; }
		}

        public override int Top
        {
            get
            {
                var view = GetView();
                if (view != null)
                {
                    return view.Top;
                }

                return base.Top;
            }
            set { base.Width = value; }
        }

        public override int Bottom
        {
            get
            {
                var view = GetView();
                if (view != null)
                {
                    return view.Bottom;
                }

                return base.Bottom;
            }
            set { base.Width = value; }
        }

        public View GetView()
        {
            if (view == null)
            {
                Activity activity;
                if (parentActivity != null && parentActivity.TryGetTarget(out activity))
                {
                    view = activity.FindViewById(viewId);
                }
            }
            return view;
        }
    }
}
