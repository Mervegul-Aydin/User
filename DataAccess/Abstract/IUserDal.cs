
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal
    {
        void Add(User user);
        User Get(Expression<Func<User, bool>> filter);
        List<User> List(Expression<Func<User, bool>> filter);
        List<User> List();
    }
}
