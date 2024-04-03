using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class global_selection : MonoBehaviour
{
    
    public PlayerInputActions playerControls;

    private InputAction selection;
    private InputAction inclusive;
    private InputAction group;
    public GameObject parent;

    public bool includes = false;
    public bool selecting = false;
    public float dragDeadzone = 40f;
    
    selected_dictionary selected_table;
    RaycastHit hit;

    bool dragSelect;

    //Collider variables
    //=======================================================//

    MeshCollider selectionBox;
    Mesh selectionMesh;

    Vector3 p1;
    Vector3 p2;

    //the corners of our 2d selection box
    Vector2[] corners;

    //the vertices of our meshcollider
    Vector3[] verts;
    Vector3[] vecs;

    // Start is called before the first frame update
    void Start()
    {
        
        selected_table = GetComponent<selected_dictionary>();
        dragSelect = false;
    }

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        selection = playerControls.Cashier.Selection;
        inclusive = playerControls.Cashier.Inclusive;
        //group = playerControls.Cashier.Group;

        selection.Enable();
        inclusive.Enable();
        //group.Enable();

        selection.started += SelectionStart;
        selection.canceled += SelectionEnd;
        inclusive.started += Includes;
        inclusive.canceled += Excludes;
        //group.performed += Group;
    }

    // Update is called once per frame
    void Update()
    {
        if(selecting && (p1 - Input.mousePosition).magnitude > dragDeadzone)
            {
                Debug.Log("Selection is Moving!");
                dragSelect = true;
            }
    }

    private void SelectionStart(InputAction.CallbackContext context)
    {
        p1 = Input.mousePosition;
        selecting = true;
    }

    private void SelectionEnd(InputAction.CallbackContext context)
    {
        if(dragSelect == false) //single select
            {
                Ray ray = Camera.main.ScreenPointToRay(p1);

                if(Physics.Raycast(ray,out hit, 50000.0f, 1 << 3))
                {
                    if (includes) //inclusive select
                    {
                        selected_table.addSelected(hit.transform.gameObject);
                    }
                    else //exclusive selected
                    {
                        StartCoroutine(NewSelection());
                    }
                }
                else //if we didnt hit something
                {
                    if (includes)
                    {
                        //do nothing
                    }
                    else
                    {
                        selected_table.deselectAll();
                    }
                }
            }
            else //marquee select
            {
                verts = new Vector3[4];
                vecs = new Vector3[4];
                int i = 0;
                p2 = Input.mousePosition;
                corners = getBoundingBox(p1, p2);

                foreach (Vector2 corner in corners)
                {
                    Ray ray = Camera.main.ScreenPointToRay(corner);

                    if (Physics.Raycast(ray, out hit, 50000.0f, 1 << 6))
                    {
                        verts[i] = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                        vecs[i] = ray.origin - hit.point;
                        Debug.DrawLine(Camera.main.ScreenToWorldPoint(corner), hit.point, Color.red, 1.0f);
                    }
                    i++;
                }

                //generate the mesh
                selectionMesh = generateSelectionMesh(verts,vecs);

                selectionBox = gameObject.AddComponent<MeshCollider>();
                selectionBox.sharedMesh = selectionMesh;
                selectionBox.convex = true;
                selectionBox.isTrigger = true;

                if (!includes)
                {
                    selected_table.deselectAll();
                }

               Destroy(selectionBox, 0.02f);

            }//end marquee select

            selecting = false;
            dragSelect = false;
    }

    private void Includes(InputAction.CallbackContext context)
    {
        includes = true;
    }

    private void Excludes(InputAction.CallbackContext context)
    {
        includes = false;
    }


    private void OnGUI()
    {
        if(dragSelect == true)
        {
            var rect = Utils.GetScreenRect(p1, Input.mousePosition);
            Utils.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            Utils.DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    }

    //create a bounding box (4 corners in order) from the start and end mouse position
    Vector2[] getBoundingBox(Vector2 p1,Vector2 p2)
    {
        // Min and Max to get 2 corners of rectangle regardless of drag direction.
        var bottomLeft = Vector3.Min(p1, p2);
        var topRight = Vector3.Max(p1, p2);

        // 0 = top left; 1 = top right; 2 = bottom left; 3 = bottom right;
        Vector2[] corners =
        {
            new Vector2(bottomLeft.x, topRight.y),
            new Vector2(topRight.x, topRight.y),
            new Vector2(bottomLeft.x, bottomLeft.y),
            new Vector2(topRight.x, bottomLeft.y)
        };
        return corners;

    }

    //generate a mesh from the 4 bottom points
    Mesh generateSelectionMesh(Vector3[] corners, Vector3[] vecs)
    {
        Vector3[] verts = new Vector3[8];
        int[] tris = { 0, 1, 2, 2, 1, 3, 4, 6, 0, 0, 6, 2, 6, 7, 2, 2, 7, 3, 7, 5, 3, 3, 5, 1, 5, 0, 1, 1, 4, 0, 4, 5, 6, 6, 5, 7 }; //map the tris of our cube

        for(int i = 0; i < 4; i++)
        {
            verts[i] = corners[i];
        }

        for(int j = 4; j < 8; j++)
        {
            verts[j] = corners[j - 4] + vecs[j - 4];
        }

        Mesh selectionMesh = new Mesh
        {
            vertices = verts,
            triangles = tris
        };

        return selectionMesh;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Selectable"))
        {
            selected_table.addSelected(other.gameObject);
        }
    }

    // I had to add this coroutine due to the deselect occurring after the selection is made
    private IEnumerator NewSelection()
    {
        selected_table.deselectAll();
        yield return new WaitForSeconds(0.00001f);
        selected_table.addSelected(hit.transform.gameObject);
    }

    /*private void Group(InputAction.CallbackContext context)
    {
        Instantiate(parent);
        gameObject.transform.parent = GameObject.FindGameObjectWithTag("Parent").transform;
    }*/

}