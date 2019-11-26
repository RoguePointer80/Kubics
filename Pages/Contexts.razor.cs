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
        private Dictionary<string, k8s.KubeConfigModels.Context> m_contexts = new Dictionary<string, k8s.KubeConfigModels.Context>();

        public string[] Names { get; set; }

        public string Current { get; set; }

        public string CurrentNamespace { get => m_contexts[Current]?.ContextDetails.Namespace ?? "default"; }

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
                m_contexts.Add(context.Name, context);
                names.Add(context.Name);
            }
            Current = conf.CurrentContext;
            Names = names.ToArray();
        }

    }
}
