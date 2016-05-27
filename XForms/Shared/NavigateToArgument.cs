using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMessenger;

namespace XForms.Shared
{
    public class NavigateToArgument : ITinyMessage
    {
        public Type Screen { get; set; }

        public string Identifier { get; set; }

        public object Sender { get; }
    }
}
