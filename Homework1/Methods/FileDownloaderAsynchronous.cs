using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework1.Methods
{
    public class FileDownloaderAsynchronous
    {
        public async Task DownloadFileAsync()
        {
            Console.WriteLine("Downloading file (asynchronous)...");
            await Task.Delay(5000); // İşlemi simüle etmek için asenkron bekletme
            Console.WriteLine("File downloaded (asynchronous).");
        }
    }
}