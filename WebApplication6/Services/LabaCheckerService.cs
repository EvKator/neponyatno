using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data.Entity;

namespace WebApplication6.Services
{
    public interface ILabaCheckerService
    {
        uint Check(Laba laba);

        void CheckAll();
    }
}
