﻿using Nest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoxProtocol.Models;
using Xamarin.Essentials;
using MagicOnion;

namespace BoxProtocol.Interfaces
{
    public interface IServerDB : IService<IServerDB>
    {
        UnaryResult<bool> Add(Item item);
        UnaryResult<bool> Update(Item updated);
        UnaryResult<bool> Delete(string id);
        UnaryResult<Item>  Get(string id);
        UnaryResult<List<Item>>  GetAll() ;
        UnaryResult<List<Item>> GetOnLocation(GeoLocation point);
        //Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
