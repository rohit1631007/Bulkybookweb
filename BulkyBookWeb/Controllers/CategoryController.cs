﻿using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApllicationDbContext _db;

    public CategoryController(ApllicationDbContext db)
    {
            _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> objCategoryList = _db.Categories;
        return View(objCategoryList);
    }
    //Get action method
    public IActionResult Create()
    {
        
        return View();
    }
    //Post action method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if(obj.Name== obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("CustomError", "The DidplayOrder cannot exactly match the Name.");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"]="Category created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }
    //Get action method
    public IActionResult Edit( int? id)
    {
        if(id == null || id==0)
                {
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
        if(categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }
    //Post action method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("CustomError", "The DidplayOrder cannot exactly match the Name.");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0) 
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }
    //Post action method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj=_db.Categories.Find(id);
        if(obj == null)
        {
            return NotFound();
        }
        
            _db.Categories.Remove(obj);
            _db.SaveChanges();
        TempData["success"] = "Category Deleted successfully";
        return RedirectToAction("Index");
        
        
    }

}
