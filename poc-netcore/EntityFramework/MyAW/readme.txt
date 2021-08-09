- maar eerst s kijken hoe we gegeven een database, een EF model kunnen maken
	vet lang lopen kutten om simpele "navigation property" werkende te krijgen, bleek EnableLazyLoading aangezet te moeten worden in die dbcontext..
- kijken naar die migrations en die update-databsae en die package manager console
	met dotnet tool install --global dotnet-ef installeer je dus een extension op de dotnet command
	vervolgens
	dotnet ef migrations add InitialCreate --project "..\EntityFramework.csproj" --context "MyModelContext"
	en je heb netjes je schema in code

	tijdens development doe je ---> 
                await ctx.Database.EnsureCreatedAsync();

	voor database naar code:
	dotnet ef dbcontext scaffold --project ..\Service.IntegrationTest.csproj "user id=niels;pwd=S08J1298UHJSD1;server=192.168.63.69;port=5432;database=visi4_test46a.bakkerspees.nl;timeout=0" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir .\EntityFramework