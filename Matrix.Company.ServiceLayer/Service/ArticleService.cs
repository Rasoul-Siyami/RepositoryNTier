using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Matrix.Company.DataLayer;
using Matrix.Company.DomainClasses;
using Matrix.Company.ServiceLayer.Base;
using Matrix.Company.ServiceLayer.Contracts;

namespace Matrix.Company.ServiceLayer.Service//Matrix.Company.ServiceLayer.Models
{
    public class ArticleService : ServiceBase<Article>, IArticleService
    {
        public ArticleService(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
}