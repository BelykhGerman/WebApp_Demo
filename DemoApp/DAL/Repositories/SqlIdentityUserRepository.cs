using DemoApp.Core.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Core.DAL.Repositories {

    public class SqlIdentityUserRepository : IRepository<IdentityUser, string> {
        private ApplicationContext _sqlDb;

        public SqlIdentityUserRepository( ApplicationContext context ) {
            _sqlDb = context ?? throw new ArgumentNullException ( nameof ( context ) );
        }

        public IdentityUser? Create( IdentityUser item ) {
            if(item is null) {
                throw new ArgumentNullException ( nameof ( item ) );
            }
            var user = _sqlDb.Entry ( item );
            user.State = EntityState.Added;
            return user.Entity;
        }

        public Task<IdentityUser?> CreateAsync( IdentityUser item ) {
            throw new NotImplementedException ();
        }

        public IdentityUser? Delete( string id ) {
            throw new NotImplementedException ();
        }

        public Task<IdentityUser?> DeleteAsync( string id ) {
            throw new NotImplementedException ();
        }

        public IEnumerable<IdentityUser> FindAll( Func<IdentityUser, bool> predicate ) {
            throw new NotImplementedException ();
        }

        public Task<IEnumerable<IdentityUser>> FindAllAsync( Func<IdentityUser, bool> predicate ) {
            throw new NotImplementedException ();
        }

        public IdentityUser? Get( string id ) {
            throw new NotImplementedException ();
        }

        public IEnumerable<IdentityUser> GetAll() {
            throw new NotImplementedException ();
        }

        public Task<IdentityUser?> GetAsync( string id ) {
            throw new NotImplementedException ();
        }

        public void SaveChanges() {
            throw new NotImplementedException ();
        }

        public Task SaveChangesAsync() {
            throw new NotImplementedException ();
        }

        public IdentityUser? Update( IdentityUser item ) {
            throw new NotImplementedException ();
        }

        public Task<IdentityUser?> UpdateAsync( IdentityUser item ) {
            throw new NotImplementedException ();
        }
    }
}