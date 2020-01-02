using System.Linq;
using Flunt.Notifications;
using Store.Domain.Command;
using Store.Domain.Commands;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Handlers.Contracts;
using Store.Domain.Repositories;
using Store.Domain.Utils;

namespace Store.Domain.Handlers
{
    public class OrderHandler : Notifiable, IHandler<CreateOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _deliveryFee;
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderHandler(
            ICustomerRepository customerRepository,
            IDeliveryFeeRepository deliveryFee,
            IDiscountRepository discountRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _deliveryFee = deliveryFee;
            _discountRepository = discountRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            // Fail Fast Validation
            command.Validate();
             if (command.Invalid)              
              return new GenericCommandResult(false, "Pedido Inválido", command.Notifications);
            
            // 1. Recupera o Cliente
            var customer = _customerRepository.Get(command.Customer);

            // 2. Calcula a Taxa de Entrega
            var deliveryFee = _deliveryFee.Get(command.ZipCode)                ;

            // 3. Obtem o Botão de desconto
            var discount = _discountRepository.Get(command.PromoCode);

            //4. Gera o Pedido
            var products = _productRepository.Get(ExtractGuids.Extract(command.Items)).ToList();
            var order = new Order(customer, deliveryFee, discount);
            foreach(var item in command.Items)
            {
                var product = products.Where(x => x.Id == item.Product).FirstOrDefault();
                order.AddItem(product, item.Quantity);
            }

            // 5. Agrupa as notificações
            AddNotifications(order.Notifications);

            // 6. Verifica se deu tudo certo
            if (Invalid)
                return new GenericCommandResult(false, "Falha ao gerar o pedido", Notifications);
            
            // 7. Retorna o resultado
            _orderRepository.Save(order);
            return new GenericCommandResult(true, $"Pedido {order.Number} gerado com sucesso!", order);
        }
    }
}