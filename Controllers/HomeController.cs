using ivt_test.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Web.Security;

namespace ivt_test.Controllers
{
    public class HomeController : Controller
    {
        static String token;

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Login(Login login, string ReturnUrl = "")
        {
            var userName = login.ApiKey;
            var passwd = login.ApiSecret;
            var url = "http://api.ivtlite.testdrive.club/auth";

            using var client = new HttpClient();

            var authToken = Encoding.ASCII.GetBytes($"{userName}:{passwd}");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(authToken));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            var auth = JsonConvert.DeserializeObject<Authentication>(json.ToString());
            HomeController.token = auth.access_token;
            if (token != null)
            {
                FormsAuthentication.SetAuthCookie(token, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Geçersiz kimlik bilgileri!";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            //token = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public async Task<ActionResult> GetCollector()
        {
            var url = "http://api.ivtlite.testdrive.club//";

            using var client = new HttpClient();


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            var collect = JsonConvert.DeserializeObject<CollectorResult>(json.ToString());
            var tmp = collect.result.ToList();
            return View(tmp);

        }

        [HttpGet]
        public async Task<ActionResult> GetBrand()
        {
            var url = "http://api.ivtlite.testdrive.club/brands";

            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            var brand = JsonConvert.DeserializeObject<BrandResult>(json.ToString());
            var tmp = brand.result.ToList();
            return View(tmp);

        }

        [HttpGet]
        public async Task<ActionResult> SmsWhiteList()
        {
            //var offset = "0";
            //var limit = "10";
            //int detail = 1;
            //int brand;
            //int recipientType;

            var url = "http://api.ivtlite.testdrive.club/portfoy/whitelist/sms?detail=1";

            using var client = new HttpClient();


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            var smswhite = JsonConvert.DeserializeObject<SmsandCallListResult>(json.ToString());
            var tmp = smswhite.result.ToList();
            return View(tmp);
        }

        [HttpGet]
        public async Task<ActionResult> SmsBlackList()
        {
            //var offset = "0";
            //var limit = "10";
            //int detail = 1;
            //int brand;
            //int recipientType;

            var url = "http://api.ivtlite.testdrive.club/portfoy/blacklist/sms?detail=1";

            using var client = new HttpClient();


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            var smsblack = JsonConvert.DeserializeObject<SmsandCallListResult>(json.ToString());
            var tmp = smsblack.result.ToList();
            return View(tmp);
        }

        [HttpGet]
        public async Task<ActionResult> SmsUnknownList()
        {
            //var offset = "0";
            //var limit = "10";
            //int detail = 1;
            //int brand;
            //int recipientType;

            var url = "http://api.ivtlite.testdrive.club/portfoy/unknown/sms?detail=1";

            using var client = new HttpClient();


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            var smsunknown = JsonConvert.DeserializeObject<SmsandCallListResult>(json.ToString());
            var tmp = smsunknown.result.ToList();
            return View(tmp);
        }

        [HttpGet]
        public async Task<ActionResult> CallWhiteList()
        {
            //var offset = "0";
            //var limit = "10";
            //int detail = 1;
            //int brand;
            //int recipientType;

            var url = "http://api.ivtlite.testdrive.club/portfoy/whitelist/call?detail=1";

            using var client = new HttpClient();


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            var callwhite = JsonConvert.DeserializeObject<SmsandCallListResult>(json.ToString());
            var tmp = callwhite.result.ToList();
            return View(tmp);
        }

        [HttpGet]
        public async Task<ActionResult> CallBlackList()
        {
            //var offset = "0";
            //var limit = "10";
            //int detail = 1;
            //int brand;
            //int recipientType;

            var url = "http://api.ivtlite.testdrive.club/portfoy/blacklist/call?detail=1";

            using var client = new HttpClient();


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            var callblack = JsonConvert.DeserializeObject<SmsandCallListResult>(json.ToString());
            var tmp = callblack.result.ToList();
            return View(tmp);
        }

        [HttpGet]
        public async Task<ActionResult> CallUnknownList()
        {
            //var offset = "0";
            //var limit = "10";
            //int detail = 1;
            //int brand;
            //int recipientType;

            var url = "http://api.ivtlite.testdrive.club/portfoy/unknown/call?detail=1";

            using var client = new HttpClient();


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            var callunknown = JsonConvert.DeserializeObject<SmsandCallListResult>(json.ToString());
            var tmp = callunknown.result.ToList();
            return View(tmp);
        }

        [HttpGet]
        public async Task<ActionResult> EmailWhiteList()
        {
            //var offset = "0";
            //var limit = "10";
            //int detail = 1;
            //int brand;
            //int recipientType;

            var url = "http://api.ivtlite.testdrive.club/portfoy/whitelist/sendmail?detail=1";

            using var client = new HttpClient();


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            var sendmailwhite = JsonConvert.DeserializeObject<EmailListResult>(json.ToString());
            var tmp = sendmailwhite.result.ToList();
            return View(tmp);
        }

        [HttpGet]
        public async Task<ActionResult> EmailBlackList()
        {
            //var offset = "0";
            //var limit = "10";
            //int detail = 1;
            //int brand;
            //int recipientType;

            var url = "http://api.ivtlite.testdrive.club/portfoy/blacklist/sendmail?detail=1";

            using var client = new HttpClient();


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            var sendmailblack = JsonConvert.DeserializeObject<EmailListResult>(json.ToString());
            var tmp = sendmailblack.result.ToList();
            return View(tmp);
        }

        [HttpGet]
        public async Task<ActionResult> EmailUnknownList()
        {
            //var offset = "0";
            //var limit = "10";
            //int detail = 1;
            //int brand;
            //int recipientType;

            var url = "http://api.ivtlite.testdrive.club/portfoy/unknown/sendmail?detail=1";

            using var client = new HttpClient();


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            var sendmailunknown = JsonConvert.DeserializeObject<EmailListResult>(json.ToString());
            var tmp = sendmailunknown.result.ToList();
            return View(tmp);
        }

        [HttpGet]
        public ActionResult AddRecord()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddRecord(string collectorId)
        {
            Record record = new Record();
            record.recordId = Request.Form["kayitId"];
            record.msisdn = Request.Form["telefon"];
            record.sms = Convert.ToInt32(Request.Form["smsİzin"]);
            record.call = Convert.ToInt32(Request.Form["aramaİzin"]);
            record.email = Request.Form["email"];
            record.sendmail = Convert.ToInt32(Request.Form["epostaİzin"]);
            record.firstName = Request.Form["ad"];
            record.lastName = Request.Form["soyad"];
            record.source = Convert.ToInt32(Request.Form["izinKaynagi"]);
            record.date = Convert.ToDateTime(Request.Form["tarih"]);
            //record.date = DateTime.UtcNow;
            record.individual = Convert.ToInt32(Request.Form["bireyselİzin"]);
            record.corporate = Convert.ToInt32(Request.Form["kurumsalİzin"]);
            record.note = Request.Form["not"];

            var tmp = Request.Form["marka"].Split(',').ToArray();
            tmp.Select(int.Parse).ToList();
            int[] dizi = new int[tmp.Length]; //{ 0, 0, 0 };
            for (int i = 0; i < tmp.Length; i++)
            {
                dizi[i] = Convert.ToInt32(tmp[i]);
            }
            record.brands = dizi;
              
            string json = JsonConvert.SerializeObject(record, Formatting.Indented);

            var url = "http://api.ivtlite.testdrive.club/data/" + collectorId;

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));

            var content = await result.Content.ReadAsStringAsync();
            JObject responsejson = JObject.Parse(content);
            var recordKey = JsonConvert.DeserializeObject<RecordResult>(responsejson.ToString());

            return View();
        }

        [HttpGet]
        public ActionResult GetMultiRecord()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GetMultiRecord(string transactionId)
        {
            var url = "http://api.ivtlite.testdrive.club//data/bulk/" + transactionId;

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject responsejson = JObject.Parse(content);
            var tmp = JsonConvert.DeserializeObject<MultiRecordResult>(responsejson.ToString());

            return View(tmp);
        }

        [HttpGet]
        public ActionResult CheckWithEmail()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CheckWithEmail(string email)
        {
            string[] emails = new string[] { email};
            //DUZELT
            string json = JsonConvert.SerializeObject(emails, Formatting.Indented);
            //string jsontest = "[" + "mehmet.yilmaz@mobildev.com" +"]";

            var url = "http://api.ivtlite.testdrive.club/check/email";

            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));

            var content = await result.Content.ReadAsStringAsync();
            JObject responsejson = JObject.Parse(content);
            var tmp = JsonConvert.DeserializeObject<QueryWithEmail>(responsejson.ToString());
            
            return View(tmp.result.ToList());
        }

        [HttpGet]
        public ActionResult CheckWithGsm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CheckWithGsm(string gsm)
        {
            string[] gsms = new string[] { gsm };

            string json = JsonConvert.SerializeObject(gsms, Formatting.Indented);

            var url = "http://api.ivtlite.testdrive.club/check/msisdn";

            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));

            var content = await result.Content.ReadAsStringAsync();
            JObject responsejson = JObject.Parse(content);
            var tmp = JsonConvert.DeserializeObject<QueryWithGsm>(responsejson.ToString());

            return View(tmp.result.ToList());
        }

        [HttpGet]
        public ActionResult CheckWithAccountId()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CheckWithAccountId(string accountid)
        {
            string[] accountids = new string[] { accountid };

            string json = JsonConvert.SerializeObject(accountids, Formatting.Indented);

            var url = "http://api.ivtlite.testdrive.club/check/record";

            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));

            var content = await result.Content.ReadAsStringAsync();
            JObject responsejson = JObject.Parse(content);
            //dynamic stuff = JObject.Parse(content);
            //var x = stuff.Result[0].detail.msisdn["5555555555"];
            
            var tmp = JsonConvert.DeserializeObject<QueryWithAccountId>(responsejson.ToString());

            return View(tmp.result.ToList());
        }

        [HttpGet]
        public async Task<ActionResult> AccountIdUpdateUnread()
        {
            var url = "http://api.ivtlite.testdrive.club/portfoy/unread";

            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject responsejson = JObject.Parse(content);

            var tmp = JsonConvert.DeserializeObject<PortfoyAccountId>(responsejson.ToString());

            return View(tmp.result.ToList());
        }

        [HttpGet]
        public async Task<ActionResult> AccountIdUpdateRead()
        {
            var url = "http://api.ivtlite.testdrive.club/portfoy/read";

            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject responsejson = JObject.Parse(content);

            var tmp = JsonConvert.DeserializeObject<PortfoyAccountId>(responsejson.ToString());

            return View(tmp.result.ToList());
        }


        [HttpGet]
        public async Task<ActionResult> GsmUpdateUnread()
        {
            var url = "http://api.ivtlite.testdrive.club/portfoy/msisdn/unread";

            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject responsejson = JObject.Parse(content);

            var tmp = JsonConvert.DeserializeObject<PortfoyGsm>(responsejson.ToString());

            return View(tmp.result.ToList());
        }

        [HttpGet]
        public async Task<ActionResult> GsmUpdateRead()
        {
            var url = "http://api.ivtlite.testdrive.club/portfoy/msisdn/read";

            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject responsejson = JObject.Parse(content);

            var tmp = JsonConvert.DeserializeObject<PortfoyGsm>(responsejson.ToString());

            return View(tmp.result.ToList());
        }

        [HttpGet]
        public async Task<ActionResult> EmailUpdateUnread()
        {
            var url = "http://api.ivtlite.testdrive.club/portfoy/email/unread";

            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject responsejson = JObject.Parse(content);

            var tmp = JsonConvert.DeserializeObject<PortfoyEmail>(responsejson.ToString());

            return View(tmp.result.ToList());
        }

        [HttpGet]
        public async Task<ActionResult> EmailUpdateRead()
        {
            var url = "http://api.ivtlite.testdrive.club/portfoy/email/read";

            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject responsejson = JObject.Parse(content);

            var tmp = JsonConvert.DeserializeObject<PortfoyEmail>(responsejson.ToString());

            return View(tmp.result.ToList());
        }

        [HttpGet]
        public async Task<ActionResult> PermissionDetailUpdateRead()
        {
            int limit = 100;

            var url = "http://api.ivtlite.testdrive.club/data/log/read?offset=0&limit="+ limit +"&formId=&collectorId=&filter=&start=&end=";

            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject responsejson = JObject.Parse(content);

            var tmp = JsonConvert.DeserializeObject<PortfoyPermission>(responsejson.ToString());

            return View(tmp.result.ToList());
        }

        [HttpGet]
        public async Task<ActionResult> PermissionDetailUpdateUnRead()
        {
            int limit = 100;

            var url = "http://api.ivtlite.testdrive.club/data/log/unread?offset=0&limit=" + limit + "&formId=&collectorId=&filter=&start=&end=";

            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();
            JObject responsejson = JObject.Parse(content);

            var tmp = JsonConvert.DeserializeObject<PortfoyPermission>(responsejson.ToString());

            return View(tmp.result.ToList());
        }


    }
}