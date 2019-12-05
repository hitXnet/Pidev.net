using Data;
using Data.Infrastructure;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CongeService : Service<Conge> , ICongeService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork iow = new UnitOfWork(factory);

        public CongeService() : base(iow)
        {

        }
    }
}
