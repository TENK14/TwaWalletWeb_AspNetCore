﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TwaWalletWeb_AspNetCore.Models
{
    public class Record : IEntity
    {
        private const string TAG = "X:" + nameof(Record);

        public int Id { get; set; }

        public float Cost { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// ForingKey
        /// </summary>
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int Warranty { get; set; }
        /// <summary>
        /// ForingKey
        /// </summary>
        public int UserId { get; set; }
        public User User { get; set; }
        /// <summary>
        /// ForingKey
        /// </summary>
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// Možnost filtrování (Ebay, Norsko, Francie,...)
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// true - příjem
        /// false - výdej
        /// </summary>
        public bool Earnings { get; set; } = false;

        //public Timestamp DateCreated { get; set; }

        //public Record IncludeObjects(IDataContext db)
        //{
        //    //Log.Debug(TAG, nameof(IncludeObjects));

        //    this.Owner = db.Select<Owner, int>((o) => o.Id == this.OwnerId, (o) => o.Id).Result.FirstOrDefault();
        //    this.PaymentType = db.Select<PaymentType, int>((o) => o.Id == this.PaymentTypeId, (o) => o.Id).Result.FirstOrDefault();
        //    this.Category = db.Select<Category, int>((o) => o.Id == this.CategoryId, (o) => o.Id).Result.FirstOrDefault();
        //    return this;
        //}

        public override string ToString()
        {
            //Log.Debug(TAG, nameof(ToString));

            return Description;
        }

        public string ToString(char delimiter, string dateFormat)
        {
            //Log.Debug(TAG, $"{nameof(ToString)} - {nameof(delimiter)}:{delimiter}, {nameof(dateFormat)}:{dateFormat}");

            //"01.10.2016"; "-170.0"; "obcerstveni"; "Vylety"; "0"; "Hotovost"; "Tom"
            return
                $"{Date.ToString(dateFormat)}{delimiter}"
                + $"{Cost}{delimiter}"
                + $"{Description}{delimiter}"
                //+ $"{CategoryId}{delimiter}"
                + $"{Category?.Description ?? string.Empty}{delimiter}"
                + $"{Warranty}{delimiter}"
                //+ $"{PaymentTypeId}{delimiter}"
                + $"{PaymentType.Description}{delimiter}"
                //+ $"{OwnerId}{delimiter}"
                + $"{User.Name}{delimiter}"
                + $"{Tag}{delimiter}"
                ;
        }
    }
}
