using Microsoft.AspNetCore.Mvc;
using StoreApp.Web.Models;

namespace StoreApp.Web.Components;

public class LikeSummaryViewComponent:ViewComponent
{
    private Like like;

    public LikeSummaryViewComponent(Like likeSevice)
    {
        like = likeSevice;
    }

    public IViewComponentResult Invoke()
    {
        return View(like);
    }
}
