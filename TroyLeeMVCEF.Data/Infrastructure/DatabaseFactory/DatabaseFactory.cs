namespace TroyLeeMVCEF.Data.Infrastructure.DatabaseFactory
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private TroyLeeMVCEFContext dataContext;
        public TroyLeeMVCEFContext Get()
        {
            return dataContext ?? (dataContext = new TroyLeeMVCEFContext());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
