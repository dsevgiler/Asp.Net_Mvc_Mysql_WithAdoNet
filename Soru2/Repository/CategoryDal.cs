using MySql.Data.MySqlClient;
using Soru2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Soru2.Repository
{
    public class CategoryDal
    {
        private DBMySqlConn conn;

        public List<category> CategoryList()
        {
            conn = new DBMySqlConn();
            List<category> plist = new List<category>();
            MySqlCommand cmd = conn.GetSqlCommand();
            cmd.CommandText = "Select * from categories "; //where IsActive = 1

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                category ck = new category();

                ck.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                ck.CategoryName = dr["CategoryName"].ToString();
                ck.IsActive = Convert.ToByte(dr["IsActive"]) == 1 ? true : false;
                ck.Order = Convert.ToByte(dr["Order"]);

                plist.Add(ck);
            }

            conn.CloseConnection();
            dr.Dispose();

            return plist;

        }

        public category CategoryDetail(int id)
        {
            conn = new DBMySqlConn();
            MySqlCommand cmd = conn.GetSqlCommand();
            cmd.CommandText = @"Select * from categories p where CategoryID = @catId";
            cmd.Parameters.AddWithValue("@catId", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            category ck = new category();

            while (dr.Read())
            {
                ck.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                ck.CategoryName = dr["CategoryName"].ToString();
                ck.IsActive = Convert.ToByte(dr["IsActive"]) == 1 ? true : false;
                ck.Order = Convert.ToByte(dr["Order"]);
            }

            conn.CloseConnection();
            dr.Dispose();

            return ck;
        }

        public void AddCategory(category cat)
        {
            conn = new DBMySqlConn();

            MySqlCommand cmd = conn.GetSqlCommand();
            cmd.CommandText = "Insert Into categories (CategoryName, IsActive, `Order`) values (@CategoryName, @IsActive, @Order)";

           // cmd.Parameters.AddWithValue("CategoryID", cat.CategoryID);
            cmd.Parameters.AddWithValue("CategoryName", cat.CategoryName);
            cmd.Parameters.AddWithValue("IsActive", cat.IsActive ? 1 : 0);
            cmd.Parameters.AddWithValue("Order", cat.Order);

            cmd.ExecuteNonQuery();

            conn.CloseConnection();
        }

        public void UpdateProduct(category cat)
        {
            conn = new DBMySqlConn();

            MySqlCommand cmd = conn.GetSqlCommand();
            cmd.CommandText = "Update categories set CategoryID=@CategoryID, CategoryName=@CategoryName,IsActive=@IsActive,`Order`=@Order where CategoryID=@CategoryID";

            cmd.Parameters.AddWithValue("CategoryID", cat.CategoryID);
            cmd.Parameters.AddWithValue("CategoryName", cat.CategoryName);
            cmd.Parameters.AddWithValue("IsActive", cat.IsActive ? 1 : 0);
            cmd.Parameters.AddWithValue("Order", cat.Order);

            cmd.ExecuteNonQuery();

            conn.CloseConnection();
        }

        public void DeleteProduct(int id)
        {
            conn = new DBMySqlConn();

            MySqlCommand cmd = conn.GetSqlCommand();
            cmd.CommandText = "Delete from categories where CategoryID = @id";
            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();

            conn.CloseConnection();
        }


    }
}