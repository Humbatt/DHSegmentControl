using System;
using UIKit;
using CoreGraphics;

namespace DHSegmentedControl.Views
{
	public class DHSegmentView : UIButton
	{
		#region Properties

		CGSize imageSize { get; set;}
		UIFont titleFont { get; set;}
		UIFont selectedTitleFont { get; set;}
		CGSize titleShadowOffset { get; set;}

		#endregion
		#region Consrtuctors

		public DHSegmentView()
		{
		}

		#endregion
	}
}

