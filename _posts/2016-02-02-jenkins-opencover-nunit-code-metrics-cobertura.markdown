---
published: true
title: Jenkins, OpenCover, NUnit, Code Metrics, Cobertura 
layout: post
---

In this tutorial, we will be talking about how to provide CI(Continuous Integration) for .NET projects using Jenkins. And how to be informed about code and test coverage and code metrics. 
Pre-Build
• Ensure that Jenkins and Git installed properly with necessary plugins and tools which are defined below.(Info: Extract all tools to C:\Tools\{toolname}\ folder.)
• Jenkins settings should be configured to be able to run C# project and code metrics tool which is needed to prepare report, properly. Meaning by that, MSBuild and Visual Studio Code Metrics Tool should be registered. 
Build 
• Source code should be pulled to Jenkins from git or any other scm repository.(In this example Github is used.) A Jenkins job is created for this action.
• After pulling the project, another Jenkins job is configured to build solution using MSBuildPlugin which is installed earlier.
• Afterwards, build step should be set to generate OpenCover coverage result using NUnit test runner and another build step should be added to get OpenCover coverage result as an HTML file.
• If you want to convert OpenCover coverage results to Cobertura reports, another build step should be added. There is a nuget package to make this easier which is OpenCoverToCoberturaConverter. (Why Cobertura?) 
• After reports, another build step is added to calculate code metrics using VS Code Metrics Power Tool.
Post-Build
• As a post-build action, publishing Cobertura coverage report step should be added using Cobertura for Jenkins. 
• And also Jenkins provides publishing reports as HTML files. Again, another post-build step should be added for this using HtmlPublisherPlugin. 
• To publish NUnit test results as a post-build action, NUnitPlugin is configured.
• To publish code metrics as a post-build action, Record VS Code Metrics Power Tool Report is configured.
Requirements
Jenkins
Please use instructions from here Installing Jenkins on Windows
Git
Download and install git from link
Jenkins Plugins
• Git
• MsBuildPlugin
• HtmlPublisherPlugin 
• NUnitPlugin 
• Visual Studio Code Metrics 
• Cobertura
Tools
• ReportGenerator
• OpenCover
• Metrics Power Tools
• OpenCoverToCoberturaConverter
• NUnit
Info: Extract all tools(Metrics Power Tools will be installed in Program Files) to C:\Tools\{toolname}\ folder.
Jenkins Settings
Register MsBuild
C:\Program Files (x86)\MSBuild\12.0\Bin\MSBuild.exe
Jenkins MSBuild Settings
Register Visual Studio Code Metrics Tool
C:\Program Files (x86)\Microsoft Visual Studio 12.0\Team Tools\Static Analysis Tools\FxCop\metrics.exe
Jenkins Visual Studio Code Metrics Tool Settings
Create Jenkins Build Job
Source Code Management Settings
Configure Jenkins job to get source code from Git repository.
https://github.com/{projectname}.git
Jenkins Job Source Control Settings
Build settings
MSBuild
Configure Jenkins job to build source code using MSBuild.
{projectname}.sln
MSBUild Settings
OpenCover & NUnit
Add build step to generate OpenCover coverage results using NUnit test runner.
"C:\Tools\opencover\OpenCover.Console.exe" -target:"C:\Tools\nunit\nunit-console.exe" -targetargs:"%JOB_NAME%.Tests\bin\Debug\%JOB_NAME%.Tests.dll /framework:net-4.5 /xml:%JOB_NAME%NunitTestResults.xml /nologo /noshadow" -filter:"+[*]* -[%JOB_NAME%.Tests]*" -register:Path64 -hideskipped:Filter -output:%JOB_NAME%Coverage.xml
OpenCover & NUnit Settings
ReportGenerator
Add build step to generate html results from OpenCover coverage results.
"C:\Tools\reportgenerator\ReportGenerator.exe" -reports:%JOB_NAME%Coverage.xml -targetDir:CodeCoverageHTML
ReportGenerator Settings
OpenCoverToCoberturaConverter
Add build step to convert opencover results to cobertura reports.
"C:\Tools\opencover_to_cobertura_converter\OpenCoverToCoberturaConverter.exe" -input:%JOB_NAME%Coverage.xml -output:%JOB_NAME%Cobertura.xml -sources:%WORKSPACE%
OpenCoverToCoberturaConverter Settings
VS Code Metrics Power Tool
Add build step to calculate Code Metrics.
Your assemblies to calculate code metrics.
Vs Code Metrics Power Tool exec Settings
Post-Build settings
Publish Cobertura Coverage Report
{YourProjectName}Cobertura.xml
Add post-build step to view code coverage results as Cobertura report. Publish Cobertura Coverage Reports
Publish Html Reports
CodeCoverageHTML   # HTML directory to archive
index.htm          # report index page
Code Coverage      # report title
Add post-build step to view code coverage results as html. Publish Html Reports
Publish NUnit Test Results Report
Add post-build step to view NUnit test results.
{YourProjectName}NunitTestResults.xml
Publish NUnit Test Results Report
Record VS Code Metrics Power Tool Report
Add post-build step to view VS Code Metrics Power Tool reports.
{YourProjectName}Metrics.xml
Record VS Code Metrics Power Tool Report
Result
Tests
Test
Code Coverage - OpenCover
Code Coverage - OpenCover
Code Coverage - Cobertura
Code Coverage - Cobertura
Code Coverage - Cobertura
Metrics
Metrics
 