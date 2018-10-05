using Microsoft.AspNetCore.Mvc;

namespace Budget.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        public string Invoke()
        {
            return "Hello from the Nav View Component!";
        }
    }
}
