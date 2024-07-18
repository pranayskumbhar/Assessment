using Assessment_18_07_2024.Common;
using Assessment_18_07_2024.Data;
using Assessment_18_07_2024.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Assessment_18_07_2024.Repository
{
    public class KalbhairavRepository : IKalbhairavRepository
    {
        private bool disposedValue;
        private readonly KalbhairavDbContext _kalbhairavDbContext;
        public KalbhairavRepository(KalbhairavDbContext kalbhairavDbContext)
        {
            _kalbhairavDbContext = kalbhairavDbContext;
        }
        public void signup(Student student)
        {
            _kalbhairavDbContext.Students.Add(student);
            _kalbhairavDbContext.SaveChanges();
        }





        public Student login(Student login)
        {
             return _kalbhairavDbContext.Students.Where(x => x.StudentPassword == Protect.ToEncrypt(login.StudentPassword) &&
             x.StudentUsername == login.StudentUsername
             ).FirstOrDefault();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~KalbhairavRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
