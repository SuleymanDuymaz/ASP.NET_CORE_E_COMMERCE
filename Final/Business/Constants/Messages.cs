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
        public static string Maintenance="Sistem bakımda";
        public static string ProductListed="Ürünler listelendi";
        public static string ProductCountOfCategoryError = "Bu kategoriye daha fazla ürün eklenemez";

        public static string CategoryCountExceded = "Kategori limiti aşıldığı için bu kategoriye alan eklenemez";
    }
}
