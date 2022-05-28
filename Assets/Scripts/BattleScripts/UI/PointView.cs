using UnityEngine;
using TMPro;

public class PointView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textView;
    int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyKilled()
    {
        points++;
        textView.text = points.ToString();
    }
}
