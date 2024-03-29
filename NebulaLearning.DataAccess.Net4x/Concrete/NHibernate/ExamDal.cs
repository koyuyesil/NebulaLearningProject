﻿using NebulaLearning.Core.Net4x.DataAccess.NHibernate;
using NebulaLearning.DataAccess.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.ComplexTypes;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace NebulaLearning.DataAccess.Net4x.Concrete.NHibernate
{
    public class ExamDal : RepositoryBase<Exam>, IExamDal
    {
        private NHibernateHelper _NHibernateHelper;
        public ExamDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _NHibernateHelper = nHibernateHelper;
        }

        public List<ExamDetail> GetExamDetailList()
        {
            using (var session=_NHibernateHelper.OpenSession())
            {
                var result = from p in session.Query<Exam>()
                             join c in session.Query<ExamCategory>() on p.CategoryId equals c.Id
                             select new ExamDetail
                             {
                                 Id = p.CategoryId,
                                 Name = p.Name,
                                 CategoryName = c.Name
                             };
                return result.ToList();
            }
        }
    }
}
