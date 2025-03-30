using UnityEngine;

public class SlingShotSting : MonoBehaviour
{
    public Transform leftPoint; 
    public Transform rightPoint; 
    public Transform centerPoint;
    
    public LineRenderer slingshotString;
    
    // Start is called before the first frame update
    void Start()
    {
        
       slingshotString = GetComponent<LineRenderer>();
    
    }
    
    // Update is called once per frame
    void Update()
    {
        slingshotString.SetPositions(new Vector3[3] { leftPoint.position, centerPoint.position, rightPoint.position });
    }
}
