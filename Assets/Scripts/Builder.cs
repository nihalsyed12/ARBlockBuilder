using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Builder : MonoBehaviour
{
    [SerializeField]
    private GameObject demoBlock;
    private ARRaycastManager raycastManager;
    // Start is called before the first frame update
    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBuildButtonPressed()
    {
        List<ARRaycastHit> arHits = new List<ARRaycastHit>();
        raycastManager.Raycast(Camera.main.ViewportPointToRay(new Vector2(.5f, .5f)), arHits, TrackableType.Planes);

        if(arHits.Count > 0)
        {
            Vector3 buildablePosition = new Vector3(Mathf.Round(arHits[0].pose.position.x/1)*1, Mathf.Round(arHits[0].pose.position.z/1)*1);
            //Quaternion represent rotation
            Quaternion buildableRotation = arHits[0].pose.rotation;
            Build(buildablePosition, buildableRotation);
        }
    }
    void Build(Vector3 pos, Quaternion rot)
    {
        Instantiate(demoBlock, pos, rot);
    }
}
