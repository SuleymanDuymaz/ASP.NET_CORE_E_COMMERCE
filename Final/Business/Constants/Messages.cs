﻿using Core.Entities.Concrete;
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
        public static string ProductAdded = "Ürün başarıyla eklendi";
        public static string ProductDeleted = "Ürün başarıyla silindi";
        public static string ProductUpdated = "Ürün başarıyla güncellendi";

        public static string CategoryUpdated = "Kategori başarıyla güncellendi";



        public static string ShipperUpdated = "Gönderici başarıyla güncellendi";
        public static string ShipperAdded = "Gönderici başarıyla eklendi";


        public static string EmployeeAdded = "Gönderici başarıyla eklendi";
        public static string EmployeeUpdated = "Gönderici başarıyla güncellendi";

        public static string TerritoryAdded = "Bölge başarıyla eklendi";
        public static string TerritoryUpdated = "Bölge başarıyla güncellendi";
        public static string TerritoryDeleted = "Bölge başarıyla silindi";



        public static string SupplierAdded = "Tedarikçi başarıyla eklendi";
        public static string SupplierUpdated = "Tedarikçi başarıyla güncellendi";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";

    }
}
