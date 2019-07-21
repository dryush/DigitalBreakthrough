using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using School.Data;
using School.Data.Models;
using School.Models;

namespace Sample.Mvc.Controllers
{
    [Route("SchoolClasses/{classId}/[controller]")]
    public class DiscussionController : Controller
    {

        ApplicationDbContext _Context { get; set; }
        private readonly UserManager<AppUser> _userManager;
        public DiscussionController(ApplicationDbContext session, UserManager<AppUser> userManager)
        {
            _Context = session;
            _userManager = userManager;
        }


        protected int classId { get => int.Parse(RouteData.Values["classId"].ToString()); }
        // GET: Discussion

        [Route("[action]")]
        public ActionResult Index()
        {
            //_Session.Store(new Discussion() { Description = "Ollllllooool", Name = "HardName"});
            //_Session.SaveChanges();
            var descs = _Context
                .Discussions
                .Where( d => d.SchoolClassId == classId)
                .GroupBy( d => d.Status) 
                .ToDictionary( d => d.Key, d => d.ToList());
            
            return View("Index",descs);
        }

        // GET: Discussion/Details/5
        [Route("[action]/{id}")]
        public ActionResult Details(int id)
        {
            var discussion = _Context.Discussions
                .Include(d => d.Voicinigs)
                    .ThenInclude(v => v.Options)
                        .ThenInclude(o => o.Voices)
                .Include(d => d.SchoolClass)
                    .ThenInclude(c => c.Parents)

                .FirstOrDefault(d => d.Id == id);


            var parentId = int.Parse(_userManager.GetUserId(User));
            Func<Voicing, int> voutedCount = (Voicing v) => v.Options.SelectMany(o => o.Voices.Select(vv => vv.UserId)).Distinct().Count();
            Func<Voicing, bool> vouted = (Voicing v) => v.Options.SelectMany(o => o.Voices.Select(vv => vv.UserId)).Contains(parentId);
            int schoolClassParentsCount = discussion.SchoolClass.Parents.Count;
            var model = new DiscussionModel()
            {
                SchoolClassId = discussion.SchoolClassId,
                Name = discussion.Name,
                Description = discussion.Description,
                EndDate = discussion.EndDate,
                SchoolClassParentsCount = schoolClassParentsCount,
                Voicinigs = discussion.Voicinigs.Select(v => new VoicingModel()
                {
                    Id = v.Id.ToString(),
                    Name = v.Name,
                    Description = v.Description,
                    IsShowVoices =  !User.IsInRole("Teacher") && discussion.Status != DiscussionStatus.CLOSE && voutedCount(v) != schoolClassParentsCount && !vouted(v),
                    VoutedCount = voutedCount(v),
                    Options = v.Options.Select(o => new VoicingOptionModel()
                    {
                        Id = o.Id.ToString(),
                        Name = o.Name,
                        VoutedCount = o.Voices.Select( vv => vv.UserId).Distinct().Count()
                    }).ToList()
                }).ToList()
            };
            return View(model);
        }

        // GET: Discussion/Create
        [Route("[action]")]
        public ActionResult Create()
        {
            return View();
        }

        public class InputDiscussionVoicingOptionModel
        {
            public string name = "";
        }
        public class InputDiscussionVoicingModel
        {
            public string name;
            public string description;
            public List<InputDiscussionVoicingOptionModel> options;
        }
        public class InputDiscussionModel
        {
            public string name;
            public string description;
            public List<InputDiscussionVoicingModel> voicings;

        }


        [Route("/Voice/{disscussionId_optionId}")]
        public ActionResult Voice(string disscussionId_optionId)
        {
            string optionId = disscussionId_optionId.Split('_')[0];
            int disscussionId = int.Parse(disscussionId_optionId.Split('_')[1]);
            string @class= disscussionId_optionId.Split('_')[2];
            return Voice(new ParentVoiceModel() { optionId = optionId.ToString(), discId = disscussionId, classId = @class});
        }

        [HttpPost]
        [Route("Voice")]
        public ActionResult Voice(ParentVoiceModel optopt)
        {
            var parentId = int.Parse(_userManager.GetUserId(User));
            var _optionId = int.Parse( optopt.optionId);
            _Context.Add(new Voice() { OptionId = _optionId, UserId = parentId });
            _Context.SaveChanges();
            return Redirect($"/SchoolClasses/{optopt.classId}/Discussion/Details/{optopt.discId}");
        }

        // POST: Discussion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var input = JsonConvert.DeserializeObject<InputDiscussionModel>(collection["Value"]);
                var disc = new Discussion()
                {
                    SchoolClassId = this.classId,
                    Name = input.name,
                    Description = input.description,
                    EndDate = DateTime.Parse( collection["DateEnd"]),
                    Voicinigs = input.voicings.Select(v => new Voicing()
                    {
                        Name = v.name,
                        Description = v.description,
                        Options = v.options.Select(o => new VoicingOption()
                        {
                            Name = o.name
                        }).ToList()
                    }).ToList()
                };
                _Context.Add(disc);
                _Context.SaveChanges();
                // TODO: Add insert logic here

                return Redirect($"Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Discussion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Discussion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Discussion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Discussion/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}