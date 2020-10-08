using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using BoxProtocol;
using BoxProtocol.Models;
using Xamarin.Essentials;
using MagicOnion.Client;
using Grpc.Core;
using BoxProtocol.Interfaces;
using MessagePack;

namespace ConsoleApp
{
    public class tmp
    {
        public async Task ExecuteLoadItemsCommand()
        {
            //var DataStore = new ServerDB();
            var channel = new Channel("localhost", 9200, ChannelCredentials.Insecure);
            var DataStore = MagicOnionClient.Create<IServerDB>(channel);

            Item item_1 = new Item
            {
                Id = Guid.NewGuid().ToString(),
                //Name = "First person",
                /*Place_image_path = "isaak.jpg",
                Place_name = "Исаакиевский собор",
                Place_rating = "10/10",
                Place_location = location,
                Place_description = "This is an item description.",
                Time_created = DateTime.Now*/
            };
            Item item_2 = new Item
            {
                Id = Guid.NewGuid().ToString(),
                //Name = "Second person",
                /*Place_image_path = "Hermitage.jpg",
                Place_name = "Эрмитаж",
                Place_rating = "10/10",
                Place_location = location,
                Place_description = "This is an item description.",
                Time_created = DateTime.Now*/
            };
            await DataStore.Add(item_1);
            await DataStore.Add(item_2);

            try
            {
                //Items.Clear();
                var items = await DataStore.GetAll();
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
    
    public class Program
    {
        static async Task Main(string[] args)
        {
            tmp tmp = new tmp();
            await tmp.ExecuteLoadItemsCommand();
        }

        //public static  ObservableCollection<Item> Items = new ObservableCollection<Item>();
    }
    
}
