using DemoApp.Core.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DemoApp.Core.DAL.Repositories {

    public class MockRepository : IRepository<IdentityUser, string> {
        private Dictionary<string, IdentityUser> _identityUsers;

        public MockRepository() {
            _identityUsers = new Dictionary<string, IdentityUser> () {
                { "7195814B-5394-4919-9D50-D805251C82EF" , new IdentityUser {UserName = "Nikolai" , Email = "Nikolai@gmail.com" , Id="7195814B-5394-4919-9D50-D805251C82EF" } },
                { "8CF748B4-E4FD-4F27-8961-5412C0E8B29A" , new IdentityUser {UserName = "Yaroslav" , Email = "Yaroslav@gmail.com", Id="8CF748B4-E4FD-4F27-8961-5412C0E8B29A" } },
                { "CCB4B3B0-1380-4DE8-9CBF-894428CE5DCC" , new IdentityUser {UserName = "Natalya" , Email = "Natalya@gmail.com", Id="CCB4B3B0-1380-4DE8-9CBF-894428CE5DCC" } },
            };
        }

        public IdentityUser? Create( IdentityUser item ) {
            if(item is null) {
                throw new ArgumentNullException ( nameof ( item ) );
            }
            item.Id = Guid.NewGuid ().ToString ();
            if(_identityUsers.TryAdd ( item.Id, item )) {
                return item;
            }
            return null;
        }

        public async Task<IdentityUser?> CreateAsync( IdentityUser item ) {
            return await Task.Run ( () => Create ( item ) );
        }

        public IdentityUser? Delete( string id ) {
            if(string.IsNullOrWhiteSpace ( id )) {
                throw new ArgumentNullException ( nameof ( id ) );
            }

            if(_identityUsers.TryGetValue ( id, out IdentityUser? user )) {
                if(_identityUsers.Remove ( id )) {
                    return user;
                }
            }
            return null;
        }

        public async Task<IdentityUser?> DeleteAsync( string id ) {
            return await Task.Run ( () => Delete ( id ) );
        }

        public IEnumerable<IdentityUser> FindAll( Func<IdentityUser, bool> predicate ) {
            if(predicate is null) {
                throw new ArgumentNullException ( nameof ( predicate ) );
            }
            return _identityUsers.Values.Where ( predicate );
        }

        public async Task<IEnumerable<IdentityUser>> FindAllAsync( Func<IdentityUser, bool> predicate ) {
            return await Task.Run ( () => FindAll ( predicate ) );
        }

        public IdentityUser? Get( string id ) {
            if(string.IsNullOrWhiteSpace ( id )) {
                throw new ArgumentNullException ( nameof ( id ) );
            }

            _identityUsers.TryGetValue ( id, out IdentityUser? user );
            return user;
        }

        public async Task<IdentityUser?> GetAsync( string id ) {
            return await Task.Run ( () => Get ( id ) );
        }

        public IEnumerable<IdentityUser> GetAll() {
            return _identityUsers?.Values ?? new Dictionary<string, IdentityUser> ().Values;
        }

        public IdentityUser? Update( IdentityUser item ) {
            if(item is null) {
                throw new ArgumentNullException ( nameof ( item ) );
            }

            if(_identityUsers.TryGetValue ( item.Id, out IdentityUser? user )) {
                _identityUsers[item.Id] = item;
                return item;
            };
            return null;
        }

        public async Task<IdentityUser?> UpdateAsync( IdentityUser item ) {
            return await Task.Run ( () => Update ( item ) );
        }

        public void SaveChanges() {
            return;
        }

        public async Task SaveChangesAsync() {
            await Task.Delay ( 1000 );
            SaveChanges ();
        }
    }
}