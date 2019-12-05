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
  public   class AbsenceService : Service<Absence> , IAbsenceService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork iow = new UnitOfWork(factory);

        public AbsenceService() : base(iow)
        {

        }
    }
}
