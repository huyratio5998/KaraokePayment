using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KaraokePayment.Data.Migrations
{
    public partial class addentity : Migration
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
                    NhanVienAdminCaLV = table.Column<int>(nullable: false),
                    NhanVienCaLVId = table.Column<int>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookPhongOrderPhong",
                columns: table => new
                {
                    NhanVienBook1Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_BookPhongOrderPhong", x => x.NhanVienBook1Id);
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
                        principalColumn: "NhanVienBook1Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThemHangHoa_HangHoa_HangHoaId",
                        column: x => x.HangHoaId,
                        principalTable: "HangHoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
