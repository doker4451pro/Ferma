using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseVegetable : MonoBehaviour
{
    [SerializeField] private float speed = 0.02f;
    public void Move(VegetablesState state) 
    {

        StartCoroutine(MoveCoroutina(state));
    }

    private IEnumerator MoveCoroutina(VegetablesState state)
    {
        float i = 0f;
        Vector3 position;
        Vector3 startPosition = transform.position;
        Vector3 finishPosition = UIManager.Instance.GetFinish();
        finishPosition.z = startPosition.z;
        while (i <= 1)
        {
            position = Vector3.Lerp(startPosition,finishPosition , i);
            transform.position = position;
            i += speed;
            yield return null;
        }
        UIManager.Instance.SetInfo(state.ToString(), 1);
        Destroy(gameObject);
    }
}
