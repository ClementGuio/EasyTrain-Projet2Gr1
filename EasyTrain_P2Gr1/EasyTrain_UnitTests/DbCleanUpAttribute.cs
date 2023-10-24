using EasyTrain_P2Gr1.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace EasyTrain_UnitTests
{
    internal class DbCleanUpAttribute : BeforeAfterTestAttribute
    {
        private BddContext _bddContext;

        public DbCleanUpAttribute()
        {
            _bddContext = new BddContext();
        }

        public override void Before(MethodInfo methodUnderTest)
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        public override void After(MethodInfo methodUnderTest)
        {
            _bddContext.Database.EnsureDeleted();
        }
    }
}
