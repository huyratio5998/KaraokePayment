namespace KaraokePayment.Enums
{
    public enum BookPhongOrderPhongStatus
    {
        Using,
        Paying,
        Paid
    }

    public enum BookPhongOrderStatus
    {
        NotPaid,
        Paid
    }

    public enum PhongStatus
    {
        Empty,
        Paying,
        Occupied,
    }

    public static class KieuThanhToan
    {
        public static string TienMat="Tiền Mặt";
        public static string ViDienTu = "Ví Điện Tử";
    }
}
