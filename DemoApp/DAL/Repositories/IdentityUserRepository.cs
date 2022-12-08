using Microsoft.AspNetCore.Identity;

namespace DemoApp.Core.DAL.Repositories {

    public class IdentityUserRepository /*: IRepository<string , IdentityUser>*/ {
        private ApplicationContext _db;

        public IdentityUserRepository( ApplicationContext context ) {
            _db = context ?? throw new ArgumentNullException ( nameof ( context ) );
        }

        public IdentityUser Create( IdentityUser item ) {
            throw new NotImplementedException ();
        }

        public Task<IdentityUser> CreateAsync( IdentityUser item ) {
            throw new NotImplementedException ();
        }

        public IdentityUser Delete( IdentityUser item ) {
            throw new NotImplementedException ();
        }

        public Task<IdentityUser> DeleteAsync( IdentityUser item ) {
            throw new NotImplementedException ();
        }

        public IEnumerable<IdentityUser> Find( Func<IdentityUser, bool> predicate ) {
            throw new NotImplementedException ();
        }

        public Task<IEnumerable<IdentityUser>> FindAsync( Func<IdentityUser, bool> predicate ) {
            throw new NotImplementedException ();
        }

        public IdentityUser Get( string id ) {
            throw new NotImplementedException ();
        }

        public IEnumerable<IdentityUser> GetAll() {
            throw new NotImplementedException ();
        }

        public Task<IdentityUser> GetAsync( string id ) {
            throw new NotImplementedException ();
        }

        public void SaveChanges() {
            throw new NotImplementedException ();
        }

        public Task<int> SaveChangesAsync() {
            throw new NotImplementedException ();
        }

        public IdentityUser Update( IdentityUser item ) {
            throw new NotImplementedException ();
        }

        public Task<IdentityUser> UpdateAsync( IdentityUser item ) {
            throw new NotImplementedException ();
        }
    }
}