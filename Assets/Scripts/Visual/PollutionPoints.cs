using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PollutionLevelDisplay : MonoBehaviour
{
    public TextMeshProUGUI pollutionText;

    void Start()
    {
        UpdatePollutionLevel();
    }

    void Update()
    {
        UpdatePollutionLevel();
    }

    void UpdatePollutionLevel()
    {
        int totalPoints = RecyclableTrashCan.totalPoints;
        int percentageReduction = totalPoints / 200;
        int currentPollutionLevel = 93 - percentageReduction;
        currentPollutionLevel = Mathf.Max(currentPollutionLevel, 0);

        pollutionText.text = $"Nivel actual de la contaminación en el Perú: {currentPollutionLevel}%\n\n" +
                             "¡Con tu ayuda podemos disminuir esta cifra!";
    }
}
