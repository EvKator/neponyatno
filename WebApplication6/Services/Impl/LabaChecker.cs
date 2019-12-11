using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data.Entity;

namespace WebApplication6.Services.Impl
{
    public class LabaChecker : ILabaChecker
    {
        private readonly ILabaCheckerImpl _labaCheckerImpl;

        public LabaChecker(ILabaCheckerImpl labaCheckerImpl)
        {
            _labaCheckerImpl = labaCheckerImpl;
        }
        public uint Check(Laba laba)
        {
            return _labaCheckerImpl.Check(laba);
        }

        public void CheckAll()
        {
            _labaCheckerImpl.CheckAll();
        }
    }
}
