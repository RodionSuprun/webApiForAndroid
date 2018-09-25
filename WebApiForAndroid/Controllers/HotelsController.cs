using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebApiForAndroid.Models;


namespace WebApiForAndroid.Controllers
{
    
    [Route("api/[controller]")]
    public class HotelsController : Controller
    {
        HotelsContext db;
        public HotelsController(HotelsContext context)
        {
            this.db = context;
            if (!db.Hotels.Any())
            {
                db.Hotels.Add(new Hotel { Name = "Klas", County = "Turkey", Desc = "Отель Klas расположен в районе Паяллар, в 2 км от курортного поселка Конаклы, в 12 км от города Алания-сердца средиземноморского побережья Турции и в 110 км от международного аэрпорта в Анталии, в 50 км от международного аэропорта в Газипаша.", Photo = "http://alramirtour.kz/wp-content/uploads/2017/02/bcf0a1438b1f18a5148b5b3ea59c7f44.jpg", NumberOfNumbers = 555, NumberOfStars = 5, Price = 65000});
                db.Hotels.Add(new Hotel { Name = "Grand Ring Hotel", County = "Almaty", Desc = "Отель Port Nature Luxury Resort and SPA располагается на берегу моря в местечке Богазкент, что находится на расстоянии 5 км от туристического центра Белек. Это место представляет собой остров, окружённый морем, озером, рекой и лесами.  Райская степь - так по-другому называют эту уникальную местность, обладающую естественной прохладой благодаря своему микроклимату. Площадь отеля состовляет 58.000 м2", Photo = "https://i.ytimg.com/vi/AmwXhR4-3H4/maxresdefault.jpg", NumberOfNumbers = 212, NumberOfStars = 4, Price = 84000 });
                db.Hotels.Add(new Hotel { Name = "Armas Gül Beach Hotel", County = "Moscow", Desc = "Клубный отель на самом берегу моря, где современная архитектура переплетается с местным колоритом. Жаркие лучи Средиземноморского солнца, золотая полоска пляжа, магический воздух, заряженный солоноватым дыханием моря, великолепные условия размещения, насыщенная анимационно - развлекательная программа и целый спектр вариантов времяпрепровождения делают этот отель привлекательным для большинства туристов, особенно для отдыха родителей с детьми. Признан лучшим семейным отелем 2011 года.", Photo = "https://myfiles.kz/Pics/RozaVetrov-wp/uploads/2017/01/Turkey.jpg", NumberOfNumbers = 654, NumberOfStars = 5, Price = 125200 });
                db.Hotels.Add(new Hotel { Name = "PGS Kiris Resort", County = "Turkey", Desc = "Отель BELLIS DELUXE состоит из главного 6-ти этажного здания и нескольких трехэтажных бунгал и находится на длинном песчаном берегу Средиземного моря. Территория отеля очень ухожена и благоустроена, благодаря чему отдыхающие смогут насладиться незабываемым отдыхом, а также красотой здешних мест. Здесь можно увидеть пышные средиземные сосны, разнообразные пальмы, в том числе и финиковые пальмы, экзотические цветы, которые поражают своей красотой, а также разнообразные кустарники и другую растительность, чтоделает этот отель, одним из лучших мест", Photo = "https://www.aeroflot.ru/media/aflfiles/tr/tr_1.jpg", NumberOfNumbers = 228, NumberOfStars = 3, Price = 12000 });
                db.Hotels.Add(new Hotel { Name = "Rixos Premium Belek", County = "Turkey", Desc = "Nashira Resort Hotel & Spa расположен в 75 км от аэропорта г. Анталия, в 7км от г. Сиде и в 1 км от пос. Титрейенгёл, на самом берегу моря. Построен в 2006 году, общая площадь 120 000 м2.", Photo = "http://ostwest.in.ua/wp-content/uploads/2016/04/3.jpg", NumberOfNumbers = 124, NumberOfStars = 5, Price = 74025 });

                db.Hotels.Add(new Hotel { Name = "Papillon Hotels", County = "India", Desc = "Отель PGS KIRIS RESORT построен в 1994 году прямо на морском побережье у подножья Торосских гор, где жарким днем голубое, без единого облачка небо, сливается с лазурной синевой моря.", Photo = "http://loveyouplanet.com/wp-content/uploads/2016/01/Turkey-regions4.jpg", NumberOfNumbers = 142, NumberOfStars = 5, Price = 451246655 });


                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Hotel> Get()
        {
            return db.Hotels.ToList();
        }

        

        // GET api/hotels/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Hotel hotel = db.Hotels.FirstOrDefault(x => x.Id == id);
            if (hotel == null)
                return NotFound();
            return new ObjectResult(hotel);
        }

        // POST api/hotels
        [HttpPost]
        public IActionResult Post([FromBody]Hotel hotel)
        {
            if (hotel == null)
            {
                return BadRequest();
            }

            db.Hotels.Add(hotel);
            db.SaveChanges();
            return Ok(hotel);
        }

        // PUT api/users/
        [HttpPut]
        public IActionResult Put([FromBody]Hotel hotel)
        {
            if (hotel == null)
            {
                return BadRequest();
            }
            if (!db.Hotels.Any(x => x.Id == hotel.Id))
            {
                return NotFound();
            }

            db.Update(hotel);
            db.SaveChanges();
            return Ok(hotel);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Hotel hotel = db.Hotels.FirstOrDefault(x => x.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }
            db.Hotels.Remove(hotel);
            db.SaveChanges();
            return Ok(hotel);
        }
    }
}