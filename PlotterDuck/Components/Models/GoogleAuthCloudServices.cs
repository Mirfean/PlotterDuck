using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterDuck.Components.Models
{
    internal class GoogleAuthCloudServices
    {
        public StorageClient GetStorageClient()
        {
            GoogleCredential credential = GoogleCredential.FromFile("P:\\Projects\\.Net\\PlotterDuck\\PlotterDuck\\Resources\\plotterduck-firebase-adminsdk.json");
            StorageClient storageClient = StorageClient.Create(credential);
            return storageClient;
        }
    }
}
