using System;
using UIKit;
using DHSegmentedControl.Data;
using CoreGraphics;
using System.Collections;
using Foundation;
using ObjCRuntime;
using CoreAnimation;
using System.Collections.Generic;
using System.Linq;

namespace DHSegmentedControl.Views
{
	[Register("DHSegmentedControl")]
	public class DHSegmentedControl : UISegmentedControl, IUIScrollViewDelegate
	{
		#region Properties

		private bool IsiOS7
		{
			get
			{
				return (UIDevice.CurrentDevice.CheckSystemVersion (7, 0));
			}
		}

		public UIColor BackgroundColor { get; set;}
		public UIColor BorderColor  { get; set;}
		public nfloat BorderWidth  { get; set;}
		public nfloat arrowSize  { get; set;}
		public DHSegmentedArrowPosition arrowPosition  { get; set;}
		public nfloat arrowHeightFactor  { get; set;}
		public nfloat animationDuration  { get; set;}
		public nfloat interItemSpace  { get; set;}
		public UIEdgeInsets stainEdgeInsets  { get; set;}
		public UIColor ShadowColor  { get; set;}
		public nfloat ShadowRadius  { get; set;}
		public nfloat ShadowOpacity  { get; set;}
		public CGSize ShadowOffset  { get; set;}

		public UIScrollView scrollView  { get; set;}

		private List<UIView> mItems;
		private UIView mSelectedStainView;
	
		nint mSelectedSegmentIndex;
		nint mLastSelectedSegmentIndex;
		CAShapeLayer mBorderBottomLayer;
		bool mIsScrollingBySelection;

		#endregion

		[Export ("layerClass")]
		public static Class LayerClass () {
			return new Class (typeof (CAShapeLayer));
		}

		#region

		/// <summary>
		/// Initializes a new instance of the <see cref="DHSegmentedControl.Views.DHSegmentedControl"/> class.
		/// </summary>
		public DHSegmentedControl() 
			: base()
		{
			CommonInit();

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DHSegmentedControl.Views.DHSegmentedControl"/> class.
		/// </summary>
		/// <param name="items">Items.</param>
		public DHSegmentedControl(List<String> items) 
			: this()
		{
			foreach (var item in items)
			{
				InsertSegment(item,items.IndexOf(item),false);
			}
		}

		#endregion

		#region Methods

		public override void AwakeFromNib()
		{
			CommonInit();

			mSelectedSegmentIndex = this.SelectedSegment;

			for (nint i = 0; i < this.NumberOfSegments; i++)
			{
				InsertSegment(this.TitleAt(i),i,false);
			}

			this.RemoveAllSegments();

		}

		private void CommonInit()
		{
			var frame = this.Frame;
			frame.Height = 43.0f;
			this.Frame = frame;

			// Init properties
			mLastSelectedSegmentIndex = -1;
			mSelectedSegmentIndex = -1;
			arrowHeightFactor = -1.0f;
			arrowPosition = DHSegmentedArrowPosition.Bottom;
			interItemSpace = Defaults.kSDSegmentedControlInterItemSpace;
			stainEdgeInsets = Defaults.kSDSegmentedControlStainEdgeInsets;

			mItems = new List<UIView>();

			// Appearance properties
			animationDuration = Defaults.kSDSegmentedControlDefaultDuration;
			arrowSize = Defaults.kSDSegmentedControlArrowSize;
			this.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

			// Reset UIKit original widget
			this.Subviews.ToList().ForEach(x => x.RemoveFromSuperview());

			this.Layer.BackgroundColor = UIColor.Clear.CGColor;

			if (!IsiOS7)
			{
				this.BackgroundColor = new UIColor(0.961f, 0.961f, 0.961f,1.0f);
				this.ShadowColor = UIColor.Black;
				this.ShadowRadius = 0.8f;
				this.ShadowOpacity = 0.6f;
				this.ShadowOffset = new CGSize(0, 1);
			}
			else
			{
				this.BackgroundColor = UIColor.Clear;
			}

			mBorderBottomLayer = (CAShapeLayer)CAShapeLayer.Create();
			this.Layer.AddSublayer(mBorderBottomLayer);

			if (!IsiOS7)
			{
				this.BorderColor = UIColor.White;
				this.BorderWidth = 0.5f;
			}
			else
			{
				this.BorderColor = UIColor.Black;
				this.BorderWidth = 0.25f;
			}

			mBorderBottomLayer.FillColor = null;

			scrollView = new UIScrollView();
			this.Add(scrollView);

			scrollView.Delegate = new DSSegmentControlScollViewDelegate();
			scrollView.ScrollsToTop = false;
			scrollView.BackgroundColor = UIColor.Clear;
			scrollView.ShowsVerticalScrollIndicator = false;
			scrollView.ShowsHorizontalScrollIndicator = false;

			mSelectedStainView = new DHStainView();

			scrollView.Add(mSelectedStainView);

		}


		public override void InsertSegment(string title, nint pos, bool animated)
		{
			this.InsertSegment(title,null,pos, animated );
		}

		public void InsertSegment(string title,UIImage image,  nint pos, bool animated)
		{

		}

		#endregion
	
		private class DSSegmentControlScollViewDelegate : UIScrollViewDelegate
		{

		}
	}


}

