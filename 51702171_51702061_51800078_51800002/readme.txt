Các bước để chạy được project như sau:
- Bước 1: Mở phần mềm SQL Server và mở file "QLCOSMESTIC.sql" trong thư mục source.
- Bước 2: Excute các câu lệnh trong file "QLCOSMESTIC.sql" để tạo bảng và insert dữ liệu.
- Bước 3: Ở bảng điều khiển Properties bên phải màn hình chương trình SQL Server, copy giá trị ở field "Connection name".
- Bước 4: Tiếp theo, mở file "QuanLyCosmestic.sln" trong thư mục "source\QuanLyCosmestic".
- Bước 5: Tìm lớp DatabaseMySql.cs trong thư mục database của project QuanLyCosmestic.
- Bước 6: Tìm đến dòng code thứ 22, ở phần khởi tạo SqlConnection, xóa đi giá trị cũ ở thuộc tính "Data Source" và dán vào giá trị của field "Connection name" đã được copy ở Bước 3.
- Bước 7: Bấm nút Start trên thanh công cụ để chạy project.

============================================================

Các role và tài khoản sử dụng phần mềm QuanLyCosmestic:
1. Quản lý:
- Username: Admin ; Password: 123456
2. Nhân viên bán hàng:
- Username: NvHa ; Password: 123456
- Username: NvThuy ; Password: 123456
- Username: NvLinh ; Password: 123456
3. Nhân viên kho:
- Username: NvKhai ; Password: 123456