using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOSimulator.Data.Models
{
    public enum ApiTypes
    {
        Easy = 1,
        Main = 2
    }

    public enum ResponseStatus
    {
        InvalidUserNameOrPassword = 1002,
        InvalidSystemNameOrJSONFormat = 2002,
        InvalidRCOServerFile = 8003,
        LicensesAreInUse = 8006,
        MissinsLicense = 8008,
        ServerIsOffline = 8010,
        InvalidApiKey = 8011
    }

    public enum CardTypes
    {
        Normal = 1,
        Temporary = 2,
        Booked = 3,
        TelephoneCard = 4,
        NormalLongID = 5,
        BookedLongID = 6
    }

    [Flags]
    public enum ParameterIncludes
    {
        AccessGroups = 1 << 0,
    }

    public enum RCOLanguage
    {
        fi = 1,
        en,
        sv,
        da,
        nb
    }

    public enum UserType
    {
        User = 0,
        Apartment = 1

    }
}
