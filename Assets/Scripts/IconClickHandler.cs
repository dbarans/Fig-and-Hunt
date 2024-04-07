using UnityEngine;
using UnityEngine.EventSystems;

public class IconClickHandler : MonoBehaviour
{
    [SerializeField] private GameObject store;
    [SerializeField] private GameObject market;
    [SerializeField] private GameObject storage;


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
    public void activateStorage()
    {
        storage.SetActive(true); 
    }
    public void deactivateStorage()
    {
        storage.SetActive(false);
    }

}
