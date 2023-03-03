using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        internal static string Maintenance="Sistem bakımda";
        internal static string ProductListed="Ürünler listelendi";
        internal static string ProductCountOfCategoryError = "Bu kategoriye daha fazla ürün eklenemez";
    }
}
