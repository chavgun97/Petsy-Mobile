using Petsy.Models.DTO;
using Refit;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Petsy.Models.RequestJSON.RequestsJSON;
using static Petsy.Models.ResponseJSON.ResponsesJSON;

namespace Petsy.Services
{
    [Headers("Accept: application/json")]
    interface IClientRestApi
    {
        [Post("/GetUserByToken")]
        Task<GetUserByTokenResponse> GetUserByToken();

        [Post("/GetAllSitters")]
        Task<GetAllSittersResponse> GetAllSitters();

        [Post("/GetSittersByLocation")]
        Task<GetSittersByLocationResponse> GetSittersByLocation(GetSitterByLocationRequest getSitterByLocationRequest);

        [Post("/GetSittersByFilter")]
        Task<GetSitterByFilterResponse> GetSittersByFilter(FilterRequest filterRequest);

        [Post("/CreateUser")]
        Task<CreateUserResponse> CreateUser(UserRequest userRequest);

        [Post("/CreateSitter")]
        Task<CreateSitterResponse> CreateSitter(SitterRequest sitterRequest);

        [Post("/CreateOrder")]
        Task<CreateOrderResponse> CreateOrder(OrderRequest orderRequest);

        [Post("/CreatePet")]
        Task<CreatePetResponse> CreatePet(PetRequest petRequest);

        [Post("/UpdateUser")]
        Task<UpdateUserResponse> UpdateUser(UserRequest userRequest);

        [Post("/UpdateSitter")]
        Task<UpdateSitterResponse> UpdateSitter(SitterRequest sitterRequest);

        [Post("/UpdatePet")]
        Task<UpdatePetResponse> UpdatePet(PetRequest petRequest);

        [Post("/UpdateOrder")]
        Task<UpdateOrderResponse> UpdateOrder(OrderRequest orderRequest);

        [Get("/GetAllBreeds")]
        Task<GetAllBreedsResponse> GetAllBreeds();





    }


}
