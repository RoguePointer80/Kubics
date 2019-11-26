using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubics.Pages
{
    public partial class Pods : ComponentBase
    {
        [Parameter]
        public string K8sNamespace { get; set; }

        [Inject] Data.KubeService K8sService { get; set; }

        protected List<string> PodNames { get; set; }

        public Pods()
        {
            PodNames = new List<string>();
        }

        protected override async Task OnInitializedAsync()
        {
            await Refresh();
        }

        protected override async Task OnParametersSetAsync()
        {
            await Refresh();
        }

        protected async Task Refresh()
        {
            var v1Pods = await K8sService.ListPodsAsync(K8sNamespace);
            PodNames = v1Pods.Select(p => p.Metadata.Name).ToList();
        }
    }
}
