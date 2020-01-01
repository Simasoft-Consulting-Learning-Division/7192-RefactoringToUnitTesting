using System;
using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Tests.Repositories
{
    public class FakeDiscountRepository : IDiscountRepository
    {
        public Discount Get(string code)
        {
            return 
                code == "12345678" ?
                    new Discount(10, DateTime.Now.AddDays(5))
                    : code == "11111111" ? 
                        new Discount(10, DateTime.Now.AddDays(-5)): null;
        }        
    }
}