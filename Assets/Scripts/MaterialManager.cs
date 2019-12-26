using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaterialManager : MonoBehaviour {
    [SerializeField] int wood;
    [SerializeField] int stone;
    [SerializeField] public Dictionary<Theme, int> decorations = new Dictionary<Theme, int>()
    {
        { Theme.EARTH, 0 },
        { Theme.FIRE, 0 },
        { Theme.WATER, 0 },
        { Theme.AIR, 0},
    };

    public TextMeshProUGUI text;

    public int Wood { get { return wood; } }
    public int Stone { get { return stone; } }

    // Start is called before the first frame update
    void Start() {
        wood = 0;
        stone = 0;
        UpdateTextWindow();
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
        UpdateTextWindow();
    }

    public void updateDecorationResources(Theme type, int quantity) {
        switch (type) {
            case Theme.FIRE:
                decorations[Theme.FIRE] += quantity;
                Debug.Log("FIRE: " + decorations[Theme.FIRE]);
                break;
            case Theme.WATER:
                decorations[Theme.WATER] += quantity;
                Debug.Log("WATER: " + decorations[Theme.WATER]);
                break;
            case Theme.EARTH:
                decorations[Theme.EARTH] += quantity;
                Debug.Log("EARTH: " + decorations[Theme.EARTH]);
                break;
            case Theme.AIR:
                decorations[Theme.AIR] += quantity;
                Debug.Log("AIR: " + decorations[Theme.AIR]);
                break;
        }
        UpdateTextWindow();
    }

    public void UpdateTextWindow()
    {
        text.text = $"<sprite=0>: {wood}\n" +
                    $"<sprite=1>: {stone}\n" +
                    $"<sprite=2>: {decorations[Theme.FIRE]}\n" +
                    $"<sprite=3>: {decorations[Theme.AIR]}\n" +
                    $"<sprite=4>: {decorations[Theme.EARTH]}\n" +
                    $"<sprite=5>: {decorations[Theme.WATER]}";
    }
    
}
