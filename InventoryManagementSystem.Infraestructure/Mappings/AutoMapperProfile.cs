using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();

            CreateMap<DocumentType, DocumentTypeDto>();
            CreateMap<DocumentTypeDto, DocumentType>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();

            CreateMap<EmployeeUser, EmployeeUserDto>();
            CreateMap<EmployeeUserDto, EmployeeUser>();

            CreateMap<MunicipalityCountry, MunicipalityCountryDto>();
            CreateMap<MunicipalityCountryDto, MunicipalityCountry>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<OrderDetailDto, OrderDetail>();

            CreateMap<OrderHistory, OrderHistoryDto>();
            CreateMap<OrderHistoryDto, OrderHistory>();

            CreateMap<OrderStatus, OrderStatusDto>();
            CreateMap<OrderStatusDto, OrderStatus>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<ProductBrand, ProductBrandDto>();
            CreateMap<ProductBrandDto, ProductBrand>();

            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductCategoryDto, ProductCategory>();

            CreateMap<ProductHistory, ProductHistoryDto>();
            CreateMap<ProductHistoryDto, ProductHistory>();

            CreateMap<ProductMovement, ProductMovementDto>();
            CreateMap<ProductMovementDto, ProductMovement>();

            CreateMap<ProductStock, ProductStockDto>();
            CreateMap<ProductStockDto, ProductStock>();

            CreateMap<RoleEmployee, RoleEmployeeDto>();
            CreateMap<RoleEmployeeDto, RoleEmployee>();

            CreateMap<StateCountry, StateCountryDto>();
            CreateMap<StateCountryDto, StateCountry>();

            CreateMap<StatusEmployed, StatusEmployedDto>();
            CreateMap<StatusEmployedDto, StatusEmployed>();
        }
    }
}
