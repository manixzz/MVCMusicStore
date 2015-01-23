using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcMusicStore.Models;
using MvcMusicStoreTests;

namespace MvcMusicStoreTests
{
    [TestClass]
    public class ShoppingCartModelTest
    {

        private const int FAKE_ALBUMID = 1;
        private const decimal FAKE_ALBUMPRICE = 8.99M;
        private const int FAKE_GENREID = 2;
        private const int FAKE_ARTISTID = 31;
        private const int FAKE_ORDERID = 6;

        private static TestDB createTestDatabase()
        {
            TestDB testDB = new TestDB();
            testDB.Albums = new TestDbSet<Album>();
            testDB.Artists = new TestDbSet<Artist>();
            testDB.Carts = new TestDbSet<Cart>();
            testDB.Genres = new TestDbSet<Genre>();
            testDB.OrderDetails = new TestDbSet<OrderDetail>();
            testDB.Orders = new TestDbSet<Order>();
            return testDB;
        }

        private Album FakeAlbum()
        {
            return new Album()
            {
                AlbumId = FAKE_ALBUMID,
                GenreId = FAKE_GENREID,
                ArtistId = FAKE_ARTISTID,
                Title = "testAlbum",
                Price = FAKE_ALBUMPRICE,
                AlbumArtUrl = "",
            };
        }

        private Cart FakeCart(TestDB testDb)
        {
            return new Cart()
            {
                CartId = "testCart",
                Count = 1,
                AlbumId = FAKE_ALBUMID,
                RecordId = 3,
                Album = testDb.Albums.Where(a => a.AlbumId == FAKE_ALBUMID).First(),
                DateCreated = DateTime.Now
            };
        }


        private Order FakeCompleteOrder(Cart cart)
        {
            return new Order()
            {
                OrderId = FAKE_ORDERID,
                Username = "tester",
                FirstName = "firstName",
                LastName = "lastName",
                Address = "testAddress",
                City = "testCity",
                State = "testState",
                PostalCode = "l0e3nt",
                Country = "testCanada",
                Phone = "1234567891",
                Email = "tester@testing.com"
            };
        }

        private Order FakeIncompleteOrder(Cart cart)
        {
            return new Order()
            {
                OrderId = FAKE_ORDERID,
                Username = "tester",
                FirstName = "firstName",
                LastName = "lastName",
                Address = "testAddress",
                City = "testCity",
                State = "testState",
                PostalCode = "l0e3nt",
                //Country field missing on purpose
                Phone = "1234567891",
                Email = "tester@testing.com"
            };
        }

        [TestMethod]
        public void CreateOrder_ProvideOrder_ExpectCorrectOrderId()
        {
            //Create the database to be used in this test case.
            TestDB testDB = createTestDatabase();
            //Create a fake album to add to the database
            Album fakeAlbum = FakeAlbum();
            //Add the fake album to the test database
            testDB.Albums.Add(fakeAlbum);

            //Create a fake cart
            Cart fakeCart = FakeCart(testDB);
            //Add the fake cart to the test database
            testDB.Carts.Add(fakeCart);

            //Create a fake order
            Order fakeOrder = FakeCompleteOrder(fakeCart);
            //Instantiate the shopping cart class with the test database           
            var shoppingCart = new ShoppingCart(testDB);
            //Create the order and get the resulting orderid
            var result = shoppingCart.CreateOrder(fakeOrder);
            //Check to make sure it matches up
            Assert.AreEqual(FAKE_ORDERID, result);
        }

        [TestMethod]
        public void CreateOrder_ProvideIncompleteOrder_ExpectCorrectOrderId() {
            //Create the database to be used in this test case.
            TestDB testDB = createTestDatabase();
            //Create a fake album to add to the database
            Album fakeAlbum = FakeAlbum();
            //Add the fake album to the test database
            testDB.Albums.Add(fakeAlbum);

            //Create a fake cart
            Cart fakeCart = FakeCart(testDB);
            //Add the fake cart to the test database
            testDB.Carts.Add(fakeCart);

            //Create a fake order
            Order fakeOrder = FakeIncompleteOrder(fakeCart);
            //Instantiate the shopping cart class with the test database           
            var shoppingCart = new ShoppingCart(testDB);
            //Create the order and get the resulting orderid
            var result = shoppingCart.CreateOrder(fakeOrder);
            //Check to make sure it matches up
            Assert.AreEqual(FAKE_ORDERID, result);
        }

        [TestMethod]
        public void GetTotal_ExpectFail() {
            //Expect a fail because we can't assign a real shopping cart id

            //Create the database to be used in this test case.
            TestDB testDB = createTestDatabase();
            //Create a fake album to add to the database
            Album fakeAlbum = FakeAlbum();
            //Add the fake album to the test database
            testDB.Albums.Add(fakeAlbum);

            //Create a fake cart
            Cart fakeCart = FakeCart(testDB);
            //Add the fake cart to the test database
            testDB.Carts.Add(fakeCart);

            var shoppingCart = new ShoppingCart(testDB);
            
            var result = shoppingCart.GetTotal();

            //Expect 0 since, total is null and get total returns 0 in this case
            Assert.AreEqual(0, result);
        }

    }
}
