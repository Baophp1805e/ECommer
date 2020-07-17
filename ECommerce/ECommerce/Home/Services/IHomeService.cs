using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Home.Models;
using Xamarin.Forms;

namespace ECommerce.Home.Services
{
    public interface IHomeService
    {
        Task<StoreModel[]> GetStoreByECommerceAsync(int id);
        Task<ProductModel[]> GetProductByECommerceAsync(int id);
        Task<List<ProductModel>> FilterByKey(string key);
        Task<ChatModel[]> GetChatByByECommerceAsync(string key);
        Task<TagsModel[]> GetDealByECommerceAsync(int id);
        Task<ObservableCollection<GroupedCartModel>> GetCartByECommerceAsync(int id);
        Task<OrderModel[]> GetOrderByECommerceAsync(int id);
        Task<FlagModel[]> GetFlagAsync();
        //Task<TagModel[]> GetTagsByECommerce(int id);
    }

    public class HomeService : IHomeService
    {
        List<ProductModel> productModels;
        List<StoreModel> Stores;
        public HomeService()
        {
            productModels = new List<ProductModel>
            {
                 new ProductModel
                {
                    IdProduct = 1, NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", Desmini = "Wireless On-Ear Headphones", Price = "$299.95"
                },new ProductModel
                {
                    IdProduct = 1, NameProduct = "Beats Solo 2", Image = "ic_headphone", Desmini = "Wireless On Ear Headphones - Gold", Price = "$399.95"
                },new ProductModel
                {
                    IdProduct = 1, NameProduct = "HeadPhone Chinese", Image = "ic_macbook", Desmini = "Wireless On Ear Headphones - Gold", Price = "$499.95"
                },new ProductModel
                {
                    IdProduct = 1, NameProduct = "iPhone 12", Image = "ic_headphone", Desmini = "Wireless On Ear Headphones - Gold", Price = "$10.95"
                },new ProductModel
                {
                    IdProduct = 1, NameProduct = "Macbook Pro 2020 13in", Image = "ic_macbook", Desmini = "Wireless On Ear Headphones - Gold", Price = "$100"
                },new ProductModel
                {
                    IdProduct = 1, NameProduct = "Headphone VietNam", Image = "ic_headphone", Desmini = "Wireless On Ear Headphones - Gold", Price = "$255"
                }
            };
        }


        public Task<List<ProductModel>> FilterByKey(string key)
        {
            try
            {
                var products = productModels.Where(x => x.NameProduct.Contains(key)).ToList();
                return Task.FromResult(products);
            }
            catch (Exception) { return null; }

        }

        public Task<ObservableCollection<GroupedCartModel>> GetCartByECommerceAsync(int id)
        {
            var grouped = new ObservableCollection<GroupedCartModel>();
            var Bao = new GroupedCartModel()
            {
                Store =
                new StoreModel()
                {
                    Id = 1,
                    NameStoreOwner = "Bao",
                    Avatar = "ic_avatar"
                }
            };
            var Quynh = new GroupedCartModel()
            {
                Store =
                new StoreModel()
                {
                    Id = 2,
                    NameStoreOwner = "Quynh",
                    Avatar = "ic_avatar_shop2"
                }
            };
            Bao.Add(new ProductModel() { IdProduct = 1, Image = "ic_headphone", NameProduct = "B&O PLAY BeoPlay H8", Desmini = "Wireless On-Ear Headphones", Price = "$299.95" });
            Bao.Add(new ProductModel() { IdProduct = 1, Image = "ic_headphone", NameProduct = "B&O PLAY BeoPlay H8", Desmini = "Wireless On-Ear Headphones", Price = "$299.95" });
            Bao.Add(new ProductModel() { IdProduct = 1, Image = "ic_headphone", NameProduct = "B&O PLAY BeoPlay H8", Desmini = "Wireless On-Ear Headphones", Price = "$299.95" });
            Quynh.Add(new ProductModel() { IdProduct = 1, Image = "ic_headphone", NameProduct = "B&O PLAY BeoPlay H8", Desmini = "Wireless On-Ear Headphones", Price = "$299.95" });
            Quynh.Add(new ProductModel() { IdProduct = 1, Image = "ic_headphone", NameProduct = "B&O PLAY BeoPlay H8", Desmini = "Wireless On-Ear Headphones", Price = "$299.95" });
            Quynh.Add(new ProductModel() { IdProduct = 1, Image = "ic_headphone", NameProduct = "B&O PLAY BeoPlay H8", Desmini = "Wireless On-Ear Headphones", Price = "$299.95" });
            grouped.Add(Bao);
            grouped.Add(Quynh);
            return Task.FromResult(grouped);
        }

        public Task<ChatModel[]> GetChatByByECommerceAsync(string key)
        {
            var ListChat = new ChatModel[]
            {
                new ChatModel
                {
                    Id = 1,
                    Content = "Hello. I was wondering if you still have the Beats Solo 2 Pink version available.", DateCreated = "5m ago",
                    User = new Customers.Model.CustomerModel() { NameCustomer = "Martha Richards", Avatar = "ic_avatar_shop2"}
                },
                new ChatModel
                {
                    Id = 2,
                    Content = "Hi Martha. Unfortunately, I don’t have those in stock yet, but they should be here next week, if you are not in a hurry.", DateCreated = "2m ago",
                    User = new Customers.Model.CustomerModel() { NameCustomer = "Mark Robertson", Avatar = "ic_avatar"}
                },new ChatModel
                {
                    Id = 3,
                    Content = "Thanks for the response. Yeah, that works.", DateCreated = "1m ago",
                    User = new Customers.Model.CustomerModel() { NameCustomer = "Martha Richards", Avatar = "ic_avatar_shop2"}
                }
            };
            return Task.FromResult(ListChat);
        }

        public Task<TagsModel[]> GetDealByECommerceAsync(int id)
        {
            var ListDeal = new TagsModel[]
            {
                new TagsModel
                {
                    Id = 1, TitleDeal = "White City Bike", Desmini = "Be free, be more active. You have a chance to do that with this cool bike.", Price = "$499.95", Image = "ic_deal1"
                },new TagsModel
                {
                    Id = 1, TitleDeal = "Happy Hugs Coffee Cup", Desmini = "Cool coffee cup for the sad rainy days. Buy this and improve your life.", Price = "$9.95", Image = "ic_deal2"
                },new TagsModel
                {
                    Id = 1, TitleDeal = "Designer’s Desk", Desmini = "Be free, be more active. You have a chance to do that with this cool bike.", Price = "$5599.95", Image = "ic_deal3"
                },new TagsModel
                {
                    Id = 1, TitleDeal = "Designer’s Desk", Desmini = "Cool coffee cup for the sad rainy days. Buy this and improve your life.", Price = "$4939.95", Image = "ic_deal4"
                },new TagsModel
                {
                    Id = 1, TitleDeal = "White City Bike", Desmini = "Be free, be more active. You have a chance to do that with this cool bike.", Price = "$99.95", Image = "ic_deal3"
                },new TagsModel
                {
                    Id = 1, TitleDeal = "White City Bike", Desmini = "Cool coffee cup for the sad rainy days. Buy this and improve your life.", Price = "$9.95", Image = "ic_deal1"
                }
            };
            return Task.FromResult(ListDeal);
        }

        public Task<FlagModel[]> GetFlagAsync()
        {
            var flag = new FlagModel[]
                {
                        new FlagModel{ Id = 1, NameFlag = "EN", ImageFlag = "AMERICAN.png"},
                        new FlagModel{ Id = 2, NameFlag = "KO", ImageFlag = "KOREA.png"},
                        new FlagModel{ Id = 3, NameFlag = "CN", ImageFlag = "CHINA.png"},
                        new FlagModel{ Id = 4, NameFlag = "JP", ImageFlag = "JAPAN.png"}
                };

            return Task.FromResult(flag);
        }

        public Task<OrderModel[]> GetOrderByECommerceAsync(int id)
        {
            var ListOrder = new OrderModel[]
            {
                new OrderModel { Id = 1,  isShip = 1, Status = "Shipped" , NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", DateOrdered = "04/10/2019" },
                new OrderModel { Id = 1,isShip = 2, Status = "Canceled" ,NameProduct = "Beats Solo 2", Image = "ic_headphone1", DateOrdered = "10/04/2015" },
                new OrderModel { Id = 1, isShip = 1,Status = "Shipped" ,NameProduct = "Macbook Pro 2020 13in", Image = "ic_macbook", DateOrdered = "12/06/2020" },
                new OrderModel { Id = 1,isShip = 2, Status = "Canceled" ,NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone2", DateOrdered = "04/10/2015" },
                new OrderModel { Id = 1, isShip = 1,Status = "Shipped" ,NameProduct = "Macbook Pro 2020 13in", Image = "ic_macbook", DateOrdered = "04/04/2014" }
            };
            return Task.FromResult(ListOrder);
        }

        public Task<ProductModel[]> GetProductByECommerceAsync(int id)
        {
            var ListProduct = new ProductModel[]
            {
                new ProductModel
                {
                    IdProduct = 1, NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", Desmini = "Wireless On-Ear Headphones", Price = "$299.95"
                },new ProductModel
                {
                    IdProduct = 2, NameProduct = "Beats Solo 2", Image = "ic_headphone", Desmini = "Wireless On Ear Headphones - Gold", Price = "$399.95"
                },new ProductModel
                {
                    IdProduct = 3, NameProduct = "HeadPhone Chinese", Image = "ic_macbook", Desmini = "Wireless On Ear Headphones - Gold", Price = "$499.95"
                },new ProductModel
                {
                    IdProduct = 4, NameProduct = "iPhone 12", Image = "ic_headphone", Desmini = "Wireless On Ear Headphones - Gold", Price = "$10.95"
                },new ProductModel
                {
                    IdProduct = 5, NameProduct = "Macbook Pro 2020 13in", Image = "ic_macbook", Desmini = "Wireless On Ear Headphones - Gold", Price = "$100"
                },new ProductModel
                {
                    IdProduct = 6, NameProduct = "Headphone VietNam", Image = "ic_headphone", Desmini = "Wireless On Ear Headphones - Gold", Price = "$255"
                }
            };
            return Task.FromResult(ListProduct);
        }

        public Task<StoreModel[]> GetStoreByECommerceAsync(int id)
        {
            var ListStore = new StoreModel[]
            {
                new StoreModel {Id = 1, NameStoreOwner = "Mark Robertson", Avatar = "ic_avatar", BgShop = "ic_bg_home" ,Address = "San Francisco, California", Review = "8,095 reviews",

                    Product = new ProductModel[]
                    {
                        new ProductModel {IdProduct = 1, IdStore = 1 , NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_headphone"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone1"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone2"
                            }
                        }},
                        new ProductModel {IdProduct = 2, IdStore = 1 ,NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_headphone"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone1"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone2"
                            }
                        }},
                        new ProductModel {IdProduct = 3, IdStore = 1 ,NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_headphone"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone1"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone2"
                            }
                        }}
                    }
                },

                new StoreModel {Id = 2, NameStoreOwner = "Adidas", Avatar = "ic_avatar_shop2", BgShop = "ic_bg_home", Address = "San Francisco, California", Review = "1,000 reviews",
                 Product = new ProductModel[]
                    {
                        new ProductModel {IdProduct = 1, IdStore = 2 ,NameProduct = "Macbook Pro 2020 13in", Image = "ic_macbook", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_macbook"
                            },new ImageProductModel()
                            {
                                Image = "ic_macbook"
                            },new ImageProductModel()
                            {
                                Image = "ic_macbook"
                            }
                        }},
                        new ProductModel {IdProduct = 2,IdStore = 2 , NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_headphone"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone1"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone2"
                            }
                        }},
                        new ProductModel {IdProduct = 3, IdStore = 3 , NameProduct = "Macbook Pro 2020 13in", Image = "ic_macbook", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_macbook"
                            },new ImageProductModel()
                            {
                                Image = "ic_macbook"
                            },new ImageProductModel()
                            {
                                Image = "ic_macbook"
                            }
                        }}
                    },},
                new StoreModel {Id = 3, NameStoreOwner = "Nguyen Bao", Avatar = "ic_myavatar.jpg", BgShop = "ic_bg_shop2", Address = "Ha Noi, Viet Nam", Review = "9,999 reviews",
                 Product = new ProductModel[]
                    {
                        new ProductModel {IdProduct = 1, IdStore = 3 ,NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_headphone"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone1"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone2"
                            }
                        }},
                        new ProductModel {IdProduct = 2, IdStore = 3 ,NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_headphone"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone1"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone2"
                            }
                        }},
                        new ProductModel {IdProduct = 3, IdStore = 3 , NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_headphone"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone1"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone2"
                            }
                        }}
                    },},
                new StoreModel {Id = 4, NameStoreOwner = "Adidas", Avatar = "ic_avatar_shop2", BgShop = "ic_bg_home", Address = "San Francisco, California", Review = "1,000 reviews",
                 Product = new ProductModel[]
                    {
                        new ProductModel {IdProduct = 1,IdStore = 4 , NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_headphone"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone1"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone2"
                            }
                        }},
                        new ProductModel {IdProduct = 2,IdStore = 4 , NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_headphone"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone1"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone2"
                            }
                        }},
                        new ProductModel {IdProduct = 3,IdStore = 4 , NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_headphone"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone1"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone2"
                            }
                        }}
                    },},new StoreModel {Id = 5, NameStoreOwner = "Adidas", Avatar = "ic_avatar_shop2", BgShop = "ic_bg_home", Address = "San Francisco, California", Review = "1,000 reviews",
                 Product = new ProductModel[]
                    {
                        new ProductModel {IdProduct = 1, IdStore = 5 ,NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_headphone"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone1"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone2"
                            }
                        }},
                        new ProductModel {IdProduct = 2, IdStore = 5 , NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_headphone"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone1"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone2"
                            }
                        }},
                        new ProductModel {IdProduct = 3,IdStore = 5 , NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_headphone"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone1"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone2"
                            }
                        }}

                    },},new StoreModel {Id = 6, NameStoreOwner = "Adidas", Avatar = "ic_avatar_shop2", BgShop = "ic_bg_home", Address = "San Francisco, California", Review = "1,000 reviews",
                 Product = new ProductModel[]
                    {
                        new ProductModel {IdProduct = 1,IdStore = 6 , NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_headphone"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone1"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone2"
                            }
                        }},
                        new ProductModel {IdProduct = 2, IdStore = 6 ,NameProduct = "B&O PLAY BeoPlay H8", Image = "ic_headphone", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_headphone"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone1"
                            },new ImageProductModel()
                            {
                                Image = "ic_headphone2"
                            }
                        }},
                        new ProductModel {IdProduct = 3, IdStore = 6 ,NameProduct = "Macbook Pro 2019 13 in", Image = "ic_macbook", Price = "$299.95",Desmini = "Wireless On-Ear Headphones", Description = "mmerse yourself in an emotional experience. The Solo2 has a more dynamic, wider range of sound, with a clarity that will bring you closer to what the artist intended you to hear…",
                        ImageArray = new ImageProductModel[]
                        {
                            new ImageProductModel()
                            {
                                Image = "ic_macbook"
                            },new ImageProductModel()
                            {
                                Image = "ic_macbook"
                            },new ImageProductModel()
                            {
                                Image = "ic_macbook"
                            }
                        }}

                    },}

            };

            return Task.FromResult(ListStore);
        }

        //public Task<TagModel[]> GetTagsByECommerce(int id)
        //{
           
        //    var tag = new TagModel[]
        //        {
        //            new TagModel{ IdTag = 1, Title = "1", Size = 40},
        //            new TagModel{ IdTag = 1, Title = "2", Size = 92},
        //            new TagModel{ IdTag = 1, Title = "3", Size = 92},
        //            new TagModel{ IdTag = 1, Title = "4", Size = 92},
        //            new TagModel{ IdTag = 1, Title = "5", Size = 92},
        //            new TagModel{ IdTag = 1, Title = "6", Size = 92},
        //            new TagModel{ IdTag = 1, Title = "7", Size = 92},
        //            new TagModel{ IdTag = 1, Title = "8", Size = 92},
        //            new TagModel{ IdTag = 1, Title = "9", Size = 92},
        //            new TagModel{ IdTag = 1, Title = "10", Size = 92},
        //            new TagModel{ IdTag = 1, Title = "11", Size = 92},
        //            new TagModel{ IdTag = 1, Title = "12", Size = 92},
        //            new TagModel{ IdTag = 1, Title = "13", Size = 92}
        //        };
            
        //    return Task.FromResult(tag);
        //}
    }
}
