using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_banco_geek.Infraestructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiCallLog",
                columns: table => new
                {
                    IdApiCallLog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Request = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValueA = table.Column<int>(type: "int", nullable: false),
                    ValueB = table.Column<int>(type: "int", nullable: false),
                    ResultValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsResultValueInFibonnaci = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiCallLog", x => x.IdApiCallLog);
                });

            migrationBuilder.CreateTable(
                name: "FibonacciValue",
                columns: table => new
                {
                    IdValue = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(30,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FibonacciValue", x => x.IdValue);
                });

            migrationBuilder.InsertData(
                table: "FibonacciValue",
                columns: new[] { "IdValue", "Value" },
                values: new object[,]
                {
                    { 1, 0m },
                    { 73, 498454011879264m },
                    { 72, 308061521170129m },
                    { 71, 190392490709135m },
                    { 70, 117669030460994m },
                    { 69, 72723460248141m },
                    { 68, 44945570212853m },
                    { 67, 27777890035288m },
                    { 66, 17167680177565m },
                    { 65, 10610209857723m },
                    { 64, 6557470319842m },
                    { 63, 4052739537881m },
                    { 62, 2504730781961m },
                    { 61, 1548008755920m },
                    { 60, 956722026041m },
                    { 59, 591286729879m },
                    { 58, 365435296162m },
                    { 57, 225851433717m },
                    { 56, 139583862445m },
                    { 55, 86267571272m },
                    { 54, 53316291173m },
                    { 53, 32951280099m },
                    { 74, 806515533049393m },
                    { 52, 20365011074m },
                    { 75, 1304969544928657m },
                    { 77, 3416454622906707m },
                    { 98, 83621143489848422977m },
                    { 97, 51680708854858323072m },
                    { 96, 31940434634990099905m },
                    { 95, 19740274219868223167m },
                    { 94, 12200160415121876738m },
                    { 93, 7540113804746346429m },
                    { 92, 4660046610375530309m },
                    { 91, 2880067194370816120m },
                    { 90, 1779979416004714189m },
                    { 89, 1100087778366101931m },
                    { 88, 679891637638612258m },
                    { 87, 420196140727489673m },
                    { 86, 259695496911122585m },
                    { 85, 160500643816367088m },
                    { 84, 99194853094755497m },
                    { 83, 61305790721611591m }
                });

            migrationBuilder.InsertData(
                table: "FibonacciValue",
                columns: new[] { "IdValue", "Value" },
                values: new object[,]
                {
                    { 82, 37889062373143906m },
                    { 81, 23416728348467685m },
                    { 80, 14472334024676221m },
                    { 79, 8944394323791464m },
                    { 78, 5527939700884757m },
                    { 76, 2111485077978050m },
                    { 51, 12586269025m },
                    { 50, 7778742049m },
                    { 49, 4807526976m },
                    { 22, 10946m },
                    { 21, 6765m },
                    { 20, 4181m },
                    { 19, 2584m },
                    { 18, 1597m },
                    { 17, 987m },
                    { 16, 610m },
                    { 15, 377m },
                    { 14, 233m },
                    { 13, 144m },
                    { 12, 89m },
                    { 11, 55m },
                    { 10, 34m },
                    { 9, 21m },
                    { 8, 13m },
                    { 7, 8m },
                    { 6, 5m },
                    { 5, 3m },
                    { 4, 2m },
                    { 3, 1m },
                    { 2, 1m },
                    { 23, 17711m },
                    { 24, 28657m },
                    { 25, 46368m },
                    { 26, 75025m },
                    { 48, 2971215073m },
                    { 47, 1836311903m },
                    { 46, 1134903170m },
                    { 45, 701408733m },
                    { 44, 433494437m },
                    { 43, 267914296m },
                    { 42, 165580141m },
                    { 41, 102334155m }
                });

            migrationBuilder.InsertData(
                table: "FibonacciValue",
                columns: new[] { "IdValue", "Value" },
                values: new object[,]
                {
                    { 40, 63245986m },
                    { 39, 39088169m },
                    { 99, 135301852344706746049m },
                    { 38, 24157817m },
                    { 36, 9227465m },
                    { 35, 5702887m },
                    { 34, 3524578m },
                    { 33, 2178309m },
                    { 32, 1346269m },
                    { 31, 832040m },
                    { 30, 514229m },
                    { 29, 317811m },
                    { 28, 196418m },
                    { 27, 121393m },
                    { 37, 14930352m },
                    { 100, 218922995834555169026m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiCallLog");

            migrationBuilder.DropTable(
                name: "FibonacciValue");
        }
    }
}
