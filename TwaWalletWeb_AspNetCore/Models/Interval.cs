﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwaWalletWeb_AspNetCore.Models
{
    /// <summary>
    /// Slouží pro pravidelné platby
    /// </summary>
    public class Interval : IEntity
    {
        private const string TAG = "X:" + nameof(Interval);

        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; } = false;

        /// <summary>
        /// YYMMDD
        /// </summary>
        //[StringLength(6)]
        public string IntervalCode { get; set; }

        public DateTime BeforeDateTime(DateTime startDateTime)
        {
            //Log.Debug(TAG, $"{nameof(NextDateTime)} - {nameof(startDateTime)}:{startDateTime.ToShortDateString()}");

            DateTime result = startDateTime;

            try
            {
                int years, months, days;

                if (int.TryParse(IntervalCode.Substring(0, 2), out years))
                {
                    result = result.AddYears(-years);
                }
                else
                {
                    throw new FormatException("Years couldn't be parsed.");
                }

                if (int.TryParse(IntervalCode.Substring(2, 2), out months))
                {
                    result = result.AddMonths(-months);
                }
                else
                {
                    throw new FormatException("Months couldn't be parsed.");
                }

                if (int.TryParse(IntervalCode.Substring(4, 2), out days))
                {
                    result = result.AddDays(-days);
                }
                else
                {
                    throw new FormatException("Days couldn't be parsed.");
                }
            }
            catch (Exception ex)
            {
                //Log.Error(TAG, nameof(NextDateTime), ex.Message);
                throw;
            }

            return result;
        }

        public DateTime NextDateTime(DateTime startDateTime)
        {
            //Log.Debug(TAG, $"{nameof(NextDateTime)} - {nameof(startDateTime)}:{startDateTime.ToShortDateString()}");

            DateTime result = startDateTime;

            try
            {
                int years, months, days;

                if (int.TryParse(IntervalCode.Substring(0, 2), out years))
                {
                    result = result.AddYears(years);
                }
                else
                {
                    throw new FormatException("Years couldn't be parsed.");
                }

                if (int.TryParse(IntervalCode.Substring(2, 2), out months))
                {
                    result = result.AddMonths(months);
                }
                else
                {
                    throw new FormatException("Months couldn't be parsed.");
                }

                if (int.TryParse(IntervalCode.Substring(4, 2), out days))
                {
                    result = result.AddDays(days);
                }
                else
                {
                    throw new FormatException("Days couldn't be parsed.");
                }
            }
            catch (Exception ex)
            {
                //Log.Error(TAG, nameof(NextDateTime), ex.Message);
                throw;
            }

            return result;
        }

        public override string ToString()
        {
            //var logger = services.GetRequiredService<ILogger<Program>>();
            //logger.LogError(ex, "An error occurred seeding the DB.");
            //Log.Debug(TAG, nameof(ToString));

            return Description;
        }
    }
}
