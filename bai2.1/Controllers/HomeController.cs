using bai2._1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace bai2._1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // action tra ve mot view la mot trang html va no co the truyen tham so hoac model
        public ActionResult TestViewResult()
        {
            return View();
        }

        //action tra ve mot partialviewresult
        public PartialViewResult TestPartialViewResult()
        {
            return PartialView();
        }

        //action tra ve mot view trong (null)
        public EmptyResult TestEmptyResult()
        {
            return new EmptyResult();
        }

        //action dap ung viec chuyen truc tiep toi mot view khac
        public RedirectResult TestRedirectResult()
        {
            return Redirect("Index");
        }

        //action tra ve mot ket qua dang json
        public JsonResult TestJsonResult()
        {
            List<Student> listStudent = new List<Student>();
            listStudent.Add(new Student() { Id = 001, Name = "Nguyễn Quang Huy", ClassName = "C1311L" });
            listStudent.Add(new Student() { Id = 001, Name = "Nguyễn Quang Huy", ClassName = "C1311L" });
            listStudent.Add(new Student() { Id = 001, Name = "Nguyễn Quang Huy", ClassName = "C1311L" });
            listStudent.Add(new Student() { Id = 001, Name = "Nguyễn Quang Huy", ClassName = "C1311L" });
            listStudent.Add(new Student() { Id = 001, Name = "Nguyễn Quang Huy", ClassName = "C1311L" });
            listStudent.Add(new Student() { Id = 001, Name = "Nguyễn Quang Huy", ClassName = "C1311L" });
            listStudent.Add(new Student() { Id = 001, Name = "Nguyễn Quang Huy", ClassName = "C1311L" });
            listStudent.Add(new Student() { Id = 001, Name = "Nguyễn Quang Huy", ClassName = "C1311L" });
            listStudent.Add(new Student() { Id = 001, Name = "Nguyễn Quang Huy", ClassName = "C1311L" });
            return Json(listStudent, JsonRequestBehavior.AllowGet);
        }
        
        //action tra ve mot view la javascript
        public JavaScriptResult TestJavaScriptResult()
        {
            string js = "funtion checkEmail(){var btloc=/^([w-]+(?:.[w-]+)@((?:[w-]+.)*w[w-]{0,66}).([a-z]{2,6}(?:.[a-z]{2})?)$/iif(btloc.test(mail)){kq=true;} else{alert('email address invalid') kq=false; } return kq;}";
            return JavaScript(js);
        }
        
        //action tra ve mot contentresult du lieu la dang van ban
        public ContentResult TestContentResult () 
        {
            XElement contentXML = new XElement("Students",
                new XElement("Student",
                new XElement("ID", "001"),
                new XElement("FullName", "Nguyễn Viết Nam"),
                new XElement("ClassName", "C1308H")),
                new XElement("Student",
                new XElement("ID", "002"),
                new XElement("FullName", "Nguyễn Hoàng Anh"),
                new XElement("ClassName", "C1411P")),
                new XElement("Student",
                new XElement("ID", "003"),
                new XElement("FullName", "Phạm Ngọc Anh"),
                new XElement("ClassName", "C1411L")),
                new XElement("Student",
                new XElement("ID", "004"),
                new XElement("FullName", "Trần Ngọc Linh"),
                new XElement("ClassName", "C1411H")),
                new XElement("Student",
                new XElement("ID", "005"),
                new XElement("FullName", "Nguyễn Hồng Anh"),
                new XElement("ClassName", "C1411L")));
            return Content(contentXML.ToString(), "text/xml", Encoding.UTF8);
        }

        public FileContentResult TestFileContentResult()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/demovideo.mp4"));
            string fileName = "demovideo.mp4";
            //return File(fileBytes,System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            return File(fileBytes, "video/mp4", fileName);
        }
        public FileStreamResult TestFileStreamResult()
        {
            string pathFile = Server.MapPath("~/Content/vonsong.docx");
            string fileName = "vonsong.docx";
            return File(new FileStream(pathFile, FileMode.Open),
            "text/doc", fileName);
        }
        public FilePathResult TestFilePathResult()
        {
            string pathFile = Server.MapPath("~/Content/vonsong.docx");
            string fileName = "vonsong.docx";
            return File(pathFile, "text/doc", fileName);
        }

    }
}
