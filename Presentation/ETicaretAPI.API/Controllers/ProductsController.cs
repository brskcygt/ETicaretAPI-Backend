using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        
        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;

            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;

            _customerWriteRepository = customerWriteRepository;
        }

        [HttpGet]
        public async Task Get()
        {
           Order order = await _orderReadRepository.GetByIdAsync("38b83e97-b14e-4400-a0fe-6e1bfc70ed12");
           order.Address = "İstanbul";

           await _orderWriteRepository.SaveAsync();

        }
    }
}

