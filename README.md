DotNet Prism
============

A C# project implements a very simple calculator in order to demonstrate writing 
a [PRISM](http://msdn.microsoft.com/en-us/library/gg406140.aspx) application.

To extract this project at different stage of development, use the following [GIT tags](http://git-scm.com/book/en/Git-Basics-Tagging):
* step-1 - pre-Unity, pre-PRISM
* step-2 - hardcoded Unity
* step-3 - use Unity configuration instead of hardcode
* step-4 - CalculatorREPL now takes an IEnumerable of IOutputService
* step-5 - add new CalculatorREPL; 2 containers in App.config
* step-6 - use IServiceLocator to make code container agnostic

For example, run the command `git checkout -f step-1` to switch to step 1

