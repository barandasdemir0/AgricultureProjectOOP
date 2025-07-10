using AgriculturePresentation.Models;
using ClosedXML.Excel;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using OfficeOpenXml;

namespace AgriculturePresentation.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticReport()
        {
           
            ExcelPackage excelPackage = new ExcelPackage();
            var workBook = excelPackage.Workbook.Worksheets.Add("dosya1");
            workBook.Cells[1, 1].Value = "Ürün Adı";
            workBook.Cells[1, 2].Value = "Ürün Kategorisi";
            workBook.Cells[1, 3].Value = "Ürün Stok";


            workBook.Cells[2, 1].Value = "Mercimek";
            workBook.Cells[2, 2].Value = "bakliyat";
            workBook.Cells[2, 3].Value = "785";

            workBook.Cells[3, 1].Value = "Buğday";
            workBook.Cells[3, 2].Value = "bakliyat";
            workBook.Cells[3, 3].Value = "1986";

            workBook.Cells[4, 1].Value = "Havuç";
            workBook.Cells[4, 2].Value = "sebze";
            workBook.Cells[4, 3].Value = "167";


            var bytes = excelPackage.GetAsByteArray();


            return File(bytes,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","BakliyatRaporu.xlsx");
        }


        public List<ContactModel> ContactList() //contact listesi döndürür
        {
            List<ContactModel> contactModels = new List<ContactModel>();  // boş bir liste oluşturur ama contactmodel öğelerinin içinde veri yokken liste oluştur
            using (var context = new AgriCultureContext()) // context nesnesi oluşturur veritabanı ile etkileşim kurmak için
            {
                contactModels = context.Contacts.Select(x => new ContactModel // veritabanındaki Contact tablosundan verileri alır ve ContactModel'e dönüştürür
                {
                    ContactID = x.ContactID, // ContactID'yi alır
                    ContactName = x.Name, // İsim alanını alır
                    ContactDate = x.Date, // Tarih alanını alır
                    ContactMail = x.Mail, // Mail alanını alır
                    ContactDetails = x.Message // Mesaj alanını alır
                }).ToList(); // Listeye dönüştürür
            }

            return contactModels; // Oluşturulan listeyi döndürür
        }

        public IActionResult ContactReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var worksheet = workBook.Worksheets.Add("Mesaj Listesi"); // Yeni bir çalışma sayfası oluşturur
                worksheet.Cell(1, 1).Value = "Mesaj ID"; // Başlıkları ekler
                worksheet.Cell(1, 2).Value = "Mesaj Adı";
                worksheet.Cell(1, 3).Value = "Mesaj Tarihi";
                worksheet.Cell(1, 4).Value = "Mesaj Mail";
                worksheet.Cell(1, 5).Value = "Mesaj Detayları";
                int contactRowCount = 2; // Başlıkların altındaki ilk satır
                foreach (var item in ContactList())
                {
                    worksheet.Cell(contactRowCount, 1).Value = item.ContactID;
                    worksheet.Cell(contactRowCount, 2).Value = item.ContactName;
                    worksheet.Cell(contactRowCount, 3).Value = item.ContactDate.ToString("dd/MM/yyyy"); // Tarihi formatlar
                    worksheet.Cell(contactRowCount, 4).Value = item.ContactMail;
                    worksheet.Cell(contactRowCount, 5).Value = item.ContactDetails;
                    contactRowCount++; // Sonraki satıra geçer
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream); // Çalışma kitabını bellek akışına kaydeder
                    var content = stream.ToArray(); // Akıştaki verileri diziye çevirir
                    return File(content, "pplication/vnd.openxmlformats-officedocument.spreadsheetml.sheet" ,"MesajRaporu.xlsx"); // Dosyayı döndürür
                }
            }
               



        }







        public List<AnnouncementModel> AnnouncementList() //contact listesi döndürür
        {
            List<AnnouncementModel> announcementModels = new List<AnnouncementModel>();  // boş bir liste oluşturur ama contactmodel öğelerinin içinde veri yokken liste oluştur
            using (var context = new AgriCultureContext()) // context nesnesi oluşturur veritabanı ile etkileşim kurmak için
            {
                announcementModels = context.Announcements.Select(x => new AnnouncementModel // veritabanındaki Contact tablosundan verileri alır ve ContactModel'e dönüştürür
                {
                    AnnouncementID = x.AnnouncementID, // ContactID'yi alır
                    Title = x.Title, // İsim alanını alır
                    Date = x.Date, // Tarih alanını alır
                    Description = x.Description, // Mail alanını alır
                    Status = x.Status // Mesaj alanını alır
                }).ToList(); // Listeye dönüştürür
            }

            return announcementModels; // Oluşturulan listeyi döndürür
        }




        public IActionResult AnnouncementReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var worksheet = workBook.Worksheets.Add("MDuyuruesaj Listesi"); // Yeni bir çalışma sayfası oluşturur
                worksheet.Cell(1, 1).Value = "Duyuru ID"; // Başlıkları ekler
                worksheet.Cell(1, 2).Value = "Duyuru Adı";
                worksheet.Cell(1, 3).Value = "Duyuru Tarihi";
                worksheet.Cell(1, 4).Value = "Duyuru Açıklaması";
                worksheet.Cell(1, 5).Value = "Duyuru Durumu";
                int contactRowCount = 2; // Başlıkların altındaki ilk satır
                foreach (var item in AnnouncementList())
                {
                    worksheet.Cell(contactRowCount, 1).Value = item.AnnouncementID;
                    worksheet.Cell(contactRowCount, 2).Value = item.Title;
                    worksheet.Cell(contactRowCount, 3).Value = item.Date.ToString("dd/MM/yyyy"); // Tarihi formatlar
                    worksheet.Cell(contactRowCount, 4).Value = item.Description;
                    worksheet.Cell(contactRowCount, 5).Value = item.Status;
                    contactRowCount++; // Sonraki satıra geçer
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream); // Çalışma kitabını bellek akışına kaydeder
                    var content = stream.ToArray(); // Akıştaki verileri diziye çevirir
                    return File(content, "pplication/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DuyuruRaporu.xlsx"); // Dosyayı döndürür
                }
            }




        }

    }
}
