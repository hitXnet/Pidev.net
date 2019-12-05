using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Pidev.Data.Infrastructure;
using ServicePattern;
namespace Service
{
    public class NoteFraisEmployeService : Service<notefraisemploye>, INoteFraisEmployeService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);
        public NoteFraisEmployeService() : base(UOW)
        {

        }
    }
}
