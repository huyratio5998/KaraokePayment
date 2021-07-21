using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KaraokePayment.Data.Migrations
{
    public partial class addtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CMT",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiaChiChiTiet",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiaChiId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ho",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVIP",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaKH",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgaySinh",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SDT",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ten",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NhanVien_DiaChiId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoaiNV",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Luong",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaNV",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CaLV",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCa = table.Column<string>(nullable: true),
                    Tu = table.Column<double>(nullable: false),
                    Den = table.Column<double>(nullable: false),
                    HeSoLuong = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaLV", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiaChi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Huyen = table.Column<string>(nullable: true),
                    Tinh = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaChi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HangHoa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHH = table.Column<string>(nullable: true),
                    Ten = table.Column<string>(nullable: true),
                    SoLuong = table.Column<int>(nullable: false),
                    Gia = table.Column<decimal>(nullable: false),
                    NgayNhap = table.Column<DateTime>(nullable: false),
                    HanSuDung = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhong = table.Column<string>(nullable: true),
                    CoPhong = table.Column<string>(nullable: true),
                    IsVIP = table.Column<bool>(nullable: false),
                    Gia = table.Column<decimal>(nullable: false),
                    TrangThai = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanVienCaLV",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayLV = table.Column<DateTime>(nullable: false),
                    NhanVienId = table.Column<string>(nullable: true),
                    CaLvId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVienCaLV", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanVienCaLV_CaLV_CaLvId",
                        column: x => x.CaLvId,
                        principalTable: "CaLV",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVienCaLV_AspNetUsers_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookPhongOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TongTT = table.Column<decimal>(nullable: false),
                    TrangThai = table.Column<int>(nullable: false),
                    KhachHangId = table.Column<string>(nullable: true),
                    NhanVienCaLVId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPhongOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookPhongOrder_AspNetUsers_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookPhongOrder_NhanVienCaLV_NhanVienCaLVId",
                        column: x => x.NhanVienCaLVId,
                        principalTable: "NhanVienCaLV",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookPhongOrderPhong",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVienBook1Id = table.Column<int>(nullable: false),
                    NhanVienBook2Id = table.Column<int>(nullable: false),
                    ThoiGianBatDau = table.Column<DateTime>(nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(nullable: false),
                    PhuongThucTT = table.Column<string>(nullable: true),
                    TrangThai = table.Column<int>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: false),
                    NgaySua = table.Column<DateTime>(nullable: false),
                    TongTien = table.Column<decimal>(nullable: false),
                    BookPhongOrderId = table.Column<int>(nullable: false),
                    PhongId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPhongOrderPhong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookPhongOrderPhong_BookPhongOrder_BookPhongOrderId",
                        column: x => x.BookPhongOrderId,
                        principalTable: "BookPhongOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookPhongOrderPhong_Phong_PhongId",
                        column: x => x.PhongId,
                        principalTable: "Phong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThemHangHoa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuong = table.Column<int>(nullable: false),
                    BookPhongOrderPhongId = table.Column<int>(nullable: false),
                    HangHoaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThemHangHoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThemHangHoa_BookPhongOrderPhong_BookPhongOrderPhongId",
                        column: x => x.BookPhongOrderPhongId,
                        principalTable: "BookPhongOrderPhong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThemHangHoa_HangHoa_HangHoaId",
                        column: x => x.HangHoaId,
                        principalTable: "HangHoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CMT", "DiaChiChiTiet", "DiaChiId", "Ho", "IsVIP", "MaKH", "NgaySinh", "SDT", "Ten" },
                values: new object[] { "86263342-cde4-4dc1-9546-a0e986ff6fca", 0, "3fb38c68-c3e8-4668-83cc-e9afbbd70baa", "KhachHang", null, false, false, null, null, null, null, null, false, "d951c9b4-13f5-4f91-9e1d-28f300fc2060", false, null, null, null, null, "Nguyen Chung", true, "KH003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09999999", "Dung" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CMT", "DiaChiChiTiet", "NhanVien_DiaChiId", "Ho", "LoaiNV", "Luong", "MaNV", "NgaySinh", "NgayTao", "SDT", "Ten" },
                values: new object[,]
                {
                    { "5a847a71-439b-4562-8972-f100fd106dc1", 0, "ff8b99cc-ddb6-41fb-ac9b-d151ba09ec02", "NhanVien", "lannp@gmail.com", false, false, null, null, null, null, null, false, "a96fe15f-e527-4f17-a0dc-bde5f90545d9", false, null, "213123123", "khu tai dinh cu", null, "Ngo Phuong", "phucvu", 9000000m, "NV005", new DateTime(1998, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0989456122", "Lan" },
                    { "cde4d308-0195-4125-877b-d7348ef5c887", 0, "7f18d626-e9be-46a3-a769-83a0d6bb3fcb", "NhanVien", "thang@gmail.com", false, false, null, null, null, null, null, false, "554b1c41-7602-4612-be1f-760c46ad03b3", false, null, "465487982", "khu tai dinh cu", null, "Nguyen Minh", "phucvu", 9000000m, "NV004", new DateTime(1998, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "031231232", "Thang" },
                    { "54a5a4b3-a75a-441f-9b4b-d72965ac2b8d", 0, "1a260458-1f37-42a5-9aec-099ed0e4caa9", "NhanVien", "duc@gmail.com", false, false, null, null, null, null, null, false, "4ca61d8a-01ff-498c-b6d8-92897a2e4c94", false, null, "115487982", "khu tai dinh cu", null, "Nguyen Minh", "phucvu", 9000000m, "NV003", new DateTime(1998, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "031231232", "Duc" },
                    { "49ece4d1-a16d-45dd-aec2-23b3a85520ca", 0, "05b7219b-6bed-46b0-aa84-0792b8f52d64", "NhanVien", "hung@gmail.com", false, false, null, null, null, null, null, false, "ff3b3113-0f6d-401d-8256-a78b7d3e07ac", false, null, "123456789", "khu tai dinh cu", null, "Nguyen Van", "phucvu", 9000000m, "NV002", new DateTime(1998, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "099457645", "Hung" },
                    { "245d8f1e-0da8-45c8-8ced-b9777dc4a636", 0, "140301db-e7ca-4875-90bd-e69ea64af325", "NhanVien", "huynguyen98.clc@gmail.com", false, false, null, null, null, null, null, false, "eef7d7be-2329-4d32-be79-00700cddd1f0", false, null, "142829244", "10N01 - khu tai dinh cu", null, "Nguyen Van", "phucvu", 10000000m, "NV001", new DateTime(1998, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0977470992", "Huy" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CMT", "DiaChiChiTiet", "DiaChiId", "Ho", "IsVIP", "MaKH", "NgaySinh", "SDT", "Ten" },
                values: new object[,]
                {
                    { "56874680-cda1-4ddf-9dbd-5a7cb1c48abe", 0, "649a206e-2070-493c-8f97-d17457c727c6", "KhachHang", null, false, false, null, null, null, null, null, false, "98bdb96c-3113-439a-94ff-f28f4494b1d3", false, null, null, null, null, "Ngo Ba", false, "KH005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0977470999", "Nam" },
                    { "32467893-6e81-4077-99cd-ed17da38c487", 0, "0c470922-0645-4b1e-bc15-62a6d970d231", "KhachHang", null, false, false, null, null, null, null, null, false, "bfc73706-c647-486a-b618-ec90df501fc2", false, null, null, null, null, "Ngo Ba", false, "KH004", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "065332255", "Duc" },
                    { "a7a7feea-f4dc-4de7-a0ea-2ad1ca46713b", 0, "64c7bc5a-d4c8-4789-a439-2f7b4dc2e1e9", "KhachHang", null, false, false, null, null, null, null, null, false, "eef34b0e-0d80-4a1b-89ee-2c9a4a69045a", false, null, null, null, null, "Kieu Dang", false, "KH002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0554513222", "Thang" },
                    { "fa123bb7-10ce-454a-9408-7ef57dd8f131", 0, "12e5fd36-3ba0-4ced-a11b-7819fec565be", "KhachHang", null, false, false, null, null, null, null, null, false, "df6aaddf-81d5-4fab-a38e-585a87a2852f", false, null, null, null, null, "Ngo Ba", true, "KH001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0665324444", "Hung" }
                });

            migrationBuilder.InsertData(
                table: "CaLV",
                columns: new[] { "Id", "Den", "HeSoLuong", "TenCa", "Tu" },
                values: new object[,]
                {
                    { 1, 11.0, 1.0, "Ca 1", 7.0 },
                    { 4, 2.0, 2.0, "Ca 4", 22.0 },
                    { 2, 18.0, 1.0, "Ca 2", 11.0 },
                    { 3, 22.0, 1.5, "Ca 3", 18.0 }
                });

            migrationBuilder.InsertData(
                table: "DiaChi",
                columns: new[] { "Id", "Huyen", "Tinh" },
                values: new object[,]
                {
                    { 5, "Cam Giang", "Hai Duong" },
                    { 1, "Nam Sach", "Hai Duong" },
                    { 4, "Nam Tan", "Hai Duong" },
                    { 3, "Ha Dong", "Ha Noi" },
                    { 2, "Tan Trieu", "Ha Noi" }
                });

            migrationBuilder.InsertData(
                table: "HangHoa",
                columns: new[] { "Id", "Gia", "HanSuDung", "MaHH", "NgayNhap", "SoLuong", "Ten" },
                values: new object[,]
                {
                    { 2, 20000m, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "HH002", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "Dia Hoa Qua" },
                    { 3, 20000m, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "HH003", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "Bim Bim Ostar" },
                    { 1, 10000m, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "HH001", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "Bim Bim Oshi Cay" },
                    { 5, 45000m, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "HH005", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000, "Bia Heineken" },
                    { 4, 40000m, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "HH004", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000, "Bia Sai Gon" }
                });

            migrationBuilder.InsertData(
                table: "Phong",
                columns: new[] { "Id", "CoPhong", "Gia", "IsVIP", "TenPhong", "TrangThai" },
                values: new object[,]
                {
                    { 1, "small", 150000m, false, "P 101", 0 },
                    { 2, "small", 300000m, true, "P 102", 0 },
                    { 3, "small", 150000m, false, "P 103", 0 },
                    { 4, "medium", 300000m, false, "P 201", 0 },
                    { 5, "medium", 600000m, true, "P 202", 0 },
                    { 6, "medium", 300000m, false, "P 203", 0 },
                    { 7, "big", 600000m, false, "P 301", 0 },
                    { 8, "big", 1200000m, true, "P 302", 0 },
                    { 9, "big", 600000m, false, "P 303", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DiaChiId",
                table: "AspNetUsers",
                column: "DiaChiId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NhanVien_DiaChiId",
                table: "AspNetUsers",
                column: "NhanVien_DiaChiId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPhongOrder_KhachHangId",
                table: "BookPhongOrder",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPhongOrder_NhanVienCaLVId",
                table: "BookPhongOrder",
                column: "NhanVienCaLVId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPhongOrderPhong_BookPhongOrderId",
                table: "BookPhongOrderPhong",
                column: "BookPhongOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPhongOrderPhong_PhongId",
                table: "BookPhongOrderPhong",
                column: "PhongId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVienCaLV_CaLvId",
                table: "NhanVienCaLV",
                column: "CaLvId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVienCaLV_NhanVienId",
                table: "NhanVienCaLV",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_ThemHangHoa_BookPhongOrderPhongId",
                table: "ThemHangHoa",
                column: "BookPhongOrderPhongId");

            migrationBuilder.CreateIndex(
                name: "IX_ThemHangHoa_HangHoaId",
                table: "ThemHangHoa",
                column: "HangHoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DiaChi_DiaChiId",
                table: "AspNetUsers",
                column: "DiaChiId",
                principalTable: "DiaChi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DiaChi_NhanVien_DiaChiId",
                table: "AspNetUsers",
                column: "NhanVien_DiaChiId",
                principalTable: "DiaChi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DiaChi_DiaChiId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DiaChi_NhanVien_DiaChiId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DiaChi");

            migrationBuilder.DropTable(
                name: "ThemHangHoa");

            migrationBuilder.DropTable(
                name: "BookPhongOrderPhong");

            migrationBuilder.DropTable(
                name: "HangHoa");

            migrationBuilder.DropTable(
                name: "BookPhongOrder");

            migrationBuilder.DropTable(
                name: "Phong");

            migrationBuilder.DropTable(
                name: "NhanVienCaLV");

            migrationBuilder.DropTable(
                name: "CaLV");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DiaChiId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NhanVien_DiaChiId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32467893-6e81-4077-99cd-ed17da38c487");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "56874680-cda1-4ddf-9dbd-5a7cb1c48abe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86263342-cde4-4dc1-9546-a0e986ff6fca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7a7feea-f4dc-4de7-a0ea-2ad1ca46713b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa123bb7-10ce-454a-9408-7ef57dd8f131");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "245d8f1e-0da8-45c8-8ced-b9777dc4a636");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49ece4d1-a16d-45dd-aec2-23b3a85520ca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54a5a4b3-a75a-441f-9b4b-d72965ac2b8d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a847a71-439b-4562-8972-f100fd106dc1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cde4d308-0195-4125-877b-d7348ef5c887");

            migrationBuilder.DropColumn(
                name: "CMT",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DiaChiChiTiet",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DiaChiId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Ho",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsVIP",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaKH",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NgaySinh",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SDT",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Ten",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NhanVien_DiaChiId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LoaiNV",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Luong",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaNV",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
