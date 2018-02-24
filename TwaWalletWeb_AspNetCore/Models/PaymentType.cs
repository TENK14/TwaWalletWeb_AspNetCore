﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwaWalletWeb_AspNetCore.Models
{
    /// <summary>
    /// Informace o typu platby (např. hotovostí nebo kartou)
    /// </summary>
    public class PaymentType : IEntity
    {
        private const string TAG = "X:" + nameof(PaymentType);

        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; } = false;

        public override string ToString()
        {
            //Log.Debug(TAG, nameof(ToString));

            return Description;
        }
    }
}
