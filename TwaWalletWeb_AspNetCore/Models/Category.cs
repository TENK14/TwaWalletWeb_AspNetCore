using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwaWalletWeb_AspNetCore.Models
{
    /// <summary>
    /// Slouží za účelem kategorizace jednotlivých položek
    /// </summary>
    public class Category : IEntity
    {
        private const string TAG = "X:" + nameof(Category);

        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; } = false;
    }
}
