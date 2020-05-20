using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.Threading.Tasks;
using System;
using Amazon.CognitoIdentity;
using Amazon.S3.Model;

namespace MFContrast.Services
{

    public class AWSDownloader
    {

        //  Cloud Access Unavailable
        private static readonly string bucketName = "";
        private static readonly string poolId = "";
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast2;

        private static AmazonS3Client s3Client;
        private static CognitoAWSCredentials cognitoCredentials;
        private static TransferUtility transferUtility;

        public static CognitoAWSCredentials Credentials
        {
            get
            {
                if (cognitoCredentials == null)
                {
                    cognitoCredentials = new CognitoAWSCredentials(
                    poolId,
                    bucketRegion);
                }
                return cognitoCredentials;
            }
        }

        public static IAmazonS3 S3Client
        {
            get
            {
                if (s3Client == null)
                {
                    s3Client = new AmazonS3Client(Credentials, bucketRegion);
                }
                return s3Client;
            }
        }

        public static TransferUtility TransferUtility
        {
            get
            {
                if (transferUtility == null)
                {
                    transferUtility = new TransferUtility(S3Client);
                }
                return transferUtility;
            }
        }


        public static async Task<bool> BucketExist()
        {
            try
            {
                var response = await S3Client.ListObjectsAsync(new ListObjectsRequest()
                {
                    BucketName = bucketName,
                    MaxKeys = 0
                }).ConfigureAwait(false);
                return true;
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("S3 Exception Triggered" + e);
                return false;
            }
        }


        public static async Task<bool> S3DirectoryDownloadAsync()
        {
            try
            {
                TransferUtilityDownloadDirectoryRequest request = new TransferUtilityDownloadDirectoryRequest()
                {
                    BucketName = bucketName,
                    S3Directory = "CsvDataTables/",
                    LocalDirectory = @"d:\MFContrast\CsvData",

                };
                await TransferUtility.DownloadDirectoryAsync(request);
                return true;
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error in S3DownloadAsync" + e);
                return false;
            }
        }
    }
}
