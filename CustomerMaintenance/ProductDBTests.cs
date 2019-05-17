using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace CustomerMaintenance
{
	[TestFixture]
	public class ProductDBTests
	{
		[Test]
		public void TestGetProduct()
		{
			Product product = ProductDB.GetProduct("2JST      ");
			Assert.AreEqual("2JST      ", product.ProductCode);
			Assert.AreEqual(6937, product.OnHandQuantity);
		}

		[Test]
		public void TestAddProduct()
		{
			Product p = new Product();
			p.ProductCode = "ZZZZ";
			p.Description = "Test Product";
			p.UnitPrice = 99.99M;
			p.OnHandQuantity = 2;
			ProductDB.AddProduct(p);

			p = ProductDB.GetProduct("ZZZZ      ");
			Assert.AreEqual("ZZZZ      ", p.ProductCode);
			Assert.AreEqual(2, p.OnHandQuantity);
		}
	}
}
