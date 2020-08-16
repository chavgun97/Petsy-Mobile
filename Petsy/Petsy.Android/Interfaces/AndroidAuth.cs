using Android.Gms.Common.Apis;
using Firebase.Auth;
using Petsy.Droid.Interfaces;
using Petsy.Interfaces;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidAuth))]
namespace Petsy.Droid.Interfaces
{
    class AndroidAuth : IFireBaseAuth 
    {
        public async Task<ResultAuth> LoginWithEP(string Email, string Psw)
        {
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(Email, Psw);
                var token = await user.User.GetIdTokenAsync(false);

                return new ResultAuth() {Token = token.Token, isError = false, Name = user.User.DisplayName, UID = user.User.Uid};
            }catch( Exception err)
            {
                return new ResultAuth() {isError = true, ErrorMsg = err.Message };
            }        
        }

        public Task<ResultAuth> LoginWithFacebook()
        {
            //GoogleAuthProvider.GetCredential();
           
            throw new NotImplementedException();
        }

        public Task<ResultAuth> LoginWithGoogle()
        {
            throw new NotImplementedException();
        }

        public async Task<ResultAuth> RegisteredWithEP(string Name,  string Email, string Psw)
        {
            try
            {
                var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(Email, Psw);
                UserProfileChangeRequest profile = new UserProfileChangeRequest.Builder().SetDisplayName(Name).Build();
                await user.User.UpdateProfileAsync(profile);
                var token = await user.User.GetIdTokenAsync(false);
                return  new ResultAuth() { Token = token.Token, isError = false, Name = Name, UID = user.User.Uid};
            }
            catch (Exception err)
            {
                return new ResultAuth() { isError = true, ErrorMsg = err.Message };
            }
        }

        
    }
}