using UnityEngine;
using System.Collections;

public class Scale : MonoBehaviour {


    private float scaleXMax = 0;
    private float scaleYMax = 0;
    private float scaleXMin = 0;
    private float scaleYMin = 0;
    private bool isScaleIn = false;
    private bool isScaleOut = false;
    private bool isScaleOutIn = false;
    private bool isScaleInOut = false;

    public float x = 0;
    public float y = 0;
    public GameObject scaleTarget;

    private GameObject objScale;
    private Vector3 scaleMin;
    private Vector3 scaleMax;
    private float scaleX = 0;
    private float scaleY = 0;

    void ResetAll()
    {        
        
        objScale = null;
        scaleMin = Vector3.zero;
        scaleMax = Vector3.zero;
        scaleX = 0;
        scaleY = 0;
        scaleXUp = 0;
        scaleYUp = 0;
        scaleXDown = 0;
        scaleYDown = 0;
        isMax = false;
        isMin = false;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isScaleOut)
        {
            UpdateScaleOut();
        }
        if(isScaleIn)
        {
            UpdateScaleIn();
        }
        if(isScaleInOut)
        {
            UpdateScaleZoomInOut();
        }
        if(isScaleOutIn)
        {
            UpdateScaleZoomOutIn();
        }
        
	}
    public void ZoomOut(GameObject obj, Vector3 _scaleMin, Vector3 _scaleMax, float _scaleX, float _scaleY)
    {
        ResetAll();
        objScale = obj;
        objScale.transform.localScale = _scaleMin;
        scaleMin = _scaleMin;
        scaleMax = _scaleMax;
        scaleX = _scaleX;
        scaleY = _scaleY;

    }
    
    void UpdateScale(Vector3 _scaleMin, Vector3 scaleMax, float _scaleX, float _scaleY, ref float _x, ref float _y)
    {
        scaleX += _scaleX * Time.deltaTime;
        _x = scaleX;
        scaleY += _scaleY * Time.deltaTime;
        _y = scaleY;
        if (objScale != null)
            objScale.transform.localScale = new Vector3(x, y);
    }
    void UpdateScaleOut()
    {
        if (scaleXMax < scaleMax.x)
            scaleXMax += scaleX * Time.deltaTime;
        if (scaleYMax < scaleMax.y)
            scaleYMax += scaleY * Time.deltaTime;
        objScale.transform.localScale = new Vector3(scaleXMax, scaleYMax);
    }
    [ContextMenu("TestZoomOut")]
    void TestZoomOut()
    {
        ZoomOut(scaleTarget, Vector3.zero, new Vector3(2,2), 0.5f, 0.5f);
        isScaleOut = true;
    }
    [ContextMenu("TestZoomIn")]
    void TestZoomIn()
    {
        ZoomIn(scaleTarget, new Vector3(2, 2), Vector3.zero, 0.5f, 0.5f);
        isScaleIn = true;
    }
    public void ZoomIn(GameObject obj, Vector3 _scaleMax, Vector3 _scaleMin, float _scaleX, float _scaleY)
    {
        ResetAll();
        objScale = obj;
        objScale.transform.localScale = _scaleMax;
        scaleMin = _scaleMin;
        scaleMax = _scaleMax;
        scaleX = _scaleX;
        scaleY = _scaleY;
        scaleXMin = _scaleMax.x;
        scaleYMin = _scaleMax.y;
    }
    void UpdateScaleIn()
    {
        if (scaleXMin > scaleMin.x)
            scaleXMin -= scaleX * Time.deltaTime;
        if (scaleYMin > scaleMin.y)
            scaleYMin -= scaleY * Time.deltaTime;
        objScale.transform.localScale = new Vector3(scaleXMin, scaleYMin);
    }
    float scaleXUp = 0;
    float scaleYUp = 0;
    float scaleXDown = 0;
    float scaleYDown = 0;

    //Zoom In Out
    public void ZoomInOut(GameObject obj, Vector3 _scale, Vector3 _scaleMax, Vector3 _scaleMin, float _scaleXUp, float _scaleYUp, float _scaleXDown, float _scaleYDown)
    {
        ResetAll();
        objScale = obj;
        objScale.transform.localScale = _scale;

        scaleMax = _scaleMax;
        scaleMin = _scaleMin;

        scaleXUp = _scaleXUp;
        scaleYUp = _scaleYUp;

        scaleXDown = _scaleXDown;
        scaleYDown = _scaleYDown;

        scaleX = _scale.x;
        scaleY = _scale.y;
    }
    private bool isMax = false;
    private bool isMin = false;
    void UpdateScaleZoomInOut()
    {
        if (isMin == false)
        {
            if (scaleX > scaleMin.x)
                scaleX -= scaleXDown * Time.deltaTime;
            if (scaleY > scaleMin.y)
                scaleY -= scaleYDown * Time.deltaTime;
            if (scaleX <= scaleMin.x && scaleY <= scaleMin.y)
            {
                isMin = true;
            }
            
        }
        else
        {
            if (scaleX < scaleMax.x)
                scaleX += scaleXUp * Time.deltaTime;
            if (scaleY < scaleMax.y)
                scaleY += scaleYUp * Time.deltaTime;
            if (scaleX >= scaleMax.x && scaleY >= scaleMax.y)
            {
                scaleX = scaleMax.x;
                scaleY = scaleMax.y;
                Scale s = scaleTarget.GetComponent<Scale>();
                if (s != null)
                {
                    Destroy(s);
                }
                isScaleInOut = false;
            }          
        }
        objScale.transform.localScale = new Vector3(scaleX, scaleY);
    }
    [ContextMenu("TestZoomInOut")]
    void TestZoomInOut()
    {
        ZoomInOut(scaleTarget, scaleTarget.transform.localScale, new Vector3(3, 3, 1), Vector3.zero, 1f, 1f, 0.5f, 0.5f);
        isScaleInOut = true;
    }

    //Zoom Out In
    public void ZoomOutIn(GameObject obj, Vector3 _scale, Vector3 _scaleMax, Vector3 _scaleMin, float _scaleXUp, float _scaleYUp, float _scaleXDown, float _scaleYDown)
    {

        ResetAll();
        scaleTarget = obj;
        isScaleOutIn = true;
        objScale = obj;
        objScale.transform.localScale = _scale;

        scaleMax = _scaleMax;
        scaleMin = _scaleMin;

        scaleXUp = _scaleXUp;
        scaleYUp = _scaleYUp;

        scaleXDown = _scaleXDown;
        scaleYDown = _scaleYDown;
        scaleX = _scale.x;
        scaleY = _scale.y;
    }
    void UpdateScaleZoomOutIn()
    {
        if (isMax == false)
        {
            if (scaleX < scaleMax.x)
                scaleX += scaleXUp * Time.deltaTime;
            if (scaleY < scaleMax.y)
                scaleY += scaleYUp * Time.deltaTime;
            if (scaleX >= scaleMax.x && scaleY >= scaleMax.y)
            {
                isMax = true;
            }

        }
        else
        {
            if (scaleX >= scaleMin.x)
                scaleX -= scaleXDown * Time.deltaTime;
            if (scaleY >= scaleMin.y)
                scaleY -= scaleYDown * Time.deltaTime;
            if (scaleX <= scaleMin.x && scaleY <= scaleMin.y)
            {
                scaleX = scaleMin.x;
                scaleY = scaleMin.y;
                Scale s = scaleTarget.GetComponent<Scale>();
                if (s != null)
                {
                    Destroy(s);
                }
                isScaleOutIn = false;
            
            }
        }
        objScale.transform.localScale = new Vector3(scaleX, scaleY);
    }
    [ContextMenu("TestZoomOutIn")]
    public void TestZoomOutIn(GameObject _obj)
    {
        scaleTarget = _obj; 

        //isScaleOutIn = true;
        ZoomOutIn(_obj, scaleTarget.transform.localScale, new Vector3(3, 3, 1), scaleTarget.transform.localScale, 5f, 5f, 3f, 3f);
        isScaleOutIn = true;
    }
    
}
