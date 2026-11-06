using System;
using System.Collections.Generic;
using StudentManagement.DTO;
using StudentManagement.DAL.Repositories;
using Microsoft.Extensions.Logging;
using StudentManagement.DAL.Logging;

namespace StudentManagement.BLL.Services
{
    public class SubjectBLL
    {
        private static readonly ILogger logger = AppLogger.GetLogger<SubjectBLL>();
        private readonly SubjectDAL subjectDAL = new SubjectDAL();

        public List<SubjectDTO> GetAll()
        {
            return subjectDAL.GetAll();
        }

        public bool Insert(SubjectDTO item)
        {
            string error = SubjectValidator.Validate(item);

            if (error != null)
            {
                logger.LogWarning(
                    "Thêm môn học {Code} thất bại: {Error}",
                    item?.SubjectCode, error);
                throw new Exception(error);
            }

            CheckDuplicateSubject(item);

            bool result = subjectDAL.Insert(item);

            if (result)
                logger.LogInformation(
                    "Thêm môn học {Code} thành công",
                    item.SubjectCode);
            else
                logger.LogWarning(
                    "Thêm môn học {Code} thất bại: không có dòng nào được thêm",
                    item.SubjectCode);

            return result;
        }

        public bool Update(SubjectDTO item)
        {
            if (item == null || item.SubjectID <= 0)
            {
                logger.LogWarning("Cập nhật môn học thất bại: mã môn học không hợp lệ");
                throw new Exception("Mã môn học không hợp lệ.");
            }

            string error = SubjectValidator.Validate(item);

            if (error != null)
            {
                logger.LogWarning(
                    "Cập nhật môn học {Code} (ID={Id}) thất bại: {Error}",
                    item.SubjectCode, item.SubjectID, error);
                throw new Exception(error);
            }

            CheckDuplicateSubject(item);

            bool result = subjectDAL.Update(item);

            if (result)
                logger.LogInformation(
                    "Cập nhật môn học {Code} (ID={Id}) thành công",
                    item.SubjectCode, item.SubjectID);
            else
                logger.LogWarning(
                    "Cập nhật môn học {Code} (ID={Id}) thất bại: không có dòng nào được cập nhật",
                    item.SubjectCode, item.SubjectID);

            return result;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                logger.LogWarning(
                    "Xóa môn học thất bại: mã môn học không hợp lệ ({Id})", id);
                throw new Exception("Mã môn học không hợp lệ.");
            }

            bool result = subjectDAL.Delete(id);

            if (result)
                logger.LogInformation("Xóa môn học ID={Id} thành công", id);
            else
                logger.LogWarning(
                    "Xóa môn học ID={Id} thất bại: không tìm thấy bản ghi", id);

            return result;
        }
        private void CheckDuplicateSubject(SubjectDTO item)
        {
            var subjects = subjectDAL.GetAll();

            bool exists = subjects.Exists(s =>
                s.SubjectCode.Equals(
                    item.SubjectCode.Trim(),
                    StringComparison.OrdinalIgnoreCase)
                && s.SubjectID != item.SubjectID);

            if (exists)
                throw new Exception("Mã môn học đã tồn tại.");
        }
        /*
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
        */
    }
}