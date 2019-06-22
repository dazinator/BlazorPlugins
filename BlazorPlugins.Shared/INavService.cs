using System;
using System.Collections.Generic;

namespace BlazorPlugins.Shared
{
    public interface INavService
    {
        event EventHandler<NavItem> ItemAdded;
        IEnumerable<NavItem> GetNavItems();
        void AddItem(NavItem item);
    }
}
