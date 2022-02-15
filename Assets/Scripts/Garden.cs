using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Garden : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private Vegetables vegetablesData;

    private GardenState currentState;
    private VegetablesState vegetablesState;
    private BaseVegetable vegetable;
    public void TryPlantVegetable(VegetablesState state) 
    {
        if (currentState == GardenState.None) 
        {
            vegetablesState = state;
            vegetable = Instantiate(vegetablesData.GetGameObjectByName(state), transform).AddComponent<BaseVegetable>();
            currentState = GardenState.Growing;

            vegetable.actionOnGwowingEnd += SetStateMatured;
            vegetable.PlantVegetable(vegetablesData.GetTimeByName(vegetablesState));
        }
    }

    private void SetStateMatured() =>
        currentState = GardenState.Matured;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentState == GardenState.Matured) 
        {
            vegetable.Move(vegetablesState);
            currentState = GardenState.None;
        }
    }

}
