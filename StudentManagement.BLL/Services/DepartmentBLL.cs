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

        public bool Insert(DepartmentDTO department)
        {
            if (department == null)
                throw new Exception("Dữ liệu khoa không hợp lệ.");

            if (string.IsNullOrWhiteSpace(department.DepartmentName))
                throw new Exception("Tên khoa không được để trống.");

            return departmentDAL.Insert(department);
        }

        public bool Update(DepartmentDTO department)
        {
            if (department == null)
                throw new Exception("Dữ liệu khoa không hợp lệ.");

            if (department.DepartmentID <= 0)
                throw new Exception("Mã khoa không hợp lệ.");

            if (string.IsNullOrWhiteSpace(department.DepartmentName))
                throw new Exception("Tên khoa không được để trống.");

            return departmentDAL.Update(department);
        }

        public bool Delete(int departmentID)
        {
            if (departmentID <= 0)
                throw new Exception("Mã khoa không hợp lệ.");

            return departmentDAL.Delete(departmentID);
        }
    }
}