using System;
using System.Collections.Generic;
using System.Text;

namespace EmailForms.DAL
{
    public interface IRepository<T>
    {
        void Update(T entity);

        void Delete(Guid id);
    }
}
