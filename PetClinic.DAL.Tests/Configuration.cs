using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace PetClinic.DAL.Tests;

public static class Configuration
{
    public const string SqliteConnectionString = "Data Source=:memory:;";
}