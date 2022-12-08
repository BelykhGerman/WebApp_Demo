namespace DemoApp.Core.DAL.Interfaces {

    public interface IRepository<T, TKey> where T : class {

        IEnumerable<T> GetAll();

        T? Get( TKey id );

        Task<T?> GetAsync( TKey id );

        T? Update( T item );

        Task<T?> UpdateAsync( T item );

        IEnumerable<T> FindAll( Func<T, bool> predicate );

        Task<IEnumerable<T>> FindAllAsync( Func<T, bool> predicate );

        T? Create( T item );

        Task<T?> CreateAsync( T item );

        T? Delete( TKey id );

        Task<T?> DeleteAsync( TKey id );

        void SaveChanges();

        Task SaveChangesAsync();
    }
}