using System.Security.Cryptography;

namespace DemoApp.Helpers {

    internal sealed class CryptionPass {

        internal string GetEncryptionPass( string password ) {
            var byteSalt = RandomNumberGenerator.GetBytes ( 24 );
            var keyDeriver = new Rfc2898DeriveBytes ( password, byteSalt );
            byte[] hash = keyDeriver.GetBytes ( 24 );

            return $"{Convert.ToBase64String ( hash )}৻(•̀ ᗜ •́ ৻){Convert.ToBase64String ( byteSalt )}";
        }

        internal bool TryAuthorizate( string password, string hashedPassword ) {
            var splitted = hashedPassword.Split ( "৻(•̀ ᗜ •́ ৻)" );
            if(splitted.Length != 2) {
                throw new Exception ( $"Can't split hasedPassword: {hashedPassword}" );
            }
            var origSalt = Convert.FromBase64String ( splitted[1] );

            var keyDeriver = new Rfc2898DeriveBytes ( password, origSalt );
            byte[] testHash = keyDeriver.GetBytes ( 24 );

            return Convert.ToBase64String ( testHash ) == splitted[0];
        }
    }
}