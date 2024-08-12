using UnityEditor;
using AWBOI.AMP.Merger;

namespace AWBOI.Editor
{
    
    class AwboiPostProcessor : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            if (AwboiMerger.Instance)
            {
                AwboiMerger.Instance.SetDlcRefresh();
            }
        }
    }
}