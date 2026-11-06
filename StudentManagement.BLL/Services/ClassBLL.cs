using System;
using System.Collections.Generic;
using StudentManagement.DTO;
using StudentManagement.DAL.Repositories;
using Microsoft.Extensions.Logging;
using StudentManagement.DAL.Logging;

namespace StudentManagement.BLL.Services
{
    public class ClassBLL
    {
        private static readonly ILogger logger = AppLogger.GetLogger<ClassBLL>();
        private readonly ClassDAL classDAL = new ClassDAL();
        private readonly DepartmentDAL departmentDAL = new DepartmentDAL();

        public List<ClassDTO> GetAll()
        {
            return classDAL.GetAll();
        }

        public bool Insert(ClassDTO item)
        {
            string error = ClassValidator.Validate(item);

            if (error != null)
            {
                logger.LogWarning(
                    "Thêm lớp {ClassName} thất bại: {Error}",
                    item?.ClassName, error);
                throw new Exception(error);
            }

            CheckDuplicateClass(item);

            bool result = classDAL.Insert(item);

            if (result)
                logger.LogInformation(
                    "Thêm lớp {ClassName} thành công",
                    item.ClassName);
            else
                logger.LogWarning(
                    "Thêm lớp {ClassName} thất bại: không có dòng nào được thêm",
                    item.ClassName);

            return result;
        }

        public bool Update(ClassDTO item)
        {
            if (item == null || item.ClassID <= 0)
            {
                logger.LogWarning("Cập nhật lớp thất bại: mã lớp không hợp lệ");
                throw new Exception("Thông tin lớp không hợp lệ.");
            }

            string error = ClassValidator.Validate(item);

            if (error != null)
            {
                logger.LogWarning(
                    "Cập nhật lớp {ClassName} (ID={ClassID}) thất bại: {Error}",
                    item.ClassName, item.ClassID, error);
                throw new Exception(error);
            }

            CheckDuplicateClass(item);

            bool result = classDAL.Update(item);

            if (result)
                logger.LogInformation(
                    "Cập nhật lớp {ClassName} (ID={ClassID}) thành công",
                    item.ClassName, item.ClassID);
            else
                logger.LogWarning(
                    "Cập nhật lớp {ClassName} (ID={ClassID}) thất bại: không có dòng nào được cập nhật",
                    item.ClassName, item.ClassID);

            return result;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                logger.LogWarning(
                    "Xóa lớp thất bại: mã lớp không hợp lệ ({Id})", id);
                throw new Exception("Mã lớp không hợp lệ.");
            }

            bool result = classDAL.Delete(id);

            if (result)
                logger.LogInformation("Xóa lớp ID={Id} thành công", id);
            else
                logger.LogWarning(
                    "Xóa lớp ID={Id} thất bại: không tìm thấy bản ghi", id);

            return result;
        }
        private void CheckDuplicateClass(ClassDTO item)
        {
            var classes = classDAL.GetAll();

            bool exists = classes.Exists(c =>
                c.ClassName.Equals(
                    item.ClassName.Trim(),
                    StringComparison.OrdinalIgnoreCase)
                && c.ClassID != item.ClassID);

            if (exists)
                throw new Exception("Tên lớp đã tồn tại.");
        }
        /*
        private void ValidateClass(ClassDTO classDTO)
        {
            if (classDTO == null)
                throw new Exception("Dữ liệu lớp không hợp lệ.");
 
            if (string.IsNullOrWhiteSpace(classDTO.ClassName))
                throw new Exception("Tên lớp không được để trống.");
 
            if (classDTO.ClassName.Length > 50)
                throw new Exception("Tên lớp không được vượt quá 50 ký tự.");
 
            if (classDTO.DepartmentID <= 0)
                throw new Exception("Vui lòng chọn khoa.");
 
            List<DepartmentDTO> departments = departmentDAL.GetAll();
 
            bool departmentExists = departments.Exists(
                d => d.DepartmentID == classDTO.DepartmentID
            );
 
            if (!departmentExists)
                throw new Exception("Khoa được chọn không tồn tại.");
        }
        */
    }
}