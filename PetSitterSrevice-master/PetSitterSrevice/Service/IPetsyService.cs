using PetSitterSrevice.Service.ExternalEntity;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PetSitterSrevice.Service
{
    /**
     * По правилам рест фул сервиса, у нас должы быть разные запросы POST, GET, PUT, DELLET для разных операций,
     * но так как авторизация происходить на уровне приложения а мы лишь получаем токен юзера, необходимо обеспечить
     * безопасность передачи данных например шифрованием полученной инофрмации и API key в теле запроса,
     * для этого метод GET не подходит, по этому все свои методы я сделал POST.
     * 
     * 
     * Методы типо getPetstByUserId существуют для оптимизации запросов. Что бы запрашиваемый обьект не был слишком большой его атрибуты 
     * типа питомцы и заказы загружаються по мере требования, например при загрузке страницы посвященной этим данным.
     * (Сей-час я их закоментировал так как для быстрейшей разработки выбрал другой спосб - отправлять обьект сразу со всеми атрибутами,
     * но возможно потребуеться оптимизация приложения , и эти методы нужно будет раелизовать.
     * 
    */
    [ServiceContract]
    public interface IPetsyService
    {
        [WebInvoke(Method = "GET", UriTemplate = "/GetUserByToken",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        User_x GetUserByToken();


        [WebInvoke(Method = "POST", UriTemplate = "/GetPetsByUserId",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        IEnumerable<Pet_x> GetPetsByUserId(int UserId);


        [WebInvoke(Method = "GET", UriTemplate = "/GetAllSitters",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        IEnumerable<Sitter_x> GetAllSitters();


        [WebInvoke(Method = "POST", UriTemplate = "/GetOrdersByUserId",
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        IEnumerable<Order_x> GetOrdersByUserId(int UserId);


        [WebInvoke(Method = "POST", UriTemplate = "/GetUrdersBySitterId",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        IEnumerable<Order_x> GetOrdersBySitterId(int SitterId);


        [WebInvoke(Method = "POST", UriTemplate = "/GetSittersByLocation",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        IEnumerable<Sitter_x> GetSittersByLocation(String location);


        [WebInvoke(Method = "POST", UriTemplate = "/GetSittersByFilter",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        IEnumerable<Sitter_x> GetSitterByFilter(Filter_x filter);


        [WebInvoke(Method = "POST", UriTemplate = "/CreateUser",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        int CreateUser(User_x user);


        [WebInvoke(Method = "POST", UriTemplate = "/CreateSitter",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        int CreateSitter(Sitter_x sitter);


        [WebInvoke(Method = "POST", UriTemplate = "/CreateOrder",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        int CreateOrder(Order_x order);


        [WebInvoke(Method = "POST", UriTemplate = "/CreatePet",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        int CreatePet(Pet_x pet);


        [WebInvoke(Method = "POST", UriTemplate = "/UpdateUser",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        int UpdateUser(User_x user);


        [WebInvoke(Method = "POST", UriTemplate = "/UpdateSitter",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        int UpdateSitter(Sitter_x sitter);

        [WebInvoke(Method = "POST", UriTemplate = "/UpdatePet",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        int UpdatePet(Pet_x pet);

        [WebInvoke(Method = "POST", UriTemplate = "/UpdateOrder",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        int UpdateOrder(Order_x order);


        [WebInvoke(Method = "GET", UriTemplate = "/GetAllBreeds",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        string[] GetAllBreeds();


        [WebInvoke(Method = "GET", UriTemplate = "/check",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        string IsWorking();



    }
}
