using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AkuteSinglePage.Models
{
    public class LocalizedConcert
    {
        private Concert concert;
        private CultureInfo lang;

        public LocalizedConcert(Concert concert, CultureInfo lang)
        {
            this.concert = concert;
            this.lang = lang;
        }

        public int Id
        {
            get
            {
                return concert.Id;
            }
        }

        public DateTime Date
        {
            get
            {
                return concert.Date;
            }
        }

        public TimeSpan? Time
        {
            get
            {
                return concert.Time;
            }
        }

        public string City
        {
            get
            {
                if (lang.Name == "be")
                {
                    return concert.CityBe;
                }
                if (lang.Name == "ru")
                {
                    return concert.CityRu;
                }
                if (lang.Name == "en")
                {
                    return concert.CityEn;
                }
                return string.Empty;
            }
        }

        public string Address
        {
            get
            {
                if (lang.Name == "be")
                {
                    return concert.AddressBe;
                }
                if (lang.Name == "ru")
                {
                    return concert.AddressRu;
                }
                if (lang.Name == "en")
                {
                    return concert.AddressEn;
                }
                return string.Empty;
            }
        }

        public string Name
        {
            get
            {
                if (lang.Name == "be")
                {
                    return concert.NameBe;
                }
                if (lang.Name == "ru")
                {
                    return concert.NameRu;
                }
                if (lang.Name == "en")
                {
                    return concert.NameEn;
                }
                return string.Empty;
            }
        }

        public string Place
        {
            get
            {
                if (lang.Name == "be")
                {
                    return concert.PlaceBe;
                }
                if (lang.Name == "ru")
                {
                    return concert.PlaceRu;
                }
                if (lang.Name == "en")
                {
                    return concert.PlaceEn;
                }
                return string.Empty;
            }
        }

        public string Contacts
        {
            get
            {
                if (lang.Name == "be")
                {
                    return concert.ContactsBe;
                }
                if (lang.Name == "ru")
                {
                    return concert.ContactsRu;
                }
                if (lang.Name == "en")
                {
                    return concert.ConactsEn;
                }
                return string.Empty;
            }
        }

        public string LogoFilename
        {
            get
            {
                return concert.LogoFilename;
            }
        }
    }
}