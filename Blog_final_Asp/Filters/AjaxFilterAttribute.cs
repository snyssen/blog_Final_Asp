using System.Web.Mvc;

namespace Blog_final_Asp.Filters
{
    public class AjaxFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
                filterContext.Result = new HttpNotFoundResult();
            base.OnActionExecuting(filterContext);
        }
    }
}