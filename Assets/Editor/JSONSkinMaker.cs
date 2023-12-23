using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using SkinList;

public class JSONSkinMaker
{
    [MenuItem("Assets/Create Skin File")]

    static void Save()
    {
        JSONSkin Skin = new JSONSkin();
        string SkinText = JsonUtility.ToJson(Skin);
        string assetBundleDirectory = "Assets/StreamingAssets";
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        Skin.LuigiSkinList.Add("Dummy");
        Skin.LuigiSkinList.Add("Dummy");
        Skin.MarioSkinList.Add("Dummy");
        Skin.LuigiSkinList.Add("Dummy");
        File.WriteAllText(assetBundleDirectory + "/Skins.json", SkinText);
        Debug.Log("Created Skins.json.");
    }
}



