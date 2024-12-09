using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework1.Methods
{
    public class FileDownloaderSynchoronous
    {
        public void DownloadFile()
        {
            Console.WriteLine("Downloading file (synchronous)...");
            System.Threading.Thread.Sleep(5000); // İşlemi simüle etmek için bekletme
            Console.WriteLine("File downloaded (synchronous).");
        }
    }
}