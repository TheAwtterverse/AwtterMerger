#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AWBOI.AMP.Core.Abstracts;
using AWBOI.AMP.Core.DLC;
using AWBOI.AMP.DLC;
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
            ResetClasses(AwboiMerger.Instance);
            ResetClasses(AwboiUnmerger.Instance);
            ResetClasses(NewDlcMakerWindow.Instance);
            ResetClasses(BackupManagerWindow.Instance);
        }

        static void ResetClasses<T>(T window) where T : BaseMerger
        {
            if (window == null) return;
            window.RefreshVars();
            window.RefreshAllUI();
        }
        
    }


}
#endif