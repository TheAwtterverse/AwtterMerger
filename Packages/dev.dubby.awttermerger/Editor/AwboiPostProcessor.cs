using System.IO;
using UnityEditor;
using AWBOI.AMP.Merger;
using UnityEngine;

namespace AWBOI.Editor
{
    
    class AwboiPostProcessor : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            if (AwboiMerger.Instance)
            {
                AwboiMerger.Instance.SetDlcRefresh();
                UpdateNamespaces();
            }
        }
        
        public static void UpdateNamespaces()
        {
            string[] guids = AssetDatabase.FindAssets("t:DLCOptions");
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                string fileContent = File.ReadAllText(path);

                // Update the namespace in the script
                if (fileContent.Contains("namespace OldNamespace"))
                {
                    fileContent = fileContent.Replace("namespace AWBOI", "namespace AWBOI.AMP.Core.Utils");
                    File.WriteAllText(path, fileContent);

                    // Refresh the asset database to apply changes
                    AssetDatabase.ImportAsset(path);
                }
            }

            Debug.Log("[AwboiPostProcessor] DLCOptions Updated");
        }
    }
}