# Name Sorter

Name Sorter is a simple console application for sorting a list of names stored in a text file alphabetically and writing the sorted names to another text file.

## Installation

To use Name Sorter, follow these steps:

1. Clone the repository to your local machine:

```bash
git clone https://github.com/dev-msalah/Dye-Durham.git
```

2. Navigate to the project directory:

```bash
cd NameSorterSolution/NameSorter
```

## Build the project:

```bash
dotnet build
```

## Usage
Name Sorter accepts one command-line argument: the path to the input text file containing the unsorted names.

1. Navigate to the bin folder 

```bash
cd bin\Debug\net8.0
```

2. run the application

```bash
NameSorter.exe unsorted-names-list.txt
```

The sorted names will be written to a file named sorted-names-list.txt in the bin\Debug\net8 directory. and it will be displayed on the command line too.
ere h
## Testing
To run the unit tests, navigate to the test project directory and execute the following steps:

1. Navigate to the solution folder Then to NameSorter.Tests. If you are still in the bin folder 
```bash
cd ..\..\..\..\NameSorter.Tests\
```

2. run the test using the following:
   
```bash
dotnet test
```

## Modifying the test data
If you want to modify the test data for the application, follow these steps:

1. Navigate to the root of the solution.
2. Locate a text file named 'unsorted-names-list.txt'.
3. Edit the data in the text file as desired.
4. Build the solution again after modification to copy the file into the bin folder:
   ```bash
   dotnet build
   ```
   Note: There is a post-build event to copy the file, so no additional steps are required other than building the solution.
5. Run the application as mentioned in the Usage section.

## CI/CD

I have tried to add the solution to travis-ci, but the project is not building because they do not support .NET 8.0.

## Dependencies
.NET Core 8.0

## Contributing
Contributions are welcome! Please fork the repository, make changes, and submit a pull request.

## License
This project is licensed under the MIT License.
