using AutoMapper;
using BLL;
using BLL.DTO;
using BLL.Servises;
using BLL.Struct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PrL.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]

    //[Produces("application/json")]

    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController()
        {
            //orderService = serv;
            
        }

        public ActionResult Index()
        {
            IEnumerable<ShowDTO> showDtos = orderService.GetShows();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ShowDTO, ShowViewModel>()).CreateMapper();
            var shows = mapper.Map<IEnumerable<ShowDTO>, List<ShowViewModel>>(showDtos);
            return View(shows);
        }

        public ActionResult BookTicket(int? showid, int? seat)
        {
            try
            {
                var tickets = orderService.GetTickets(showid);
                var ticket = tickets.Where(x => x.Seat == seat).First();
                //TicketDTO show = tickets.
                //var showview = new ShowViewModel { Author = show.Author, id = show.id, Genre = show.Genre, Name = show.Name, Size = show.Size };
                var ticketview = new TicketViewModel { showid = ticket.showid, Seat = ticket.Seat, Price = ticket.Price, Status = ticket.Status };

                return View(ticketview);
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
                return Content("<h1>Ваш заказ успешно оформлен</h1>");
            }
            catch (ValidationException ex)
            {

                return Content("<h1>"+ex.Message+"</h1>");
            }
        }

        public ActionResult BuyTicket(int? showid, int? seat)
        {
            try
            {
                var tickets = orderService.GetTickets(showid);
                var ticket = tickets.Where(x => x.Seat == seat).First();
                //TicketDTO show = tickets.
                //var showview = new ShowViewModel { Author = show.Author, id = show.id, Genre = show.Genre, Name = show.Name, Size = show.Size };
                var ticketview = new TicketViewModel { showid = ticket.showid, Seat = ticket.Seat, Price = ticket.Price, Status = ticket.Status };

                return View(ticketview);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult BuyTicket(TicketViewModel ticket)
        {
            try
            {

                var showDto = orderService.GetShow(ticket.showid);
                orderService.BuyTicket(showDto.id, ticket.Seat);
                return Content("<h1>Ваш заказ успешно оформлен</h1>");
            }
            catch (ValidationException ex)
            {

                return Content("<h1>" + ex.Message + "</h1>");
            }
        }





        public ActionResult OrderMenu(int? id)
        {
            try
            {
                IEnumerable<TicketDTO> ticketDtos = orderService.GetTickets(id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, TicketViewModel>()).CreateMapper();
                var tickets = mapper.Map<IEnumerable<TicketDTO>, List<TicketViewModel>>(ticketDtos);

                //ShowDTO show = orderService.GetShow(id);
                //var showview = new ShowViewModel { Author = show.Author, id = show.id, Genre = show.Genre, Name = show.Name, Size = show.Size };

                return View(tickets);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}
