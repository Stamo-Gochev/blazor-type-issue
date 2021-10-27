using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Linq;
using Microsoft.JSInterop;

namespace RazorClassLibrary1
{
    public partial class Component1<TItem> : ComponentBase
    {
        [Parameter]
        public IEnumerable<TItem> Data { get; set; }

        public bool IsItemPredefined(TItem item)
        {
            var itemType = item?.GetType();

            var isPredefined = IsPredefinedType(itemType);

            return isPredefined;
        }

        internal static readonly Type[] PredefinedTypes =
        {
            typeof(Object),
            typeof(Boolean),
        };

        public bool IsPredefinedType(Type type)
        {
            foreach (Type t in PredefinedTypes)
            {
                if (t == type)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
