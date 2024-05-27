using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUygulamaProje1.Models;
using WebUygulamaProje1.Utility;

namespace WebUygulamaProje1.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]

    public class KitapTuruController : Controller
    {
        private readonly IKitapTuruRepository _kitapTuruRepository;
        public KitapTuruController(IKitapTuruRepository context)
        {
            _kitapTuruRepository = context;
        }

        public IActionResult Index()
        {
            List<KitapTuru> objKitapTuruList = _kitapTuruRepository.GetAll().ToList();
            return View(objKitapTuruList);
        }

        public IActionResult Ekle()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Ekle(KitapTuru kitapturu)
        {
            if(ModelState.IsValid)
            {
                _kitapTuruRepository.Ekle(kitapturu);
                _kitapTuruRepository.Kaydet();
                TempData["basarili"] = "Yeni Kitap Türü Başarıyla Eklendi!";
                return RedirectToAction("Index");
            }
            return View();
            
        }

        public IActionResult Guncelle(int? id)
        {
            if(id == null|| id == 0)
            {
                return NotFound();
            }
            KitapTuru kitapTuruVt = _kitapTuruRepository.Get(u=>u.Id==id);
            if(kitapTuruVt == null)
            {
                return NotFound();
            }
            return View(kitapTuruVt);
        }

        [HttpPost]
        public IActionResult Guncelle(KitapTuru kitapturu)
        {
            if (ModelState.IsValid)
            {
                _kitapTuruRepository.Guncelle(kitapturu);
                _kitapTuruRepository.Kaydet();
                TempData["basarili"] = "Kitap Türü Başarıyla Güncellendi!";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            KitapTuru kitapTuruVt = _kitapTuruRepository.Get(u => u.Id == id);
            if (kitapTuruVt == null)
            {
                return NotFound();
            }
            return View(kitapTuruVt);
        }

        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            KitapTuru? kitapTuru = _kitapTuruRepository.Get(u => u.Id == id); 
            if(kitapTuru == null)
            {
                return NotFound();
            }
            _kitapTuruRepository.Sil(kitapTuru);
            _kitapTuruRepository.Kaydet();
            TempData["basarili"] = "Kitap Türü Başarıyla Silindi!";
            return RedirectToAction("Index" ,"KitapTuru");
        }
    }
}
