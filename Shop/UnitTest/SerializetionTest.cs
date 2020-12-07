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


            Serialize serialize = new Serialize();
            serialize.SerializeToJSON(dataRepository);
            dataRepository = new DataRepository(new RandomFiller());

            Assert.AreEqual(0, dataRepository.GetAllClients().Count);
            Assert.AreEqual(0, dataRepository.GetAllProducts().Count);
            Assert.AreEqual(0, dataRepository.GetAllMagazineStates().Count);
            Assert.AreEqual(0, dataRepository.GetAllStockEvents().Count);
            
            Deserialize deserialize = new Deserialize();
            dataRepository.SetAllClients(deserialize.JSONToClient("Clients.json"));
            dataRepository.SetAllProducts(deserialize.JSONToProduct("Products.json"));
            dataRepository.SetAllMagazineStates(deserialize.JSONToMagazineState("MagazineStates.json"));
            dataRepository.SetAllStockEvents(deserialize.JSONToStockEvent("StockEvents.json"));

            Assert.AreEqual(2, dataRepository.GetAllClients().Count);
            Assert.AreEqual(2, dataRepository.GetAllProducts().Count);
            Assert.AreEqual(2, dataRepository.GetAllMagazineStates().Count);
            Assert.AreEqual(2, dataRepository.GetAllStockEvents().Count);

            serialize.SerializeToCSV(dataRepository);

            dataRepository = new DataRepository(new RandomFiller());

            Assert.AreEqual(0, dataRepository.GetAllClients().Count);
            Assert.AreEqual(0, dataRepository.GetAllProducts().Count);
            Assert.AreEqual(0, dataRepository.GetAllMagazineStates().Count);
            Assert.AreEqual(0, dataRepository.GetAllStockEvents().Count);

            dataRepository.SetAllClients(deserialize.CSVToClients("Clients.csv"));
            dataRepository.SetAllProducts(deserialize.CSVToProducts("Products.csv"));
            /*dataRepository.SetAllMagazineStates(deserialize.CSVToMagazineState("MagazineStates.json"));*/
            /*dataRepository.SetAllStockEvents(deserialize.CSVToStockEvent("StockEvents.json"));*/

            /*            "MagazineStates.csv"
                            "StockEvents.csv"*/
            /*dataRepository = new DataRepository(new RandomFiller());*/
            Assert.AreEqual(2, dataRepository.GetAllClients().Count);
            Assert.AreEqual(2, dataRepository.GetAllProducts().Count);
            /*            Assert.AreEqual(2, dataRepository.GetAllMagazineStates().Count);
                        Assert.AreEqual(2, dataRepository.GetAllStockEvents().Count);*/

        }
    }
}
