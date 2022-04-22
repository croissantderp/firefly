using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class lights : MonoBehaviour
{
    public TMP_Text text;
    public Image image;
    public TMP_Text failText;

    public GameObject pixel;
    public GameObject parent;
    Camera mainCamera;

    public float interval = 1;

    float timeRemaining = 0;

    public Color off;
    public Color on;

    //   1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6
    string code = "16,9;" +
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

    int currentFrameNum = 0;

    string[] frames;

    int x;
    int y;

    public List<SpriteRenderer> pixels = new List<SpriteRenderer>();

    bool noRun = false;

    // Start is called before the first frame update
    void Start()
    {
        interval = PlayerPrefs.GetFloat("spf", 1f);

        code = PlayerPrefs.GetString("current", code);

        string thing443 = code.Split(';')[0];
        code = code.Split(';')[1];

        x = int.Parse(thing443.Split(',')[0]);
        y = int.Parse(thing443.Split(',')[1]);

        string OnColorTemp = PlayerPrefs.GetString("OnColor", "255,255,255");

        var split = OnColorTemp.Split(',').Select(a => a == "" ? a = "0" : a).ToArray();

        on = new Color(float.Parse(split[0]) / 255f, float.Parse(split[1]) / 255f, float.Parse(split[2]) / 255f, 255f);

        string OffColorTemp = PlayerPrefs.GetString("OffColor", "0,0,0");

        split = OffColorTemp.Split(',').Select(a => a == "" ? a = "0" : a).ToArray();

        off = new Color(float.Parse(split[0]) / 255f, float.Parse(split[1]) / 255f, float.Parse(split[2]) / 255f, 255f);

        image.color = on;

        text.outlineColor = on;
        text.faceColor = off;

        mainCamera = FindObjectOfType<Camera>();
        mainCamera.backgroundColor = off;

        frames = code.Split('/');

        if (frames[0].Split(',').Length != x * y)
        {
            failText.text = $"code not compatable with chosen resolution (current pixels: {x * y}, needed: {frames[0].Split(',').Length})";
            noRun = true;
            return;
        }

        for (int i = 0; i < x * y; i++)
        {
            var thing = Instantiate(pixel);
            thing.transform.parent = parent.transform;
            thing.transform.position = new Vector3((i % x) - ((float)x / 2f) + 0.5f, -((i / x) % x) + ((float)y / 2f) - 0.5f, 0);

        pixels.Add(thing.GetComponent<SpriteRenderer>());
        }

        float scale = 
            x - 16 > y - 9 ? 
            (16f / (float)x - 1) * 1.25f + 1f : 
            (9f / (float)y - 1) * 1.25f + 1f ;

        parent.transform.localScale = new Vector3(scale, scale);

    }

    // Update is called once per frame
    void Update()
    {
        if (!noRun)
        {
            if (timeRemaining <= 0)
            {
                string[] currentFrame = frames[currentFrameNum].Replace("\n", "").Split(',');

                for (int i = 0; i < pixels.Count(); i++)
                {
                    pixels[i].color = currentFrame[i] == "1" ? on : off;
                }

                if (currentFrameNum >= frames.Length - 1)
                {
                    currentFrameNum = 0;
                }
                else
                {
                    currentFrameNum++;
                }

                //resets timer
                timeRemaining = interval;
            }
            else
            {
                timeRemaining -= Time.deltaTime;
            }
        }
    }

    public void buttonPress()
    {
        SceneManager.LoadScene("menu");
    }
}
