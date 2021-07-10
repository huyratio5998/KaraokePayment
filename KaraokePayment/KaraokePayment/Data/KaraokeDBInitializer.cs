using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KaraokePayment.Data
{
    public static class KaraokeDBInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region initialize phong

            modelBuilder.Entity<Phong>().HasData(
                new Phong() { Id = 1, TenPhong = "P 101", CoPhong = "small", Gia = 150000, IsVIP = false, TrangThai = "empty" },
                new Phong() { Id = 2, TenPhong = "P 102", CoPhong = "small", Gia = 300000, IsVIP = true, TrangThai = "empty" },
                new Phong() { Id = 3, TenPhong = "P 103", CoPhong = "small", Gia = 150000, IsVIP = false, TrangThai = "empty" },
                new Phong() { Id = 4, TenPhong = "P 201", CoPhong = "medium", Gia = 300000, IsVIP = false, TrangThai = "empty" },
                new Phong() { Id = 5, TenPhong = "P 202", CoPhong = "medium", Gia = 600000, IsVIP = true, TrangThai = "empty" },
                new Phong() { Id = 6, TenPhong = "P 203", CoPhong = "medium", Gia = 300000, IsVIP = false, TrangThai = "empty" },
                new Phong() { Id = 7, TenPhong = "P 301", CoPhong = "big", Gia = 600000, IsVIP = false, TrangThai = "empty" },
                new Phong() { Id = 8, TenPhong = "P 302", CoPhong = "big", Gia = 1200000, IsVIP = true, TrangThai = "empty" },
                new Phong() { Id = 9, TenPhong = "P 303", CoPhong = "big", Gia = 600000, IsVIP = false, TrangThai = "empty" }
            );

            #endregion


            #region initialize Dia Chi

            modelBuilder.Entity<DiaChi>().HasData(
                new DiaChi() { Id = 1, Huyen = "Nam Sach", Tinh = "Hai Duong" },
                new DiaChi() { Id = 2, Huyen = "Tan Trieu", Tinh = "Ha Noi" },
                new DiaChi() { Id = 3, Huyen = "Ha Dong", Tinh = "Ha Noi" },
                new DiaChi() { Id = 4, Huyen = "Nam Tan", Tinh = "Hai Duong" },
                new DiaChi() { Id = 5, Huyen = "Cam Giang", Tinh = "Hai Duong" }
            );

            #endregion

            #region initialize Nhan vien

            var nv1 = new NhanVien()
            {
                Id = Guid.NewGuid().ToString(),
                Ho = "Nguyen Van",
                Ten = "Huy",
                SDT = "0977470992",
                NgaySinh = new DateTime(1998, 09, 05),
                CMT = "142829244",
                Email = "huynguyen98.clc@gmail.com",
                DiaChiChiTiet = "10N01 - khu tai dinh cu",
                MaNV = "NV001",
                Luong = 10000000,
                NgayTao = new DateTime(2020, 06, 10),
                LoaiNV = "phucvu"
            };
            var nv2 = new NhanVien()
            {
                Id = Guid.NewGuid().ToString(),
                Ho = "Nguyen Van",
                Ten = "Hung",
                SDT = "099457645",
                NgaySinh = new DateTime(1998, 09, 05),
                CMT = "123456789",
                Email = "hung@gmail.com",
                DiaChiChiTiet = "khu tai dinh cu",
                MaNV = "NV002",
                Luong = 9000000,
                NgayTao = new DateTime(2020, 06, 10),
                LoaiNV = "phucvu"
            };
            var nv3 = new NhanVien()
            {
                Id = Guid.NewGuid().ToString(),
                Ho = "Nguyen Minh",
                Ten = "Duc",
                SDT = "031231232",
                NgaySinh = new DateTime(1998, 09, 05),
                CMT = "115487982",
                Email = "duc@gmail.com",
                DiaChiChiTiet = "khu tai dinh cu",
                MaNV = "NV003",
                Luong = 9000000,
                NgayTao = new DateTime(2020, 06, 10),
                LoaiNV = "phucvu"
            };
            var nv4 = new NhanVien()
            {
                Id = Guid.NewGuid().ToString(),
                Ho = "Nguyen Minh",
                Ten = "Thang",
                SDT = "031231232",
                NgaySinh = new DateTime(1998, 09, 05),
                CMT = "465487982",
                Email = "thang@gmail.com",
                DiaChiChiTiet = "khu tai dinh cu",
                MaNV = "NV004",
                Luong = 9000000,
                NgayTao = new DateTime(2020, 06, 10),
                LoaiNV = "phucvu"
            };
            var nv5 = new NhanVien()
            {
                Id = Guid.NewGuid().ToString(),
                Ho = "Ngo Phuong",
                Ten = "Lan",
                SDT = "0989456122",
                NgaySinh = new DateTime(1998, 02, 04),
                CMT = "213123123",
                Email = "lannp@gmail.com",
                DiaChiChiTiet = "khu tai dinh cu",
                MaNV = "NV005",
                Luong = 9000000,
                NgayTao = new DateTime(2020, 06, 10),
                LoaiNV = "phucvu"
            };
            modelBuilder.Entity<NhanVien>().HasData(nv1, nv2, nv3, nv4, nv5);

            #endregion

            #region HangHoa

            modelBuilder.Entity<HangHoa>().HasData(
                new HangHoa()
                {
                    Id = 1, MaHH = "HH001", Ten = "Bim Bim Oshi Cay", Gia = 10000,
                    HanSuDung = new DateTime(2022, 09, 09),
                    NgayNhap = new DateTime(2021, 05, 05), SoLuong = 50
                },
                new HangHoa()
                {
                    Id = 2,
                    MaHH = "HH002",
                    Ten = "Dia Hoa Qua",
                    Gia = 20000,
                    HanSuDung = new DateTime(2022, 09, 09),
                    NgayNhap = new DateTime(2021, 05, 05),
                    SoLuong = 50
                },
                new HangHoa()
                {
                    Id = 3,
                    MaHH = "HH003",
                    Ten = "Bim Bim Ostar",
                    Gia = 20000,
                    HanSuDung = new DateTime(2022, 09, 09),
                    NgayNhap = new DateTime(2021, 05, 05),
                    SoLuong = 50
                },
                new HangHoa()
                {
                    Id = 4,
                    MaHH = "HH004",
                    Ten = "Bia Sai Gon",
                    Gia = 40000,
                    HanSuDung = new DateTime(2022, 09, 09),
                    NgayNhap = new DateTime(2021, 05, 05),
                    SoLuong = 1000
                },
                new HangHoa()
                {
                    Id = 5,
                    MaHH = "HH005",
                    Ten = "Bia Heineken",
                    Gia = 45000,
                    HanSuDung = new DateTime(2022, 09, 09),
                    NgayNhap = new DateTime(2021, 05, 05),
                    SoLuong = 1000
                }
            );

            #endregion

            #region KhachHang

            modelBuilder.Entity<KhachHang>().HasData(
                new KhachHang()
                {
                    Id = Guid.NewGuid().ToString(), Ho = "Ngo Ba", Ten = "Hung", SDT = "0665324444", MaKH = "KH001",
                    IsVIP = true
                },
                new KhachHang()
                {
                    Id = Guid.NewGuid().ToString(), Ho = "Kieu Dang", Ten = "Thang", SDT = "0554513222", MaKH = "KH002",
                    IsVIP = false
                },
                new KhachHang()
                {
                    Id = Guid.NewGuid().ToString(), Ho = "Nguyen Chung", Ten = "Dung", SDT = "09999999", MaKH = "KH003",
                    IsVIP = true
                },
                new KhachHang()
                {
                    Id = Guid.NewGuid().ToString(), Ho = "Ngo Ba", Ten = "Duc", SDT = "065332255", MaKH = "KH004",
                    IsVIP = false
                },
                new KhachHang()
                {
                    Id = Guid.NewGuid().ToString(), Ho = "Ngo Ba", Ten = "Nam", SDT = "0977470999", MaKH = "KH005",
                    IsVIP = false
                }
            );

            #endregion
            #region CalV

            modelBuilder.Entity<CaLV>().HasData(
                new CaLV()
                {
                    Id = 1,
                    TenCa = "Ca 1",
                    Tu = 7,
                    Den = 11,
                    HeSoLuong = 1,
                },
                new CaLV()
                {
                    Id = 2,
                    TenCa = "Ca 2",
                    Tu = 11,
                    Den = 18,
                    HeSoLuong = 1,
                },
                new CaLV()
                {
                    Id = 3,
                    TenCa = "Ca 3",
                    Tu = 18,
                    Den = 22,
                    HeSoLuong = 1.5,
                },
                new CaLV()
                {
                    Id = 4,
                    TenCa = "Ca 4",
                    Tu = 22,
                    Den = 2,
                    HeSoLuong = 2,
                }
            );

            #endregion
        }
    }
}
