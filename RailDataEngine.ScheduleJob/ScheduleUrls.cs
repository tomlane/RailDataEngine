namespace RailDataEngine.ScheduleJob
{
    public static class ScheduleUrls
    {
        public static string MondaySchedule
        {
            get
            {
                return "https://datafeeds.networkrail.co.uk/ntrod/CifFileAuthenticate?type=CIF_EF_TOC_UPDATE_DAILY&day=toc-update-mon";
            }
        }

        public static string TuesdaySchedule
        {
            get
            {
                return "https://datafeeds.networkrail.co.uk/ntrod/CifFileAuthenticate?type=CIF_EF_TOC_UPDATE_DAILY&day=toc-update-tue";
            }
        }

        public static string WednesdaySchedule
        {
            get
            {
                return "https://datafeeds.networkrail.co.uk/ntrod/CifFileAuthenticate?type=CIF_EF_TOC_UPDATE_DAILY&day=toc-update-wed";
            }
        }

        public static string ThursdaySchedule
        {
            get
            {
                return "https://datafeeds.networkrail.co.uk/ntrod/CifFileAuthenticate?type=CIF_EF_TOC_UPDATE_DAILY&day=toc-update-thu";
            }
        }

        public static string FridaySchedule
        {
            get
            {
                return "https://datafeeds.networkrail.co.uk/ntrod/CifFileAuthenticate?type=CIF_EF_TOC_UPDATE_DAILY&day=toc-update-fri";
            }
        }

        public static string SaturdaySchedule
        {
            get
            {
                return "https://datafeeds.networkrail.co.uk/ntrod/CifFileAuthenticate?type=CIF_EF_TOC_UPDATE_DAILY&day=toc-update-sat";
            }
        }

        public static string SundaySchedule
        {
            get
            {
                return "https://datafeeds.networkrail.co.uk/ntrod/CifFileAuthenticate?type=CIF_EF_TOC_UPDATE_DAILY&day=toc-update-sun";
            }
        }
    }
}
