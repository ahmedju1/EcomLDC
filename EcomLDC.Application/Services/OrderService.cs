using EcomLDC.Application.DTOs;
using EcomLDC.Domain.Entities;
using EcomLDC.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository; 
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IOrderRepository orderRepository,IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }   
        public async Task<Guid> CreateOrderAsync(Order order)
        {
            await _orderRepository.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return order.id;
        }
    }
}
