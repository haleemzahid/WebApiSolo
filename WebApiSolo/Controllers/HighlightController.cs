using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSolo.CustomApiService;
using WebApiSolo.Models;

namespace WebApiSolo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HighlightController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("GetHighlightedData")]
        public async Task<string> GetData()
        {
            var data=await SaveSiteDetails(await  new Api_service().GetDataOfHighLight());
            using (surebetdbContext db=new surebetdbContext())
            {
                return JsonConvert.SerializeObject(db.SiteData.ToList());
            }
            
        }

        public async Task<bool> SaveSiteDetails(string data)
        {
            try
            {

          
            using (surebetdbContext db = new surebetdbContext())
            {

                var dataList = JsonConvert.DeserializeObject<ApiModel.Upcomming_Data>(data);


                    var specificData = dataList.data.Where( x => x.sites.Any(x => x.site_key.ToLower() == "betfair" || x.site_key.ToLower() == "sport888" || x.site_key.ToLower() == "pinnacle")).ToList();

                foreach (var item in specificData)
                {

                        if (db.SiteData.Any(x => x.SiteUniqueId == item.id))
                        {
                            continue;
                        }

                        SiteDatum site = new SiteDatum();
                    site.HomeTeam = item.home_team;
                    site.League = item.sport_nice;
                    site.Day = item.commence_time.ToString();
                    site.AwayTeam = item.teams.Where(x => x!= item.home_team).FirstOrDefault();
                    site.Site = item.sites.FirstOrDefault().site_key;
                    var winner_info = item.sites.Where(x => x.site_key.ToLower() == "betfair" || x.site_key.ToLower() == "sport888" || x.site_key.ToLower() == "pinnacle").FirstOrDefault();
                        if (winner_info!=null)
                        {
                            site.Site = winner_info.site_key;
                        }
                        try
                        {
                            site.SiteId = db.TblSites.Where(x => x.SiteName.ToLower().Contains(item.sport_key.ToLower())).FirstOrDefault().SiteId;
                         }
                        catch
                        {

                        }
                    site.SiteUniqueId = item.id;
                    
                    if (winner_info != null) {

                        try
                        {
                            site.HomeWin = winner_info.odds.h2h[0].ToString();
                        }
                        catch
                        {

                        }

                        try
                        {
                            site.Draw = winner_info.odds.h2h[1].ToString();
                        }
                        catch
                        {

                        }

                        try
                        {
                            site.AwayWin = winner_info.odds.h2h[0].ToString();
                        }
                        catch
                        {

                        }

                    }
                        db.SiteData.Add(site);
                        db.SaveChanges();
                }

                return true;
            }
            }
            catch (Exception ex)
            {

                return false;
            }

        }


    }
}
