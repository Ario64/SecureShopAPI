using AutoMapper;
using SecureShopAPI.DTOs.ProductDto;
using SecureShopAPI.DTOs.RoleDto;
using SecureShopAPI.DTOs.UserDto;
using SecureShopAPI.Models;

namespace SecureShopAPI.Mapping.Profiles;

public class Profiler : Profile
{
    public Profiler()
    {
        #region Mapinng User

        CreateMap<CreateUserDto, User>().ReverseMap();
        CreateMap<UpdateUserDto, User>().ReverseMap();
        CreateMap<DeleteUserDto, User>().ReverseMap();

        #endregion

        #region Mapinng Product

        CreateMap<CreateProductDto, Product>().ReverseMap();
        CreateMap<UpdateProductDto, Product>().ReverseMap();
        CreateMap<DeleteProductDto, Product>().ReverseMap();

        #endregion

        #region Mapinng Role

        CreateMap<CreateRoleDto, Role>().ReverseMap();
        CreateMap<UpdateRoleDto, Role>().ReverseMap();
        CreateMap<DeleteRoleDto, Role>().ReverseMap();

        #endregion

    }
}