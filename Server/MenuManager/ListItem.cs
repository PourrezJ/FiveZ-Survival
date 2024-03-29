﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace FiveZ
{
    public class ListItem : MenuItem, IListItem
    {
        #region Public properties
        public List<object> Items { get; set; }
        public int SelectedItem { get; set; } = 0;
        public bool ExecuteCallbackListChange { get; set; }
        [JsonIgnore]
        public Menu.MenuListCallbackAsync ListItemChangeCallback { get; set; }
        #endregion

        #region Constructors
        public ListItem(string text, string description, string id, int itemsMax, int selectedItem, bool executeCallback = false, bool executeCallbackListChange = false) : base(text, description, id)
        {
            Type = MenuItemType.ListItem;
            Items = new List<object>();

            for (int i = 0; i < itemsMax; i++)
                Items.Add(i.ToString());

            SelectedItem = selectedItem;
            ExecuteCallback = executeCallback;
            ExecuteCallbackListChange = executeCallbackListChange;
        }

        public ListItem(string text, string description, string id, List<object> items, int selectedItem, bool executeCallback = false, bool executeCallbackListChange= false) : base(text, description, id)
        {
            Type = MenuItemType.ListItem;
            Items = items;
            SelectedItem = selectedItem;
            ExecuteCallback = executeCallback;
            ExecuteCallbackListChange = executeCallbackListChange;
        }
        #endregion

        #region Public overrided methods
        public override bool IsInput()
        {
            return false;
        }
        #endregion
    }
}
