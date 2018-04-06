Development Web Api

Latest Update: April 2018

INTRODUCTION
============

1. PRE-REQUISITES
=================

1.1 VISUAL STUDIO 2017
	.NET 4.6.1

1.2 Menage NuGet Packages...
			DevWebApi
				Install-Package Microsoft.EntityFrameworkCore.SqlServer 
				Install-Package Microsoft.EntityFrameworkCore.Tools 
				Install-Package Microsoft.EntityFrameworkCore.SqlServer.Design 
				Scaffold-DbContext "Data Source=MILANCHO\SQLEXPRESS;Initial Catalog=Demo;user id=aspekt;password=aspekt;" Microsoft.EntityFrameworkCore.SqlServer -f -OutputDir Models -Context DemoContext
				
				// Owin - Ouath - Token
				Install-Package Microsoft.AspNet.WebApi.Owin
				Install-Package Microsoft.Owin.Host.SystemWeb
				Install-Package Microsoft.Owin.Security.OAuth
				Install-Package Microsoft.Owin.Cors
				Install-Package Microsoft.AspNet.WebApi.Cors
				
				Instlal-Package System.ComponentModel.Annotations
				
				// update-package
				add Startup.cs file

				Post: token
				http://localhost:8090/token
				Headers:
				Accept: application/json
				Content-Type: application/x-www-form-urlencoded
				Body:
				grant_type: password
				username: test
				password: test
				Authorization: Bearer


2. Solution structure
=====================

2. Business
	- 
3. Hosts

4. Tests