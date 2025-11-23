namespace LibraryTeamWinFormApp.Common
{
    public static class Constants
    {
        public static readonly string[] UserRoles = { "читач", "бібліотекар", "адміністратор" };
        public static readonly string[] UserRolesEnglish = { "reader", "librarian", "admin" };

        public const int MaxIsbnLength = 32;
        public const int DefaultUserId = 1;
    }
}