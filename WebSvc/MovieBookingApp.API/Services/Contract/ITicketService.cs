﻿using MongoDB.Bson;
using MovieBookingApp.API.Models;

namespace MovieBookingApp.API.Services.Contract
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetAllTicket();
        Task<Ticket> GetTicketByUserId(ObjectId Ticketid);
        Task AddTicket(Ticket ticket);
        Task UpdateTicket(Ticket ticket);
        Task DeleteTicket(ObjectId Ticketid);
    }
}
