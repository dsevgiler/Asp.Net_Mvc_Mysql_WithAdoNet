using MySql.Data.MySqlClient;
using Soru2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Soru2.Repository
{
    public class ProductDal
    {
        private DBMySqlConn conn;

        public List<products> ProductsList()
        {
            conn = new DBMySqlConn();
            List<products> plist = new List<products>();
            MySqlCommand cmd = conn.GetSqlCommand();
            cmd.CommandText = "Select * from products p " +
                "inner join categories c on p.CategoryID = c.CategoryID ";

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                products pk = new products();

                pk.ProductID = Convert.ToInt32(dr["ProductID"]);
                pk.ProductName = dr["ProductName"].ToString();
                pk.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                pk.UnitInStock = Convert.ToInt32(dr["UnitInStock"]);
                pk.CategoryName = dr["CategoryName"].ToString();
                pk.Price = Convert.ToDouble(dr["Price"]);

                plist.Add(pk);
            }

            conn.CloseConnection();
            dr.Dispose();

            return plist;

        }

        public products ProductDetail(int id)
        {
            conn = new DBMySqlConn();
            MySqlCommand cmd = conn.GetSqlCommand();
            cmd.CommandText = @"Select * from products p " +
                "inner join categories c on p.CategoryID = c.CategoryID " +
                "where ProductID = @proId";
            cmd.Parameters.AddWithValue("@proId", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            products pro = new products();

            while (dr.Read())
            {
                pro.ProductID = Convert.ToInt32(dr["ProductID"]);
                pro.ProductName = dr["ProductName"].ToString();
                pro.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                pro.CategoryName = dr["CategoryName"].ToString();
                pro.UnitInStock = Convert.ToInt32(dr["UnitInStock"]);
                pro.Price = Convert.ToDouble(dr["Price"]);
            }

            conn.CloseConnection();
            dr.Dispose();

            return pro;
        }

        public void AddProduct(products pro)
        {
            conn = new DBMySqlConn();

            MySqlCommand cmd = conn.GetSqlCommand();
            cmd.CommandText = "Insert Into products (ProductID, CategoryID, ProductName, UnitInStock, Price) values (@ProductID, @CategoryID, @ProductName, @UnitInStock, @Price)";

            cmd.Parameters.AddWithValue("ProductID", pro.ProductID);
            cmd.Parameters.AddWithValue("CategoryID", pro.CategoryID);
            cmd.Parameters.AddWithValue("ProductName", pro.ProductName);
            cmd.Parameters.AddWithValue("UnitInStock", pro.UnitInStock);
            cmd.Parameters.AddWithValue("Price", pro.Price);

            cmd.ExecuteNonQuery();

            conn.CloseConnection();
        }

        public void UpdateProduct(products pro)
        {
            conn = new DBMySqlConn();

            MySqlCommand cmd = conn.GetSqlCommand();
            cmd.CommandText = "Update products set ProductID=@ProductID, CategoryID=@CategoryID,ProductName=@ProductName,UnitInStock=@UnitInStock,Price=@Price where ProductID=@ProductID";

            cmd.Parameters.AddWithValue("ProductID", pro.ProductID);
            cmd.Parameters.AddWithValue("CategoryID", pro.CategoryID);
            cmd.Parameters.AddWithValue("ProductName", pro.ProductName);
            cmd.Parameters.AddWithValue("UnitInStock", pro.UnitInStock);
            cmd.Parameters.AddWithValue("Price", pro.Price);

            cmd.ExecuteNonQuery();

            conn.CloseConnection();
        }

        public void DeleteProduct(int id)
        {
            conn = new DBMySqlConn();

            MySqlCommand cmd = conn.GetSqlCommand();
            cmd.CommandText = "Delete from products where ProductID = @id";
            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();

            conn.CloseConnection();
        }

        public List<category> CategoryList()
        {
            conn = new DBMySqlConn();
            List<category> catlist = new List<category>();

            MySqlCommand cmd = conn.GetSqlCommand();
            cmd.CommandText = "Select * from categories";

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                category cat = new category();

                cat.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                cat.CategoryName = dr["CategoryName"].ToString();

                catlist.Add(cat);
            }

            conn.CloseConnection();
            dr.Dispose();

            return catlist;
        }



    }
}