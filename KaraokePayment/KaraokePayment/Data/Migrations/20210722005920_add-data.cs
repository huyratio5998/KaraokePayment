using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KaraokePayment.Data.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CMT", "DiaChiChiTiet", "DiaChiId", "Ho", "IsVIP", "MaKH", "NgaySinh", "SDT", "Ten" },
                values: new object[] { "e0c931ef-cd0b-4717-bda4-bf182af505ff", 0, "2957f0f2-e018-4d55-836f-ed0e197f355c", "KhachHang", null, false, false, null, null, null, null, null, false, "025dc734-23da-447f-bf09-84047d92a1f0", false, null, null, null, null, "Nguyen Chung", true, "KH003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09999999", "Dung" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CMT", "DiaChiChiTiet", "NhanVien_DiaChiId", "Ho", "LoaiNV", "Luong", "MaNV", "NgaySinh", "NgayTao", "SDT", "Ten" },
                values: new object[,]
                {
                    { "587efee0-853a-4b4f-b9be-095e0304d6e1", 0, "816caed1-96de-4bcf-b684-a94ea0907f0a", "NhanVien", "lannp@gmail.com", false, false, null, null, null, null, null, false, "ba0ac5f6-30f3-4c26-8b64-14736c53596b", false, null, "213123123", "khu tai dinh cu", null, "Ngo Phuong", "phucvu", 9000000m, "NV005", new DateTime(1998, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0989456122", "Lan" },
                    { "9e769695-9331-4da9-8dd0-19ad18fbfb62", 0, "72eeaeb6-3eff-4a1f-8a29-781735dc8c53", "NhanVien", "thang@gmail.com", false, false, null, null, null, null, null, false, "1f51f963-32be-42b8-a4d4-588536b3e10d", false, null, "465487982", "khu tai dinh cu", null, "Nguyen Minh", "phucvu", 9000000m, "NV004", new DateTime(1998, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "031231232", "Thang" },
                    { "5f804eb9-34a7-4d4a-825e-0f5c4afad89d", 0, "c8db10bb-bbab-472b-b5d8-5c590c70a5d9", "NhanVien", "duc@gmail.com", false, false, null, null, null, null, null, false, "056f42f3-7000-419f-a260-e3718b8958b7", false, null, "115487982", "khu tai dinh cu", null, "Nguyen Minh", "phucvu", 9000000m, "NV003", new DateTime(1998, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "031231232", "Duc" },
                    { "a56d36ff-4d3c-4f45-80cc-190ebc0562dd", 0, "9ec415af-9cb8-449e-8831-022690bc12aa", "NhanVien", "hung@gmail.com", false, false, null, null, null, null, null, false, "1da8f6e0-db7a-4919-9ef6-e5168f9fceec", false, null, "123456789", "khu tai dinh cu", null, "Nguyen Van", "phucvu", 9000000m, "NV002", new DateTime(1998, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "099457645", "Hung" },
                    { "4d6eaa33-90b5-42b4-8ece-a14d85942093", 0, "42b3e0f1-5d0a-451d-a9dc-24491a9f49a6", "NhanVien", "huynguyen98.clc@gmail.com", false, false, null, null, null, null, null, false, "69634fa1-17e1-4bae-b45b-839f8adb3e94", false, null, "142829244", "10N01 - khu tai dinh cu", null, "Nguyen Van", "phucvu", 10000000m, "NV001", new DateTime(1998, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0977470992", "Huy" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CMT", "DiaChiChiTiet", "DiaChiId", "Ho", "IsVIP", "MaKH", "NgaySinh", "SDT", "Ten" },
                values: new object[,]
                {
                    { "dee766dd-f986-4e3c-bf21-5339a002cd15", 0, "02dc52d3-23b0-4eaf-8c38-34a975f32e55", "KhachHang", null, false, false, null, null, null, null, null, false, "1544d26d-d301-4ff0-bbb0-525913caacfa", false, null, null, null, null, "Ngo Ba", false, "KH005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0977470999", "Nam" },
                    { "9eb94a67-ad50-45c0-8591-20a700215e2f", 0, "83041f9b-f038-4cff-815f-55b28801bc04", "KhachHang", null, false, false, null, null, null, null, null, false, "daae5de7-0eae-40fd-b91e-fcc213bb1851", false, null, null, null, null, "Ngo Ba", false, "KH004", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "065332255", "Duc" },
                    { "314791f2-fe23-4057-ae41-eaa6378e9fcd", 0, "36ebf476-edac-4103-8592-1ae0be47dc45", "KhachHang", null, false, false, null, null, null, null, null, false, "e6624364-3f99-4994-a76f-1f8ddbd83cac", false, null, null, null, null, "Kieu Dang", false, "KH002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0554513222", "Thang" },
                    { "3f3eadcb-9451-4611-a547-2149eef0b16c", 0, "01126a37-9a86-49ad-82f1-66a5f49f67b0", "KhachHang", null, false, false, null, null, null, null, null, false, "dba5a001-397f-42cb-a445-14ef0bcf093c", false, null, null, null, null, "Ngo Ba", true, "KH001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0665324444", "Hung" }
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
                columns: new[] { "Id", "Gia", "HanSuDung", "HangHoaImage", "MaHH", "NgayNhap", "SoLuong", "Ten" },
                values: new object[,]
                {
                    { 2, 20000m, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HH002", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "Dia Hoa Qua" },
                    { 3, 20000m, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HH003", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "Bim Bim Ostar" },
                    { 1, 10000m, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HH001", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "Bim Bim Oshi Cay" },
                    { 5, 45000m, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HH005", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000, "Bia Heineken" },
                    { 4, 40000m, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HH004", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000, "Bia Sai Gon" }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "314791f2-fe23-4057-ae41-eaa6378e9fcd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f3eadcb-9451-4611-a547-2149eef0b16c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9eb94a67-ad50-45c0-8591-20a700215e2f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dee766dd-f986-4e3c-bf21-5339a002cd15");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0c931ef-cd0b-4717-bda4-bf182af505ff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d6eaa33-90b5-42b4-8ece-a14d85942093");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587efee0-853a-4b4f-b9be-095e0304d6e1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5f804eb9-34a7-4d4a-825e-0f5c4afad89d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e769695-9331-4da9-8dd0-19ad18fbfb62");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a56d36ff-4d3c-4f45-80cc-190ebc0562dd");

            migrationBuilder.DeleteData(
                table: "CaLV",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CaLV",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CaLV",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CaLV",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DiaChi",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiaChi",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DiaChi",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DiaChi",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DiaChi",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HangHoa",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HangHoa",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HangHoa",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HangHoa",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HangHoa",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Phong",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Phong",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Phong",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Phong",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Phong",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Phong",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Phong",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Phong",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Phong",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
