using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Pattern;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;

namespace Solution.Service
{
    public class TacheService : Service<Tache>
    {
        public static IDataBaseFactory factory = new DataBaseFactory();
        public static IUnitOfWork UTK = new UnitOfWork(factory);
        public TacheService() : base(UTK)
        {

        }
    }
}