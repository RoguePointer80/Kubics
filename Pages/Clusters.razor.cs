using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kubics.Data;
using Microsoft.AspNetCore.Components;

namespace Kubics.Pages
{
    public partial class Clusters : ComponentBase
    {
        public string[] Names { get; set; }

        [Inject] KubeService K8sService { get; set; }


        public Clusters()
        {
            Names = new string[0];
        }

        protected override async Task OnInitializedAsync()
        {
            Names = (await K8sService.ListClustersAsync()).ToArray();
        }
    }
}
