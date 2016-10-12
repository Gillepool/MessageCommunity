using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunity.DataLayer.Infrastructure
{
    public interface IDatabaseManager : IDisposable
    {
        DatabaseContext Init();
    }
}
