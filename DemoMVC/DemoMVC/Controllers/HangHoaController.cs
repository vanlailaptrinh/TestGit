using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Seminar.Models;
using static Project_Seminar.Models.HangHoaVM;

namespace Project_Seminar.Controllers
{
 
    public class HangHoaController : Controller
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(hangHoas);

        }
        [HttpPost]
        public IActionResult Add(HangHoaVM hangHoaVM)
        {
            var HangHoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia

            };
            hangHoas.Add(HangHoa);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(hangHoas); 
        }


        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpGet("Edit")]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Guid id,HangHoaVM hangHoaVM)
        {
            try
            {
                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == id);

                if (hanghoa == null)
                {
                    TempData["Message"] = "Khong tim thay mat hang nay";
                    return RedirectToAction("Index");
                }
                hanghoa.TenHangHoa = hangHoaVM.TenHangHoa;
                hanghoa.DonGia = hangHoaVM.DonGia;

                TempData["Message"] = "Da cap nhat thanh cong";
                return RedirectToAction("Index");




            }

            catch (Exception ex) {
                TempData["Message"] = "Đã xảy ra lỗi khi cập nhật!";
                return RedirectToAction("Index");

            }

        }



    }
}
