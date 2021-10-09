﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace PTrackerAPI.Models
{
    public class Portfolio
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Stock> Stocks { get; set; }
    }
}
