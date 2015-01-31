using System;
using CoreGraphics;
using UIKit;

namespace DHSegmentedControl.Data
{
	public static class Defaults
	{
		public const float kSDSegmentedControlDefaultDuration = 0.2f;
		public const float kSDSegmentedControlArrowSize = 6.5f;
		public const float kSDSegmentedControlInterItemSpace = 30.0f;
		public const float kSDSegmentedControlScrollOffset = 20.0f;

		public static UIEdgeInsets kSDSegmentedControlStainEdgeInsets
		{
			get
			{
				return new UIEdgeInsets(-2, -16, -4, -16);
			}
		}

		public static CGSize kSDSegmentedControlImageSize
		{
			get
			{
				return new CGSize(18, 18);
			}
		}
	}
}

