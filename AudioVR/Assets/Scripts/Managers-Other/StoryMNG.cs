using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryMNG : MonoBehaviour
{
    public TextMeshPro StoryTXT;

    private int StoryPtr;
    private string CurrStory;

    private string story1 = "A 30-year-old female patient has been experiencing imbalance and recurrent vertigo attacks for the past year. The vertigo is more pronounced on the left side and is triggered by loud sounds, including her own voice, as well as coughing, sneezing, and straining. She reports increased difficulty in speech comprehension in noisy environments but denies tinnitus. The patient has no history of trauma or any surgical procedures. Her other medical history is unremarkable.";
    private string story2 = "A 45-year-old female patient presents with hearing loss, tinnitus resembling a ringing sound, and difficulty distinguishing speech in noisy environments. She does not report vertigo, dizziness, or any additional ear complaints. She is being monitored for hypertension as a comorbid condition.";
    private string story3 = "A 25-year-old female patient requires a hearing examination before starting her newly accepted job. She does not report any complaints of ear pressure, tinnitus, pain, or a feeling of fullness. She has no known comorbidities.";
    
    void Awake()
    {
        StoryPtr = SceneData.myValue;
        if (StoryPtr == 1) CurrStory = story1;
        else if (StoryPtr == 2) CurrStory = story2;
        else if (StoryPtr == 3) CurrStory = story3;
        StoryTXT.text = CurrStory;
    }
}

