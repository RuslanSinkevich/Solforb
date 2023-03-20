using AutoFixture;
using Solforb.Models;

namespace TestSolforb.Helper
{
    internal class BdTests
    {
        public IList<Order> GetTestOrder()
        {
            var order = new List<Order>
            {
                new Fixture()
                    .Build<Order>()
                    .With(u=>u.Number, "n10")
                    .With(u=>u.ProviderId, 1)
                    .Create(),
                new Fixture()
                    .Build<Order>()
                    .With(u=>u.Number, "n15")
                    .With(u=>u.ProviderId, 1)
                    .Create(),
                new Fixture()
                    .Build<Order>()
                    .With(u=>u.Number, "n20")
                    .With(u=>u.ProviderId, 2)
                    .Create(),
                new Fixture()
                    .Build<Order>()
                    .With(u=>u.Number, "n25")
                    .With(u=>u.ProviderId, 1)
                    .Create(),
            };
            return order;
        }

        public IList<Provider> GetTestProvider()
        {
            var provider = new List<Provider>
            {
                new Fixture()
                    .Build<Provider>()
                    .With(u=>u.Id, 1)
                    .Create(),
                new Fixture()
                    .Build<Provider>()
                    .With(u=>u.Id, 2)
                    .Create(),
            };
            return provider;
        }
    }
}
