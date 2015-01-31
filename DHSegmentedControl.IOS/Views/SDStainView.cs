using System;
using UIKit;
using CoreGraphics;

namespace DHSegmentedControl.Views
{
	public class DHStainView : UIView
	{
		#region Properties

		UIColor backgroundColor { get; set;}
		nfloat cornerRadius { get; set;}
		UIEdgeInsets edgeInsets { get; set;}
		CGSize shadowOffset { get; set;}
		nfloat shadowBlur { get; set;}
		UIColor shadowColor { get; set;}
		nfloat innerStrokeLineWidth { get; set;}
		UIColor innerStrokeColor { get; set;}

		#endregion

		#region Consrtuctors

		public DHStainView()
		{
		}

		#endregion
	}
}

