using Nhom2_QuanLyNhanSu.Models;
using Nhom2_QuanLyNhanSu.Models.Enums;
using Nhom2_QuanLyNhanSu.Models.Filters;

namespace Nhom2_QuanLyNhanSu.Common.Session;

public static class CurrentUser
{
    public static Account? Account { get; private set; }
    public static bool IsAdmin => Account?.Role == AccountRole.Admin;

    public static void Set(Account account) => Account = account;
    public static void Clear() => Account = null;
}