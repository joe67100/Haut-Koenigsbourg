using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VHS;

public class FootstepSwapper : MonoBehaviour
{
    private FirstPersonController fpc;
    private TerrainChecker checker;
    private string currentLayer;
    public FootstepCollection[] terrainFootstepCollections;

    // Start is called before the first frame update
    void Start()
    {
        checker = new TerrainChecker();
        fpc = GetComponent<FirstPersonController>();

    }

    public void CheckLayers()
    {
        // raycast down
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 3))
        {
            // check if terrain exists
            if (hit.transform.GetComponent<Terrain>()!=null)
            {
                Terrain t = hit.transform.GetComponent<Terrain>();
                // if layer matches our currentLayer
                if (currentLayer != checker.GetLayerName(transform.position, t))
                {
                    currentLayer = checker.GetLayerName(transform.position, t);

                    // swap footsteps
                    foreach (FootstepCollection collection in terrainFootstepCollections)
                    {
                        if (currentLayer == collection.name)
                        {
                            fpc.SwapFootsteps(collection);
                        }
                    }
                }
            }
        }
    }
}
