This repository contains the PayPal Core SDK .NET class library application and its NUnit Test application.


Prerequisites:
--------------
*	Visual Studio 2005 or higher
*	NUnit 2.6.2
*   Optional [NuGet.exe 2.2 and .NET Framework 4.0]


The PayPal Core SDK for .NET:
-----------------------------
*	The PayPal Core SDK is used to call the PayPal Platform API Web Service for the given payload and PayPal API profile settings.

*	The PayPal Core SDK addresses the essential needs of the PayPal API caller:
 	Frequent and up-to-date releases: The PayPal Core SDK is available on NuGet, which translates as immediate SDK refreshes upon updates to PayPal APIs.
 	Simpler configuration: A single configuration file that lets you manage your API credentials (supports multiple credentials), connectivity details, and service endpoints.
 	Error log: The PayPal Core SDK uses the log4net tool to log output statements to a text file to help locate the problem.
 	Backward compatibility: The PayPal Core SDK is developed using .NET Framework 2.0 and should compile on later versions of the .NET Framework.
 	
 
 Tools:
-------
*	log4net 1.2.10 is included in sdk-core-dotnet\lib folder
	Optional [To download and install log4net 1.2.10 using NuGet]
	
*	log4net is a tool to help the programmer output log statements to a variety of output targets. 
    In case of problems with an application, it is helpful to enable logging so that the problem can be located. 
    With log4net it is possible to enable logging at runtime without modifying the application binary. 
    The log4net package is designed so that log statements can remain in shipped code without incurring a high performance cost. 
    It follows that the speed of logging (or rather not logging) is crucial. 
    At the same time, log output can be so voluminous that it quickly becomes overwhelming. 
    One of the distinctive features of log4net is the notion of hierarchical loggers. 
    Using these loggers it is possible to selectively control which log statements are output at arbitrary granularity.

	
Optional [log4net 1.2.10 using NuGet]:
----------------------------------------------
*	log4net 1.2.10
	Visual Studio 2005 and 2008
	NuGet Install Arguments: 
	install log4net -Version 1.2.10 -excludeversion -outputDirectory .\Packages

*   Visual Studio 2010 and 2012:
    Go to Menu --> Tools --> Library Package Manager --> Package Manager Console
	Select NuGet official package source from the Package source dropdown box in the Package Manager Console
	Enter at PM> 
	Install-Package log4net -Version 1.2.10


NuGet 2.2
---------
*	NuGet is a Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects that use the .NET Framework. 
	If you develop a library or tool that you want to share with other developers, you create a NuGet package and store the package in a NuGet repository. 
	If you want to use a library or tool that someone else has developed, you retrieve the package from the repository and install it in your Visual Studio project or solution. 
	When you install the package, NuGet copies files to your solution and automatically makes whatever changes are needed, such as adding references and changing your app.config or web.config file. 
	If you decide to remove the library, NuGet removes files and reverses whatever changes it made in your project so that no clutter is left.


NuGet - Integrating NuGet with Visual Studio 2005 and 2008:
---------------------------------------------------

Prerequisites:
*	.NET Framework 4.0
*	NuGet 2.2

*	Download NuGet.exe Command Line (free to download): http://nuget.codeplex.com/releases/view/58939

*	Save NuGet.exe to folder viz., 'C:\NuGet' and add its path to the Environment Variables Path:

*	Go to Visual Studio Menu --> Tools
	Select External Tools…
	External Tools having 5* default tools in the Menu contents, Click Add
	*Note: The number of default tools may differ depending on the particular Visual Studio installation 
	Enter the following:
		Title: NuGet Install
		Command (Having in Environment Variables Path): NuGet.exe
		Arguments: install your.package.name -excludeversion -outputDirectory .\Packages
		Initial directory: $(SolutionDir)
		Use Output window: Check
		Prompt for arguments: Check
	Click Apply
	Click OK	
	On Clicking Apply and OK, NuGet Install will be added (as External Command 6*)
	*Note: The External Command number may differ depending on the particular Visual Studio installation
	Also, NuGet Toolbar can be added, right-click on Visual Studio Menu and select Customize…
	Customize by clicking New…
	Enter Toolbar name: NuGet and click OK
	Check NuGet Checkbox in the Toolbars tab for NuGet Toolbar to pop up
	Click Commands tab and select Tools and External Command 6 (Having added NuGet Install as External Command 6*) to Menu --> Tools	
	*Note: The External Command number may differ depending on the particular Visual Studio installation
	Menu --> Tools, clicking on NuGet Install will pop up for NuGet Install Arguments and Command Line
	Drag and drop External Command 6 to NuGet Toolbar
	Right-click NuGet Toolbar
	Enter Name: Install Package
	Right-click Change Button Image and select an image (Down Arrow)
	Close Customize
	Drag and drop NuGet Toolbar to the Menu
	Click the NuGet Toolbar Install Package
	Clicking on the NuGet Toolbar Install Package will pop up for NuGet Install Arguments and Command Line
 		Example NuGet Install:
		Enter Arguments: 
		install [your.package.name] -Version [X.X.X] -excludeversion -outputDirectory .\Packages
	The output window should display: Successfully installed '[your.package.name] [X.X.X]'.
	
*   Menu View --> Output (Ctrl+Alt+O)
	Note: By default, the root directory of Nuget Install is the same as that of the solution (.sln) file.
	In case of direct install using Visual Studio without loading any solution: 
	The typical location for Visual Studio 2005:    
	'C:\Program Files (x86)\Microsoft Visual Studio 8\Common7\IDE\'
	The typical Installation location for Visual Studio 2008:
	'C:\Program Files (x86)\Microsoft Visual Studio 9.0\Common7\IDE\'

	
NuGet Package Manager Installation in Visual Studio 2010 and 2012:
---------------------------------------------------------------
*	Visual Studio 2010 and 2012
	Go to Visual Studio 2010 Menu --> Tools
	Select Extension Manager…
	Enter NuGet in the search box and click Online Gallery
	Select the retrieved NuGet Package Manager, click Download
	Install the downloaded Package Manager
	
*	Go to Visual Studio 2010 Menu --> Tools, select Options…
		Verify the following on the Options popup
		Click Package Manager  Package Sources
		Available package sources:
		Check box (checked) NuGet official package source
		https://nuget.org/api/v2/
		Name: NuGet official package source
		Source: https://nuget.org/api/v2/
		And click OK
		
	Also, go to Menu --> Tools --> Library Package Manager, select Manage NuGet Packages for Solution…
	Manage NuGet Packages