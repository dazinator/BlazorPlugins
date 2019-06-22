using BlazorPlugins.Shared;
using System;
using System.Collections.Generic;

namespace BlazorPlugins.Client
{
    public class NavService : INavService
    {
        public event EventHandler<NavItem> ItemAdded;

        public List<NavItem> NavItems { get; set; } = new List<NavItem>();

        public void AddItem(NavItem item)
        {
            NavItems.Add(item);
            ItemAdded?.Invoke(this,item);
        }

        public IEnumerable<NavItem> GetNavItems()
        {
            return NavItems.AsReadOnly();
        }
    }
}
