using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Matrix.Company.DataLayer;
using Matrix.Company.DomainClasses;
using Matrix.Company.ServiceLayer.Base;

namespace Matrix.Company.ServiceLayer.Contracts
{
    public interface INewsService : IServiceBase<News>
    {
    }
}