using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.UI.WebControls;

namespace Acik_Artirma
{
    public class SQLBaglanti
    {
        public SqlConnection con;
        SqlCommand cmd = null;
        string sorgu = "";

        int id = 0;
        List<string> imagePaths = new List<string>();
        string mesaj = "";
        public static string oldUsername = "";
        public static string oldMail = "";

        public SQLBaglanti()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDb"].ToString());
        }

        public string getMesaj()
        {
            return mesaj;
        }

        public string getAdSoyad(string tabloAdi, string username, string password)
        {
            int id = this.Giris(tabloAdi, username, password);
            sorgu = "select * from Users Where id=@id";
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string ad = "";
            string soyad = "";
            while (dr.Read())
            {
                ad = dr["ad"].ToString();
                soyad = dr["soyad"].ToString();
            }
            cmd.Parameters.Clear();
            dr.Close();
            con.Close();


            return ad + " " + soyad;
        }

        public string getAvatar(string tabloAdi, string username, string password)
        {
            SqlCommand sqlCommand;
            sorgu = "SELECT picture FROM Users WHERE id=@id";
            cmd.CommandType = CommandType.Text;
            sqlCommand = new SqlCommand(sorgu, con);
            int id = Giris(tabloAdi, username, password);
            sqlCommand.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            string avatar = "";
            while (dr.Read())
            {
                avatar = dr["picture"].ToString();

            }
            if (avatar == null || avatar == "")
            {
                avatar = "avatar.png";
            }
            dr.Close();
            con.Close();
            return avatar;
        }

        public List<string> getImagePaths()
        {
            return imagePaths;
        }

        public int mukerrerKontrol(string tabloAdi, string sutun, string aranan)
        {
            int sonuc = 0;
            cmd = new SqlCommand();
            con.Open();

            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "mukerrerKayitKontrol";
            cmd.Parameters.Add("@TabloAdi", SqlDbType.NVarChar, 50).Value = tabloAdi;
            cmd.Parameters.Add("@SutunAdi", SqlDbType.NVarChar, 50).Value = sutun;
            cmd.Parameters.Add("@ArananKelime", SqlDbType.NVarChar, 50).Value = aranan;
            sonuc = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();
            return sonuc;
        }

        public void Sil(string tabloAdi, string id)
        {
            if (tabloAdi == "Products")
            {
                sorgu = " DELETE Products FROM Products WHERE id = @id; ";
                cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                sorgu = " DELETE ProductsPictures FROM ProductsPictures WHERE ProductsID = @id; ";
            }
            else if (tabloAdi == "Users")
            {
                sorgu = " DELETE Users FROM Users WHERE id = @id; ";
            }

            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Ekle(string tabloAdi, HttpPostedFile file, string dir1, string dir2, params string[] degerler)
        {
            try
            {
                if (tabloAdi == "Users")
                {
                    if (mukerrerKontrol(tabloAdi, "mail", degerler[2].ToString()) != 0 || mukerrerKontrol(tabloAdi, "username", degerler[0].ToString()) != 0)
                    {
                        mesaj = "Böyle bir E-Mail ya da Kullanıcı Adı Zaten mevcut!";
                    }
                    else
                    {
                        cmd = new SqlCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "EKLE";
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@TabloAdi", SqlDbType.VarChar, int.MaxValue).Value = tabloAdi;
                        cmd.Parameters.Add("@KolonSayisi", SqlDbType.Int, 128).Value = (degerler.Length + 1);
                        cmd.Parameters.Add("@Value_1", SqlDbType.VarChar, int.MaxValue).Value = degerler[0];
                        cmd.Parameters.Add("@Value_2", SqlDbType.VarChar, int.MaxValue).Value = degerler[1];
                        cmd.Parameters.Add("@Value_3", SqlDbType.VarChar, int.MaxValue).Value = degerler[2];
                        cmd.Parameters.Add("@Value_4", SqlDbType.VarChar, int.MaxValue).Value = "";
                        cmd.Parameters.Add("@Value_5", SqlDbType.VarChar, int.MaxValue).Value = degerler[3];
                        cmd.Parameters.Add("@Value_6", SqlDbType.VarChar, int.MaxValue).Value = degerler[4];
                        cmd.Parameters.Add("@Value_7", SqlDbType.VarChar, int.MaxValue).Value = degerler[5];
                        id = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();

                        uploadPic(file, dir1, dir2);

                        sorgu = "UPDATE " + tabloAdi + " SET picture = @picture WHERE id = @id";
                        cmd = new SqlCommand(sorgu, con);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@picture", imagePaths[0]);
                        cmd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        mesaj = "Başarılı bir şekilde Kayıt Edildi.";
                    }
                }

                else if (tabloAdi == "Products")
                {
                    cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "EKLE";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@TabloAdi", SqlDbType.VarChar, int.MaxValue).Value = tabloAdi;
                    cmd.Parameters.Add("@KolonSayisi", SqlDbType.Int, 128).Value = (degerler.Length + 2);
                    cmd.Parameters.Add("@Value_1", SqlDbType.VarChar, int.MaxValue).Value = HttpContext.Current.Session["LoginTable"];
                    cmd.Parameters.Add("@Value_2", SqlDbType.VarChar, int.MaxValue).Value = HttpContext.Current.Session["LoginID"];
                    cmd.Parameters.Add("@Value_3", SqlDbType.VarChar, int.MaxValue).Value = degerler[0];
                    cmd.Parameters.Add("@Value_4", SqlDbType.VarChar, int.MaxValue).Value = degerler[1];
                    cmd.Parameters.Add("@Value_5", SqlDbType.VarChar, int.MaxValue).Value = degerler[2];
                    cmd.Parameters.Add("@Value_6", SqlDbType.VarChar, int.MaxValue).Value = degerler[3];
                    cmd.Parameters.Add("@Value_7", SqlDbType.VarChar, int.MaxValue).Value = degerler[4];
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    uploadPic(file, dir1, dir2);

                    sorgu = "INSERT INTO ProductsPictures (ProductsID,picture) VALUES (@ProductsID,@picture)";
                    for (int i = 0; i < imagePaths.Count; i++)
                    {
                        cmd = new SqlCommand(sorgu, con);
                        cmd.Parameters.AddWithValue("@ProductsID", id);
                        cmd.Parameters.AddWithValue("@picture", imagePaths[i]);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    mesaj = "Ürün başarılı bir şekilde Kayıt Edildi.";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        public List<Products> UserUrunleriGuncelle(string id)
        {
            List<Products> liste = new List<Products>();
            sorgu = "SELECT * FROM Products WHERE IDEkleyen = @id";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Products products = new Products();
                products.id = (dr[0] == DBNull.Value) ? -1 : Convert.ToInt32(dr[0]);
                products.rol = (dr[1] == DBNull.Value) ? string.Empty : dr[1].ToString();
                products.UserID = (dr[2] == DBNull.Value) ? -1 : Convert.ToInt32(dr[2]);
                products.baslik = (dr[3] == DBNull.Value) ? string.Empty : dr[3].ToString();
                products.basFiyat = (dr[4] == DBNull.Value) ? -1 : Convert.ToInt32(dr[4]);
                products.basTarih = (dr[5] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr[5]);
                products.bitTarih = (dr[6] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr[6]);
                products.aciklama = (dr[7] == DBNull.Value) ? string.Empty : dr[7].ToString();

                liste.Add(products);
            }
            con.Close();
            dr.Close();

            sorgu = "SELECT * FROM ProductsPictures WHERE ProductsID = @ProductsID";
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            for (int i = 0; i < liste.Count; i++)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ProductsID", liste[i].id);
                dr = cmd.ExecuteReader();
                List<string> test = new List<string>();
                test.Clear();
                while (dr.Read())
                {
                    test.Add(dr[2].ToString());
                }
                liste[i].pictures = test;
                dr.Close();
            }
            con.Close();

            cmd = new SqlCommand("SELECT GETDATE()", con);
            con.Open();
            for (int i = 0; i < liste.Count; i++)
            {
                cmd.Parameters.Clear();
                var dt = (DateTime)cmd.ExecuteScalar();

                if ((liste[i].basTarih - dt).TotalSeconds <= 0)
                {
                    liste[i].basladiMi = true;
                }
                else
                {
                    liste[i].basladiMi = false;
                }

                if ((liste[i].bitTarih - dt).TotalSeconds <= 0)
                {
                    liste[i].bittiMi = true;
                }
                else
                {
                    liste[i].bittiMi = false;
                }
            }
            con.Close();

            sorgu = "SELECT * FROM Users WHERE id=@id";
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            for (int i = 0; i < liste.Count; i++)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", liste[i].UserID);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    liste[i].satanKisi = dr["ad"].ToString() + " " + dr["soyad"].ToString();
                }
                dr.Close();
            }
            con.Close();




            sorgu = "SELECT MAX(teklifler) FROM auctions WHERE IDProducts=@IDProducts";
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            for (int i = 0; i < liste.Count; i++)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IDProducts", liste[i].id);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr[0] != DBNull.Value)
                    {
                        liste[i].enYuksekTeklif = Convert.ToInt32(dr[0]);

                    }
                    else
                    {
                        liste[i].enYuksekTeklif = -999;
                    }
                }
                dr.Close();
            }
            con.Close();

            return liste;
        }

        public List<Products> UserinUrunleriniGoster(string id)
        {
            List<Products> liste = new List<Products>();
            sorgu = "SELECT * FROM Products WHERE IDEkleyen = @id";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Products products = new Products();
                products.id = (dr[0] == DBNull.Value) ? -1 : Convert.ToInt32(dr[0]);
                products.rol = (dr[1] == DBNull.Value) ? string.Empty : dr[1].ToString();
                products.UserID = (dr[2] == DBNull.Value) ? -1 : Convert.ToInt32(dr[2]);
                products.baslik = (dr[3] == DBNull.Value) ? string.Empty : dr[3].ToString();
                products.basFiyat = (dr[4] == DBNull.Value) ? -1 : Convert.ToInt32(dr[4]);
                //products.basTarih = (dr[5] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr[5];
                products.basTarih = (dr[5] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr[5]);
                products.bitTarih = (dr[6] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr[6]);
                products.aciklama = (dr[7] == DBNull.Value) ? string.Empty : dr[7].ToString();

                liste.Add(products);
            }
            con.Close();
            dr.Close();

            sorgu = "SELECT * FROM ProductsPictures WHERE ProductsID = @ProductsID";
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            for (int i = 0; i < liste.Count; i++)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ProductsID", liste[i].id);
                dr = cmd.ExecuteReader();
                List<string> test = new List<string>();
                test.Clear();
                while (dr.Read())
                {
                    test.Add(dr[2].ToString());
                }
                liste[i].pictures = test;
                dr.Close();
            }
            con.Close();

            cmd = new SqlCommand("SELECT GETDATE()", con);
            con.Open();
            for (int i = 0; i < liste.Count; i++)
            {
                cmd.Parameters.Clear();
                var dt = (DateTime)cmd.ExecuteScalar();

                if ((liste[i].basTarih - dt).TotalSeconds <= 0)
                {
                    liste[i].basladiMi = true;
                }
                else
                {
                    liste[i].basladiMi = false;
                }

                if ((liste[i].bitTarih - dt).TotalSeconds <= 0)
                {
                    liste[i].bittiMi = true;
                }
                else
                {
                    liste[i].bittiMi = false;
                }
            }
            con.Close();

            sorgu = "SELECT * FROM Users WHERE id=@id";
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            for (int i = 0; i < liste.Count; i++)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", liste[i].UserID);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    liste[i].satanKisi = dr["ad"].ToString() + " " + dr["soyad"].ToString();
                }
                dr.Close();
            }
            con.Close();




            sorgu = "SELECT MAX(teklifler) FROM auctions WHERE IDProducts=@IDProducts";
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            for (int i = 0; i < liste.Count; i++)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IDProducts", liste[i].id);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr[0] != DBNull.Value)
                    {
                        liste[i].enYuksekTeklif = Convert.ToInt32(dr[0]);

                    }
                    else
                    {
                        liste[i].enYuksekTeklif = -999;
                    }
                }
                dr.Close();
            }
            con.Close();

            return liste;
        }

        public List<string> Goster()
        {
            List<string> degerler = new List<string>();
            string tablo = HttpContext.Current.Session["LoginTable"].ToString();
            string id = HttpContext.Current.Session["LoginID"].ToString();
            sorgu = "SELECT * FROM " + tablo + " WHERE id = @id";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (tablo == "Admins")
            {
                Roles.Admins admins = new Roles.Admins();
                while (dr.Read())
                {
                    admins.id = (dr["id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["id"]);
                    admins.username = (dr["username"] == DBNull.Value) ? "-1" : dr["username"].ToString();
                    admins.password = (dr["password"] == DBNull.Value) ? "-1" : dr["password"].ToString();
                }
                dr.Close();
                con.Close();
                degerler.Add(admins.id.ToString());
                degerler.Add(admins.username);
                degerler.Add(admins.password);
            }
            else if (tablo == "Users")
            {
                Roles.Users users = new Roles.Users();
                while (dr.Read())
                {
                    users.id = (dr["id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["id"]);
                    users.username = (dr["username"] == DBNull.Value) ? "-1" : dr["username"].ToString();
                    users.password = (dr["password"] == DBNull.Value) ? "-1" : dr["password"].ToString();
                    users.mail = (dr["mail"] == DBNull.Value) ? "-1" : dr["mail"].ToString();
                    users.picture = (dr["picture"] == DBNull.Value) ? "-1" : dr["picture"].ToString();
                    users.bakiye = (dr["bakiye"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["bakiye"]);
                    users.ad = (dr["ad"] == DBNull.Value) ? "-1" : dr["ad"].ToString();
                    users.soyad = (dr["soyad"] == DBNull.Value) ? "-1" : dr["soyad"].ToString();
                }
                dr.Close();
                con.Close();
                degerler.Add(users.id.ToString());
                degerler.Add(users.username);
                degerler.Add(users.password);
                degerler.Add(users.mail);
                degerler.Add(users.picture);
                degerler.Add(users.bakiye.ToString());
                degerler.Add(users.ad);
                degerler.Add(users.soyad);
            }
            return degerler;
        }

        public void UserProfilGuncelle(string sutun, string deger)
        {
            if (sutun == "ad")
            {
                if (deger != string.Empty)
                {
                    sorgu = "UPDATE Users SET ad = @ad WHERE id = @id";
                    cmd = new SqlCommand(sorgu, con);
                    cmd.Parameters.AddWithValue("@ad", deger);
                    cmd.Parameters.AddWithValue("@id", HttpContext.Current.Session["LoginID"]);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            else if (sutun == "soyad")
            {
                if (deger != string.Empty)
                {
                    sorgu = "UPDATE Users SET soyad = @soyad WHERE id = @id";
                    cmd.Parameters.Clear();
                    cmd = new SqlCommand(sorgu, con);
                    cmd.Parameters.AddWithValue("@soyad", deger);
                    cmd.Parameters.AddWithValue("@id", HttpContext.Current.Session["LoginID"]);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }


        }

        public void UserProfilGuncelleSifre(string yeniSifre, string eskiSifre)
        {

            string eskiSifreTemp = "";
            sorgu = "SELECT password FROM Users WHERE id = @id";
            cmd.Parameters.Clear();
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@id", HttpContext.Current.Session["LoginID"]);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                eskiSifreTemp = dr[0].ToString();
            }
            dr.Close();
            con.Close();
            if (yeniSifre != string.Empty)
            {
                if (eskiSifre == eskiSifreTemp)
                {
                    sorgu = "UPDATE Users SET password = @password WHERE id = @id";
                    cmd = new SqlCommand(sorgu, con);
                    cmd.Parameters.AddWithValue("@password", yeniSifre);
                    cmd.Parameters.AddWithValue("@id", HttpContext.Current.Session["LoginID"]);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    mesaj = "Girmiş olduğunuz şifre eski şifreniz ile uyuşmuyor!";
                }
            }

        }

        public void UserProfilGuncelleAvatar(HttpPostedFile file)
        {
            uploadPic(file, "Users", "Avatars");
            sorgu = "UPDATE Users SET picture = @picture WHERE id =@id";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@picture", getImagePaths()[0]);
            cmd.Parameters.AddWithValue("@id", HttpContext.Current.Session["LoginID"]);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateClientProducts(string id, List<string> degerler)
        {
            sorgu = "UPDATE Products SET baslik=@baslik, basFiyat=@basFiyat, basTarih=@basTarih,bitTarih=@bitTarih, aciklama=@aciklama WHERE id=@id";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
            cmd.Parameters.AddWithValue("@baslik", degerler[0]);
            cmd.Parameters.AddWithValue("@basFiyat", int.Parse(degerler[1]));
            cmd.Parameters.AddWithValue("@basTarih", Convert.ToDateTime(degerler[2]));
            cmd.Parameters.AddWithValue("@bitTarih", Convert.ToDateTime(degerler[3]));
            cmd.Parameters.AddWithValue("@aciklama", degerler[4]);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            //sorgu = "UPDATE ProductsPictures SET picture=@Picture WHERE ProductsID=@ProductsID";
            //for (int i = 0; i < path.Count; i++)
            //{
            //    cmd = new SqlCommand(sorgu, con);
            //    cmd.Parameters.AddWithValue("@ProductsID", id);
            //    cmd.Parameters.AddWithValue("@picture", path[i]);
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}
        }

        public List<Products> AuctionGoster()
        {
            List<Products> liste = new List<Products>();
            sorgu = "SELECT * FROM Products";
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Products products = new Products();
                products.id = (dr[0] == DBNull.Value) ? -1 : Convert.ToInt32(dr[0]);
                products.rol = (dr[1] == DBNull.Value) ? string.Empty : dr[1].ToString();
                products.UserID = (dr[2] == DBNull.Value) ? -1 : Convert.ToInt32(dr[2]);
                products.baslik = (dr[3] == DBNull.Value) ? string.Empty : dr[3].ToString();
                products.basFiyat = (dr[4] == DBNull.Value) ? -1 : Convert.ToInt32(dr[4]);
                products.basTarih = (dr[5] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr[5]);
                products.bitTarih = (dr[6] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr[6]);
                products.aciklama = (dr[7] == DBNull.Value) ? string.Empty : dr[7].ToString();
                liste.Add(products);
            }
            con.Close();
            dr.Close();

            sorgu = "SELECT * FROM ProductsPictures WHERE ProductsID = @ProductsID";
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            for (int i = 0; i < liste.Count; i++)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ProductsID", liste[i].id);
                dr = cmd.ExecuteReader();
                List<string> test = new List<string>();
                test.Clear();
                while (dr.Read())
                {
                    test.Add(dr[2].ToString());
                }
                liste[i].pictures = test;
                dr.Close();
            }
            con.Close();

            //cmd = new SqlCommand("SELECT GETDATE()", con);
            //con.Open();
            //for (int i = 0; i < liste.Count; i++)
            //{
            //    cmd.Parameters.Clear();
            //    var dt = (DateTime)cmd.ExecuteScalar();

            //    if ((liste[i].basTarih - dt).TotalSeconds <= 0)
            //    {
            //        liste[i].basladiMi = true;
            //    }
            //    else
            //    {
            //        liste[i].basladiMi = false;
            //    }

            //    if ((liste[i].bitTarih - dt).TotalSeconds <= 0)
            //    {
            //        liste[i].bittiMi = true;
            //    }
            //    else
            //    {
            //        liste[i].bittiMi = false;
            //    }
            //}
            //con.Close();

            sorgu = "SELECT * FROM Users WHERE id=@id";
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            for (int i = 0; i < liste.Count; i++)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", liste[i].UserID);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    liste[i].satanKisi = dr["ad"].ToString() + " " + dr["soyad"].ToString();
                }
                dr.Close();
            }
            con.Close();

            sorgu = "SELECT MAX(teklifler) FROM auctions WHERE IDProducts=@IDProducts";
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            for (int i = 0; i < liste.Count; i++)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IDProducts", liste[i].id);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr[0] != DBNull.Value)
                    {
                        liste[i].enYuksekTeklif = Convert.ToInt32(dr[0]);

                    }
                    else
                    {
                        liste[i].enYuksekTeklif = -999;
                    }
                }
                dr.Close();
            }
            con.Close();

            return liste;
        }

        public int Giris(string tabloAdi, string username, string password)
        {
            int result = -1;
            try
            {
                cmd = new SqlCommand();
                con.Open();

                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "girisKontrol";
                cmd.Parameters.Add("@TabloAdi", SqlDbType.NVarChar, 50).Value = tabloAdi;
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = password;
                result = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return result;
        }

        public void uploadPic(HttpPostedFile file, string dir1, string dir2)
        {
            if (dir2.Equals("Avatars"))
            {
                if (file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    imagePaths.Add(Path.Combine("~/Images/" + dir1 + "/" + id.ToString() + "/" + dir2, fileName));
                    string image = HttpContext.Current.Server.MapPath(imagePaths[0]);
                    if (!(Directory.Exists(HttpContext.Current.Server.MapPath("~/Images/" + dir1 + "/" + id.ToString() + "/" + dir2))))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Images/" + dir1 + "/" + id.ToString() + "/" + dir2));
                    }
                    file.SaveAs(image);
                }
            }
            else
            {
                HttpFileCollection httpFileCollection = HttpContext.Current.Request.Files;
                for (int i = 0; i < httpFileCollection.Count; i++)
                {
                    file = httpFileCollection[i];
                    if (file.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(file.FileName);
                        imagePaths.Add(Path.Combine("~/Images/" + dir1 + "/" + id.ToString() + "/" + dir2, fileName));
                        string image = HttpContext.Current.Server.MapPath(imagePaths[i]);
                        if (!(Directory.Exists(HttpContext.Current.Server.MapPath("~/Images/" + dir1 + "/" + id.ToString() + "/" + dir2))))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Images/" + dir1 + "/" + id.ToString() + "/" + dir2));
                        }
                        file.SaveAs(image);
                    }
                }
            }

        }

        public void PopulateGridview(string tabloAdi, GridView tablo)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + tabloAdi, con);
            DataTable table = new DataTable();
            da.Fill(table);
            if (table.Rows.Count > 0)
            {
                tablo.DataSource = table;
                tablo.DataBind();
            }
            else
            {
                table.Rows.Add(table.NewRow());
                tablo.DataSource = table;
                tablo.DataBind();
                tablo.Rows[0].Cells.Clear();
                tablo.Rows[0].Cells.Add(new TableCell());
                tablo.Rows[0].Cells[0].ColumnSpan = table.Columns.Count;
                tablo.Rows[0].Cells[0].Text = "Veritabanında Hiçbir Müşteri Yok ..!";
                tablo.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
            con.Close();

        }

        public void rowCommandEkle(string tabloAdi, GridView tablo, GridViewCommandEventArgs e, HttpPostedFile file, string mesaj)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                try
                {
                    if (tabloAdi == "Users")
                    {
                        Roles.Users user = new Roles.Users();
                        user.username = (tablo.FooterRow.FindControl("txtUsernameFooter") as TextBox).Text.Trim();
                        user.password = (tablo.FooterRow.FindControl("txtPasswordFooter") as TextBox).Text.Trim();
                        user.mail = (tablo.FooterRow.FindControl("txtMailFooter") as TextBox).Text.Trim();
                        user.picture = (tablo.FooterRow.FindControl("txtPictureFooter") as TextBox).Text.Trim();
                        user.bakiye = Convert.ToInt32((tablo.FooterRow.FindControl("txtBakiyeFooter") as TextBox).Text.Trim());
                        user.ad = (tablo.FooterRow.FindControl("txtAdFooter") as TextBox).Text.Trim();
                        user.soyad = (tablo.FooterRow.FindControl("txtSoyadFooter") as TextBox).Text.Trim();
                        if (mukerrerKontrol(tabloAdi, "mail", (tablo.FooterRow.FindControl("txtMailFooter") as TextBox).Text.Trim()) != 0 || mukerrerKontrol(tabloAdi, "username", (tablo.FooterRow.FindControl("txtUsernameFooter") as TextBox).Text.Trim()) != 0)
                        {
                            mesaj = "Böyle bir E-Mail ya da Kullanıcı Adı Zaten mevcut!";
                        }
                        else
                        {
                            cmd = new SqlCommand();
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "EKLE";
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@TabloAdi", SqlDbType.VarChar, int.MaxValue).Value = tabloAdi;
                            cmd.Parameters.Add("@KolonSayisi", SqlDbType.Int, 128).Value = 7;
                            cmd.Parameters.Add("@Value_1", SqlDbType.VarChar, int.MaxValue).Value = user.username;
                            cmd.Parameters.Add("@Value_2", SqlDbType.VarChar, int.MaxValue).Value = user.password;
                            cmd.Parameters.Add("@Value_3", SqlDbType.VarChar, int.MaxValue).Value = user.mail;
                            cmd.Parameters.Add("@Value_4", SqlDbType.VarChar, int.MaxValue).Value = "";
                            cmd.Parameters.Add("@Value_5", SqlDbType.VarChar, int.MaxValue).Value = user.bakiye;
                            cmd.Parameters.Add("@Value_6", SqlDbType.VarChar, int.MaxValue).Value = user.ad;
                            cmd.Parameters.Add("@Value_7", SqlDbType.VarChar, int.MaxValue).Value = user.soyad;
                            id = Convert.ToInt32(cmd.ExecuteScalar());
                            con.Close();

                            PopulateGridview(tabloAdi, tablo);

                            uploadPic(file, "Users", "Avatars");

                            sorgu = "UPDATE Users SET picture = @picture WHERE id = @id";
                            cmd = new SqlCommand(sorgu, con);
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@picture", imagePaths[0]);
                            cmd.Parameters.AddWithValue("@id", id);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            mesaj = "Başarılı bir şekilde Kayıt Edildi.";
                        }
                    }

                    else if (tabloAdi == "Products")
                    {
                        Products products = new Products();
                        products.rol = HttpContext.Current.Session["LoginTable"].ToString();
                        products.UserID = Convert.ToInt32(HttpContext.Current.Session["LoginID"]);
                        products.baslik = (tablo.FooterRow.FindControl("txtBaslikFooter") as TextBox).Text.Trim();
                        products.basFiyat = Convert.ToInt32((tablo.FooterRow.FindControl("txtBasFiyatFooter") as TextBox).Text.Trim());
                        products.basTarih = Convert.ToDateTime(tablo.FooterRow.FindControl("basTarihFooter"));
                        products.bitTarih = Convert.ToDateTime(tablo.FooterRow.FindControl("bitTarihFooter"));
                        products.aciklama = (tablo.FooterRow.FindControl("txtAciklamaFooter") as TextBox).Text.Trim();
                        cmd = new SqlCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "EKLE";
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@TabloAdi", SqlDbType.VarChar, int.MaxValue).Value = tabloAdi;
                        cmd.Parameters.Add("@KolonSayisi", SqlDbType.Int, 128).Value = 8;
                        cmd.Parameters.Add("@Value_1", SqlDbType.VarChar, int.MaxValue).Value = products.rol;
                        cmd.Parameters.Add("@Value_2", SqlDbType.VarChar, int.MaxValue).Value = products.UserID;
                        cmd.Parameters.Add("@Value_3", SqlDbType.VarChar, int.MaxValue).Value = products.baslik;
                        cmd.Parameters.Add("@Value_4", SqlDbType.VarChar, int.MaxValue).Value = products.basFiyat;
                        cmd.Parameters.Add("@Value_5", SqlDbType.VarChar, int.MaxValue).Value = products.basTarih;
                        cmd.Parameters.Add("@Value_6", SqlDbType.VarChar, int.MaxValue).Value = products.bitTarih;
                        cmd.Parameters.Add("@Value_7", SqlDbType.VarChar, int.MaxValue).Value = products.aciklama;
                        id = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();

                        PopulateGridview(tabloAdi, tablo);

                        uploadPic(file, "Products", "Pictures");

                        sorgu = "INSERT INTO ProductsPictures (ProductsID,picture) VALUES (@ProductsID,@picture)";
                        for (int i = 0; i < imagePaths.Count; i++)
                        {
                            cmd = new SqlCommand(sorgu, con);
                            cmd.Parameters.AddWithValue("@ProductsID", id);
                            cmd.Parameters.AddWithValue("@picture", imagePaths[i]);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        mesaj = "Ürün başarılı bir şekilde Kayıt Edildi.";
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
        }

        public void rowEditing(string tabloAdi, GridView tablo, GridViewEditEventArgs e)
        {
            tablo.EditIndex = e.NewEditIndex;
            PopulateGridview(tabloAdi, tablo);
            oldMail = (tablo.Rows[e.NewEditIndex].FindControl("txtMail") as TextBox).Text.Trim();
            oldUsername = (tablo.Rows[e.NewEditIndex].FindControl("txtUsername") as TextBox).Text.Trim();
        }

        public void rowCancelling(string tabloAdi, GridView tablo)
        {
            tablo.EditIndex = -1;
            PopulateGridview(tabloAdi, tablo);
        }

        public void rowDeleting(string tabloAdi, GridView tablo, GridViewDeleteEventArgs e)
        {
            Sil(tabloAdi, tablo.DataKeys[e.RowIndex].Value.ToString());
            PopulateGridview(tabloAdi, tablo);
        }

        public void rowUpdating(string tabloAdi, GridView tablo, GridViewUpdateEventArgs e, HttpPostedFile file)
        {
            try
            {
                if (tabloAdi == "Users")
                {
                    Roles.Users user = new Roles.Users();
                    user.username = (tablo.Rows[e.RowIndex].FindControl("txtUsername") as TextBox).Text.Trim();
                    user.password = (tablo.Rows[e.RowIndex].FindControl("txtPassword") as TextBox).Text.Trim();
                    user.mail = (tablo.Rows[e.RowIndex].FindControl("txtMail") as TextBox).Text.Trim();
                    //user.picture = (tablo.Rows[e.RowIndex].FindControl("imageItem") as Image).ImageUrl.Trim();
                    user.bakiye = Convert.ToInt32((tablo.Rows[e.RowIndex].FindControl("txtBakiye") as TextBox).Text.Trim());
                    user.ad = (tablo.Rows[e.RowIndex].FindControl("txtAd") as TextBox).Text.Trim();
                    user.soyad = (tablo.Rows[e.RowIndex].FindControl("txtSoyad") as TextBox).Text.Trim();
                    user.id = Convert.ToInt32(tablo.DataKeys[e.RowIndex].Value.ToString());

                    if ((tablo.Rows[e.RowIndex].FindControl("txtMail") as TextBox).Text.Trim() == oldMail && (tablo.Rows[e.RowIndex].FindControl("txtUsername") as TextBox).Text.Trim() == oldUsername)
                    {
                        System.Diagnostics.Debug.WriteLine("if çalıştı");
                        sorgu = "UPDATE Users SET username=@username, password=@password, mail=@mail, bakiye=@bakiye, ad=@ad, soyad=@soyad WHERE id=@id";
                        cmd = new SqlCommand(sorgu, con);
                        con.Open();
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@username", user.username);
                        cmd.Parameters.AddWithValue("@password", user.password);
                        cmd.Parameters.AddWithValue("@mail", user.mail);
                        //cmd.Parameters.AddWithValue("@picture", user.picture);
                        cmd.Parameters.AddWithValue("@bakiye", user.bakiye.ToString());
                        cmd.Parameters.AddWithValue("@ad", user.ad);
                        cmd.Parameters.AddWithValue("@soyad", user.soyad);
                        cmd.Parameters.AddWithValue("@id", user.id);
                        id = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();

                        PopulateGridview(tabloAdi, tablo);

                        uploadPic(file, "Users", "Avatars");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("else çalıştı");
                        if (mukerrerKontrol(tabloAdi, "mail", (tablo.Rows[e.RowIndex].FindControl("txtMail") as TextBox).Text.Trim()) == 1 && mukerrerKontrol(tabloAdi, "username", (tablo.Rows[e.RowIndex].FindControl("txtUsername") as TextBox).Text.Trim()) == 1)
                        {
                            mesaj = "Böyle bir E-Mail ya da Kullanıcı Adı Zaten mevcut!";
                        }
                        else
                        {
                            sorgu = "UPDATE Users SET username=@username, password=@password, mail=@mail, bakiye=@bakiye, ad=@ad, soyad=@soyad WHERE id=@id";
                            cmd = new SqlCommand(sorgu, con);
                            con.Open();
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@username", user.username);
                            cmd.Parameters.AddWithValue("@password", user.password);
                            cmd.Parameters.AddWithValue("@mail", user.mail);
                            //cmd.Parameters.AddWithValue("@picture", user.picture);
                            cmd.Parameters.AddWithValue("@bakiye", user.bakiye.ToString());
                            cmd.Parameters.AddWithValue("@ad", user.ad);
                            cmd.Parameters.AddWithValue("@soyad", user.soyad);
                            cmd.Parameters.AddWithValue("@id", user.id);
                            id = Convert.ToInt32(cmd.ExecuteScalar());
                            con.Close();

                            PopulateGridview(tabloAdi, tablo);

                            uploadPic(file, "Users", "Avatars");
                        }
                    }

                }

                else if (tabloAdi == "Products")
                {
                    Products products = new Products();
                    products.rol = HttpContext.Current.Session["LoginTable"].ToString();
                    products.UserID = Convert.ToInt32(HttpContext.Current.Session["LoginID"]);
                    products.baslik = (tablo.FooterRow.FindControl("txtBaslikFooter") as TextBox).Text.Trim();
                    products.basFiyat = Convert.ToInt32((tablo.FooterRow.FindControl("txtBasFiyatFooter") as TextBox).Text.Trim());
                    products.basTarih = Convert.ToDateTime(tablo.FooterRow.FindControl("basTarihFooter"));
                    products.bitTarih = Convert.ToDateTime(tablo.FooterRow.FindControl("bitTarihFooter"));
                    products.aciklama = (tablo.FooterRow.FindControl("txtAciklamaFooter") as TextBox).Text.Trim();
                    cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "EKLE";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@TabloAdi", SqlDbType.VarChar, int.MaxValue).Value = tabloAdi;
                    cmd.Parameters.Add("@KolonSayisi", SqlDbType.Int, 128).Value = 8;
                    cmd.Parameters.Add("@Value_1", SqlDbType.VarChar, int.MaxValue).Value = products.rol;
                    cmd.Parameters.Add("@Value_2", SqlDbType.VarChar, int.MaxValue).Value = products.UserID;
                    cmd.Parameters.Add("@Value_3", SqlDbType.VarChar, int.MaxValue).Value = products.baslik;
                    cmd.Parameters.Add("@Value_4", SqlDbType.VarChar, int.MaxValue).Value = products.basFiyat;
                    cmd.Parameters.Add("@Value_5", SqlDbType.VarChar, int.MaxValue).Value = products.basTarih;
                    cmd.Parameters.Add("@Value_6", SqlDbType.VarChar, int.MaxValue).Value = products.bitTarih;
                    cmd.Parameters.Add("@Value_7", SqlDbType.VarChar, int.MaxValue).Value = products.aciklama;
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();

                    PopulateGridview(tabloAdi, tablo);

                    uploadPic(file, "Products", "Pictures");

                    sorgu = "INSERT INTO ProductsPictures (ProductsID,picture) VALUES (@ProductsID,@picture)";
                    for (int i = 0; i < imagePaths.Count; i++)
                    {
                        cmd = new SqlCommand(sorgu, con);
                        cmd.Parameters.AddWithValue("@ProductsID", id);
                        cmd.Parameters.AddWithValue("@picture", imagePaths[i]);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    mesaj = "Ürün başarılı bir şekilde Kayıt Edildi.";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

        }

        public void AuctionDetayGöster(Products product)
        {
            sorgu = "SELECT * FROM Products WHERE id=@id";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", product.id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                product.rol = dr["rolEkleyen"].ToString();
                product.UserID = Convert.ToInt32(dr["IDEkleyen"]);
                product.baslik = dr["baslik"].ToString();
                product.basFiyat = Convert.ToInt32(dr["basFiyat"]);
                product.basTarih = Convert.ToDateTime(dr["basTarih"]);
                product.bitTarih = Convert.ToDateTime(dr["bitTarih"]);
                product.aciklama = dr["aciklama"].ToString();
            }
            dr.Close();
            con.Close();

            sorgu = "SELECT id, ad, soyad FROM " + product.rol + " WHERE id=@id";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", product.UserID);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                product.satanKisi = dr["ad"] + " " + dr["soyad"];
            }
            dr.Close();
            con.Close();

            sorgu = "SELECT picture FROM ProductsPictures WHERE ProductsID=@ProductsID";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ProductsID", product.id);
            con.Open();
            dr = cmd.ExecuteReader();
            List<string> resimler = new List<string>();
            while (dr.Read())
            {
                resimler.Add(dr["picture"].ToString());
            }
            product.pictures = resimler;
            dr.Close();
            con.Close();
        }

        public void AuctionEkle(AuctionClass auction)
        {

            sorgu = "INSERT INTO auctions(IDTeklifVeren, RoleTeklifVeren, IDProducts, teklifler, teklifTarih)" +
                " VALUES (@IDTeklifVeren, @RoleTeklifVeren, @IDProducts, @teklifler, @teklifTarih)";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@IDTeklifVeren", auction.IDTeklifVeren);
            cmd.Parameters.AddWithValue("@RoleTeklifVeren", auction.RoleTeklifVeren);
            cmd.Parameters.AddWithValue("@IDProducts", auction.IDProduct);
            cmd.Parameters.AddWithValue("@teklifler", auction.teklif);
            cmd.Parameters.AddWithValue("@teklifTarih", auction.teklifTarihi);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<AuctionClass> TekliflerGoster(AuctionClass auction)
        {
            List<AuctionClass> liste = new List<AuctionClass>();
            sorgu = "SELECT * FROM auctions WHERE IDProducts=@IDProducts";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@IDProducts", auction.IDProduct);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                auction = new AuctionClass();
                auction.IDTeklifVeren = dr["IDTeklifVeren"].ToString();
                auction.RoleTeklifVeren = dr["RoleTeklifVeren"].ToString();
                auction.teklif = dr["teklifler"].ToString();
                auction.teklifTarihi = dr["teklifTarih"].ToString();
                liste.Add(auction);
            }
            liste.Reverse();
            dr.Close();
            con.Close();
            return liste;
        }

        public List<Para> AdminParaOnayListesi(Para para)
        {
            List<Para> list = new List<Para>();
            sorgu = "SELECT * FROM OnayPara WHERE bakıldıMı = @bakıldıMı ;";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@bakıldıMı", "hayır");
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                para = new Para();
                para.id = dr["id"].ToString();
                para.IDUser = dr["IDUser"].ToString();
                para.para = dr["para"].ToString();
                para.onaylandıMı = dr["onaylandıMı"].ToString();
                list.Add(para);
            }
            dr.Close();
            con.Close();

            return list;
        }
        public void ParaOnay(string id, string onayDurumu, string bakiye)
        {
            sorgu = "UPDATE OnayPara SET onaylandıMı=@onaylandıMı, bakıldıMı=@bakıldıMı WHERE IDUser=@IDUser";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@IDUser", id);
            cmd.Parameters.AddWithValue("@bakıldıMı", "evet");
            if (onayDurumu == "evet")
            {

                cmd.Parameters.AddWithValue("@onaylandıMı", "evet");
            }
            else if (onayDurumu == "hayır")
            {
                cmd.Parameters.AddWithValue("@onaylandıMı", "hayır");
            }


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            sorgu = "SELECT bakiye FROM Users WHERE id=@id";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            string oncekiBakiye = "";
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                oncekiBakiye = dr["bakiye"].ToString();
            }
            dr.Close();
            con.Close();
            if (onayDurumu == "evet")
            {
                sorgu = "UPDATE Users SET bakiye=@bakiye WHERE id=@id";
                cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);

                cmd.Parameters.AddWithValue("@bakiye", (Convert.ToInt32(oncekiBakiye) + Convert.ToInt32(bakiye)).ToString());

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void setParaOnay(Para para)
        {
            sorgu = "INSERT INTO OnayPara(IDUser, para, onaylandıMı, bakıldıMı) VALUES (@IDUser, @para, @onaylandıMı, @bakıldıMı)";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@IDUser", para.IDUser);
            cmd.Parameters.AddWithValue("@para", para.para);
            cmd.Parameters.AddWithValue("@onaylandıMı", para.onaylandıMı);
            cmd.Parameters.AddWithValue("@bakıldıMı", para.bakıldıMı);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public string getBakiye(string id)
        {
            string bakiye = "";
            sorgu = "SELECT bakiye FROM Users WHERE id = @id";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                bakiye = dr["bakiye"].ToString();
            }
            dr.Close();
            con.Close();

            return bakiye;
        }

        public void bakiyeAzalt(Para para)
        {
            string oncekiBakiye = "";
            sorgu = "SELECT bakiye FROM Users WHERE id=@id";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", para.IDUser);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                oncekiBakiye = dr["bakiye"].ToString();
            }
            dr.Close();
            con.Close();

            sorgu = "UPDATE Users SET bakiye=@bakiye WHERE id=@id";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", para.IDUser);
            cmd.Parameters.AddWithValue("@bakiye", (Convert.ToInt32(oncekiBakiye) - Convert.ToInt32(para.para)).ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void MesajYolla(Mesaj mesaj)
        {
            sorgu = "INSERT INTO Mesaj (IDUser, mesaj) VALUES (@IDUser, @mesaj)";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@IDUser", mesaj.IDUser);
            cmd.Parameters.AddWithValue("@mesaj", mesaj.mesaj);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Mesaj> MesajListesi(Mesaj mesaj)
        {
            List<Mesaj> list = new List<Mesaj>();
            sorgu = "SELECT * FROM Mesaj";
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                mesaj = new Mesaj();
                mesaj.IDUser = dr["IDUser"].ToString();
                mesaj.mesaj = dr["mesaj"].ToString();
                list.Add(mesaj);
            }
            dr.Close();
            con.Close();

            return list;
        }
    }
}