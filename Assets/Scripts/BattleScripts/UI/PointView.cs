using UnityEngine;
using TMPro;

public class PointView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textView;
    [SerializeField] private TextMeshProUGUI _comboView;
    private int _points = 0;
    private int _comboPoints;
    // Start is called before the first frame update
    void Start()
    {
        _points = 0;
        _comboPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyKilled(bool combo)
    {
        if (combo)
        {
            _comboPoints++;
        }
        else
        {
            _comboPoints = 0;
        }
        _points += 10 * _comboPoints;
        _textView.text = _points.ToString();
        _comboView.text = _comboPoints.ToString();
    }
}
