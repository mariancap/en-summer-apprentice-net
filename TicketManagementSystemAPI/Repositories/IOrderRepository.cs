﻿using TicketManagementSystemAPI.Models;

namespace TicketManagementSystemAPI.Repositories
{
    public interface IOrderRepository
    {

        IEnumerable<Order> GetAll();
       Task< Order> GetById(int id);
        int Add(Order @order);

        void Update(Order @order);

        void delete(Order @order);
    }
}
