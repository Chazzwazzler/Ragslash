using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LoadCustomImages
{
    public static List<Sprite> CustomSprites(){
        string[] files;
        string path = Application.dataPath + "/CustomImages/";
        files = Directory.GetFiles(path);
        List<Sprite> customSprites = new List<Sprite>();

        for(int i = 0; i < files.Length; i++){
            byte[] fileBytes = File.ReadAllBytes(files[i]);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(fileBytes);
            customSprites.Add(Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), tex.height));
        }
        return customSprites;
    }
}
