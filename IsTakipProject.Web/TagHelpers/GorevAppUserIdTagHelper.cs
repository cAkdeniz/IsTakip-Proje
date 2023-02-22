using IsTakipProject.Business.Interfaces;
using IsTakipProject.Entities.Concrete;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipProject.Web.TagHelpers
{
    [HtmlTargetElement("getirGorevAppUserId")]
    public class GorevAppUserIdTagHelper : TagHelper
    {
        private IGorevService _gorevService;
        public GorevAppUserIdTagHelper(IGorevService gorevService)
        {
            _gorevService = gorevService;
        }
        public int AppUserId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Gorev> gorevler = _gorevService.GetirileAppUserId(AppUserId);

            int tamamlananGorevler = gorevler.Where(x => x.Durum).Count();
            int devamEdenGorevler = gorevler.Where(x => !x.Durum).Count();

            string data = "<strong>Tamamlanan Görev Sayısı: </strong>" + tamamlananGorevler +
                "<br> <strong>Çalıştığı Görev Sayısı: </strong>" + devamEdenGorevler;

            output.Content.SetHtmlContent(data);
        }
    }
}
