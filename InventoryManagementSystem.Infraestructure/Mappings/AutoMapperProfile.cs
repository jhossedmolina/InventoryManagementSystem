using AutoMapper;
using InventoryManagementSystem.Core.DTOs;
using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<ProductBrand, ProductBrandDto>();
            CreateMap<ProductBrandDto, ProductBrand>();

            CreateMap<DocumentType, DocumentTypeDto>();
            CreateMap<DocumentTypeDto, DocumentType>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();

            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();

            CreateMap<RoleEmployeeDto, RoleEmployee>();
            CreateMap<RoleEmployee, RoleEmployeeDto>();

        }
    }
}
