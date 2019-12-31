using Windows.ApplicationModel;

namespace KoreaTV.AppClass {
    public static class AppConfig {
        public static readonly string AndroidAppVersion = "4.8";
        public static readonly string AndroidAppVC = "a_4800";
        public static readonly string AndroidAppUK = "dhh1rEkIUsLwHyy0llDIvIN4MB01TJnNIbti8GtEwTY=";
        public static readonly string AndroidUserAgent = "HanjuTV/4.8 (MEIZU Zero; Android 7.0; Scale/2.00)";
        public static readonly string AndroidSign = "wBGtCpB2s2CVv3rFerEPmTqNUYfVdxPcyizLgx1DAD7d9QPLUtnF7bm0pWDm7IES2Mzb7CYBizgyTQVd+a2s9Mvwx3wC8USkmI1wjED8zCdgp3/nKF9DnDCYZsxq5sENnXnvIT3AEuBBFYySyaEAG5FL9nyhe9AFVLqB8BUSCMI67sbFpdYbKAJEHjVj3EbmIwbIbvooZsPhPWe+VRlN80pz/g/kPoLVWimMyrqEodEjZk8xP0TgodUwoCZczpBTnv51yUDWwMQuHqRcd8oV6O0EeZeOCjxV0+7V6RAvxapdgMJdMragNvCyz4bTdEDOfSfW/DjJLf3Uwc1gUuRacXelHeQldrzNnr4VEFyucrvWBTG7tsO+nNaQktqS+raukxuvhAuwnqUWSKBO8n2rtvOQNexDnwuUcBFc68DFH5A/jaXUj6z7mn18n8n2P44cyS0oPfSvqXINhBNHhg86C+bA1Njo5KbdO0XJiqCuI/Aa4eM4i5XrnBW+efC+eCZ+TW9NtggNw12TPfhcR7XFRMzvphiYx7oE/KeQqFNlzUhuxdEh15a/b1ki32wtESSqVu7c0jDXhmigPPZQNIoKX1osG+bJpfe8d7jtcMI3pgI=";

        public static string Version {
            get {
                return string.Format("Version: {0}.{1}.{2}.{3}",
                    Package.Current.Id.Version.Major,
                    Package.Current.Id.Version.Minor,
                    Package.Current.Id.Version.Build,
                    Package.Current.Id.Version.Revision);
            }
        }
    }
}
