using System.Drawing;
using Tesseract;
using UnityEditor;
using UnityEngine;
using Rect = UnityEngine.Rect;

public class TesseractOCrWnd : EditorWindow
{
    private static int _winWidth = 600;
    private static int _winHeight = 400;
    
    [MenuItem("Tools/OCR")]
    static void OpenWindow()
    {
        Rect rectangle = new Rect((Screen.width - _winWidth) * 0.5f, (Screen.height - _winHeight) * 0.5f, _winWidth, _winHeight);
        TesseractOCrWnd aspriseOcrWnd = EditorWindow.CreateWindow<TesseractOCrWnd>("TesseractOCrWnd");
        aspriseOcrWnd.position = rectangle;
        aspriseOcrWnd.Init();
    }

    private void Init()
    {
        string img_path = "Assets/test.png";
        Rect outRect = new Rect(0,0,2400,3200);
        
    //选图片并调用ocr识别方法
   
        //openFileDialog1.Filter = "";
            var imgPath = @"D:\MyWork\Unity2018\DuoNetOCR\Assets\test1.jpg";
            string strResult = ImageToText(imgPath);
            if (string.IsNullOrEmpty(strResult))
            {
                Debug.Log("无法识别");
            }
            else
            {
                Debug.Log(strResult);
            }
    }
    //调用tesseract实现OCR识别
    public string ImageToText(string imgPath)
    {
        using (var engine = new TesseractEngine("tessdata", "chi_sim", EngineMode.Default))
        {
            using (var img = Pix.LoadFromFile(imgPath))
            {
                using (var page = engine.Process(img))
                {
                    return page.GetText();
                }
            }
        }
    }
}
