using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSower : MonoBehaviour
{
    [SerializeField] private VegetablesState state;

    private Player player;
    private void Start()
    {
        player = gameObject.GetComponent<Player>();
    }

    public void ChangeVegetablesState(int i) 
    {
        player.ChangeState(PlayerState.Sower);
        state = (VegetablesState)i;
    }

    public void CustomOnMouseDown() 
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.transform != null) 
        {
            var garden = hit.transform.GetComponent<Garden>();
            if (garden != null) 
            {
                garden.TryPlantVegetable(state);
            }
        }
    }
}
