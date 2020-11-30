using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using DataTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Data;

namespace UnitTests
{
    [TestClass]
    public class SerializetionTest
    {

        [TestMethod]
        public void serializeTest()
        {
            
            IDataRepository dataRepository = new DataRepository(new RandomFiller());
            dataRepository.Fill();

            Assert.AreEqual(2, dataRepository.GetAllClients().Count);
            Assert.AreEqual(2, dataRepository.GetAllProducts().Count);
            Assert.AreEqual(2, dataRepository.GetAllMagazineStates().Count);
            Assert.AreEqual(2, dataRepository.GetAllStockEvents().Count);


            Serialize serialize = new Serialize(dataRepository.GetDataContext());

            dataRepository = new DataRepository(new RandomFiller());

            Assert.AreEqual(0, dataRepository.GetAllClients().Count);
            Assert.AreEqual(0, dataRepository.GetAllProducts().Count);
            Assert.AreEqual(0, dataRepository.GetAllMagazineStates().Count);
            Assert.AreEqual(0, dataRepository.GetAllStockEvents().Count);
            
            Deserialize deserialize = new Deserialize();
            dataRepository.SetDataContext(deserialize.getDeserializeContex());

            Assert.AreEqual(2, dataRepository.GetAllClients().Count);
            Assert.AreEqual(2, dataRepository.GetAllProducts().Count);
            Assert.AreEqual(2, dataRepository.GetAllMagazineStates().Count);
            Assert.AreEqual(2, dataRepository.GetAllStockEvents().Count);
            /*            serialize = new Serialize(dataRepository.GetAllMagazineStates());
                        serialize = new Serialize(dataRepository.GetAllProducts());
                        serialize = new Serialize(dataRepository.GetAllStockEvents());*/
        }
    }
}
