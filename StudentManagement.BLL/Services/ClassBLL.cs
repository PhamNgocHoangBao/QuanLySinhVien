using System;
using System.Collections.Generic;
using StudentManagement.DTO;
using StudentManagement.DAL.Repositories;

namespace StudentManagement.BLL.Services
{
    public class ClassBLL
    {
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
                throw new Exception(error);
            CheckDuplicateClass(item);
            return classDAL.Insert(item);
        }

        public bool Update(ClassDTO item)
        {
            if (item == null || item.ClassID <= 0)
                throw new Exception("Thông tin lớp không hợp lệ.");

            string error = ClassValidator.Validate(item);

            if (error != null)
                throw new Exception(error);
            CheckDuplicateClass(item);
            return classDAL.Update(item);
        }

        public bool Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Mã lớp không hợp lệ.");

            return classDAL.Delete(id);
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