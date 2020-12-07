dotnet test --filter "AOC5.Tests.UnitTest1"

dotnet new classlib --name AOC6
dotnet new xunit --name AOC6.Tests

dotnet sln add AOC6
dotnet sln add AOC6.Tests  