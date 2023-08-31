using DemoDotNetAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace DemoDotNetAPI.Services
{
    public class TypeRepositoryInMemory : ITypeRepository
    {
        //Mảng danh sách Type VM
        static List<TypeVM> typeVMs = new List<TypeVM>
        {
            new TypeVM{TypeId = 1, TypeName = "IP"},
            new TypeVM{TypeId = 2, TypeName = "IPad"},
            new TypeVM{TypeId = 3, TypeName = "TV"},
            new TypeVM{TypeId = 4, TypeName = "Desktop"},
        };

        public void DeleteType(int id)
        {
            var type = typeVMs.SingleOrDefault(t => t.TypeId == id);
            if(type != null)
            {
                typeVMs.Remove(type);
            }
        }

        public List<TypeVM> GetAllTypes()
        {
            return typeVMs;
        }

        public TypeVM GetTypeById(int id)
        {
            return typeVMs.SingleOrDefault(t => t.TypeId == id);
        }

        public TypeVM NewType(TypeModel type)
        {
            var _type = new TypeVM
            {
                TypeId = typeVMs.Max(t => t.TypeId) + 1,
                TypeName = type.TypeName
            };
            typeVMs.Add(_type);
            return _type;
        }

        public void UpdateType(TypeVM type)
        {
            var _type = typeVMs.SingleOrDefault(t => t.TypeId == type.TypeId);
            if(_type != null)
            {
                _type.TypeName = type.TypeName;
            }
        }
    }
}
