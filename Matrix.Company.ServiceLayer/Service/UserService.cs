using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using Matrix.Company.DataLayer;
using Matrix.Company.DomainClasses;
using Matrix.Company.ServiceLayer.Base;
using Matrix.Company.ServiceLayer.Contracts;

namespace Matrix.Company.ServiceLayer.Service
{
    public class UserService : ServiceBase<User>, IUserService
    {
        public UserService(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
}