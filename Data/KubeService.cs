using k8s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubics.Data
{
    public class KubeService
    {
        public KubeService()
        {
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
    }
}
