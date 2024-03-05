
using Microsoft.Extensions.Logging;
using NameSorter.Interfaces;
using System;

namespace NameSorter.Services
{
    public class FileWriter : IFileWriter
    {
        private readonly ILogger<FileWriter> _logger;

        public FileWriter(ILogger<FileWriter> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void WriteNamesToFile(List<string> names, string filePath)
        {
            try
            {
                if (names == null || string.IsNullOrWhiteSpace(filePath))
                {
                    throw new ArgumentNullException(nameof(names));
                }

                string directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var name in names)
                    {
                        writer.WriteLine(name);
                    }
                }
            }
            catch (IOException ex)
            {
                _logger.LogError(ex, $"An I/O error occurred while writing to the file '{filePath}'.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while writing to the file '{filePath}'.");
            }
        }

        public bool FileExists(string filePath)
        {
            try
            {
                return File.Exists(filePath);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while checking if the file exists: {ex.Message}");
                return false; 
            }
        }
    }
}
