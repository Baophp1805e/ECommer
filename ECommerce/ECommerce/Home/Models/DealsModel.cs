using System;
using Prism.Mvvm;

namespace ECommerce.Home.Models
{
    public class TagsModel: BindableBase
    {
        public int Id { get; set; }
        public string TitleDeal { get; set; }
        public string Desmini { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
    }
}
