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

        public bool Insert(SubjectDTO subject)
        {
            ValidateSubject(subject);
            return subjectDAL.Insert(subject);
        }

        public bool Update(SubjectDTO subject)
        {
            if (subject == null || subject.SubjectID <= 0)
                throw new Exception("Mã môn học không hợp lệ.");

            ValidateSubject(subject);
            return subjectDAL.Update(subject);
        }

        public bool Delete(int subjectID)
        {
            if (subjectID <= 0)
                throw new Exception("Mã môn học không hợp lệ.");

            return subjectDAL.Delete(subjectID);
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