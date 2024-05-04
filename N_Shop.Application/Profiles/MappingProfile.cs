using AutoMapper;
using N_Shop.Application.DTOs.Orders.Order;
using N_Shop.Application.DTOs.Orders.OrderDetail;
using N_Shop.Application.DTOs.Products.Category;
using N_Shop.Application.DTOs.Products.Product;
using N_Shop.Application.DTOs.Products.ProductComment;
using N_Shop.Application.DTOs.Products.ProductCommentVote;
using N_Shop.Application.DTOs.Products.ProductVote;
using N_Shop.Application.DTOs.Role_Permissions.Permission;
using N_Shop.Application.DTOs.Role_Permissions.Role;
using N_Shop.Application.DTOs.Role_Permissions.RolePermission;
using N_Shop.Application.DTOs.Users.User;
using N_Shop.Application.DTOs.Users.Wallet;
using N_Shop.Application.DTOs.Users.WalletType;
using N_Shop.Domain.Orders;
using N_Shop.Domain.Products;
using N_Shop.Domain.Role_Permissions;
using N_Shop.Domain.Users;
using N_Shop.Application.Models.Identity;

namespace N_Shop.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Orders 

            CreateMap<Order, OrderDto>().ReverseMap();

            #region Order

            #endregion

            #region OrderDetail

            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, CUDOrderDetailDto>().ReverseMap();

            #endregion

            #endregion

            #region Products 

            #region Category

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            #endregion

            #region Product

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductListDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            #endregion

            #region ProductComment

            CreateMap<ProductComment, ProductCommentListDto>().ReverseMap();
            CreateMap<ProductComment, CreateProductCommentDto>().ReverseMap();
            CreateMap<ProductComment, UpdateProductCommentDto>().ReverseMap();

            #endregion

            #region ProductCommentVote

            CreateMap<ProductCommentVote, CUDProductCommentVoteDto>().ReverseMap();

            #endregion

            #region ProductVote

            CreateMap<ProductVote, CUDProductVoteDto>().ReverseMap();

            #endregion

            #endregion

            #region Role_Permissions 

            #region Permission

            CreateMap<Permission, PermissionDto>().ReverseMap();
            CreateMap<Permission, CreatePermissionDto>().ReverseMap();
            CreateMap<Permission, UpdatePermissionDto>().ReverseMap();

            #endregion

            #region Role

            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Role, CreateRoleDto>().ReverseMap();
            CreateMap<Role, UpdateRoleDto>().ReverseMap();

            #endregion

            #region RolePermission

            CreateMap<RolePermission, RolePermissionDto>().ReverseMap();

            #endregion

            #endregion

            #region Users 

            #region User

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserProfileDto>().ReverseMap();

            CreateMap<User, RegistrationRequestModel>().ReverseMap();
            CreateMap<User, AuthRequestModel>().ReverseMap();

            #endregion

            #region Wallet

            CreateMap<Wallet, WalletDto>().ReverseMap();

            #endregion

            #region WalletType

            CreateMap<WalletType, WalletTypeDto>().ReverseMap();

            #endregion

            #endregion

        }
    }
}
