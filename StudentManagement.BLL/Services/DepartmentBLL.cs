using System;
using System.Collections.Generic;
using StudentManagement.DTO;
using StudentManagement.DAL.Repositories;
using Microsoft.Extensions.Logging;
using StudentManagement.DAL.Logging;

namespace StudentManagement.BLL.Services
{
    public class DepartmentBLL
    {
        private static readonly ILogger logger = AppLogger.GetLogger<DepartmentBLL>();
        private readonly DepartmentDAL departmentDAL = new DepartmentDAL();

        public List<DepartmentDTO> GetAll()
        {
            return departmentDAL.GetAll();
        }

        public bool Insert(DepartmentDTO item)
        {
            string error = DepartmentValidator.Validate(item);

            if (error != null)
            {
                logger.LogWarning(
                    "Thêm khoa {DepartmentName} thất bại: {Error}",
                    item?.DepartmentName, error);
                throw new Exception(error);
            }

            CheckDuplicateDepartment(item);

            bool result = departmentDAL.Insert(item);

            if (result)
                logger.LogInformation(
                    "Thêm khoa {DepartmentName} thành công",
                    item.DepartmentName);
            else
                logger.LogWarning(
                    "Thêm khoa {DepartmentName} thất bại: không có dòng nào được thêm",
                    item.DepartmentName);

            return result;
        }

        public bool Update(DepartmentDTO item)
        {
            if (item == null || item.DepartmentID <= 0)
            {
                logger.LogWarning("Cập nhật khoa thất bại: mã khoa không hợp lệ");
                throw new Exception("Mã khoa không hợp lệ.");
            }

            string error = DepartmentValidator.Validate(item);

            if (error != null)
            {
                logger.LogWarning(
                    "Cập nhật khoa {DepartmentName} (ID={DepartmentID}) thất bại: {Error}",
                    item.DepartmentName, item.DepartmentID, error);
                throw new Exception(error);
            }

            CheckDuplicateDepartment(item);

            bool result = departmentDAL.Update(item);

            if (result)
                logger.LogInformation(
                    "Cập nhật khoa {DepartmentName} (ID={DepartmentID}) thành công",
                    item.DepartmentName, item.DepartmentID);
            else
                logger.LogWarning(
                    "Cập nhật khoa {DepartmentName} (ID={DepartmentID}) thất bại: không có dòng nào được cập nhật",
                    item.DepartmentName, item.DepartmentID);

            return result;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                logger.LogWarning(
                    "Xóa khoa thất bại: mã khoa không hợp lệ ({Id})", id);
                throw new Exception("Mã khoa không hợp lệ.");
            }

            bool result = departmentDAL.Delete(id);

            if (result)
                logger.LogInformation("Xóa khoa ID={Id} thành công", id);
            else
                logger.LogWarning(
                    "Xóa khoa ID={Id} thất bại: không tìm thấy bản ghi", id);

            return result;
        }
        private void CheckDuplicateDepartment(DepartmentDTO item)
        {
            var departments = departmentDAL.GetAll();

            bool exists = departments.Exists(d =>
                d.DepartmentName.Equals(
                    item.DepartmentName.Trim(),
                    StringComparison.OrdinalIgnoreCase)
                && d.DepartmentID != item.DepartmentID);

            if (exists)
                throw new Exception("Tên khoa đã tồn tại.");
        }
    }
}