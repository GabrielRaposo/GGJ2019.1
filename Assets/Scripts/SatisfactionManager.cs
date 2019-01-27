using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatisfactionManager : MonoBehaviour {
    [SerializeField] int strikeLimit = 3;

    public int strikes = 0;
    private float satisfaction = 0;

    public void checkSatisfactionStartOfDay() {
        if (satisfaction > 0 && strikes > 0) {
            strikes--;
        }
    }

    public void checkSatisfactionEndOfDay() {
        if (satisfaction < 0) {
            strikes++;
            if (strikes >= strikeLimit) {
                PeopleBehaviour pb = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<PeopleBehaviour>();
                pb.kickCitizen(this.gameObject);
            }
        }
    }

    public void updateSatisfaction(int quantity) {
        satisfaction += quantity;
    }

}