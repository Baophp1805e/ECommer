using System;
using Prism.Mvvm;

namespace ECommerce.Home.Models
{
    public class TagModel: BindableBase
    {
        public int IdTag { get; set; }
        public ProductModel Product { get; set; }
        public string Title { get; set; }
        public float SizeTag { get; set; }
        public float Radious { get { return SizeTag / 2; }}
    }
}
