using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunity.DataLayer.Infrastructure
{
    // Interface that initialize instances of our dbcontext class
    public interface IDatabaseManager : IDisposable
    {
        DatabaseContext Init();
    }
}
