# No-SQL Data Generator

This project uses the library below to make records for use in testing no-SQL Databases like Mongo or CosmosDB

Uses the NuGet Package - Data Generator from https://github.com/FermJacob/Faker.Data

# Build

Compile using VS 2022, dotnet, or MSBUILD

# Run

Here are the command line options:
    
      -n, --Number_of_Records(Default: 100) Number of Records
    
      -o, --Output_Folder(Default: ) Output Folder
    
      -d, --Data_File(Default: datamaker-data.json) When used with -a
     name of file to use
    
      -a, --As JSON Array(Default: False) Output one file with all records
     as a JSON Array
    
      -h, --Help (Default: False) Help


# Examples

## One record per file

500 Records each in its own file:

```ps1
    datamaker.console -o "c:\temp\data\" -n 500
```
This would make 500 records to the folder specified

## One big file as an array of records

500 Records in one big file (suitable for mongoimport)

```ps1
    datamaker.console -n 500 -o "c:\temp\data" -a true -d "people-data.json"
```

This would make a file called "c:\temp\data\people-data.json" with 500 records in it

## mongoimport notes

The utility can be very fussy, and gives little or no useful diagnostic information.

Generally, batches of multiple records per file work better than individual files with one record each.

### Import command

Here is a sample that worked for me against Cosmos DB (in Mongo DB API mode)
```ps1
    mongoimport --host %HOST%:%PORT% -u %USER% -p %PASS% --db %DB% --collection %COLL% --ssl --sslAllowInvalidCertificates --type json --file %DIR%\%%i --jsonArray
```

Where the %% tokens (DOS SET Variables) are replaced with values from the azure portal connection string tab for your Cosmos DB instance.

Here is the output:
```ps1
    2017-08-11T16:16:03.180-0700connected to: %HOST%:%PORT%
    2017-08-11T16:16:05.258-0700[########################] DemoData2.People
    324KB/324KB (100.0%)
    2017-08-11T16:16:08.255-0700[########################] DemoData2.People
    324KB/324KB (100.0%)
    2017-08-11T16:16:11.255-0700[########################] DemoData2.People
    324KB/324KB (100.0%)
    2017-08-11T16:16:13.131-0700[########################] DemoData2.People
    324KB/324KB (100.0%)
    2017-08-11T16:16:13.132-0700imported 500 documents
```    

### Common annoyances:

**Q**: Why no records imported?
A: Is the database, collection, or other connection info misspelled? 
A: Did you specify a partition key (use '/_id' by default)

**Q**: I get weird SSL errors after importing about 50 single files
A: Yep. Use -a true -d "filename.json" to group files into batches

# Sample JSON Record

Here is a sample in the one record per file format, as an array the records are the same but in an array.

file name: `00b241a0-0fe3-4d99-a101-b9f4beb842ec.json`
```json
    {
        "_id": "00b241a0-0fe3-4d99-a101-b9f4beb842ec",
        "NameLast": "Wick",
        "NameFirst": "Shawn",
        "EMail": "Shawn.Wick@dropzone.com",
        "Company": "dropzone.com",
        "MemberSince": "1989-10-23T00:00:00",
        "Birthday": "1971-02-24T00:00:00",
        "Addresses": [{
            "Address1": "6682 Saddlewood Drive Center",
            "Address2": null,
            "City": "Puyallup",
            "State": "AZ",
            "Zip": "13736",
            "Kind": "Mailing"
        }],
        "Preference": {
            "distinctio-0": "Cras distinctio neque arcu purus ipsa sintoccaecati efficitur neque non.",
            "dapibus-1": "Suscipit inceptos dignissimos.",
            "auctor-2": "Aliquam cursus provident sociis vestibulum facilisis rem facilisis facilisis nullam nobis.",
            "voluptas-3": "Aliquet tempus omnis sit tempor fames maiores accusantiumdoloremque fermentum.",
            "magnis-4": "Nisi nostra quibusdam ipsum vivamus sequi vivamus massa."
        }
    }
```