using System;
using Newtonsoft.Json;
using System.IO;
namespace MFContrast.Services
{
    public class ConvertJSON
    {
        // Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);
        public string local_json_file_path_url;
        public string local_destination_file_path_url;
        public ConvertJSON()
        {
            
        }
        public ConvertJSON(string local_from_url, string local_to_url)
        {
        
            this.local_destination_file_path_url = local_from_url;
            this.local_destination_file_path_url = local_to_url;
        }
        /*
        public void createObject()
        {
            try
            {
                using (FileStream fs = File.OpenRead(local_destination_file_path_url))
                {

                }
            }
            catch
            {
                (FileNotFoundException err){

                }
            }

        }
        */

    }
}
