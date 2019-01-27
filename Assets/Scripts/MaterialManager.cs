using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour {
    [SerializeField] int wood;
    [SerializeField] int stone;
    [SerializeField]
    Dictionary<Theme, int> decorations = new Dictionary<Theme, int>()
    {
        { Theme.EARTH, 0 },
        { Theme.FIRE, 0 },
        { Theme.WATER, 0 },
        { Theme.AIR, 0},
    };

    // Start is called before the first frame update
    void Start() {
        wood = 0;
        stone = 0;
    }

    public void updateBasicResources(resourceTypes type, int quantity) {
        switch (type) {
            case resourceTypes.wood:
                wood += quantity;
                break;
            case resourceTypes.stone:
                stone += quantity;
                break;
        }
    }

    public void updateDecorationResources(Theme type, int quantity) {
        switch (type) {
            case Theme.FIRE:
                decorations[Theme.FIRE]++;
                break;
            case Theme.WATER:
                decorations[Theme.WATER]++;
                break;
            case Theme.EARTH:
                decorations[Theme.EARTH]++;
                break;
            case Theme.AIR:
                decorations[Theme.AIR]++;
                break;
        }
    }
}
