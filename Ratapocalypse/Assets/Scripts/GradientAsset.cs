using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GradientAsset : ScriptableObject
{
    public Gradient gradient;
}

public class GradientCreator
{
    [MenuItem("Assets/Create/Gradient")]
    public static void CreateGradient()
    {
        Gradient gradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[2];
        colorKeys[0] = new GradientColorKey(Color.red, 0f);
        colorKeys[1] = new GradientColorKey(Color.green, 1f);
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0] = new GradientAlphaKey(1f, 0f);
        alphaKeys[1] = new GradientAlphaKey(1f, 1f);
        gradient.SetKeys(colorKeys, alphaKeys);

        GradientAsset gradientAsset = ScriptableObject.CreateInstance<GradientAsset>();
        gradientAsset.gradient = gradient;

        string path = EditorUtility.SaveFilePanelInProject("Save Gradient", "New Gradient", "asset", "Save Gradient", "Assets");
        if (!string.IsNullOrEmpty(path))
        {
            AssetDatabase.CreateAsset(gradientAsset, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
