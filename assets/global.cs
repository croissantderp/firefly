using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class global : MonoBehaviour
{
    Camera bg;

    public Slider ors, ogs, obs, frs, fgs, fbs;

    public Image[] buttons;
    public TMP_Text[] texts;

    public float or,og,ob;
    public float fr, fg, fb;

    public Color OnColor;
    public Color OffColor;

    public TMP_InputField inputNum;
    public TMP_InputField inputSPF;
    public TMP_InputField inputCode;
    public TMP_Text Errortext;

    public TextAsset badApple;

    //defaults

    //   1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6
    string code1, ocode1 = "16,9;" +
        "1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,\n" +
        "1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,\n" +
        "1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,\n" +
        "1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,\n" +
        "1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,\n" +
        "1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,\n" +
        "1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,\n" +
        "1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,\n" +
        "1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0\n" +
        "/" +
        "0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,\n" +
        "0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,\n" +
        "0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,\n" +
        "0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,\n" +
        "0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,\n" +
        "0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,\n" +
        "0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,\n" +
        "0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,\n" +
        "0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1\n";

    string code2, ocode2 = "16,9;" +
        "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1," +
        "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1," +
        "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1," +
        "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1," +
        "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1," +
        "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1," +
        "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1," +
        "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1," +
        "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1" +
        "/"+
        "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0," +
        "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0," +
        "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0," +
        "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0," +
        "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0," +
        "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0," +
        "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0," +
        "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0," +
        "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";

    string code3, ocode3 = "16,9;" +
        "0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0," +
        "1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0," +
        "1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1," +
        "0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1," +
        "0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0," +
        "1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0," +
        "1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1," +
        "0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1," +
        "0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0" +
        "/" +
        "1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0," +
        "1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1," +
        "0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1," +
        "0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0," +
        "1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0," +
        "1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1," +
        "0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1," +
        "0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0," +
        "1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0" +
        "/" +
        "1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1," +
        "0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1," +
        "0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0," +
        "1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0," +
        "1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1," +
        "0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1," +
        "0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0," +
        "1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0," +
        "1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1" +
        "/" +
        "0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1," +
        "0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0," +
        "1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0," +
        "1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1," +
        "0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1," +
        "0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0," +
        "1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0," +
        "1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1," +
        "0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1";

    string code5, ocode5;

    Dictionary<string, string[]> letterToPattern = new Dictionary<string, string[]>()
    {
        { " ", new string[] { "0,0,0,0,0,0", "0,0,0,0,0,0", "0,0,0,0,0,0", "0,0,0,0,0,0", "0,0,0,0,0,0", "0,0,0,0,0,0", "0,0,0,0,0,0", "0,0,0,0,0,0", "0,0,0,0,0,0" } },
        { "a", new string[] { "0,1,1,1,0,0", "1,0,0,0,1,0", "1,0,0,0,1,0", "1,0,0,0,1,0", "1,1,1,1,1,0", "1,0,0,0,1,0", "1,0,0,0,1,0", "1,0,0,0,1,0", "1,0,0,0,1,0" } },
        { "b", new string[] { "1,1,1,1,0,0", "1,0,0,0,1,0", "1,0,0,0,1,0", "1,0,0,0,1,0", "1,1,1,1,0,0", "1,0,0,0,1,0", "1,0,0,0,1,0", "1,0,0,0,1,0", "1,1,1,1,0,0" } },
        { "c", new string[] { "0,1,1,1,1,0", "1,0,0,0,0,0", "1,0,0,0,0,0", "1,0,0,0,0,0", "1,0,0,0,0,0", "1,0,0,0,0,0", "1,0,0,0,0,0", "1,0,0,0,0,0", "0,1,1,1,1,0" } }
    };

    // Start is called before the first frame update
    void Start()
    {
        code1 = ocode1;
        code2 = ocode2;
        code3 = ocode3;

        code5 = badApple.text;
        ocode5 = badApple.text;

        bg = FindObjectOfType<Camera>();

        string OnColorTemp = PlayerPrefs.GetString("OnColor", "255,255,255");
        
        var split = OnColorTemp.Split(',').Select(a => a == "" ? a = "0" : a).ToArray();
        
        OnColor = new Color(float.Parse(split[0]) / 255f, float.Parse(split[1]) / 255f, float.Parse(split[2]) / 255f, 255f);

        or = float.Parse(split[0]);

        ors.value = or;
        
        og = float.Parse(split[1]);

        ogs.value = og;

        ob = float.Parse(split[2]);

        obs.value = ob;

        string OffColorTemp = PlayerPrefs.GetString("OffColor", "0,0,0");

        split = OffColorTemp.Split(',').Select(a => a == "" ? a = "0" : a).ToArray();

        OffColor = new Color(float.Parse(split[0]) / 255f, float.Parse(split[1]) / 255f, float.Parse(split[2]) / 255f, 255f);
        
        fr = float.Parse(split[0]);

        frs.value = fr;

        fg = float.Parse(split[1]);

        fgs.value = fg;

        fb = float.Parse(split[2]);

        fbs.value = fb;

        bg.backgroundColor = OffColor;

        foreach (var button in buttons)
        {
            button.color = OnColor;
        }

        foreach (var text in texts)
        {
            text.outlineColor = OnColor;
            text.faceColor = OffColor;
        }

        inputSPF.text = PlayerPrefs.GetFloat("spf", 1f).ToString();
    }

    public void saveButton()
    {
        float temp;

        if (float.TryParse(inputSPF.text, out temp))
        {
            PlayerPrefs.SetFloat("spf", temp);
            PlayerPrefs.Save();
            if (inputNum.text == "" && inputCode.text == "")
            {
                return;
            }
        }
        else if (inputNum.text == "" && inputCode.text == "")
        {
            Errortext.text = "Enter a number in SPF";
            return;
        }

        if (inputNum.text == "")
        {
            Errortext.text = "Fill out The slot number";
            return;
        }
        if (inputCode.text == "")
        {
            Errortext.text = "Fill out The code";
            return;
        }

        int temp2;

        if (int.TryParse(inputNum.text, out temp2))
        {
            if (temp2 > 5)
            {
                Errortext.text = "There are only 5 save slots";
                return;
            }
        }
        else
        {
            Errortext.text = "Enter a number in slot";
            return;
        }

        if (inputCode.text == "default")
        {
            string code = "never gonna give you up";
            switch (inputNum.text) {
                case "1":
                    code = ocode1;
                    break;
                case "2":
                    code = ocode2;
                    break;
                case "3":
                    code = ocode3;
                    break;
                default:
                    code = ocode5;
                    break;

            }

            PlayerPrefs.SetString("slot" + inputNum.text, code);
        }
        else
        {
            try
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(inputCode.text, @"^\d+,\d+;\s*([01][,/\s]*){1,}$"))
                {
                    Errortext.text = "Incorrect format, check the how-to for more information";
                    return;
                }

                string[] split = inputCode.text.Split(';')[1].Replace("\n", "").Split('/');
                int length = split[0].Length;

                if (!split.All(a => a.Length == length))
                {
                    Errortext.text = "Check that all frames have the same amount of pixels";
                    return;
                }
            }
            catch
            {
                Errortext.text = "Something else went wrong, check the format of the input";
                return;
            }

            PlayerPrefs.SetString("slot" + inputNum.text, inputCode.text);
        }

        Errortext.text = "";
        PlayerPrefs.Save();
    }

    /*public void scrollingSaveButton()
    {
        float temp;

        if (float.TryParse(inputSPF.text, out temp))
        {
            PlayerPrefs.SetFloat("spf", temp);
            PlayerPrefs.Save();
            if (inputNum.text == "" && inputCode.text == "")
            {
                return;
            }
        }
        else if (inputNum.text == "" && inputCode.text == "")
        {
            Errortext.text = "Enter a number in SPF";
            return;
        }

        if (inputNum.text == "")
        {
            Errortext.text = "Fill out The slot number";
            return;
        }
        if (inputCode.text == "")
        {
            Errortext.text = "Fill out The code";
            return;
        }

        int temp2;

        if (int.TryParse(inputNum.text, out temp2))
        {
            if (temp2 > 5)
            {
                Errortext.text = "There are only 5 save slots";
                return;
            }
        }
        else
        {
            Errortext.text = "Enter a number in slot";
            return;
        }
        
        string moded = inputCode.text.Replace("\n", " ");

        string[] chars = moded.ToCharArray().Select(a => a.ToString()).ToArray();

        List<string[]> replacedStrings = new List<string[]>();

        foreach (string cha in chars)
        {
            replacedStrings.Add(letterToPattern[cha]);
        }

        List<string> finalLines = new List<string>();

        for (int i = 0; i < 9; i++)
        {
            string final = "";
            foreach(string[] replacedString in replacedStrings)
            {
                final += replacedString[i] + ",";
            }
            finalLines.Add("0," + final);
        }

        int frameCount = finalLines[0].Split(',').Length - 16;

        List<string> finalLinesDoubled = finalLines.Select(a => a = a + a).ToList();

        if (frameCount < 1)
        {
            Errortext.text = "Not enough text";
            return;
        }

        List<string> frames = new List<string>();

        for (int i = 0; i < frameCount * 2 - 1; i++)
        {
            string final2 = "";
            foreach (string finalLine in finalLinesDoubled)
            {
                final2 += string.Join(",", finalLine.Split(',').Skip(i).Take(16)) + ",";
            }

            final2 = final2.Remove(final2.Length - 1);

            frames.Add(final2);
        }

        Errortext.text = "";
        PlayerPrefs.SetString("slot" + inputNum.text, string.Join("/", frames));
        PlayerPrefs.Save();
    }
    */

    public void howTo()
    {
        Application.OpenURL("https://github.com/croissantderp/firefly");
    }

    public void buttonPress1()
    {
        Errortext.text = "loading... (this could take a while)";
        PlayerPrefs.SetString("current", PlayerPrefs.GetString("slot1", code1));
        PlayerPrefs.Save();
        SceneManager.LoadScene("lights");
    }

    public void buttonPress2()
    {
        Errortext.text = "loading... (this could take a while)";
        PlayerPrefs.SetString("current", PlayerPrefs.GetString("slot2", code2));
        PlayerPrefs.Save();
        SceneManager.LoadScene("lights");
    }

    public void buttonPress3()
    {
        Errortext.text = "loading... (this could take a while)";
        PlayerPrefs.SetString("current", PlayerPrefs.GetString("slot3", code3));
        PlayerPrefs.Save();
        SceneManager.LoadScene("lights");
    }

    public void buttonPress4()
    {
        Errortext.text = "loading... (this could take a while)";
        PlayerPrefs.SetString("current", PlayerPrefs.GetString("slot4", code1));
        PlayerPrefs.Save();
        SceneManager.LoadScene("lights");
        
    }

    public void buttonPress5()
    {
        Errortext.text = "loading... (this could take a while)";
        PlayerPrefs.SetString("current", PlayerPrefs.GetString("slot5", code5));
        PlayerPrefs.Save();
        SceneManager.LoadScene("lights");
    }

    public void ORSliderChange(float newValue)
    {
        or = newValue;
        PlayerPrefs.SetString("OnColor", or + "," + og + "," + ob);
        PlayerPrefs.Save();

        OnColor = new Color(or / 255f, og / 255f, ob / 255f, 255f);

        foreach (var button in buttons)
        {
            button.color = OnColor;
        }

        foreach (var text in texts)
        {
            text.outlineColor = OnColor;
            text.faceColor = OffColor;
        }
    }

    public void OGSliderChange(float newValue)
    {
        og = newValue;
        PlayerPrefs.SetString("OnColor", or + "," + og + "," + ob);
        PlayerPrefs.Save();

        OnColor = new Color(or / 255f, og / 255f, ob / 255f, 255f);

        foreach (var button in buttons)
        {
            button.color = OnColor;
        }

        foreach (var text in texts)
        {
            text.outlineColor = OnColor;
            text.faceColor = OffColor;
        }
    }

    public void OBSliderChange(float newValue)
    {
        ob = newValue;
        PlayerPrefs.SetString("OnColor", or + "," + og + "," + ob);
        PlayerPrefs.Save();

        OnColor = new Color(or / 255f, og / 255f, ob / 255f, 255f);

        foreach (var button in buttons)
        {
            button.color = OnColor;
        }

        foreach (var text in texts)
        {
            text.outlineColor = OnColor;
            text.faceColor = OffColor;
        }
    }

    public void FRSliderChange(float newValue)
    {
        fr = newValue;

        PlayerPrefs.SetString("OffColor", fr + "," + fg + "," + fb);
        PlayerPrefs.Save();

        OffColor = new Color(fr / 255f, fg / 255f, fb / 255f, 255f);
        bg.backgroundColor = OffColor;
    }

    public void FGSliderChange(float newValue)
    {
        fg = newValue;

        PlayerPrefs.SetString("OffColor", fr + "," + fg + "," + fb);
        PlayerPrefs.Save();

        OffColor = new Color(fr / 255f, fg / 255f, fb / 255f, 255f);
        bg.backgroundColor = OffColor;
    }

    public void FBSliderChange(float newValue)
    {
        fb = newValue;
        PlayerPrefs.SetString("OffColor", fr + "," + fg + "," + fb);
        PlayerPrefs.Save();

        OffColor = new Color(fr / 255f, fg / 255f, fb / 255f, 255f);
        bg.backgroundColor = OffColor;
    }
}
