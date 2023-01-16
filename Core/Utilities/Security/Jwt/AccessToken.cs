using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{ 
    //<summary>
    // Erişim anahtarıdır ve çeşitli bilgiler tutmak için nesne oluşturduk.
    //</summary>

    public class AccessToken
    {
        public string Token { get; set; }               
        public DateTime Expiration { get; set; }        //Alınan tokenın ne kadar geçerli olacağını belirlemek için

    }
}
