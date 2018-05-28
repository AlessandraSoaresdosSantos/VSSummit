using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebAPICoreExempleTest;
using WebAPICoreExempleTest.Controllers;
using WebAPICoreExempleTest.Models;

namespace UnitTestProject1
{


    [TestClass]
    public class UnitTest1
    {
         
         

        private static DataContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<WebAPICoreExempleTest.DataContext>()
                              .UseSqlServer(@"Data Source=ALESSANDRA-PC;Initial Catalog=Mundo;Integrated Security=True")
                              .Options;
            var context = new WebAPICoreExempleTest.DataContext(options);

                  return context;
        }

        [TestMethod]
        public void TestMethod1()
        {
            var controller = new GrupoOperacaosController(GetContextWithData());

            var result = controller.Get();

        }
         
    }

   
}
