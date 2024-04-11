using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selected_dictionary : MonoBehaviour
{
    public Dictionary<int, GameObject> selectedTable = new Dictionary<int, GameObject>();

    public void addSelected(GameObject go)
    {
        int id = go.GetInstanceID();

        if (!selectedTable.ContainsKey(id))
        {
            selectedTable.Add(id, go);
            go.AddComponent<selection_component>();
            Debug.Log("Added " + id + " to selected dict");
        }
    }

    public void deselect(int id)
    {
        selectedTable[id].GetComponent<selection_component>().gameObject.transform.parent = null;
        Destroy(selectedTable[id].GetComponent<selection_component>());
        selectedTable.Remove(id);
    }

    public void deselectAll()
    {
        foreach(KeyValuePair<int,GameObject> pair in selectedTable)
        {
            if(pair.Value != null)
            {
                pair.Value.GetComponent<selection_component>().gameObject.transform.parent = null;
                Destroy(selectedTable[pair.Key].GetComponent<selection_component>());
            }
        }
        selectedTable.Clear();
    }
}