using UnityEngine;

public class quality : MonoBehaviour
{
    public GameObject bloomEffects;
    // Start is called before the first frame update
    void Start()
    {
        int level = PlayerPrefs.GetInt("quality", 1);
        QualitySettings.SetQualityLevel(level);
        if (level == 0)
            bloomEffects.SetActive(false);
        else
            bloomEffects.SetActive(true);
    }

    // Update is called once per frame
    public void changeLevels(int level)
    {
        QualitySettings.SetQualityLevel(level);
        PlayerPrefs.SetInt("quality", level);
        if (level == 0)
            bloomEffects.SetActive(false);
        else
            bloomEffects.SetActive(true);
    }
}
