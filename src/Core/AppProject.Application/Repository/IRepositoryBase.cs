using AppProject.Domain.Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Application.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IEntity, new ()
    {
        /// <summary>
        /// Id değeri verilen veri tabanı kaydını geriye döndürür.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(long id);

        /// <summary>
        /// Talep edilen tabloya ait filtrelenmiş listeyi döndürür.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        /// <summary>
        /// Talep edilen tabloya ait filtrelenmiş kaydı döndürür.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Gönderilen objeyi veri tabanına kaydeder.
        /// </summary>
        /// <param name="entity"></param>
        void AddAsync(TEntity entity);

        /// <summary>
        /// Liste olarak verilen objeleri veri tabanına sırasıyla ekler.
        /// </summary>
        /// <param name="entities"></param>
        void AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Objeyi veri tabanında günceller.
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Id'si verilen kaydı veri tabanından tamamen siler. 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);

        /// <summary>
        /// Belirtilen filtreye göre, tabloyu ilişkili olduğu tabloları ile birlikte getirir.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsyncWithIncludeParams(Expression<Func<TEntity, bool>> filter, IList<string> includes = null);


    }
}
