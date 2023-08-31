using DemoDotNetAPI.Models;
using System.Collections.Generic;

namespace DemoDotNetAPI.Services
{
    public interface ITypeRepository
    {
        //Define method CRUD
        //List<Type> //Không nên return về Type trực tiếp mà phải thông qua VM
        List<TypeVM> GetAllTypes();
        TypeVM GetTypeById(int id);
        TypeVM NewType(TypeModel type);
        void UpdateType(TypeVM type);
        void DeleteType(int id);
    }
}
