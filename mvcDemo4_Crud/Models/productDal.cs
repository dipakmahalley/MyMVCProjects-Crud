using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace mvcDemo4_Crud.Models
{
    public class productDal
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=e_com;Integrated Security=True");
        SqlCommand cmd;
        product p = new product();

        public int AddNewProduct(product p)
        {
            cmd = new SqlCommand("Insert into products(product_id,category_id,product_name,description,video_url,price,product_posted_date,product_image) values(@product_id,@category_id,@product_name,@description,@video_url,@price,@product_posted_date,@product_image)", con);
            cmd.Parameters.AddWithValue("@product_id", p.product_id);
            cmd.Parameters.AddWithValue("@category_id", p.category_id);
            cmd.Parameters.AddWithValue("@product_name", p.product_name);
            cmd.Parameters.AddWithValue("@description", p.description);
            cmd.Parameters.AddWithValue("@video_url", p.video_url);
            cmd.Parameters.AddWithValue("@price", p.price);
            cmd.Parameters.AddWithValue("@product_posted_date", p.product_posted_date);
            cmd.Parameters.AddWithValue("@product_image", p.product_image);
            con.Open();
            int rowsaffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsaffected;
        }
        public int DeleteProduct(int? id)
        {
            cmd = new SqlCommand("Delete from products where product_id="+id, con);
            con.Open();
            int rowsaffected=cmd.ExecuteNonQuery();
            con.Close();
            return rowsaffected;
        }
        public int UpdateProduct(product p)
        {
            cmd = new SqlCommand("Update products set category_id=@category_id,product_name=@product_name,description=@description,video_url=@video_url,price=@price,product_posted_date=@product_posted_date,product_image=@product_image where product_id=@product_id", con);
            cmd.Parameters.AddWithValue("@product_id", p.product_id);
            cmd.Parameters.AddWithValue("@category_id", p.category_id);
            cmd.Parameters.AddWithValue("@product_name", p.product_name);
            cmd.Parameters.AddWithValue("@description", p.description);
            cmd.Parameters.AddWithValue("@video_url", p.video_url);
            cmd.Parameters.AddWithValue("@price", p.price);
            cmd.Parameters.AddWithValue("@product_posted_date", p.product_posted_date);
            cmd.Parameters.AddWithValue("@product_image", p.product_image);
            con.Open();
            int rowsaffected=cmd.ExecuteNonQuery();
            con.Close();
            return rowsaffected;
        }
        public product GetProductById(int? id)
        {
            cmd = new SqlCommand("select * from products where product_id="+id, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    p.product_id = Convert.ToInt32(dr["product_id"]);
                    p.category_id = Convert.ToInt32(dr["category_id"]);
                    p.product_name = dr["product_name"].ToString();
                    p.description = dr["description"].ToString();
                    p.video_url = dr["video_url"].ToString();
                    p.price = Convert.ToInt32(dr["price"]);
                    p.product_posted_date = dr["product_posted_date"].ToString();
                    p.product_image = dr["product_image"].ToString();
                    return p;
                }
            }
            con.Close();
            return null;
        }
        //public product GetProductByName(string prefix)
        //{
        //    cmd = new SqlCommand("select * from products where product_Name Like '" +prefix + "%'", con);
        //    con.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        p.product_id = Convert.ToInt32(dr["product_id"]);
        //        p.category_id = Convert.ToInt32(dr["category_id"]);
        //        p.product_name = dr["product_name"].ToString();
        //        p.description = dr["description"].ToString();
        //        p.video_url = dr["video_url"].ToString();
        //        p.price = Convert.ToInt32(dr["price"]);
        //        p.product_posted_date = dr["product_posted_date"].ToString();
        //        p.product_image = dr["product_image"].ToString();
        //    }
        //    con.Close();
        //    return p;
        //}
        public List<product> GetAllProducts()
        {
            cmd = new SqlCommand("Select product_id,category_id,product_name,price,product_posted_date,product_image from products",con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                List<product> plist = new List<product>();
                while (dr.Read())
                {
                    product p = new product();
                    p.product_id = Convert.ToInt32(dr["product_id"]);
                    p.category_id = Convert.ToInt32(dr["category_id"]);
                    p.product_name = dr["product_name"].ToString();
                   // p.description = dr["description"].ToString();
                   // p.video_url = dr["video_url"].ToString();
                    p.price = Convert.ToInt32(dr["price"]);
                    p.product_posted_date = dr["product_posted_date"].ToString();
                    p.product_image = dr["product_image"].ToString();

                    plist.Add(p);
                }
                con.Close();
                return plist;
            }
            return null;
        }
    }
}