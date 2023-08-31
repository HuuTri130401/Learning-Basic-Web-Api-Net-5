using DemoDotNetAPI.Data;
using DemoDotNetAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace DemoDotNetAPI.Services
{
    public class TypeRepository : ITypeRepository
    {
        private readonly DemoDbContext _context;

        public TypeRepository(DemoDbContext context) 
        { 
            _context = context;
        }
        public void DeleteType(int id)
        {
            var type = _context.Types.FirstOrDefault(t => t.TypeId == id);
            if (type != null)
            {
                _context.Types.Remove(type);
                _context.SaveChanges();
            }
        }

        public List<TypeVM> GetAllTypes()
        {
            //return list ViewModel
            var types = _context.Types.Select(ty => new TypeVM
            {
                TypeId = ty.TypeId,
                TypeName = ty.TypeName,
            });
            return types.ToList();
        }

        public TypeVM GetTypeById(int id)
        {
            var type = _context.Types.SingleOrDefault(t => t.TypeId == id);
            if(type != null)
            {
                return new TypeVM
                {
                    TypeId = type.TypeId,
                    TypeName = type.TypeName,
                };
            }
            return null;
        }

        public TypeVM NewType(TypeModel type)
        {
            var _type = new Type
            {
                TypeName = type.TypeName,
            };
            _context.Add(_type);
            _context.SaveChanges();

            //truyên vô TyModel chỉ có mỗi NameType 
            //nhưng trả về thì trả về Type có cả NameType và NameId
            return new TypeVM
            {
                TypeId = _type.TypeId,
                TypeName = _type.TypeName,
            };
        }

        public void UpdateType(TypeVM type)
        {
            var _type = _context.Types.FirstOrDefault(t => t.TypeId == type.TypeId);
            if(_type != null)
            {
                _type.TypeName = type.TypeName;
                _context.SaveChanges();
            }
        }
    }
}
