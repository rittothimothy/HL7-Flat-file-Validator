HL7 v2.8 
--------
	1.HL7 v2.8 Flat File (.txt) Validation - Implemented only for ADT_0_A04 type messages (Patient Registraion/Admission)
	This console application tool will help the user to validate segments in an HL7 flat file message. It will validate the number of occurrences
	as well as required property of each segment types eg (MSH, PV!, DG1).

	2.HL7 message processing is not yet implemented.

Configurations & Settings
-------------------------
ADTFlatFileValidatorConfig.xml : Used for configuring validation strategy based on HL7 v2.8. User can include custom tags and change configuration
to get the desired result.

HL7FlatFileInput (Folder): Folder is used to accept the input HL7 flat file.
HL7ADT04example1.txt : File name used to accept the HL7 flat file.

Dependancies
------------
	dotnet cli
	dotnet core 3.1

How to run
----------
Extract zip folder.
Use command prompt and naviggate to solution file(.sln) containing folder and type command 'dotnet build'
Use command prompt and navigate to project 'HL7 Flat file Validator' and type command 'dotnet run'



Functional Reference
---------------------
http://healthcareitsystems.com/2012/05/20/sample-hl7-adt-a04-message/

https://hl7-definition.caristix.com/v2/HL7v2.8/TriggerEvents/ADT_A04







