﻿using System;
using NsqSharp.Bus;
using PointOfSale.Messages;
using PointOfSale.Services;

namespace PointOfSale.Handlers.Handlers
{
    public class GetCustomerDetailsHandler : IHandleMessages<GetCustomerDetails>
    {
        private readonly ICustomerService _customerService;

        public GetCustomerDetailsHandler(ICustomerService customerService)
        {
            if (customerService == null)
                throw new ArgumentNullException("customerService");

            _customerService = customerService;
        }

        public void Handle(GetCustomerDetails message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            var customer = _customerService.GetCustomer(message.CustomerId);

            Console.WriteLine("Customer: Id: {0} First: {1} Last: {2} Street: {3} City: {4}",
                customer.CustomerId, customer.FirstName, customer.LastName, customer.Street, customer.City);
        }
    }
}