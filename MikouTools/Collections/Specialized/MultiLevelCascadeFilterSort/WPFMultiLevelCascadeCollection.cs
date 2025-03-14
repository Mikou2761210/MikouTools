﻿namespace MikouTools.Collections.Specialized.MultiLevelCascadeFilterSort
{
    [Obsolete("This class was previously part of MikouTools but is now maintained as a standalone repository. It is recommended to use the new repository.")]
    public class WPFMultiLevelCascadeCollection<FilterKey, ItemValue> : ConcurrentMultiLevelCascadeCollectionBase<FilterKey, ItemValue, WPFMultiLevelCascadeCollection<FilterKey, ItemValue>, WPFMultiLevelCascadeFilteredView<FilterKey, ItemValue>> where FilterKey : notnull where ItemValue : notnull
    {


        protected override WPFMultiLevelCascadeFilteredView<FilterKey, ItemValue> CreateChildCollection(WPFMultiLevelCascadeCollection<FilterKey, ItemValue> @base, Func<ItemValue, bool>? filter = null, IComparer<ItemValue>? comparer = null)
        {
            return new WPFMultiLevelCascadeFilteredView<FilterKey, ItemValue>(this, null, filter, comparer);
        }


        public new ItemValue this[int id]
        {
            get
            {
                return base[id];
            }
            set
            {
                lock (base._lock)
                {
                    ItemValue oldvalue = base[id];
                    base._baseList[id] = value; 
                    
                    foreach (var child in _children)
                    {
                        child.Value.NotifyChildrenOfReplace(id, value, oldvalue);
                    }
                }

            }
        }


    }
}
