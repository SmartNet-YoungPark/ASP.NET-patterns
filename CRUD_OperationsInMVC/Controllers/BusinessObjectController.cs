using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OperationsInMVC;
using OperationsInMVC.Models;

namespace OperationsInMVC.Controllers
{
    public class BusinessObjectController : Controller
    {
        //Stored Procedure called, named GetAllMembers()
         public ActionResult Index()
            {
                MemberBusinessLayer memberBusinessLayer = new MemberBusinessLayer();
                List<Member> members = memberBusinessLayer.GetAllMembers();
                return View(members);
            }
        //Form binding
        [HttpGet]
       public ActionResult CreateForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateForm(FormCollection formCollection)
        {
            Member member = new Member();
            // Retrieve form data using form collection
            member.Name = formCollection["Name"];
            member.Gender = formCollection["Gender"];
            member.City = formCollection["City"];
            member.Salary = Convert.ToDecimal(formCollection["Salary"]);
            member.DateOfBirth = Convert.ToDateTime(formCollection["DateOfBirth"]);
            MemberBusinessLayer memberBusinessLayer = new MemberBusinessLayer();
            memberBusinessLayer.AddMember(member);
            return RedirectToAction("/Index");
        }
        //Data binding
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            if (ModelState.IsValid)
            {
                MemberBusinessLayer memberBusinessLayer = new MemberBusinessLayer();
                Member member = new Member();
                //Data binding with UpdateModel or TryUpdateModel
                TryUpdateModel<Member>(member);
                memberBusinessLayer.AddMember(member);
                return RedirectToAction("/Index");
            }
            return View();
        }
        //Data binding
        [HttpGet]
        [ActionName("CreateParam")]
        public ActionResult CreateParam_Get()
        {
            return View();
        }
        [HttpPost]
        [ActionName("CreateParam")]
        public ActionResult CreateParam_Post(Member member)
        {
            if (ModelState.IsValid)
            {
                MemberBusinessLayer memberBusinessLayer = new MemberBusinessLayer();
                memberBusinessLayer.AddMember(member);
                return RedirectToAction("/Index");
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            MemberBusinessLayer memberBusinessLayer = new MemberBusinessLayer();
            Member member = memberBusinessLayer.GetAllMembers().FirstOrDefault(emp => emp.ID == id);
            return View(member);
        }
        [HttpPost]
        public ActionResult Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                MemberBusinessLayer memberBusinessLayer = new MemberBusinessLayer();
                memberBusinessLayer.UpdateMember(member);
                return RedirectToAction("/Index");
            }
            return View(member);
        }
        [HttpGet]
        [ActionName("EditExceptNameBind")]
        public ActionResult Edit_Get(int id)
        {
            MemberBusinessLayer memberBusinessLayer = new MemberBusinessLayer();
            Member member = memberBusinessLayer.GetAllMembers().FirstOrDefault(mem => mem.ID == id);
            return View(member);
        }
        //[HttpPost]
        //[ActionName("EditExceptNameBind")]
        //public ActionResult Edit_Post(int id)
        //{
        //    MemberBusinessLayer memberBusinessLayer = new MemberBusinessLayer();
        //    Member member = memberBusinessLayer.GetAllMembers().Single(x => x.ID == id);
        //    UpdateModel<IMember>(member);
        //    if (ModelState.IsValid)
        //    {
        //        memberBusinessLayer.UpdateMember(member);
        //        return RedirectToAction("/Index");
        //    }
        //    return View(member);
        //}

        [HttpPost]
        [ActionName("EditExceptNameBind")]
        //or Change public ActionResult Edit_Post([Bind(Exclude = "Name")] Employee employee)
        public ActionResult Edit_Post([Bind(Include = "Id, Gender, City, Salary, DateOfBirth")] Member member)
        {
            MemberBusinessLayer memberBusinessLayer = new MemberBusinessLayer();
            member.Name = memberBusinessLayer.GetAllMembers().FirstOrDefault(x => x.ID == member.ID).Name;
            if (ModelState.IsValid)
            {
                memberBusinessLayer.UpdateMember(member);
                return RedirectToAction("/Index");
            }
            return View(member);
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(int id)
        {
            MemberBusinessLayer memberBusinessLayer = new MemberBusinessLayer();
            Member member = memberBusinessLayer.GetAllMembers().FirstOrDefault(mem => mem.ID == id);
            return View(member);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            MemberBusinessLayer memberBusinessLayer = new MemberBusinessLayer();
            memberBusinessLayer.DeleteMember(id);
            return RedirectToAction("/Index");
        }
        //if (ModelState.IsValid)
        //{
        //    foreach (string key in formCollection.AllKeys)
        //    {
        //        Response.Write("Key = " + key + "  ");
        //        Response.Write("Value = " + formCollection[key]);
        //        Response.Write("<br/>");
        //    }
        //}
        //return View();
    }

            // GET: BusinessObject
            //public ActionResult Index1()
            //{
            //    return View();
            //}
            //// GET: BusinessObject
            //public ViewResult Index()
            //{
            //    ViewData["Countries"] = new List<string>
            //    {
            //        "India",
            //        "US",
            //        "Canada",
            //        "Brazil",
            //        "Korea"
            //    };
            //    return View();
        
   
}