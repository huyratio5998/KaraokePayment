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
                    HanSuDung = table.Column<DateTime>(nullable: false),
                    HangHoaImage = table.Column<string>(nullable: true)
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
                    NhanVienCaLVId = table.Column<int>(nullable: false),
                    NhanVienAdminEmail = table.Column<string>(nullable: true)
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
                values: new object[] { "10304421-6181-4bd4-bdd1-18504d5b74f0", 0, "937a9758-d10b-495a-9b9a-7f8573b8f65b", "KhachHang", null, false, false, null, null, null, null, null, false, "110af261-6251-4fd5-a212-1b7ef20f5dfc", false, null, null, null, null, "Kiều Đăng", false, "KH002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0554513222", "Thắng" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CMT", "DiaChiChiTiet", "NhanVien_DiaChiId", "Ho", "LoaiNV", "Luong", "MaNV", "NgaySinh", "NgayTao", "SDT", "Ten" },
                values: new object[,]
                {
                    { "f520d6f1-64db-4a37-87ce-e52dbf5cecb3", 0, "9376532d-7f8e-450b-872d-fb622f48e1fb", "NhanVien", "linh@gmail.com", false, false, null, null, null, null, null, false, "3c562845-2ac6-4642-83b6-6008db4ada1b", false, null, "213123123", "khu tai dinh cu", null, "Ngô Phương", "phucvu", 9000000m, "NV005", new DateTime(1998, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0989456122", "Linh" },
                    { "623850f6-3239-49cb-8b88-749de8557ba9", 0, "14ad8841-ec86-41a2-a15e-87b0fbd7e72c", "NhanVien", "thang@gmail.com", false, false, null, null, null, null, null, false, "d2e0cecd-3c5d-439b-ba70-da95bf063814", false, null, "465487982", "khu tai dinh cu", null, "Nguyễn Minh", "phucvu", 9000000m, "NV004", new DateTime(1998, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "031231232", "Thắng" },
                    { "9e357e12-9c7f-4c7b-bad2-c8a0847b2282", 0, "080ede73-9083-4bab-8c27-ad511937691d", "NhanVien", "duc@gmail.com", false, false, null, null, null, null, null, false, "2fccb9ab-f6a9-4d91-bfb3-6d7c15b23f63", false, null, "115487982", "khu tai dinh cu", null, "Nguyễn Minh", "phucvu", 9000000m, "NV003", new DateTime(1998, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "031231232", "Đức" },
                    { "7d1ab060-2e8d-4feb-98e5-a44b91dac793", 0, "eb63d6ef-aa81-4324-9b30-d36f790a5e09", "NhanVien", "bay@gmail.com", false, false, null, null, null, null, null, false, "d1314139-6270-4788-8d40-e3d4c9e6c47c", false, null, "123456789", "khu tai dinh cu", null, "Nguyễn Văn", "phucvu", 9000000m, "NV002", new DateTime(1998, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "099457645", "Bảy" },
                    { "bffe74da-7935-4fd8-a42d-43d49aa32cfe", 0, "51c4d972-9fb4-493b-b59d-b4df495ce692", "NhanVien", "huynguyen98.clc@gmail.com", false, false, null, null, null, null, null, false, "9967ce3c-72d6-4ee0-89dd-14ab08585e28", false, null, "142829244", "10N01 - khu tai dinh cu", null, "Nguyễn Văn", "phucvu", 10000000m, "NV001", new DateTime(1998, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0977470992", "Huy" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CMT", "DiaChiChiTiet", "DiaChiId", "Ho", "IsVIP", "MaKH", "NgaySinh", "SDT", "Ten" },
                values: new object[,]
                {
                    { "7d7ce6df-52d9-416a-8212-baa5480640af", 0, "2ef6706d-b76f-4696-9ae9-9571a9aee665", "KhachHang", null, false, false, null, null, null, null, null, false, "4752d1a9-e184-42e0-b3ef-c47a83e02c7e", false, null, null, null, null, "Ngô Phương", false, "KH005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0977470999", "Nam" },
                    { "96907bc0-91b4-406e-9f31-e8fdf2794f6d", 0, "e3ec5d28-7561-4c52-8c16-d70cb31ab785", "KhachHang", null, false, false, null, null, null, null, null, false, "ed461d48-ef0d-4aff-bb39-4cc5445bffa0", false, null, null, null, null, "Ngô Bá", false, "KH004", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "065332255", "Khá" },
                    { "313d8672-30a5-4762-8fa6-bf7b14038997", 0, "18c786ab-a104-49de-b4a2-d85ae31627c6", "KhachHang", null, false, false, null, null, null, null, null, false, "ffe91439-5aba-4964-b336-61022861264c", false, null, null, null, null, "Nguyễn Chung", true, "KH003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09999999", "Dũng" },
                    { "e2b8dd51-876e-46ee-8a3e-cf0447af4bc9", 0, "b83b2590-2f1e-4494-b074-d7207341b745", "KhachHang", null, false, false, null, null, null, null, null, false, "35c0818d-206d-4474-83ad-11d70de4693a", false, null, null, null, null, "Ngô Bá", true, "KH001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0665324444", "Hùng" }
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
                    { 1, "Nam Sach", "Hai Duong" },
                    { 2, "Tan Trieu", "Ha Noi" },
                    { 5, "Cam Giang", "Hai Duong" },
                    { 4, "Nam Tan", "Hai Duong" },
                    { 3, "Ha Dong", "Ha Noi" }
                });

            migrationBuilder.InsertData(
                table: "HangHoa",
                columns: new[] { "Id", "Gia", "HanSuDung", "HangHoaImage", "MaHH", "NgayNhap", "SoLuong", "Ten" },
                values: new object[,]
                {
                    { 2, 20000m, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "fruit.jpg", "HH002", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "Đĩa Hoa Quả" },
                    { 3, 20000m, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "bimbimostar.jpg", "HH003", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "Bim Bim Ostar" },
                    { 1, 10000m, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "bimbimoshicay.jpg", "HH001", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "Bim Bim Oshi Cay" },
                    { 6, 40000m, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "biahanoi.PNG", "HH006", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000, "Bia Hà Nội" },
                    { 5, 45000m, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "biaheineken.jpg", "HH005", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000, "Bia Heineken" },
                    { 4, 40000m, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "biasaigon.jpg", "HH004", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000, "Bia Sài Gòn" }
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
                keyValue: "10304421-6181-4bd4-bdd1-18504d5b74f0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "313d8672-30a5-4762-8fa6-bf7b14038997");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d7ce6df-52d9-416a-8212-baa5480640af");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "96907bc0-91b4-406e-9f31-e8fdf2794f6d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8dd51-876e-46ee-8a3e-cf0447af4bc9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "623850f6-3239-49cb-8b88-749de8557ba9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d1ab060-2e8d-4feb-98e5-a44b91dac793");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e357e12-9c7f-4c7b-bad2-c8a0847b2282");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bffe74da-7935-4fd8-a42d-43d49aa32cfe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f520d6f1-64db-4a37-87ce-e52dbf5cecb3");

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
