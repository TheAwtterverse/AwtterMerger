using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AWBOI.AMP.Core.Abstracts;
using AWBOI.AMP.DLC;
using UnityEditor;
using AWBOI.AMP.Merger;
using UnityEngine;

namespace AWBOI.Editor
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