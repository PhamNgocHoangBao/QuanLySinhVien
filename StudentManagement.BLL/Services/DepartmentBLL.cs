using System;
using System.Collections.Generic;
using StudentManagement.DTO;
using StudentManagement.DAL.Repositories;

namespace StudentManagement.BLL.Services
{
    public class DepartmentBLL
    {
        private readonly DepartmentDAL departmentDAL = new DepartmentDAL();

        public List<DepartmentDTO> GetAll()
        {
            return departmentDAL.GetAll();
        }

        public bool Insert(DepartmentDTO item)
        {
            string error = DepartmentValidator.Validate(item);

            if (error != null)
                throw new Exception(error);
            CheckDuplicateDepartment(item);
            return departmentDAL.Insert(item);
        }

        public bool Update(DepartmentDTO item)
        {
            if (item == null || item.DepartmentID <= 0)
                throw new Exception("Mã khoa không hợp lệ.");

            string error = DepartmentValidator.Validate(item);

            if (error != null)
                throw new Exception(error);
            CheckDuplicateDepartment(item);
            return departmentDAL.Update(item);
        }

        public bool Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Mã khoa không hợp lệ.");

            return departmentDAL.Delete(id);
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