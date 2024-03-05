using Microsoft.Extensions.Logging;
using NameSorter.Interfaces;
using NameSorter.Sorting;
using System;

namespace NameSorter.Services
{
    public class NameSorterService : INameSorterService
    {
        private readonly ILogger<NameSorterService> _logger;
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;
        private readonly ISortStrategy _sortStrategy;

        public NameSorterService(ILogger<NameSorterService> logger, IFileReader fileReader, IFileWriter fileWriter, ISortStrategy sortStrategy)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
            _fileWriter = fileWriter ?? throw new ArgumentNullException(nameof(fileWriter));
            _sortStrategy = sortStrategy ?? throw new ArgumentNullException(nameof(sortStrategy));
        }

        public List<string> SortNamesFromFile(string inputFile, string outputFile)
        {
            try
            {
                if (!ValidateInput(inputFile, outputFile))
                {
                    return null;
                }

                var names = _fileReader.ReadNamesFromFile(inputFile);
                names = names.Where(name => !string.IsNullOrWhiteSpace(name)).ToList();

                if (names == null || !names.Any())
                {
                    _logger.LogInformation("No names found in the input file.");
                    return null;
                }

                names = _sortStrategy.SortNames(names);
                _fileWriter.WriteNamesToFile(names, outputFile);

                _logger.LogInformation($"Names sorted successfully. See {outputFile} for the sorted names.");
                return names;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred: {ex.Message}");
                return null;
            }
        }

        public bool ValidateInput(string inputFile, string outputFile)
        {
            if (string.IsNullOrWhiteSpace(inputFile) || !_fileWriter.FileExists(inputFile))
            {
                _logger.LogError($"Invalid input file path or file does not exist: {inputFile}");
                return false;
            }

            string directory = Path.GetDirectoryName(outputFile);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                try
                {
                    Directory.CreateDirectory(directory);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while creating the output directory: {ex.Message}");
                    return false;
                }
            }

            return true;
        }
    }
}
