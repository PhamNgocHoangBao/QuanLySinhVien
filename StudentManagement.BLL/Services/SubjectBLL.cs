using System;
using System.Collections.Generic;
using StudentManagement.DTO;
using StudentManagement.DAL.Repositories;

namespace StudentManagement.BLL.Services
{
    public class SubjectBLL
    {
        private readonly SubjectDAL subjectDAL = new SubjectDAL();

        public List<SubjectDTO> GetAll()
        {
            return subjectDAL.GetAll();
        }

        public bool Insert(SubjectDTO item)
        {
            string error = SubjectValidator.Validate(item);

            if (error != null)
                throw new Exception(error);

            return subjectDAL.Insert(item);
        }

        public bool Update(SubjectDTO item)
        {
            if (item == null || item.SubjectID <= 0)
                throw new Exception("Mã môn học không hợp lệ.");

            string error = SubjectValidator.Validate(item);

            if (error != null)
                throw new Exception(error);

            return subjectDAL.Update(item);
        }

        public bool Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Mã môn học không hợp lệ.");

            return subjectDAL.Delete(id);
        }

        private void ValidateSubject(SubjectDTO subject)
        {
            if (subject == null)
                throw new Exception("Dữ liệu môn học không hợp lệ.");

            if (string.IsNullOrWhiteSpace(subject.SubjectCode))
                throw new Exception("Mã môn học không được để trống.");

            if (subject.SubjectCode.Length > 20)
                throw new Exception("Mã môn học không được vượt quá 20 ký tự.");

            if (string.IsNullOrWhiteSpace(subject.SubjectName))
                throw new Exception("Tên môn học không được để trống.");

            if (subject.SubjectName.Length > 100)
                throw new Exception("Tên môn học không được vượt quá 100 ký tự.");

            if (subject.Credits <= 0)
                throw new Exception("Số tín chỉ phải lớn hơn 0.");
        }
    }
}