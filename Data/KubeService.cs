using k8s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubics.Data
{
    public class KubeService
    {
        private Kubernetes m_k8s;

        public KubeService()
        {
            // Temporary workaround : oidc auth-provider not supported
            var clientConfig = new KubernetesClientConfiguration { Host = "http://127.0.0.1:8001" };
            m_k8s = new Kubernetes(clientConfig);
        }

        public async Task<IList<string>> ListClustersAsync()
        {
            List<string> clusters = new List<string>();
            var conf = await KubernetesClientConfiguration.LoadKubeConfigAsync();
            foreach (var cluster in conf.Clusters)
            {
                clusters.Add(cluster.Name);
            }

            return clusters;
        }

        public async Task<IList<string>> ListNamespaceAsync()
        {
            var v1ns = await m_k8s.ListNamespaceAsync();
            return v1ns.Items.Select(x => x.Metadata.Name).ToList();
        }

        public async Task<IList<k8s.Models.V1Pod>> ListPodsAsync(string ns)
        {
            var pods = await m_k8s.ListNamespacedPodAsync(ns);
            return pods.Items;
        }
    }
}
