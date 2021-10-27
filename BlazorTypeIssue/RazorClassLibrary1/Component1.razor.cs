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
        public string Id { get; set; } = "123";

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
            //typeof(Char),
            //typeof(String),
            //typeof(SByte),
            //typeof(Byte),
            //typeof(Int16),
            //typeof(UInt16),
            //typeof(Int32),
            //typeof(UInt32),
            //typeof(Int64),
            //typeof(UInt64),
            //typeof(Single),
            //typeof(Double),
            //typeof(Decimal),
            //typeof(DateTime),
            //typeof(TimeSpan),
            //typeof(Guid),
            //typeof(Math),
            //typeof(Convert)
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
