using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ImageLocation
{
	partial class PhotoCollectionImageCell : UICollectionViewCell
	{
		public PhotoCollectionImageCell (IntPtr handle) : base (handle)
		{
		}

        public void SetImage(UIImage image)
        {
            cellImageView.Image = image;
        }
	}
}
