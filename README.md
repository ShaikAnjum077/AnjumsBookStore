# AnjumsBookStore

1ST November 2:30PM Create a new project using Asp.net core web application and select the project name and source as well. Configure for https and enable razor runtime compilation and individual user accounts. and then select create. Project will be created
upload the code to github. file->create ->create git repository-> create and push.

1st Nov 3:30PM Click on icon==>Create a Git Repository--->>Create and Push

3:50PM: --> Extend HomeControllers to base class as HomeController:Controller

4;00 PM --> LoginPartial.cshtml is used for buttons to login and register

2:50PM In controllers--> home controllers-> extend the home controller 

2nd November 1:30AM :--> layout.cshtml is the master page of the application

2nd November 9:00AM --> Replace the bootsrap.css file

3rd November 10AM--> Views=>Shared=>Layout.cshtml=>Change the filename from bootstrap.min.css to bootstrap.css

4th Nov 3AM--> Change the nav class from navbar-light to navbar dark and bg-white to bg-primary

From Line 23 Remove the text-dark

5th November 9AM--> Remove references to text-dark

Now run the project ti review the  changes.

6th Novemer 10AM: Additional 3rd Party Tools JQuery UI(Datepicker)--> Data Tables--> Sweet Alerts-->font Awesome--> Toastr

7th November 1AM--> Add to the_layout.cshtml page the additional stylesheets and scripts from the CSS_JS.txt file

7thNovember 10AM--> Content Management-->Add three new projects (.net core class library to the application)

AnjumsBooks.DataAccess
AnjumsBooks.Models
AnjumsBooks.Utility

11AM Copy the Data folder and paste to .DataAccess projecct delete the orginal one

1PM:- Install Micrsoft.EntityFrameworkCore.Relational and Core.SqlServer packages

Delete the Migration Folder

Install NuGet Package: identity.EntityFramework Core

2Pm Modify the Namespace and now delete the default Class1.cs file from all projects and Build the project. Move Models into AnjumsBooks.Models and delete the original one. 

3PM 7th Nov:-> Modify Views>shared>Error.cshtml

project-Add-Project-Reference-.DataAccess and .Models

4Pm :-> Rename Models folder to ViewModels
5PM:- Change the ErrorViewModels.cs namespace .Models.ViewModels and then Build the project

5:30PM same day:- Remove the using statement from Startup.cs and In the error .cshtml file correct ErrorViewModel to the new .Models.ViewModels.ErrorViewModels and now run the application

6PM In the Utility Project create a static details class called SD.cs

7PM: Views are now in Aresa, but masterpage is defined as _ViewStart

Modify the _ViewStart.cshtml to refelect the new path
Now Run the application


 
