namespace TroyLeeMVCEF.Data.Infrastructure.UnitOfWork
{
    using TroyLeeMVCEF.Data.Infrastructure.DatabaseFactory;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private TroyLeeMVCEFContext dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected TroyLeeMVCEFContext DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }

        public void Commit()
        {
            DataContext.Commit();
        }
    }
}
