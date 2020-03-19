#if UNITY_IPHONE || UNITY_IOS
using System.Net.Mime;
using System.IO;

using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEngine;

public class IOSBuildForPListProcessor
{
    [PostProcessBuild(100)]
    public static void OnPostProcessBuild(BuildTarget buildTarget, string path)
    {
        string projectPath = PBXProject.GetPBXProjectPath(path);
        PBXProject project = new PBXProject();
        string fileText = File.ReadAllText(projectPath);
        project.ReadFromString((fileText));
        string targetGuid = project.TargetGuidByName(PBXProject.GetUnityTargetName());
        SetBuildSetting(project, targetGuid, path);
        SetLibrary(project, targetGuid, path);
        CopyFiles(project, targetGuid, path);
        project.WriteToFile(projectPath);
        SetInfoList(path);
    }

    static void SetBuildSetting(PBXProject project, string targetGuid, string path)
    {
        string linkerFlag = "OTHER_LDFLAGS";
        project.SetBuildProperty(targetGuid, "ENABLE_BITCODE", "NO");
        project.AddBuildProperty(targetGuid, linkerFlag, "-ObjC -lstdc++");
    }

    static void SetLibrary(PBXProject project, string targetGuid, string path)
    {
        string[] libs = {
            "CoreTelephony.framework",
            "AdSupport.framework",
            "StoreKit.framework",
            "CoreLocation.framework",
            "Security.framework",
            "SystemConfiguration.framework",
            "WebKit.framework",
            "AVFoundation.framework",
            "QuartzCore.framework",
            "libxml2.tbd",
            "libz.tbd"
             };
        foreach (string str in libs)
        {
            project.AddFrameworkToProject(targetGuid, str, false);
        }

    }

    static void CopyFiles(PBXProject project, string targetGuid, string path)
    {
        string bundleFilePath = Application.dataPath + "/ValpubSDK/Plugins/IOS/ValpubSDK/TMPSResource.bundle";
        string fileGuid = project.AddFile(bundleFilePath, "Frameworks/TMPSResource.bundle", PBXSourceTree.Build);
        project.AddFileToBuild(targetGuid, fileGuid);
    }

    static void SetInfoList(string path)
    {
        string plistPath = Path.Combine(path, "Info.plist");
        PlistDocument plist = new PlistDocument();
        plist.ReadFromFile(plistPath);

        PlistElementDict rootDict = plist.root;

        PlistElementDict dict = rootDict.CreateDict("NSAppTransportSecurity");
        dict.SetBoolean("NSAllowsArbitraryLoads", true);

        plist.WriteToFile(plistPath);
        File.WriteAllText(plistPath, plist.WriteToString());
    }

}


#endif