namespace PRN221_DinhChinh_Ass3.WpfApp
{
    public static class Session
    {
        public static string? UserName { get; set; }
        public static string? Role { get; set; }
        public static int? UserId { get; set; }

        // Add other properties as needed
        public static void Clear()
        {
            UserName = null;
            Role = null;
            UserId = null;
        }
    }
}
