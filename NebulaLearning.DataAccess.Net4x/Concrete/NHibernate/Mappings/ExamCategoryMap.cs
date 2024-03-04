﻿using FluentNHibernate.Mapping;
using NebulaLearning.Entities.Net4x.Concrete;

namespace NebulaLearning.DataAccess.Net4x.Concrete.NHibernate.Mappings
{
    public class ExamCategoryMap : ClassMap<ExamCategory>
    {
        public ExamCategoryMap()
        {
            Table(@"ExamCategories");
            LazyLoad();
            Id(x => x.CategoryId).Column("CategoryId");
            Map(x => x.CategoryName).Column("CategoryName");
        }
    }
}
