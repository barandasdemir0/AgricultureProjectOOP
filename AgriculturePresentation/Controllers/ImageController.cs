using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;





namespace AgriculturePresentation.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var values = _imageService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddImage(Image image)
        {
            ImageValidator validationRules = new ImageValidator(); //validasyonu çağır
            ValidationResult validationResult = validationRules.Validate(image); //gelen verileri kontrol et

            if (validationResult.IsValid)
            {
                _imageService.Insert(image);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();


        }

        public IActionResult DeleteImage(int id)
        {
            var result = _imageService.GetById(id);
            _imageService.Delete(result);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateImage(int id)
        {
            var result = _imageService.GetById(id);
            return View(result);
        }


        [HttpPost]
        public IActionResult UpdateImage(Image image)
        {
            ImageValidator validationRules = new ImageValidator();
            ValidationResult validationResult = validationRules.Validate(image);

            if (validationResult.IsValid)
            {
                _imageService.Update(image);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();



        }

    }
}
