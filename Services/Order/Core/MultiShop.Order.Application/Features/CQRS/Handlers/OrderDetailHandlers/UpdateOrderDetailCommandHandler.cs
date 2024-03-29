using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var orderDetailForUpdate = await _repository.GetByIdAsync(command.OrderDetailID);
            orderDetailForUpdate.ProductName = command.ProductName;
            orderDetailForUpdate.ProductPrice = command.ProductPrice;
            orderDetailForUpdate.ProductTotalPrice = command.ProductTotalPrice;
            orderDetailForUpdate.ProductAmount = command.ProductAmount;
            orderDetailForUpdate.ProductID = command.ProductID;
            orderDetailForUpdate.OrderingID = command.OrderingID;
            await _repository.UpdateAsync(orderDetailForUpdate);
        }
    }
}
