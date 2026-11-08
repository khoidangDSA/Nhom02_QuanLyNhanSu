using System;
using System.Data;

namespace Nhom2_QuanLyNhanSu.Services.Interfaces
{
    public interface IWorkHistoryService
    {
        DataTable GetAll();
        DataTable GetByValue(string keyword);
        bool Add(int employeeId, int eventType, DateTime eventDate, int? fromDeptId, int? toDeptId, int? fromPosId, int? toPosId, string note);
        bool Update(int id, int employeeId, int eventType, DateTime eventDate, int? fromDeptId, int? toDeptId, int? fromPosId, int? toPosId, string note);
        bool Delete(int id);
        DataTable GetEmployeeLookup();
        DataTable GetDepartmentLookup();
        DataTable GetPositionLookup();
    }
}