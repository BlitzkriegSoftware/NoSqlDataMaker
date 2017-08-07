# No-SQL Data Generator

This project uses the library below to make records for use in testing no-SQL Databases like Mongo or CosmosDB

Uses the NuGet Package - Data Generator from https://github.com/FermJacob/Faker.Data

# Build

Compile using VS 2017 or the equipment MSBUILD

# Run

Here are the command line options:

    datamaker.console 1.0.2.0
    Copyright c Blitzkrieg Software 2017
    
      -n, --Number_of_Records(Default: 100) Number of Records
    
      -o, --Output_Folder(Default: ) Output Folder
    
      -h, --Help (Default: False) Help
    
      --help Display this help screen.

Example:

    datamaker.console -o "c:\temp\data\" -n 500

This would make 500 records to the folder specified