using System;

namespace TroyLeeMVCEF.Data.Infrastructure.DatabaseFactory
{
    public interface IDatabaseFactory : IDisposable
    {
        TroyLeeMVCEFContext Get();
    }
}
