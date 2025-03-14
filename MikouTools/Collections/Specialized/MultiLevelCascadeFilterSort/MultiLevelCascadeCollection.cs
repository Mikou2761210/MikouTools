﻿namespace MikouTools.Collections.Specialized.MultiLevelCascadeFilterSort
{
    [Obsolete("This class was previously part of MikouTools but is now maintained as a standalone repository. It is recommended to use the new repository.")]
    public class MultiLevelCascadeCollection<FilterKey, ItemValue> : MultiLevelCascadeCollectionBase<FilterKey, ItemValue, MultiLevelCascadeCollection<FilterKey, ItemValue>, MultiLevelCascadeFilteredView<FilterKey, ItemValue>> where FilterKey : notnull where ItemValue : notnull
    {

        protected override MultiLevelCascadeFilteredView<FilterKey, ItemValue> CreateChildCollection(MultiLevelCascadeCollection<FilterKey, ItemValue> @base, Func<ItemValue, bool>? filter = null, IComparer<ItemValue>? comparer = null)
        {
            return new MultiLevelCascadeFilteredView<FilterKey, ItemValue>(this, null, filter, comparer);
        }
    }
}
