﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace OrderApp
{
    public class MarketOrder
    {
        /// <summary>
        /// Id of the Instrument
        /// </summary>
        public string InstrumentId { get; set; }

        /// <summary>
        /// Price of this Instrument available
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Quantity of how many units available at given Price
        /// </summary>
        public int Quantity { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
