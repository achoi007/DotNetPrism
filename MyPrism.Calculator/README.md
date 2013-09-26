Notes
=====

Descriptions for folders:
* Calculator - Calculator library
* IOLibrary - I/O library
* MyPrism.Calculator - Main program
* MyPrism.Interfaces - Interfaces used by Main Program, implemented in Calculator/IOLibrary

CHANGES
-------

step-3:
* Add Unity configuration to App.config.
* Remove references of IOLibrary and Calculator from MyPrism.Calculator project.
* Add reference of System.Configuration to MyPrism.Calculator.
* Add PostBuild.bat to copy runtime dll's into MyPrism.Calculator\bin.
* Change Program.cs to use Unity Configuration.

step-2: 
* Use UnityContainer in MyPrism.Calculator/Program.cs.
* Add reference to Unity3 in Nuget.

step-1: 
* Initial version


