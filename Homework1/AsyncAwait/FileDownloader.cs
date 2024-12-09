using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework1.AsyncAwait
{
    public class FileDownloader
    {
        public async Task DownloadFileAsync(string fileName)
        {
            try
            {
                Console.WriteLine($"Starting download of {fileName}...");

                // Hata oluşabilecek bir işlem simülasyonu
                await Task.Delay(2000); // Dosya indiriliyor gibi bekletme

                if (string.IsNullOrWhiteSpace(fileName))
                {
                    throw new ArgumentException("File name cannot be null or empty.");
                }

                // İşlem başarılı
                Console.WriteLine($"File {fileName} downloaded successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Download attempt completed.");
            }
        }
    }
}