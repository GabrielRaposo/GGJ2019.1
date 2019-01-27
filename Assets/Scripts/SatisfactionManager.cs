using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatisfactionManager : MonoBehaviour {
    [SerializeField] [Range(0f, 10f)] float happiness;
    [SerializeField] [Range(0f, 10f)] float sadness;
    [SerializeField] int strikeLimit = 3;

    public int strikes = 0;
    private float satisfaction = 0;

    public void checkSatisfactionStartOfDay() {
        Debug.Log(strikes);
        satisfaction =  happiness - sadness;
        if (satisfaction > 0 && strikes > 0) {
            strikes--;
        }
    }

    public void checkSatisfactionEndOfDay() {
        Debug.Log(strikes);
        satisfaction = happiness - sadness;
        if (satisfaction < 0) {
            strikes++;
            if (strikes >= strikeLimit) {
                PeopleBehaviour pb = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<PeopleBehaviour>();
                pb.kickCitizen(this.gameObject);
            }
        }
    }

    public void updateHapiness(int quantity) {
        happiness += quantity;
    }
    public void updateSadness(int quantity) {
        sadness += quantity;
    }

}