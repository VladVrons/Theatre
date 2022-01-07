
using AutoMapper;
using BLL;
using BLL.DTO;
using BLL.Servises;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace PL
{
        public class HomeController : Controller
        {
            IOrderService orderService;
            public HomeController(IOrderService serv)
            {
                orderService = serv;
            }
            public ActionResult Index()
            {
                IEnumerable<ShowDTO> showDtos = orderService.GetShows();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ShowDTO, ShowViewModel>()).CreateMapper();
                var shows = mapper.Map<IEnumerable<ShowDTO>, List<ShowViewModel>>(showDtos);
                return View(shows);
            }

            public ActionResult BookTicket(int? id)
            {
                try
                {
                    ShowDTO show = orderService.GetShow(id);
                    var showview = new ShowViewModel { Author = show.Author, id = show.id, Genre = show.Genre, Name = show.Name, Size = show.Size };

                    return View(showview);
                }
                catch (ValidationException ex)
                {
                    return Content(ex.Message);
                }
            }
            [HttpPost]
            public ActionResult BookTicket(TicketViewModel ticket)
            {
                try
                {

                    var showDto = orderService.GetShow(ticket.showid);
                orderService.BookTicket(showDto.id, ticket.Seat);
                    return Content("<h2>Ваш заказ успешно оформлен</h2>");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError(ex.Property, ex.Message);
                }
                return View(ticket);
            }
            protected override void Dispose(bool disposing)
            {
                orderService.Dispose();
                base.Dispose(disposing);
            }
        }
}
