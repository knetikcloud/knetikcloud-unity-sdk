﻿using KnetikUnity.Build;
using UnityEditor;

namespace KnetikCloudBuild
{
    public static class KnetikPackageExporter
    {
        [MenuItem("Knetik Cloud/Export Package...")]
        public static void Process()
        {
            KnetikCommandLine.ParseCommandLine();
            string outputPath = KnetikCommandLine.GetArg("-outputPath");

            if (string.IsNullOrEmpty(outputPath))
            {
                outputPath = "KnetikCloudSDK.unitypackage";
            }

            string[] pathsToExport =
            {
                "Assets/Editor/KnetikCloud",
                "Assets/Plugins",
                "Assets/ThirdParty/KnetikCloud"
            };

            AssetDatabase.ExportPackage(pathsToExport, outputPath, ExportPackageOptions.Recurse);
            UnityEngine.Debug.Log("Package export complete.");
        }
    }
}
