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
                    TrangThai = table.Column<string>(nullable: true)
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
                    TrangThai = table.Column<string>(nullable: true),
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
                    TrangThai = table.Column<string>(nullable: true),
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
                values: new object[] { "1c1b0576-1637-440a-9fa2-7078f63fd7d3", 0, "26b8b80f-1a14-4540-b0a8-f951ba0af442", "KhachHang", null, false, false, null, null, null, null, null, false, "35c75df6-5e0d-4632-90f4-d2a6eefad192", false, null, null, null, null, "Nguyen Chung", true, "KH003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09999999", "Dung" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CMT", "DiaChiChiTiet", "NhanVien_DiaChiId", "Ho", "LoaiNV", "Luong", "MaNV", "NgaySinh", "NgayTao", "SDT", "Ten" },
                values: new object[,]
                {
                    { "e707250e-16f8-4744-a69a-e67bbd24b37e", 0, "de4a3b71-5e67-4ec2-ac66-5b10ddc9aa1d", "NhanVien", "lannp@gmail.com", false, false, null, null, null, null, null, false, "c6464a37-13c2-4106-88e5-0676fe15636a", false, null, "213123123", "khu tai dinh cu", null, "Ngo Phuong", "phucvu", 9000000m, "NV005", new DateTime(1998, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0989456122", "Lan" },
                    { "62572cad-20e3-49bf-972e-9d26ba4171c2", 0, "5fe07214-7274-426c-a5fd-fb4397ae941a", "NhanVien", "thang@gmail.com", false, false, null, null, null, null, null, false, "9764d41e-d0c5-488c-bb92-fbb31a2907dd", false, null, "465487982", "khu tai dinh cu", null, "Nguyen Minh", "phucvu", 9000000m, "NV004", new DateTime(1998, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "031231232", "Thang" },
                    { "0b8ccd03-8076-4e32-9754-93497ca6d9f5", 0, "d13deec5-9d42-4906-92fb-4c1e273b8a22", "NhanVien", "duc@gmail.com", false, false, null, null, null, null, null, false, "efe65f34-a0ff-4e7b-9df1-da0d86fa0ece", false, null, "115487982", "khu tai dinh cu", null, "Nguyen Minh", "phucvu", 9000000m, "NV003", new DateTime(1998, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "031231232", "Duc" },
                    { "41f50fb1-d73c-461a-b788-ee3dbac4b5ef", 0, "9bc9b24c-99b4-436d-8468-f5f1e569e6d2", "NhanVien", "hung@gmail.com", false, false, null, null, null, null, null, false, "48ec08e5-44b9-482a-8b9f-f7ab9623a2a1", false, null, "123456789", "khu tai dinh cu", null, "Nguyen Van", "phucvu", 9000000m, "NV002", new DateTime(1998, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "099457645", "Hung" },
                    { "88cfe559-4a68-45c2-82b5-4ec8071540b1", 0, "a8689549-cb9a-46a3-8425-5a629b4a0d3c", "NhanVien", "huynguyen98.clc@gmail.com", false, false, null, null, null, null, null, false, "a79879df-8ae4-4013-99ea-ac3859b416f0", false, null, "142829244", "10N01 - khu tai dinh cu", null, "Nguyen Van", "phucvu", 10000000m, "NV001", new DateTime(1998, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0977470992", "Huy" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CMT", "DiaChiChiTiet", "DiaChiId", "Ho", "IsVIP", "MaKH", "NgaySinh", "SDT", "Ten" },
                values: new object[,]
                {
                    { "b024c420-806c-4630-a1ac-76db0f2d382c", 0, "51e7f336-f899-49a3-a297-68a766c9db2f", "KhachHang", null, false, false, null, null, null, null, null, false, "621b8860-5281-4ac0-9dc6-00d781d74e3e", false, null, null, null, null, "Ngo Ba", false, "KH005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0977470999", "Nam" },
                    { "abc90950-b7f8-4750-aa77-4789373928bb", 0, "20ec8e3a-e2f4-4dfa-a6f5-10bad9560d59", "KhachHang", null, false, false, null, null, null, null, null, false, "8b3e104c-31ae-411e-a6e5-5c52078870ba", false, null, null, null, null, "Ngo Ba", false, "KH004", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "065332255", "Duc" },
                    { "7e2a44c9-4990-40c3-86ed-47880c11ca3e", 0, "b130d152-1c24-435d-8f6d-e115ed38862f", "KhachHang", null, false, false, null, null, null, null, null, false, "1883a210-271b-4258-9e4b-dae1d397c44e", false, null, null, null, null, "Kieu Dang", false, "KH002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0554513222", "Thang" },
                    { "270f9859-7e96-4cbe-880b-9fa9c3df87ea", 0, "9be66c76-5d4f-4a46-bb68-1c17d0b2052b", "KhachHang", null, false, false, null, null, null, null, null, false, "812cc1d4-0beb-4f49-8aaf-94d3e7c6ee02", false, null, null, null, null, "Ngo Ba", true, "KH001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0665324444", "Hung" }
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
                    { 1, "small", 150000m, false, "P 101", "empty" },
                    { 2, "small", 300000m, true, "P 102", "empty" },
                    { 3, "small", 150000m, false, "P 103", "empty" },
                    { 4, "medium", 300000m, false, "P 201", "empty" },
                    { 5, "medium", 600000m, true, "P 202", "empty" },
                    { 6, "medium", 300000m, false, "P 203", "empty" },
                    { 7, "big", 600000m, false, "P 301", "empty" },
                    { 8, "big", 1200000m, true, "P 302", "empty" },
                    { 9, "big", 600000m, false, "P 303", "empty" }
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
                keyValue: "1c1b0576-1637-440a-9fa2-7078f63fd7d3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "270f9859-7e96-4cbe-880b-9fa9c3df87ea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e2a44c9-4990-40c3-86ed-47880c11ca3e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abc90950-b7f8-4750-aa77-4789373928bb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b024c420-806c-4630-a1ac-76db0f2d382c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0b8ccd03-8076-4e32-9754-93497ca6d9f5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41f50fb1-d73c-461a-b788-ee3dbac4b5ef");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62572cad-20e3-49bf-972e-9d26ba4171c2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88cfe559-4a68-45c2-82b5-4ec8071540b1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e707250e-16f8-4744-a69a-e67bbd24b37e");

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
