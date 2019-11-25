using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;

namespace Kubics.Pages
{
    public partial class Contexts : ComponentBase
    {
        public string[] Names { get; set; }

        public string Current { get; set; }

        public Contexts()
        {
            Names = new string[1];
            Names[0] = "<loading>";
        }

        protected override async Task OnInitializedAsync()
        {
            var conf = await KubernetesClientConfiguration.LoadKubeConfigAsync();
            List<string> names = new List<string>();
            foreach (var context in conf.Contexts)
            {
                names.Add(context.Name);
            }
            Current = conf.CurrentContext;
            Names = names.ToArray();
        }

    }
}
