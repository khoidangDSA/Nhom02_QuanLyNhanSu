using Nhom2_QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nhom2_QuanLyNhanSu.Views.Interfaces
{
    public interface IDepartmentView
    {
      
            string DepartmentCode { get; set; }
            string DepartmentName { get; set; }
            string Description { get; set; }
            string SearchKeyword { get; }
            int SelectedId { get; }

            event EventHandler? LoadData;
            event EventHandler? SearchRequested;
            event EventHandler? AddRequested;
            event EventHandler? UpdateRequested;
            event EventHandler? DeleteRequested;
            event EventHandler? ClearRequested;
            event EventHandler? SelectionChanged;

            void ShowDepartments(List<Department> departments);
            void ClearInput();
            void ShowMessage(string message);
            void ShowError(string message);
            bool Confirm(string message);
        
    }
}
