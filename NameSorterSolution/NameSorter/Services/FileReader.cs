using Microsoft.Extensions.Logging;
using NameSorter.Interfaces;
using System;

namespace NameSorter.Services
{
    public class FileReader : IFileReader
    {
        private readonly ILogger<FileReader> _logger;

        public FileReader(ILogger<FileReader> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public List<string> ReadNamesFromFile(string filePath)
        {
            var names = new List<string>();

            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"The file '{filePath}' does not exist.");
                }

                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            names.Add(line.Trim());
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                _logger.LogError(ex, $"The file '{filePath}' does not exist.");
            }
            catch (IOException ex)
            {
                _logger.LogError(ex, $"An I/O error occurred while reading from the file '{filePath}'.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while reading from the file '{filePath}'.");
            }

            return names;
        }

    }
}
