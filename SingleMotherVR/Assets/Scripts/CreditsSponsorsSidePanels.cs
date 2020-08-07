using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsSponsorsSidePanels : MonoBehaviour
{
    public List<GameObject> Items = new List<GameObject>();

    public void HideAll() {
        foreach (var item in Items)
        {
            item.SetActive(false);
        }
    }


    public IEnumerator Show() {
        foreach (var item in Items)
        {
            yield return new WaitForSeconds(1);
            item.SetActive(true);
        }
    }
}
