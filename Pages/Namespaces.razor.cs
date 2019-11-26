using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;

namespace Kubics.Pages
{
    public partial class Namespaces : ComponentBase
    {
        [Parameter]
        public string Context { get; set; }

        [Inject] Data.KubeService K8sService { get; set; }

        protected string[] NamespaceList;

        public Namespaces()
        {
            NamespaceList = new string[1];
            NamespaceList[0] = "default";
        }

        protected override async Task OnInitializedAsync()
        {
            var v1List = await K8sService.ListNamespaceAsync();
            NamespaceList = v1List.ToArray();
        }
    }
}
