REM copying implementation libraries to output directory
REM copy /Y "%1\IOLibrary\bin\%2\IOLibrary.dll" "%3"
REM copy /Y "%1\Calculator\bin\%2\Calculator.dll" "%3"
REM echo "%1IOLibrary\bin\%2\IOLibrary.dll" 
REM echo "%1Calculator\bin\%2\Calculator.dll"
REM echo "%3"
COPY /Y "%1IOLibrary\bin\%2\IOLibrary.dll"  "%3"
COPY /Y "%1Calculator\bin\%2\Calculator.dll" "%3"