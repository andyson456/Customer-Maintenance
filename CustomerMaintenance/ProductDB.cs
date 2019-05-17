using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CustomerMaintenance
{
	public class ProductDB
	{
		public static Product GetProduct(string prodCode)
		{
			SqlConnection connection = MMABooksDB.GetConnection();
			string selectStatement
				= "SELECT * "
				+ "FROM Products "
				+ "WHERE ProductCode = @ProductCode"; // @ProductCode points to the customerID parameter
			SqlCommand selectCommand =
				new SqlCommand(selectStatement, connection);
			selectCommand.Parameters.AddWithValue("@ProductCode", prodCode);

			try
			{
				connection.Open();
				SqlDataReader prodReader =
					selectCommand.ExecuteReader(CommandBehavior.SingleRow);
				if (prodReader.Read())
				{
					Product product = new Product();
					product.ProductCode = prodReader["ProductCode"].ToString();
					product.Description= prodReader["Description"].ToString();
					product.UnitPrice = (decimal)prodReader["UnitPrice"];
					product.OnHandQuantity = (int)prodReader["OnHandQuantity"];
					prodReader.Close();
					return product;
				}
				else
				{
					return null;
				}
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				connection.Close();
			}
		}

		public static void AddProduct(Product product)
		{
			SqlConnection connection = MMABooksDB.GetConnection();
			string insertStatement =
				"INSERT Products " +
				"(ProductCode, Description, UnitPrice, OnHandQuantity) " +
				"VALUES (@ProductCode, @Description, @UnitPrice, @OnHandQuantity)";
			SqlCommand insertCommand =
				new SqlCommand(insertStatement, connection);
			insertCommand.Parameters.AddWithValue(
				"@ProductCode", product.ProductCode);
			insertCommand.Parameters.AddWithValue(
				"@Description", product.Description);
			insertCommand.Parameters.AddWithValue(
				"@UnitPrice", product.UnitPrice);
			insertCommand.Parameters.AddWithValue(
				"@OnHandQuantity", product.OnHandQuantity);
			try
			{
				connection.Open();
				insertCommand.ExecuteNonQuery();
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				connection.Close();
			}
		}
	}
}
