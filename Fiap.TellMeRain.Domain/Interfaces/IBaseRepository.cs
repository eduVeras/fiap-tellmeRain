using System.Collections.Generic;

namespace Fiap.TellMeRain.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        List<TEntity> Get();
        TEntity Get(int id);
        int Insert(TEntity entity);
        int Insert(List<TEntity> entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}