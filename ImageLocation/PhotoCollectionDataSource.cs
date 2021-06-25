using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;
using Photos;

namespace ImageLocation
{
    class PhotoCollectionDataSource : UICollectionViewDataSource
    {
        private static readonly string photoCellIdentifier = "ImageCellIdentifier";
        private PHFetchResult imageFetchResult;
        private PHImageManager imageManager;

        public PhotoCollectionDataSource()
        {
            imageFetchResult = PHAsset.FetchAssets(PHAssetMediaType.Image, null);
            imageManager = new PHImageManager();
        }

        ~PhotoCollectionDataSource()
        {
            imageManager.Dispose();
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var imageCell = collectionView.DequeueReusableCell(photoCellIdentifier, indexPath) as PhotoCollectionImageCell;

            var imageAsset = imageFetchResult[indexPath.Item] as PHAsset;

            imageManager.RequestImageForAsset(imageAsset,
                new CoreGraphics.CGSize(100.0, 100.0), PHImageContentMode.AspectFill,
                new PHImageRequestOptions(),
                (UIImage image, NSDictionary info) =>
                {
                    imageCell.SetImage(image);
                });

            return imageCell;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return imageFetchResult.Count;
        }

        public void ReloadPhotos()
        {
            imageFetchResult = PHAsset.FetchAssets(PHAssetMediaType.Image, null);
        }

    }
}
