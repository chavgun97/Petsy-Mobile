using Firebase.Database;
using Firebase.Database.Offline;
using Firebase.Database.Query;
using Petsy.Cache;
using Petsy.Models.DTO;
using Petsy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petsy.Services.FireBaseRealTimeDataBase
{

   
    public class RealtimeDatabaseChatService : IChatApi
    {
        private static readonly RealtimeDatabaseChatService Instance = new RealtimeDatabaseChatService();
        
        //public delegate void OnChangeOrAddMsgHandler(Message msg);
        event IChatApi.OnChangeOrAddMsgHandler OnChangeOrAddMsgHandlerNotify;

        FirebaseClient firebase = new FirebaseClient("https://petsy-a0383.firebaseio.com/"//, new FirebaseOptions
        //{
           // AuthTokenAsyncFactory = () => Task.FromResult(auth)
        //}
        );
          RealtimeDatabaseChatService()
        {
        }

        event IChatApi.OnChangeOrAddMsgHandler IChatApi.OnChangeOrAddMsgHandlerNotify
        {
            add
            {
                OnChangeOrAddMsgHandlerNotify += value;
            }

            remove
            {
                OnChangeOrAddMsgHandlerNotify -= value;
            }
        }

        public static RealtimeDatabaseChatService GetInstance()
        {
            return Instance;
        }
        public void SubscribeToMsgChanges()
        {
            firebase.Child("Messages").AsObservable<Message>().Subscribe(x => OnChangeOrAddMsgHandlerNotify?.Invoke(x.Object));
        }

        public async Task SendMsg(string text)
        {
            var msg = new Message { Text = text, Uid = CurrentUser.GetInstance().Get().UID, Date = DateTime.Now.ToString() };
            await firebase.Child("Messages")
              .PostAsync(msg);
        }
        public async Task<List<Message>> GetAllMsg()
        {

            return ( firebase.Child("Messages").OnceAsync<Message>(new TimeSpan(0,0,5)).Result).Select(item => new Message()
            {
                Uid = item.Object.Uid,
                Text = item.Object.Text,
                Date = item.Object.Date
            }).ToList();
        }

        /* public async Task<Person> GetPerson(int personId)
         {
             var allPersons = await GetAllPersons();
             await firebase
               .Child("Persons")
               .OnceAsync<Person>();
             return allPersons.Where(a => a.PersonId == personId).FirstOrDefault();
         }

         public async Task UpdatePerson(int personId, string name)
         {
             var toUpdatePerson = (await firebase
               .Child("Persons")
               .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();

             await firebase
               .Child("Persons")
               .Child(toUpdatePerson.Key)
               .PutAsync(new Person() { PersonId = personId, Name = name });
         }

         public async Task DeletePerson(int personId)
         {
             var toDeletePerson = (await firebase
               .Child("Persons")
               .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();
             await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

         }*/
    }

    public class Message
    {
        public string Uid { get; set; }
        public string Date { get; set; }
        public string  Text { get; set; }
    }
   /* public class Chat
    {
        public string Uid1 { get; set; }
        public string Uid2 { get; set; }

        public Message[] Messages { get; set; }
    }*/
}
/*
    private void SubscribeToDbChanges()
{
   firebase
   .Child("jobs").AsObservable<Job>()
   .Where(job => !jobList.ContainsKey(job.Object.ID) && job.EventType == Firebase.Xamarin.Database.Streaming.FirebaseEventType.InsertOrUpdate)
   .Subscribe(job =>
   {
       if (job.EventType == Firebase.Xamarin.Database.Streaming.FirebaseEventType.InsertOrUpdate)
       {
           while (!jobList.TryAdd(job.Object.ID, job.Object)) ;
       }
   });
   firebase
   .Child("jobs").AsObservable<Job>()
   .Where(job => jobList.ContainsKey(job.Object.ID) && job.EventType == Firebase.Xamarin.Database.Streaming.FirebaseEventType.Delete)
   .Subscribe(job =>
   {
       Thread remove = new Thread(() =>
       {
           Job removed = null;
           jobList.TryRemove(job.Object.ID, out removed);
       });
       remove.Start();
   });

}


    */
