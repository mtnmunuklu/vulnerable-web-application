using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Models;
using System.Diagnostics;
using System.Text;
using System.IO;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public SiparisKontrolEntities db = new SiparisKontrolEntities();
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult sqlinjection()
        {
            return View();
        }
        [HttpPost]
        public ActionResult sqlinjection(String name) //TexBox ile alınan değer parametre olara gelir.
        {
            List<Personel> l = new List<Personel>(); //Personel tablosundan List tipinde bir nesne oluşturulur.
            try{
            SqlConnection con = new SqlConnection("Data source=COMPUTER\\SQLEXPRESS;database=SiparisKontrol;integrated security=true");
            con.Open(); //Çalıştırılcak sorgunun hangi bağlantı üzerinden işlem yapılacağı belirlenir.
            string sqlQuery = string.Format("SELECT FullName,UserName FROM Personel WHERE UserId={0}",name); //kullanıcı tarafından
            //girilen sorguyu normal sorgumuza ekler.
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text; //Çalıştırılacak sql sorgusunun tipi belirlenir.

            SqlDataReader dr; //SqlDataReader tipinde nesne türetilir
            dr = cmd.ExecuteReader();//SqlCommand' ın ExecuteReader özelliği kullanılılarak birden fazla satır dondurur.
            while (dr.Read())//Okuma işlemi gerçekleştirilir.Bool türünde değer döndürür.
            {
                Personel personel = new Personel(); //Personel Tablosundan nesne türetilir.
                personel.FullName = dr[0].ToString();// sorgu sonucu sonucları bu tablonun sutunlarına eklenir. 
                personel.UserName = dr[1].ToString();
                l.Add(personel); //personel bilgileri listeye eklenir. 
            }
            }
            catch (Exception ex)
            {
                Session["hata"] =ex.Message; //hata mesajı bilgisini tutar
                return View("yanlis");//hata gerçekleştiğinde bu sayfaya yönlendirir.
            }
            return View(l);//personel bilgileri liste olarak gönderilir.
        }

        public ActionResult yanlis()
        {
           
            return View();
        }
        public ActionResult kurulum()
        {
            return View();
        }

        public ActionResult XssEkle()
        {   

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]  
        public ActionResult XssEkle(Mesaj mesaj)//textbox aracılığıyla alınan bilgiler parametre olarak gelir.
        {
          if (ModelState.IsValid)//Herhangi bir model hatası eklenip eklenmediğini bildirir  
          {
            Mesaj msj = new Mesaj(); //Veritabanındaki Mesaj tablosundan msj nesnesi türerilir.
            msj.AdSoyad = mesaj.AdSoyad; //msj nesnesinin Adsoyad özelliğine ,textbox ile alınan Adsoyad bilgisi eklenir. 
            msj.Email = mesaj.Email;//msj nesnesinin "Email" özelliğine,textbox ile alınan Email bilgisi eklenir.
            msj.Yorum = mesaj.Yorum;//msj nesnesinin "Yorum" özelliğine,textbox ile alınan Yorum bilgisi eklenir.
            db.Mesaj.Add(msj);//msj nesnesi üzerinde veriler veritabanındaki Mesaj tablosuna kaydedilir.
            db.SaveChanges();//değişiklikler kaydedilir
            return RedirectToAction("XssListele");//ilgili sayfaya yönlendirilir.
           }
            return View();                 
        }
        public ActionResult XssListele()
        {
            var liste = db.Mesaj.ToList();
            return View(liste);
        }
        public ActionResult Komutinjeciton()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Komutinjeciton(string name)
        {
            List<Mesaj> l = new List<Mesaj>();
            //Belirleme DIR location, konumun içeriğini gösterir.

            //Komut C:dahil olmak üzere birçok komut üzerinde DIRbelirtme,
            //C sürücüsünü belirtir ve geçerli dizini belirtir. Geçerli dizini görmek için şunu yazın:
            //string strCmdText = @"/C dir c:\" +name;
            string strCmdText = @"/C ping " + name;
            Process p = new Process();//Process sınıfından p adında bir nesne türetilmektedir
            p.StartInfo = new ProcessStartInfo("CMD.exe",strCmdText);// işlemin nasıl başlayacağı belirlenir
            p.StartInfo.UseShellExecute = false; //false olarak ayarlanarak giriş çıkış hata akışlarının yeniden
            //yönlendirilmesi sağlanır.
            p.StartInfo.RedirectStandardOutput = true;//cıktının yazılır olup olmadığını gösteren bir değer alır.
            p.Start();//işlemi gerçekleştirecek proses başlatılır.
            StreamReader s = p.StandardOutput;//çıkıtının okunması işlemi gerçekleştirilir.
            var lines = s.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);//okunan
            //çıktıyı satır satır tutar
            foreach (var line in lines)
            {
                Mesaj m = new Mesaj(); // Satır satır tutulan çıktı Mesaj tipinde bir listeye eklenir
                m.Yorum = line;
                l.Add(m); //çıktı liste olarak gönderilir.
            }
                       
            p.WaitForExit();
       return View(l);
        }
	}
}   