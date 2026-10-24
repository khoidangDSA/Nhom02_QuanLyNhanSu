using Nhom2_QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;

namespace Nhom2_QuanLyNhanSu.Views.Interfaces
{
    public interface IPositionView
    {
        string PositionCode { get; set; }
        string PositionName { get; set; }
        decimal Allowance { get; set; }
        string Description { get; set; }
        string SearchKeyword { get; }
        int SelectedId { get; }

        event EventHandler LoadData;
        event EventHandler SearchRequested;
        event EventHandler AddRequested;
        event EventHandler UpdateRequested;
        event EventHandler DeleteRequested;
        event EventHandler ClearRequested;
        event EventHandler SelectionChanged;

        void ShowPositions(List<Position> positions);
        void ClearInput();
        void ShowMessage(string message);
        void ShowError(string message);
        bool Confirm(string message);
    }
}