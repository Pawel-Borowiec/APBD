using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CW_12.Migrations
{
    public partial class New2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "idStudent", "Avatar", "BirthDate", "FirstName", "LastName", "Studies" },
                values: new object[,]
                {
                    { 1, "https://cdn.icon-icons.com/icons2/2643/PNG/512/male_boy_person_people_avatar_icon_159358.png", new DateTime(2000, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adam", "Banan", "Informatyka" },
                    { 2, "https://cdn.icon-icons.com/icons2/2643/PNG/512/male_boy_person_people_avatar_icon_159358.png", new DateTime(2001, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paweł", "Czerniak", "Informatyka" },
                    { 3, "https://image.flaticon.com/icons/png/512/194/194938.png", new DateTime(2002, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natalia", "Zachaj", "Kulturoznawsto" },
                    { 4, "https://cdn.icon-icons.com/icons2/2643/PNG/512/male_boy_person_people_avatar_icon_159358.png", new DateTime(2001, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rudolf", "Stronheim", "Germanistyka" },
                    { 5, "https://image.flaticon.com/icons/png/512/194/194938.png", new DateTime(2004, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monika", "Kurczyk", "Kulturoznawsto" },
                    { 6, "https://cdn.icon-icons.com/icons2/2643/PNG/512/male_boy_person_people_avatar_icon_159358.png", new DateTime(2002, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michał", "Parchaś", "Kulturoznawsto" },
                    { 7, "https://cdn.icon-icons.com/icons2/2643/PNG/512/male_boy_person_people_avatar_icon_159358.png", new DateTime(2002, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michał", "Zachajewczyk", "Obrona narodowa" },
                    { 8, "https://cdn.icon-icons.com/icons2/2643/PNG/512/male_boy_person_people_avatar_icon_159358.png", new DateTime(1998, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tytus", "Bomba", "Obrona narodowa" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "idStudent",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "idStudent",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "idStudent",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "idStudent",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "idStudent",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "idStudent",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "idStudent",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "idStudent",
                keyValue: 8);
        }
    }
}
