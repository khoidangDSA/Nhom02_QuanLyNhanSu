using System;
using System.Windows.Forms;

namespace Nhom2_QuanLyNhanSu.Views.Interfaces
{
    public interface IWorkHistoryView
    {
        string SearchValue { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;

        void SetWorkHistoryListBindingSource(BindingSource source);
    }
}