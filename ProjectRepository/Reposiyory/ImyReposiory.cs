using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRepository.Reposiyory
{
    interface ImyReposiory<T> where T : class
    {
        void Insert(T Entity);

        void Update(T Entity);

        void Delete(object EntityId);

        void Delete(T Entity);

        void Save(T Entity);

    }
}
