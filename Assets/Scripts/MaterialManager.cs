using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour {
    [SerializeField] int wood;
    [SerializeField] int stone;
    [SerializeField] int decoration;

    // Start is called before the first frame update
    void Start() {
        wood = 0;
        stone = 0;
        decoration = 0;
    }

    public void updateResources(resourceTypes type, int quantity) {
        switch (type) {
            case resourceTypes.wood:
                wood += quantity;
                break;
            case resourceTypes.stone:
                stone += quantity;
                break;
            case resourceTypes.decoration:
                decoration += quantity;
                break;
        }
    }
}
