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

# Sample JSON Record

filename: `00b241a0-0fe3-4d99-a101-b9f4beb842ec.json`

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