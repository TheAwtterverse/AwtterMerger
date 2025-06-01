#if UNITY_EDITOR
using AWBOI.AMP.Merger;
using UnityEditor;

namespace Editor
{

    class AwboiPostProcessor : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            if (AwboiMerger.Instance)
            {
                AwboiMerger.Instance.SetDlcRefresh();
            }
        }
    }


}
#endif