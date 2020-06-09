using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Data.EF.Migrations
{
    public partial class FullTextSearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE FULLTEXT CATALOG StoreFullTextCatalog AS DEFAULT", suppressTransaction: true);
            migrationBuilder.Sql("CREATE FULLTEXT INDEX ON Books(Author, Title) KEY INDEX PK_Books WITH STOPLIST = SYSTEM", suppressTransaction: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FULLTEXT INDEX ON Books", suppressTransaction: true);
            migrationBuilder.Sql("DROP FULLTEXT CATALOG StoreFullTextCatalog", suppressTransaction: true);
        }
    }
}
