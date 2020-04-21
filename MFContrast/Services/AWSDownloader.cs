using System.IO;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace MFContrast.Services
{
    public class AWSDownloader
    {
        private const string bucketName = "mfcontrast";
        private readonly string secretKey = "N5SyoZ3NjSUHAQtD84mpB22IAHM2GZOKF45SA88d";
        private readonly string accessKey = "AKIAQXPQOE6XFVCBIFN3";
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast2;
        private AmazonS3Client s3Client;
        private TransferUtility transferUtility;


        public AWSDownloader()
        {
            s3Client = new AmazonS3Client(
                accessKey,
                secretKey,
                bucketRegion);
            var config = new TransferUtilityConfig();
            // var file = Path.Combine(Android.Environment.ExternalStorageDirectory.AbsolutePath, Android.OS.Environment.DirectoryDownloads);

            transferUtility = new TransferUtility(s3Client, config);

            // TransferUtilityDownloadRequest request = new TransferUtilityDownloadRequest();

            
        }

        public void S3Download(string file)
        {
            string key = Path.Combine("CsvDataTables", file);

            transferUtility.Download(
                Path.Combine(@"d:\MFContrast", file),
                bucketName,
                key
            );
        }
    }
}
