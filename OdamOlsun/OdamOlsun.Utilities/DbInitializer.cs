using Microsoft.AspNetCore.Identity;
using OdamOlsun.Entities.DbContexts.OdamOlsun.Entities.DbContexts;
using OdamOlsun.Entities.Models.Concrete;

public static class DbInitializer
{
    public static async Task Seed(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
    {
        // Rolleri seed et
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        if (!await roleManager.RoleExistsAsync("Customer"))
        {
            await roleManager.CreateAsync(new IdentityRole("Customer"));
        }

        // Kullanıcıları seed et
        if (userManager.Users.All(u => u.UserName != "admin@site.com"))
        {
            var adminUser = new ApplicationUser
            {
                UserName = "admin@site.com",
                Email = "admin@site.com",
                Name = "Admin",
                Surname = "User",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                CreateDate = DateTime.Now
            };

            var result = await userManager.CreateAsync(adminUser, "Admin123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

        if (userManager.Users.All(u => u.UserName != "user@site.com"))
        {
            var normalUser = new ApplicationUser
            {
                UserName = "user@site.com",
                Email = "user@site.com",
                Name = "Normal",
                Surname = "User",
                PhoneNumber = "5478917509",
                EmailConfirmed = true,
                CreateDate = DateTime.Now
            };

            var result = await userManager.CreateAsync(normalUser, "User123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(normalUser, "Customer");
            }
        }
        if (userManager.Users.All(u => u.UserName != "user2@site.com"))
        {
            var normalUser = new ApplicationUser
            {
                UserName = "user2@site.com",
                Email = "user2@site.com",
                Name = "Normal",
                Surname = "User2",
                PhoneNumber = "5467827613",
                EmailConfirmed = true,
                CreateDate = DateTime.Now
            };

            var result = await userManager.CreateAsync(normalUser, "User123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(normalUser, "Customer");
            }
        }
        if (userManager.Users.All(u => u.UserName != "emirozturk@site.com"))
        {
            var normalUser = new ApplicationUser
            {
                UserName = "emirozturk@site.com",
                Email = "emirozturk@site.com",
                Name = "Emir",
                Surname = "Öztürk",
                PhoneNumber = "5380309297",
                EmailConfirmed = true,
                CreateDate = DateTime.Now
            };

            var result = await userManager.CreateAsync(normalUser, "User123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(normalUser, "Customer");
            }
        }
        if (userManager.Users.All(u => u.UserName != "cemyilmaz@site.com"))
        {
            var normalUser = new ApplicationUser
            {
                UserName = "cemyilmaz@site.com",
                Email = "cemyilmaz@site.com",
                Name = "Cem",
                Surname = "Yılmaz",
                PhoneNumber = "5334567892",
                EmailConfirmed = true,
                CreateDate = DateTime.Now
            };

            var result = await userManager.CreateAsync(normalUser, "User123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(normalUser, "Customer");
            }
        }
        if (userManager.Users.All(u => u.UserName != "tolgacevik@site.com"))
        {
            var normalUser = new ApplicationUser
            {
                UserName = "tolgacevik@site.com",
                Email = "tolgacevik@site.com",
                Name = "Tolga",
                Surname = "Çevik",
                PhoneNumber = "5317658172",
                EmailConfirmed = true,
                CreateDate = DateTime.Now
            };

            var result = await userManager.CreateAsync(normalUser, "User123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(normalUser, "Customer");
            }
        }
        if (userManager.Users.All(u => u.UserName != "azizsancar@site.com"))
        {
            var normalUser = new ApplicationUser
            {
                UserName = "azizsancar@site.com",
                Email = "azizsancar@site.com",
                Name = "Aziz",
                Surname = "Sancar",
                PhoneNumber = "5768193424",
                EmailConfirmed = true,
                CreateDate = DateTime.Now
            };

            var result = await userManager.CreateAsync(normalUser, "User123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(normalUser, "Customer");
            }
        }

        if (!context.Ilanlar.Any())
    {
        var ilanlar = new List<Ilan>
        {
            new Ilan { Title = "Merkezi Konumda Eşyalı Oda", Size = 15, Price = 2000, Deposit = 500, Address = "Toplu taşımaya yakın, sessiz bir sokakta", NumberOfRooms = 1, NumberOfFloorOfBuild = 5, FloorOfHouse = 2, AgeOfBuild = 10, Furnished = true, Cigarette = false, Animal = false, RoomAndHomeDetails = "Geniş balkon, ortak kullanımlı banyo", Il = "34", Ilce = "BEŞİKTAŞ", Semt = "LEVENT MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/00c658e6-be2c-4546-a9c2-02aa9884926e.jpeg"}, new Resim { Url = "/images/ilan/5f6f393c-aa4a-41eb-8c5a-2777b67ca614.jpg" }, new Resim { Url = "/images/ilan/5a4709ac-f950-4f6c-bfc2-e322baed802e.jpeg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "user2@site.com").Id },
            new Ilan { Title = "Sessiz ve Sakin Bir Sokakta Oda", Size = 12, Price = 1500, Deposit = 400, Address = "Yeşillikler içinde, park yakınında", NumberOfRooms = 1, NumberOfFloorOfBuild = 4, FloorOfHouse = 1, AgeOfBuild = 8, Furnished = true, Cigarette = false, Animal = true, RoomAndHomeDetails = "Bahçeli, ortak mutfak", Il = "35", Ilce = "KARŞIYAKA", Semt = "BOSTANLI MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/00c658e6-be2c-4546-a9c2-02aa9884926e.jpg" }, new Resim { Url = "/images/ilan/de3da08b-92f7-4704-9c53-999662deb2c4.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "user2@site.com").Id },
            new Ilan { Title = "Uygun Fiyatlı Öğrenciye Uygun Oda", Size = 10, Price = 1000, Deposit = 300, Address = "Üniversiteye yürüme mesafesinde", NumberOfRooms = 1, NumberOfFloorOfBuild = 3, FloorOfHouse = 2, AgeOfBuild = 15, Furnished = true, Cigarette = true, Animal = false, RoomAndHomeDetails = "Ortak kullanım alanları, kablosuz internet", Il = "6", Ilce = "ÇANKAYA", Semt = "KIZILAY MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/00c658e6-be2c-4546-a9c2-02aa9884926e.jpeg" }, new Resim { Url = "/images/ilan/9a9a7c91-25b1-4aec-b3f8-71824685f55f.jpg" }, new Resim { Url = "/images/ilan/5f6f393c-aa4a-41eb-8c5a-2777b67ca614.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "cemyilmaz@site.com").Id },
            new Ilan { Title = "Çift Kişilik Yataklı Ferah Oda", Size = 18, Price = 2500, Deposit = 600, Address = "Alışveriş merkezine yakın, nezih bir mahallede", NumberOfRooms = 1, NumberOfFloorOfBuild = 6, FloorOfHouse = 3, AgeOfBuild = 5, Furnished = true, Cigarette = false, Animal = true, RoomAndHomeDetails = "Geniş gardırop, özel banyo", Il = "34", Ilce = "ŞİŞLİ", Semt = "DUATEPE MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/e6913234-942c-4ff6-a211-e98e26ef4188.jpg" }, new Resim { Url = "/images/ilan/00c658e6-be2c-4546-a9c2-02aa9884926e.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "user2@site.com").Id },
            new Ilan { Title = "Metroya Yakın, Uygun Fiyatlı Oda", Size = 14, Price = 1800, Deposit = 450, Address = "Toplu taşımaya yakın, merkezi konum", NumberOfRooms = 1, NumberOfFloorOfBuild = 7, FloorOfHouse = 4, AgeOfBuild = 12, Furnished = true, Cigarette = false, Animal = false, RoomAndHomeDetails = "Ortak mutfak, geniş pencere", Il = "34", Ilce = "BAKIRKÖY", Semt = "ATAKÖY 1. KISIM MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/de3da08b-92f7-4704-9c53-999662deb2c4.jpg" }, new Resim { Url = "/images/ilan/00c658e6-be2c-4546-a9c2-02aa9884926e.jpeg" }, new Resim { Url = "/images/ilan/e23bfbad-4e98-4f41-848a-5d79ed81ccd1.jpg" }, new Resim { Url = "/images/ilan/ceaf48c2-a168-4a6d-af1c-de1c1d9f4a56.jpg" }, new Resim { Url = "/images/ilan/d0e66573-6817-46b8-8c80-cfe8b1e5a75e.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "emirozturk@site.com").Id },
            new Ilan { Title = "Lüks Rezidans'ta Manzaralı Oda", Size = 20, Price = 3500, Deposit = 1000, Address = "Rezidans içinde, güvenlikli", NumberOfRooms = 1, NumberOfFloorOfBuild = 20, FloorOfHouse = 15, AgeOfBuild = 2, Furnished = true, Cigarette = false, Animal = false, RoomAndHomeDetails = "Yüzme havuzu, fitness salonu", Il = "34", Ilce = "KADIKÖY", Semt = "ACIBADEM MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/fdab5ec6-f6b9-48db-afa9-7c687dd3780f.jpeg" }, new Resim { Url = "/images/ilan/c1939ec5-fa0f-4adc-8c2c-970e838f6e55.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "azizsancar@site.com").Id },
            new Ilan { Title = "Deniz Manzaralı Sakin Oda", Size = 17, Price = 2700, Deposit = 700, Address = "Sahil kenarında, doğa ile iç içe", NumberOfRooms = 1, NumberOfFloorOfBuild = 10, FloorOfHouse = 6, AgeOfBuild = 6, Furnished = true, Cigarette = false, Animal = true, RoomAndHomeDetails = "Geniş teras, deniz manzarası", Il = "35", Ilce = "KONAK", Semt = "ALSANCAK MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/fdab5ec6-f6b9-48db-afa9-7c687dd3780f.jpeg" }, new Resim { Url = "/images/ilan/d0e66573-6817-46b8-8c80-cfe8b1e5a75e.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "emirozturk@site.com").Id },
            new Ilan { Title = "Kiralık Oda - Şehir Merkezinde", Size = 13, Price = 1300, Deposit = 400, Address = "Çarşıya yakın, toplu taşımaya kolay erişim", NumberOfRooms = 1, NumberOfFloorOfBuild = 5, FloorOfHouse = 3, AgeOfBuild = 11, Furnished = true, Cigarette = false, Animal = false, RoomAndHomeDetails = "Merkezi ısıtma, geniş pencere", Il = "6", Ilce = "YENİMAHALLE", Semt = "BATI SİTESİ MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/9a9a7c91-25b1-4aec-b3f8-71824685f55f.jpg" }, new Resim { Url = "/images/ilan/90a93d54-c550-4e07-b7ab-c6d267900c8d.jpg" }, new Resim { Url = "/images/ilan/00c658e6-be2c-4546-a9c2-02aa9884926e.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "emirozturk@site.com").Id },
            new Ilan { Title = "Eşyalı, Bahçeli Oda", Size = 16, Price = 1600, Deposit = 500, Address = "Geniş bahçe, evcil hayvan dostu", NumberOfRooms = 1, NumberOfFloorOfBuild = 2, FloorOfHouse = 1, AgeOfBuild = 20, Furnished = true, Cigarette = true, Animal = true, RoomAndHomeDetails = "Ortak mutfak, bahçe kullanım hakkı", Il = "6", Ilce = "GÖLBAŞI", Semt = "İNCEK MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/de3da08b-92f7-4704-9c53-999662deb2c4.jpg" }, new Resim { Url = "/images/ilan/d0e66573-6817-46b8-8c80-cfe8b1e5a75e.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "cemyilmaz@site.com").Id },
            new Ilan { Title = "Öğrenciye Uygun Geniş Oda", Size = 14, Price = 1200, Deposit = 350, Address = "Üniversite kampüsüne yakın", NumberOfRooms = 1, NumberOfFloorOfBuild = 4, FloorOfHouse = 2, AgeOfBuild = 7, Furnished = true, Cigarette = false, Animal = false, RoomAndHomeDetails = "Kablosuz internet, çalışma masası", Il = "34", Ilce = "MALTEPE", Semt = "FINDIKLI MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/e6913234-942c-4ff6-a211-e98e26ef4188.jpg" }, new Resim { Url = "/images/ilan/00c658e6-be2c-4546-a9c2-02aa9884926e.jpeg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "emirozturk@site.com").Id },
            new Ilan { Title = "Boğaz Manzaralı Lüks Oda", Size = 22, Price = 4000, Deposit = 1200, Address = "Boğaz manzaralı, geniş balkonlu", NumberOfRooms = 1, NumberOfFloorOfBuild = 8, FloorOfHouse = 5, AgeOfBuild = 3, Furnished = true, Cigarette = false, Animal = true, RoomAndHomeDetails = "Özel banyo, geniş salon", Il = "34", Ilce = "BEŞİKTAŞ", Semt = "ORTAKÖY MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/e23bfbad-4e98-4f41-848a-5d79ed81ccd1.jpg" }, new Resim { Url = "/images/ilan/d0e66573-6817-46b8-8c80-cfe8b1e5a75e.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "tolgacevik@site.com").Id },
            new Ilan { Title = "Metroya Yakın, Uygun Fiyatlı Oda", Size = 14, Price = 1700, Deposit = 450, Address = "Toplu taşımaya yakın, merkezi konum", NumberOfRooms = 1, NumberOfFloorOfBuild = 7, FloorOfHouse = 4, AgeOfBuild = 12, Furnished = true, Cigarette = false, Animal = false, RoomAndHomeDetails = "Ortak mutfak, geniş pencere", Il = "34", Ilce = "BAKIRKÖY", Semt = "ATAKÖY 1. KISIM MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/d0e66573-6817-46b8-8c80-cfe8b1e5a75e.jpg" }, new Resim { Url = "/images/ilan/ceaf48c2-a168-4a6d-af1c-de1c1d9f4a56.jpg" }, new Resim { Url = "/images/ilan/5f6f393c-aa4a-41eb-8c5a-2777b67ca614.jpg" }, new Resim { Url = "/images/ilan/5a4709ac-f950-4f6c-bfc2-e322baed802e.jpeg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "cemyilmaz@site.com").Id },
            new Ilan { Title = "Metro Yakını, Merkezi Oda", Size = 13, Price = 1600, Deposit = 400, Address = "Merkezi lokasyon, toplu taşımaya yakın", NumberOfRooms = 1, NumberOfFloorOfBuild = 5, FloorOfHouse = 3, AgeOfBuild = 15, Furnished = true, Cigarette = true, Animal = false, RoomAndHomeDetails = "Ortak kullanım alanları", Il = "34", Ilce = "KADIKÖY", Semt = "FENERBAHÇE MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/ceaf48c2-a168-4a6d-af1c-de1c1d9f4a56.jpg" }, new Resim { Url = "/images/ilan/e6913234-942c-4ff6-a211-e98e26ef4188.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "cemyilmaz@site.com").Id },
            new Ilan { Title = "Geniş ve Aydınlık Oda", Size = 19, Price = 2400, Deposit = 800, Address = "Sessiz sokakta, merkezi konum", NumberOfRooms = 1, NumberOfFloorOfBuild = 6, FloorOfHouse = 3, AgeOfBuild = 5, Furnished = true, Cigarette = false, Animal = true, RoomAndHomeDetails = "Geniş pencere, ortak mutfak", Il = "35", Ilce = "KONAK", Semt = "GÜZELYALI MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/c1939ec5-fa0f-4adc-8c2c-970e838f6e55.jpg" }, new Resim { Url = "/images/ilan/00c658e6-be2c-4546-a9c2-02aa9884926e.jpeg" }, new Resim { Url = "/images/ilan/00c658e6-be2c-4546-a9c2-02aa9884926e.jpg" }, new Resim { Url = "/images/ilan/ceaf48c2-a168-4a6d-af1c-de1c1d9f4a56.jpg" }, new Resim { Url = "/images/ilan/9a9a7c91-25b1-4aec-b3f8-71824685f55f.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "cemyilmaz@site.com").Id },
            new Ilan { Title = "Uygun Fiyatlı, Merkezi Oda", Size = 14, Price = 1300, Deposit = 400, Address = "Merkezi konum, toplu taşımaya yakın", NumberOfRooms = 1, NumberOfFloorOfBuild = 4, FloorOfHouse = 2, AgeOfBuild = 18, Furnished = true, Cigarette = true, Animal = false, RoomAndHomeDetails = "Ortak mutfak, kablosuz internet", Il = "6", Ilce = "ÇANKAYA", Semt = "KIZILAY MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/a9dbdebd-178a-4abd-95b9-55752675e82f.jpeg" }, new Resim { Url = "/images/ilan/57803cd4-c0e4-4df1-8ff5-34c4ee3b99be.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "tolgacevik@site.com").Id },
            new Ilan { Title = "Öğrenciye Uygun Ferah Oda", Size = 15, Price = 1400, Deposit = 350, Address = "Üniversiteye yürüme mesafesinde", NumberOfRooms = 1, NumberOfFloorOfBuild = 3, FloorOfHouse = 2, AgeOfBuild = 14, Furnished = true, Cigarette = false, Animal = false, RoomAndHomeDetails = "Ortak kullanım alanları, kablosuz internet", Il = "34", Ilce = "BEYLİKDÜZÜ", Semt = "YAKUPLU MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/556215ef-5742-473f-9471-bbdc09a72f8a.jpeg" }, new Resim { Url = "/images/ilan/82f30065-ac2a-4f21-9666-4644051e38d2.jpeg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "tolgacevik@site.com").Id },
            new Ilan { Title = "Merkezi Konumda Bahçeli Oda", Size = 18, Price = 2600, Deposit = 700, Address = "Bahçeli, merkezi konumda", NumberOfRooms = 1, NumberOfFloorOfBuild = 5, FloorOfHouse = 2, AgeOfBuild = 10, Furnished = true, Cigarette = false, Animal = true, RoomAndHomeDetails = "Bahçe kullanımı, geniş salon", Il = "34", Ilce = "ÜSKÜDAR", Semt = "KUZGUNCUK MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/90a93d54-c550-4e07-b7ab-c6d267900c8d.jpg" }, new Resim { Url = "/images/ilan/556215ef-5742-473f-9471-bbdc09a72f8a.jpeg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "azizsancar@site.com").Id },
            new Ilan { Title = "Geniş ve Ferah Oda", Size = 20, Price = 2800, Deposit = 800, Address = "Şehir merkezinde, ulaşım kolaylığı", NumberOfRooms = 1, NumberOfFloorOfBuild = 7, FloorOfHouse = 4, AgeOfBuild = 7, Furnished = true, Cigarette = false, Animal = true, RoomAndHomeDetails = "Ortak kullanım alanları, geniş pencere", Il = "34", Ilce = "MALTEPE", Semt = "FINDIKLI MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/57803cd4-c0e4-4df1-8ff5-34c4ee3b99be.jpg" }, new Resim { Url = "/images/ilan/81f9333c-efd5-4fbd-9bc6-66aec304821e.jpg" }, new Resim { Url = "/images/ilan/7d547323-e501-4b05-bbf8-c8b0d904a944.jpg" }, new Resim { Url = "/images/ilan/00c658e6-be2c-4546-a9c2-02aa9884926e.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "cemyilmaz@site.com").Id },
            new Ilan { Title = "Boğaz Manzaralı Geniş Oda", Size = 24, Price = 4500, Deposit = 1300, Address = "Boğaz manzaralı, geniş balkonlu", NumberOfRooms = 1, NumberOfFloorOfBuild = 8, FloorOfHouse = 5, AgeOfBuild = 3, Furnished = true, Cigarette = false, Animal = true, RoomAndHomeDetails = "Özel banyo, geniş salon", Il = "34", Ilce = "BEŞİKTAŞ", Semt = "ORTAKÖY MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/82f30065-ac2a-4f21-9666-4644051e38d2.jpeg" }, new Resim { Url = "/images/ilan/1841f230-d25e-4e66-8398-8395bc56f74a.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "azizsancar@site.com").Id },
            new Ilan { Title = "Metroya Yakın Lüks Oda", Size = 22, Price = 3700, Deposit = 1100, Address = "Merkezi konum, metroya yakın", NumberOfRooms = 1, NumberOfFloorOfBuild = 10, FloorOfHouse = 6, AgeOfBuild = 5, Furnished = true, Cigarette = false, Animal = false, RoomAndHomeDetails = "Geniş pencere, kablosuz internet", Il = "34", Ilce = "ATAŞEHİR", Semt = "BARBAROS MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/1841f230-d25e-4e66-8398-8395bc56f74a.jpg" }, new Resim { Url = "/images/ilan/9a9a7c91-25b1-4aec-b3f8-71824685f55f.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "tolgacevik@site.com").Id },
            new Ilan { Title = "Metro Yakını, Sessiz Oda", Size = 14, Price = 1700, Deposit = 450, Address = "Toplu taşımaya yakın, merkezi konum", NumberOfRooms = 1, NumberOfFloorOfBuild = 7, FloorOfHouse = 4, AgeOfBuild = 12, Furnished = true, Cigarette = false, Animal = false, RoomAndHomeDetails = "Ortak mutfak, geniş pencere", Il = "34", Ilce = "BAKIRKÖY", Semt = "YEŞİLKÖY MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/81f9333c-efd5-4fbd-9bc6-66aec304821e.jpg" }, new Resim { Url = "/images/ilan/e23bfbad-4e98-4f41-848a-5d79ed81ccd1.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "cemyilmaz@site.com").Id },
            new Ilan { Title = "Uygun Fiyatlı Öğrenci Odası", Size = 10, Price = 1000, Deposit = 300, Address = "Üniversiteye yürüme mesafesinde", NumberOfRooms = 1, NumberOfFloorOfBuild = 4, FloorOfHouse = 2, AgeOfBuild = 20, Furnished = true, Cigarette = false, Animal = false, RoomAndHomeDetails = "Ortak kullanım alanları, kablosuz internet", Il = "35", Ilce = "BORNOVA", Semt = "EVKA 3 MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/54d03742-23fc-42a4-844b-f4a9348fd402.jpeg" }, new Resim { Url = "/images/ilan/00c658e6-be2c-4546-a9c2-02aa9884926e.jpeg" }, new Resim { Url = "/images/ilan/00c658e6-be2c-4546-a9c2-02aa9884926e.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "tolgacevik@site.com").Id },
            new Ilan { Title = "Şehir Merkezinde Lüks Oda", Size = 23, Price = 3900, Deposit = 1200, Address = "Şehir merkezinde, ulaşım kolaylığı", NumberOfRooms = 1, NumberOfFloorOfBuild = 9, FloorOfHouse = 5, AgeOfBuild = 8, Furnished = true, Cigarette = false, Animal = true, RoomAndHomeDetails = "Özel banyo, geniş balkon", Il = "34", Ilce = "ŞİŞLİ", Semt = "KAPTANPAŞA MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/5a4709ac-f950-4f6c-bfc2-e322baed802e.jpeg" }, new Resim { Url = "/images/ilan/e23bfbad-4e98-4f41-848a-5d79ed81ccd1.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "azizsancar@site.com").Id },
            new Ilan { Title = "Merkezi Konumda Uygun Fiyatlı Oda", Size = 12, Price = 1500, Deposit = 400, Address = "Merkezi lokasyon, toplu taşımaya yakın", NumberOfRooms = 1, NumberOfFloorOfBuild = 6, FloorOfHouse = 3, AgeOfBuild = 10, Furnished = true, Cigarette = false, Animal = false, RoomAndHomeDetails = "Ortak kullanım alanları, kablosuz internet", Il = "34", Ilce = "KADIKÖY", Semt = "ACIBADEM MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/9a9a7c91-25b1-4aec-b3f8-71824685f55f.jpg" }, new Resim { Url = "/images/ilan/e23bfbad-4e98-4f41-848a-5d79ed81ccd1.jpg" }, new Resim { Url = "/images/ilan/5a4709ac-f950-4f6c-bfc2-e322baed802e.jpeg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "tolgacevik@site.com").Id },
            new Ilan { Title = "Bahçeli Geniş Oda", Size = 18, Price = 2800, Deposit = 800, Address = "Bahçeli, merkezi konumda", NumberOfRooms = 1, NumberOfFloorOfBuild = 5, FloorOfHouse = 2, AgeOfBuild = 12, Furnished = true, Cigarette = false, Animal = true, RoomAndHomeDetails = "Bahçe kullanımı, geniş salon", Il = "34", Ilce = "ÜSKÜDAR", Semt = "KUZGUNCUK MAH", Resims = new List<Resim> { new Resim { Url = "/images/ilan/00c658e6-be2c-4546-a9c2-02aa9884926e.jpg" }, new Resim { Url = "/images/ilan/a9dbdebd-178a-4abd-95b9-55752675e82f.jpeg" }, new Resim { Url = "/images/ilan/54d03742-23fc-42a4-844b-f4a9348fd402.jpeg" }, new Resim { Url = "/images/ilan/7d547323-e501-4b05-bbf8-c8b0d904a944.jpg" } }, ApplicationUserId = context.Users.FirstOrDefault(u=> u.Email == "cemyilmaz@site.com").Id },
        };

        await context.Ilanlar.AddRangeAsync(ilanlar);
        await context.SaveChangesAsync();
    }
    }
}
