using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün başarıyla eklendi ";
        public static string ProductDeleted = "Ürün başarıyla silindi ";
        public static string ProductUpdated = "Ürün başarıyla güncellendi ";
        public static string UserAdded = "Kullanıcı başarıyla eklendi.";

        public static string UserNotFound = "Kullanıcı bulunamadı !!";

        public static string PasswordNotFound = "Şifre bulunamadı";
        public static string SuccessLogin = "Başarıyla giriş yaptınız";
        public static string ExistingUser ="Kullanıcı halihazırda mevcut ";
        public static string NotExists = "Kullanıcı bulunamadı";
        public static string UserRegistered = "Kullanıcı başaryıla kayıt oldu";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";
    }
}
