using UnityEngine;
using UnityEngine.EventSystems;

public class IconClickHandler : MonoBehaviour
{
    [SerializeField] private GameObject store;
    [SerializeField] private GameObject market;

 
    public void activateStore()
    { 
        store.SetActive(true);

    }
    public void activateMarket()
    { 
        market.SetActive(true); 
    }
    public void deactivateStore()
    { 
        store.SetActive(false);
    }
    public void deactivateMarket()
    {
        market.SetActive(false);
    }

}
