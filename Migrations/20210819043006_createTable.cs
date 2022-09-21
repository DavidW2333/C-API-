using Microsoft.EntityFrameworkCore.Migrations;

namespace CS335_A1.Migrations
{
    public partial class createTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                            name: "Staff",
                            columns: table => new
                            {
                                Id = table.Column<int>(type: "INTEGER", nullable: false)
                                    .Annotation("Sqlite:Autoincrement", true),
                                LastName = table.Column<string>(type: "TEXT", nullable: false),
                                FirstName = table.Column<string>(type: "TEXT", nullable: false),
                                Title = table.Column<string>(type: "TEXT", nullable: true),
                                Email = table.Column<string>(type: "TEXT", nullable: true),
                                Tel = table.Column<string>(type: "TEXT", nullable: true),
                                Url = table.Column<string>(type: "TEXT", nullable: true),
                                Research = table.Column<string>(type: "TEXT", nullable: true)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_Staff", x => x.Id);
                            });
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<string>(type: "DOUBLE", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
            
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Time = table.Column<string>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IP = table.Column<string>(type: "TEXT", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });
        }



        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff");
            migrationBuilder.DropTable(
                name: "Products");
            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}

