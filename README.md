# What is it?
BrandApp is a basic application build to explore following using MVVC architecture:
 - [Log4Net] (https://meelivyas.blogspot.com/p/log4net.html)
 - [Data Annotation] (https://meelivyas.blogspot.com/p/data-annotation.html)
 - [User Authentication using Sessions] (https://meelivyas.blogspot.com/p/user-authentication-session.html)
 - [User Authentication using Form authentication] (https://meelivyas.blogspot.com/p/user-authentication.html)
 - [Adding Unique Index using Code First Approach (Entity Framework)] (https://meelivyas.blogspot.com/p/adding-unique-index.html)
 - Show Modal on button click

# How do I set up?
## Software Requirement
 - Git Bash: https://git-scm.com/
 - Visual Studio
 
## Environment Setup
 - Clone the repository using  `git clone https://github.com/harshalshahg/CSharpMVCSneakPeak.git` command in Git Bash
 - Open`BrandApp.sln` solution file from respitory in Visual Studio.

## Database Configuration
 - Update the value of "Data Source" related to the connectionString from `Web.config` and `App.config` files present in "BrandApp.MVC" and "BrandApp.Services" projects of the repository. 
```xml
<connectionStrings>
	<add name="SASContext"  providerName="System.Data.SqlClient" connectionString="Data Source=.\sqlexpress; Initial Catalog=BrandApp.DB; Integrated Security=True; MultipleActiveResultSets=True"/>
</connectionStrings>
```
 - Clean and build the application.
 - Migrations are already executed on this project, hence you will see `*.cs` file at "\BrandApp.Services\Migrations" location. ([here] (https://meelivyas.blogspot.com/p/part1.html) are the steps to create migrations from scratch)
 - Run `Update-Database –Verbose` command from 'Package Manager Console' to create the database and tables.
 
 
# How do I use it?
 - Open <http://localhost:61467/Home/Index> on your web browser to see the appliction.
 - Register a new user and explore the brands/promotions