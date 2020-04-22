using System;
using System.IO;
using System.Collections.Generic;
using MFContrast.Models;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon;
using System.Threading.Tasks;
using System.Data;
using LumenWorks.Framework.IO.Csv;
using System.Threading;

namespace MFContrast.Services
{
    public class AWSGenerateHoldingsList
    {
        //private const string bucketName = "mfcontrast";
        //private readonly string secretKey = "N5SyoZ3NjSUHAQtD84mpB22IAHM2GZOKF45SA88d";
        //private readonly string accessKey = "AKIAQXPQOE6XFVCBIFN3";
        //private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast2;
        //private readonly AmazonS3Config config;
        //// private readonly string CsvDirectory = @"d:\MFContrast\DataFiles";
        //private IAmazonS3 client;

        //private readonly Func<DataTable, GetObjectResponse, DataTable> StreamFunc =
        //    new Func<DataTable, GetObjectResponse, DataTable>(LoadStreams);

        //private readonly Func<DataTable, List<Holding>> TableToLH =
        //    new Func<DataTable, List<Holding>>(ConvertTable);

        //private readonly Func<string, string, string> PathofFile =
        //    new Func<string, string, string>(GetPath);

        ////public Func<string, Task<bool>> DownloadCsv =
        ////    new Func<string, Task<bool>>(Download);

        //public bool DownloadComplete { get; set; }
        //public CancellationTokenSource CancellationTokenSource { get; set; }
        
        //public AWSGenerateHoldingsList()
        //{
        //    DownloadComplete = false;
        //    config = new AmazonS3Config();
        //    CancellationTokenSource = new CancellationTokenSource();
        //    client = new AmazonS3Client(
        //        accessKey,
        //        secretKey,
        //        bucketRegion);
        //}

        //private static string GetPath(string filename, string directory= @"d:\MFContrast\DataFiles")
        //{
        //    return Path.Combine(directory, filename);
        //}

        //public async Task<List<Holding>> CreateAsync(string keyName)
        //{
        //    try
        //    {
        //        DataTable data = await GenerateDataTableAsync(keyName);
        //        List<Holding> HoldingsList = TableToLH(data);
        //        return HoldingsList;
        //    }
        //    catch (NullReferenceException e)
        //    {
        //        Console.WriteLine("ReadObjectDataAsync returned null:", e.Message);
        //        return null;
        //    }
        //}

        //public async Task<DataTable> GenerateDataTableAsync(string keyName)
        //{
        //    DataTable responseDataTable = new DataTable();
        //    var client = new AmazonS3Client(
        //       accessKey,
        //       secretKey,
        //       bucketRegion);

        //    try
        //    {
        //        GetObjectRequest request = new GetObjectRequest
        //        {
        //            BucketName = bucketName,
        //            Key = keyName,
        //        };

        //        using (GetObjectResponse response = await client.GetObjectAsync(request))
        //        {
        //            lock (this)
        //            {
        //                return StreamFunc(responseDataTable, response);
        //            }
        //        }
        //    }
        //    catch (AmazonS3Exception e)
        //    {
        //        Console.WriteLine("Error encountered ***. Message:'{0}' when writing an object", e.Message);
        //        return null;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
        //        return null;
        //    }
        //}

        //private static DataTable LoadStreams(DataTable responseDataTable, GetObjectResponse response)
        //{
        //    // var assembly = Assembly.GetAssembly(typeof(AWSGenerateHoldingsList));
        //    // Should the files be written or 
        //    // var pclStream = assembly.GetManifestResourceStream(response.WriteResponseStreamToFileAsync());
        //    try
        //    {
        //        using (Stream responseStream = response.ResponseStream)
        //        using (StreamReader reader = new StreamReader(responseStream))
        //        using (CsvReader csvReader = new CsvReader(reader, true))
        //        {
        //            responseDataTable.Load(csvReader);
        //        }
        //        return responseDataTable;
        //    }
        //    catch (AmazonS3Exception e)
        //    {
        //        Console.WriteLine("Error encountered ***. Message:'{0}' when writing an object", e.Message);
        //    }
        //    return responseDataTable;
        //}

        //private async Task LoadDataAsync(Func<string, string> pathFunc, GetObjectResponse response, string fileName)
        //{
        //    await response.WriteResponseStreamToFileAsync(pathFunc(fileName), false, CancellationTokenSource.Token);
        //    DownloadComplete = true;
        //}

        //private static List<Holding> ConvertTable(DataTable data)
        //{
        //    List<Holding> HoldingsList = new List<Holding>();
        //    foreach (DataRow row in data.Rows)
        //    {
        //        HoldingsList.Add(new Holding
        //        {
        //            Name = row[4].ToString(),
        //            Rank = row[1].ToString(),
        //            Percentage = row[3].ToString(),
        //            Symbol = row[5].ToString()
        //        });
        //    }
        //    return HoldingsList;
        //}


        //private static GetObjectRequest GenerateRequest(string fileName, string bucketName = "mfcontrast")
        //{
        //    string key = Path.Combine("CsvDataTables", fileName);
        //    GetObjectRequest request = new GetObjectRequest
        //    {
        //        BucketName = bucketName,
        //        Key = key,
        //        // ModifiedSinceDateUtc
        //    };
        //    return request;
        //}

        ////public static async Task<bool> Download(string fileName)
        ////{
        ////    bool isDownloaded = false;

        ////    GetObjectRequest request = GenerateRequest(fileName);

        ////    try
        ////    {
        ////        using (var response = await client.GetObjectAsync(request))
        ////        {
        ////            string avatarFilepath = Path.Combine("MFContrast", fileName);
        ////            await response.WriteResponseStreamToFileAsync(avatarFilepath, true, CancellationTokenSource.Token);
        ////            isDownloaded = true;
        ////        }
        ////    }
        ////    catch (AmazonS3Exception)
        ////    {
        ////        isDownloaded = false;
        ////    }
        ////    return isDownloaded;
        ////}

    }
}
