using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoreaTV.AppClass {
    public static class Urls {

		public static string HomeUrl = "http://api.hanju.koudaibaobao.com/api/index/recommend_v3";
		public static string UserInfoUrl = "http://api.hanju.koudaibaobao.com/api/user/info";
		public static string starsList = "http://api.hanju.koudaibaobao.com/star/api/star/index";

		private static string hanjuList = "http://api.hanju.koudaibaobao.com/api/series/indexV2?offset={0}&count={1}";
		private static string hanjuInfo = "http://api.hanju.koudaibaobao.com/api/series/ddetailV2?sid={0}";
		private static string starsInfo = "http://api.hanju.koudaibaobao.com/star/api/star/info?sid={0}";
		private static string starsRank = "http://api.hanju.koudaibaobao.com/star/api/star/rank/detail?rid={0}";

		public static string GetHanjuListUrl(int offset=0,int count=48) {
			return string.Format(hanjuList,offset,offset);
		}

		public static string GetHanjuInfoUrl(int sid) {
			return string.Format(hanjuInfo,sid);
		}

		public static string GetStarsInfoUrl(int sid) {
			return string.Format(starsInfo,sid);
		}

		public static string GetStarsRankUrl(int rid) {
			return string.Format(starsRank, rid);
		}

	}
}
