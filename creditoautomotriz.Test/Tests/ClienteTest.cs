using creditoautomotriz.API.Controllers;
using creditoautomotriz.Domain.Interfaces;
using creditoautomotriz.Entity.Models;
using creditoautomotriz.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Transactions;

namespace creditoautomotriz.Test
{
    public class ClienteTest
    {
        private ClienteController controller;
        [SetUp]
        public void Setup()
        {
            
            //controller = new ClienteController();
        }

        [Test]
        public void TestGetCliente()
        {
            Cliente cliente = new Cliente("1719815019", "Juan Francisco", "Simbaña Gonzalez", 25, Convert.ToDateTime("17/06/1997"), "El Inca", "0998646496", 1, true);
                Cliente res = controller.GetCliente("1719815019").Result;
                Assert.IsTrue(res.Nombres.Equals(cliente.Nombres));
                Assert.IsFalse(res.Nombres.Equals(cliente.Nombres), "El cliente no concide.");
        }
        /*[Test]
        public void TestGetClientes()
        {
            Cliente cliente = new Cliente("1719815019", "Juan Francisco", "Simbaña Gonzalez", 25, Convert.ToDateTime("17/06/1997"), "El Inca", "0998646496", 1, true);
            Cliente res = controller.GetCliente("1719815019").Result;
            Assert.IsTrue(res.Nombres.Equals(cliente.Nombres));
            Assert.IsFalse(res.Nombres.Equals(cliente.Nombres), "El cliente no concide.");
        }*/
    }
}