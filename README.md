# Commands used for scaffolding

NOTE: Looks like scaffolding of razor pages with a DBContext does only work with MSSql, therefore I added MSSql.core and removed it afterwards.

```
[andreaskluth@localhost ContosoUniversity]$ dotnet tool install -g dotnet-aspnet-codegenerator

[andreaskluth@localhost ContosoUniversity]$ dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

[andreaskluth@localhost ContosoUniversity]$ dotnet add package Microsoft.EntityFrameworkCore
[andreaskluth@localhost ContosoUniversity]$ dotnet add package Microsoft.EntityFrameworkCore.Design
[andreaskluth@localhost ContosoUniversity]$ dotnet add package Microsoft.EntityFrameworkCore.SqlServer

This generates the code in the root namespace:
[andreaskluth@localhost ContosoUniversity]$ dotnet-aspnet-codegenerator razorpage -m ContosoUniversity.Models.Student -dc ContosoUniversity.Data.SchoolContext
```

# Additional setup
```
[andreaskluth@localhost ContosoUniversity]$ dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
[andreaskluth@localhost ContosoUniversity]$ dotnet add package  EFCore.NamingConventions
```