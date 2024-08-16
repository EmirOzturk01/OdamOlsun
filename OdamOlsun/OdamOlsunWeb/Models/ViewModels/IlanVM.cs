using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdamOlsunWeb.Models.ViewModels
{
    public class IlanVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Başlık alanı zorunludur")]
        [MaxLength(50,ErrorMessage ="50 karakterden uzun olamaz")]
        [DisplayName("Başlık")]
        public string Title { get; set; }

        //
        [Required(ErrorMessage = "Odanın Metrekaresi alanı zorunludur")]
        [DisplayName("Odanın Metrekaresi")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Lütfen 0 dan büyük bir sayı giriniz.")]
        public int Size { get; set; }

        //
        [Required(ErrorMessage = "Fiyat alanı zorunludur")]
        [DisplayName("Fiyat")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Lütfen 0 dan büyük bir sayı giriniz.")]
        public int Price { get; set; }

        //
        [Required(ErrorMessage = "Depozito alanı zorunludur")]
        [DisplayName("Depozito")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Lütfen 0 dan büyük bir sayı giriniz.")]

        public int Deposit { get; set; }

        //
        [Required(ErrorMessage = "Adres alanı zorunludur")]
        [DisplayName("Adres")]
        public string Address { get; set; }

        //
        [Required(ErrorMessage = "Evdeki Oda Sayısı alanı zorunludur")]
        [DisplayName("Evdeki Oda Sayısı")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Lütfen 0 dan büyük bir sayı giriniz.")]
        public int NumberOfRooms { get; set; }

        //
        [Required(ErrorMessage = "Binadaki Kat Sayısı alanı zorunludur")]
        [DisplayName("Binadaki Kat Sayısı")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Lütfen 0 dan büyük bir sayı giriniz.")]
        public int NumberOfFloorOfBuild { get; set; }

        //
        [Required(ErrorMessage = "Evin Bulunduğu Kat alanı zorunludur")]
        [DisplayName("Evin Bulunduğu Kat")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Lütfen 0 dan büyük bir sayı giriniz.")]
        public int FloorOfHouse { get; set; }

        //
        [Required(ErrorMessage = "Binanın Yaşı alanı zorunludur")]
        [DisplayName("Binanın Yaşı")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Lütfen 0 dan büyük bir sayı giriniz.")]

        public int AgeOfBuild { get; set; }

        //
        [Required]
        [DisplayName("Oda Eşyalı Mı?")]
        public bool Furnished { get; set; }


        //
        [Required]
        [DisplayName("Evde/Odada Sigara İçilebilir mi ?")]
        public bool Cigarette { get; set; }

        //
        [Required]
        [DisplayName("Evde/Odada Hayvan Bakılabilir mi?")]
        public bool Animal { get; set; }

        //
        [Required]
        [DisplayName("Ev ve Oda Hakkında Detaylar")]
        public string? RoomAndHomeDetails { get; set; }

        //
        [Required(ErrorMessage = "Lütfen Bir İl Seçiniz")]
        [DisplayName("İl")]
        public string Il { get; set; }

        //
        [Required(ErrorMessage = "Lütfen Bir İlçe Seçiniz")]
        [DisplayName("İlçe")]
        public string Ilce { get; set; }

        //
        [Required(ErrorMessage = "Lütfen Bir Semt Seçiniz")]
        [DisplayName("Semt")]
        public string Semt { get; set; }

        public IFormFileCollection? Resimler { get; set; }

    }
}