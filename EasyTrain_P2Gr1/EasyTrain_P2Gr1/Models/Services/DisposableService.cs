using System;

namespace EasyTrain_P2Gr1.Models.Services
{
    public abstract class DisposableService : IDisposable
    {
        protected BddContext _bddContext;

        protected DisposableService()
        {
            _bddContext = new BddContext();
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}
