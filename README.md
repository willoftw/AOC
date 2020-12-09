dotnet test --filter "AOC5.Tests.UnitTest1"

dotnet new classlib --name AOC6
dotnet new xunit --name AOC6.Tests

dotnet sln add AOC6
dotnet sln add AOC6.Tests  

dotnet test --collect:"XPlat Code Coverage" -r "./TestResults"
reportgenerator  "-reports:TestResults/7ff6e479-1a81-4be9-8430-6208e830c136/coverage.cobertura.xml" "-targetdir:TestsCoverageReport" -reporttypes:Html