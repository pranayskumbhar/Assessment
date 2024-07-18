using Assessment_18_07_2024.Models;

namespace Assessment_18_07_2024.Repository
{
    public interface IKalbhairavRepository : IDisposable
    {
        void signup(Student student);

        Student login(Student student);
    }
}
