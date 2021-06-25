using System;

using UIKit;
using Photos;

namespace ImageLocation
{
    public partial class ViewController : UIViewController
    {
        private PhotoCollectionDataSource photoDataSource;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            if (PHPhotoLibrary.AuthorizationStatus == PHAuthorizationStatus.NotDetermined)
            {
                PHPhotoLibrary.RequestAuthorization((PHAuthorizationStatus newStatus) => { });
            }

            photoDataSource = new PhotoCollectionDataSource();
            collectionView.DataSource = photoDataSource;

            PHPhotoLibrary.SharedPhotoLibrary.RegisterChangeObserver((changeObserver) => {
                InvokeOnMainThread(() => {
                    photoDataSource.ReloadPhotos();
                    collectionView.ReloadData();
                });
            });

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}