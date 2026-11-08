# 🏢 Đề tài 15: Hệ thống Quản lý Nhân sự (HRM)

**Môn học:** COMP1019 - Lập trình trên Windows  
**Đơn vị:** Khoa Công nghệ Thông tin - Trường Đại học Sư phạm TP.HCM (HCMUE)  
**Quy mô nhóm:** 3 thành viên  
**Kiến trúc phần mềm:** C# Windows Forms áp dụng nghiêm ngặt mẫu thiết kế **MVP (Model - View - Presenter)**.

---

## 📖 Tổng quan dự án

Hệ thống Quản lý Nhân sự là ứng dụng Desktop được xây dựng nhằm hỗ trợ các nhân viên nhân sự và quản trị viên hệ thống trong việc số hóa và quản lý thông tin nhân viên. 

Hệ thống cho phép quản lý chi tiết từ thông tin cá nhân, ảnh đại diện, quá trình công tác, phòng ban, chức vụ cho đến hợp đồng lao động. Giao diện được thiết kế trực quan, phân tách thông tin rõ ràng và tích hợp các tính năng báo cáo, xuất file, cảnh báo thông minh.

### 🛠 Công nghệ & Công cụ
* **Ngôn ngữ:** C#
* **Framework:** .NET Windows Forms
* **Kiến trúc:** MVP (Model - View - Presenter)
* **Cơ sở dữ liệu:** Microsoft SQL Server
* **Quản lý phiên bản:** Git & GitHub
* **Báo cáo & In ấn:** Microsoft ReportViewer / Crystal Reports, Export (Excel, PDF)
* **Tài liệu báo cáo:** LaTeX

---

## 🌟 Chức năng chính

### 1. Quản trị hệ thống
* Đăng nhập và Phân quyền người dùng (Quản trị viên & Nhân viên).
* Giao diện chính tích hợp MDI Form / Sidebar Navigation UI.

### 2. Quản lý Hồ sơ nhân sự
* Quản lý thông tin cá nhân và thông tin công tác (tách biệt bằng TabControl/Form).
* Xử lý, lưu trữ và hiển thị ảnh chân dung nhân viên.
* **Tìm kiếm đa tiêu chí:** Lọc linh hoạt theo Mã NV, Họ tên, Phòng ban, Chức vụ, Tình trạng.

### 3. Quản lý Tổ chức & Quá trình công tác
* **Phòng ban & Chức vụ:** Thực hiện các thao tác CRUD, thiết lập quyền hạn, vai trò.
* **Sơ đồ tổ chức:** Trực quan hóa cấu trúc phòng ban và nhân viên bằng `TreeView` / Custom Control.
* **Quá trình công tác:** Theo dõi lịch sử luân chuyển, thăng chức, khen thưởng, kỷ luật.

### 4. Quản lý Hợp đồng & Báo cáo
* **Hợp đồng lao động:** Quản lý loại hợp đồng, thời hạn, mức lương, phụ cấp,...
* **Cảnh báo thông minh:** Tự động thông báo các hợp đồng sắp hết hạn (15-30 ngày).
* **In ấn & Xuất file:** In sơ yếu lý lịch, danh sách nhân sự; Xuất báo cáo thống kê ra định dạng **Excel** và **PDF**.

---

## 👥 Phân công công việc

| Vai trò | Thành viên | Nhiệm vụ chính |
| :--- | :--- | :--- |
| **Thành viên 1**<br>*(Nhóm trưởng)* | `Kiều Gia Bảo`<br>`51.01.104.128` | - Thiết lập kiến trúc MVP, thiết kế CSDL (SQL Server).<br>- Module Đăng nhập & Phân quyền.<br>- Quản lý Git, merge code, giải quyết xung đột.<br>- Quản lý hồ sơ & ảnh nhân viên.<br>- Tìm kiếm nhân viên đa tiêu chí. |
| **Thành viên 2** | `Đặng Nguyên Khôi`<br>`51.01.104.138` | - Thiết kế & code MVP module Phòng ban, Chức vụ, Quá trình công tác.<br>- Vẽ sơ đồ tổ chức nhân sự (TreeView).<br>- Lọc và xuất danh sách nhân sự theo phòng ban. |
| **Thành viên 3** | `Nguyễn Đức Gia Huy`<br>`51.01.104.136` | - Thiết kế & code MVP module Hợp đồng lao động, Báo cáo.<br>- Tích hợp công cụ in ấn (ReportViewer).<br>- Làm tính năng Cảnh báo hợp đồng sắp hết hạn.<br>- Xuất báo cáo đa định dạng (Excel, PDF). |

---

## 🚀 Hướng dẫn Cài đặt & Chạy ứng dụng

1. **Clone repository này về máy:**
   
```bash
   git clone [https://github.com/your-username/your-repo-name.git](https://github.com/your-username/your-repo-name.git)
