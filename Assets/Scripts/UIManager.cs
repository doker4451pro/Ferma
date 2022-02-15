using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] Transform finishTransform;
    [SerializeField] TextMeshProUGUI textMesh;

    Dictionary<string, int> stats;
    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        stats = new Dictionary<string, int>();
    }

    public void PrintInfo() 
    {
        StringBuilder stringBuilder = new StringBuilder(); 
        foreach (var item in stats)
        {
            stringBuilder.Append(item.Key + ": " + item.Value+"\n");
        }
        textMesh.text = stringBuilder.ToString();
    }

    public void SetInfo(string name,int count) 
    {
        if (stats.ContainsKey(name))
            stats[name] += count;
        else
            stats.Add(name, count);

        PrintInfo();
    }

    public Vector3 GetFinish() =>
        finishTransform.position;
}
