using System;
using ECommerce.Customers.Model;
using Prism.Mvvm;

namespace ECommerce.Home.Models
{
    public class ChatModel: BindableBase
    {
        public int Id { get; set; }
        public CustomerModel User { get; set; }
        public string DateCreated { get; set; }
        public string Content { get; set; }
    }
}
