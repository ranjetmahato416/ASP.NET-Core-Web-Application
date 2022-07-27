using School.System.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.System.Services
{
    public interface IStudentServices
    {

    }
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository studentRepository;

        public StudentServices(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
    }
}
