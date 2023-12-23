using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using SkinList;
public class SkinManager : MonoBehaviour
{
    public GameObject Mario, Luigi;
    public TMP_Dropdown MarioSkinDropdown, LuigiSkinDropdown;
    public string CurrentLuigiSkin;
    public string CurrentMarioSkin;
    public TMP_Text MarioSkinText, LuigiSkinText;
    public bool NoSkins;
    // Start is called before the first frame update
    void Awake()
    {
        print(Application.streamingAssetsPath);
        if (Settings.Instance.MarioSkin != "Mario" && Settings.Instance.MarioSkinBundle == null)
        {
            Settings.Instance.MarioSkinBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "MarioSkin_" + Settings.Instance.MarioSkin));
        }
        if (Settings.Instance.LuigiSkin != "Luigi" && Settings.Instance.LuigiSkinBundle == null)
        {
            Settings.Instance.LuigiSkinBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "LuigiSkin_" + Settings.Instance.LuigiSkin));
        }
        string SkinListJSON = File.ReadAllText(Application.streamingAssetsPath + "/Skins.json");
        JSONSkin SkinList = JsonUtility.FromJson<JSONSkin>(SkinListJSON);
        if (SkinList == null)
        {
            Debug.Log("Failed to load Skinlist!");
        }
        else
        {
            LuigiSkinDropdown.AddOptions(SkinList.LuigiSkinList);
            MarioSkinDropdown.AddOptions(SkinList.MarioSkinList);
        }
        if (MarioSkinDropdown.options.Count == 1)
        {
            MarioSkinDropdown.interactable = false;
        }
        if (LuigiSkinDropdown.options.Count == 1)
        {
            LuigiSkinDropdown.interactable = false;
        }
        if ((LuigiSkinDropdown.interactable == false) && (MarioSkinDropdown.interactable == false))
        {
            NoSkins = true;
        }
        else
        {
            NoSkins = false;
        }
        MarioSkinText.text = "Current Mario Skin: " + Settings.Instance.MarioSkin;
        LuigiSkinText.text = "Current Luigi Skin: " + Settings.Instance.LuigiSkin;
        Debug.Log(Settings.Instance.MarioSkin + " skin loaded");
        Debug.Log(Settings.Instance.LuigiSkin + " skin loaded");
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLuigiCharacterSkin()
    {
        bool error = false;
        Settings.Instance.LuigiSkin = LuigiSkinDropdown.captionText.text;
        if (LuigiSkinDropdown.captionText.text != "Luigi")
        {
            if (Settings.Instance.LuigiSkinBundle != null)
            {
                Settings.Instance.LuigiSkinBundle.Unload(false);
            }

            Settings.Instance.LuigiSkinBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "LuigiSkin_" + Settings.Instance.LuigiSkin));
            if (Settings.Instance.LuigiSkinBundle == null)
            {
                Debug.Log("Skin bundle not found.");
                error = true;
            }
            if (error == true)
            {
                Settings.Instance.LuigiSkin = "Luigi";
            }
        }
        Debug.Log(Settings.Instance.LuigiSkin + " skin loaded");
        Settings.Instance.SaveSettingsToPreferences();
        LuigiSkinText.text = "Current Luigi Skin: " + Settings.Instance.LuigiSkin;
    }

    public void ChangeMarioCharacterSkin()
    {
        bool error = false;
        Settings.Instance.MarioSkin = MarioSkinDropdown.captionText.text;
        if (MarioSkinDropdown.captionText.text != "Mario")
        {
            if (Settings.Instance.MarioSkinBundle != null)
            {
                Settings.Instance.MarioSkinBundle.Unload(false);
            }

            Settings.Instance.MarioSkinBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "MarioSkin_" + Settings.Instance.MarioSkin));
            if (Settings.Instance.MarioSkinBundle == null)
            {
                Debug.Log("Skin bundle not found.");
                error = true;
            }
            if (error == true)
            {
                Settings.Instance.MarioSkin = "Mario";
            }
            
        }
        Debug.Log(Settings.Instance.MarioSkin + " skin loaded");
        Settings.Instance.SaveSettingsToPreferences();
        MarioSkinText.text = "Current Mario Skin: " + Settings.Instance.MarioSkin;
    }
}
    
