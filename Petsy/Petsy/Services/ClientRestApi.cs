using Refit;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Petsy.Services
{
    /*
     Возможно стоит реализовать в этом класе IClientRestApi и сделать обертку на реализацию
    этого интерфейса Refit ом, потому что очень много лишней и одинаковой информации приходиться писать при вызове 
    методов для работы с сервером. Или создать свой интерфейс доступа к серверу, с блек джеком и шлюхами, где 
    можно использовать функциональность refit и добавить свою, которая не нужна при использовании сервера.
    Так же можно релазовать работу с текущим пользователем прямо здесь( его обновлени), и тогда не нужно будет вручную
    его обновлять. Останеться только возможно его взятия.
     */
    static class ClientRestApi
    {
        /*
         HttpClientHandler - удали эту надстройку когда будет нормальный сертефикат! Этот код отключает 
        проверку сертефиката SSL!!!!
         */
        private static readonly HttpClient client = new HttpClient(new HttpClientHandler()
        { ServerCertificateCustomValidationCallback = ((sender, cert, chain, sslPolicyErrors) => { return true; })}
        )
        {
            BaseAddress = new Uri("http://192.168.0.129/Service/PetsyService.svc")
            
        };

        private static IClientRestApi Service;


        public static IClientRestApi CreateNewInstance(String token)
        {
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            Service = RestService.For<IClientRestApi>(client);
            return Service;
        }

        public static IClientRestApi getInstance()
        {
            if(Service == null)
            {
                throw new Exception("Сначало создайте екземпляр с токеном пользователя");
            }
            return Service;
        }
        
        

    }
}
