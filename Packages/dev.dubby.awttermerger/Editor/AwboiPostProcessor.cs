#if UNITY_EDITOR
using AWBOI.AMP.Core.DLC;
using AWBOI.AMP.Merger;
using AWBOI.AMP.Unmerger;
using UnityEditor;

namespace Editor
{

    class AwboiPostProcessor : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            if (AwboiMerger.Instance) AwboiMerger.Instance.SetDlcRefresh();
            
            if (BackupManagerWindow.Instance) BackupManagerWindow.Instance.ResetVars();
        }
    }


}
#endif