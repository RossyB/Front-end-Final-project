namespace BookStore.Api
{
    using System.Data.Entity;
    using BookStore.Data;
    using BookStore.Data.Migrations;

    internal static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreDbContext, Configuration>());
            BookStoreDbContext.Create().Database.Initialize(true);
        }
    }
}