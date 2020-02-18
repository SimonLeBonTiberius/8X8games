
using UnityEngine;


public class CubeScript : MonoBehaviour
{
   
  
    [SerializeField] private SpriteRenderer sprite;
    public Transform trans;

    //colori red, blue, green, yellow,violet, orange
    private Color red = new Color(255f,0f,0f);
     private Color blue = new Color(0f, 0f, 255f);
     private Color green = new Color(0f, 255f, 0f);
     private Color yellow = new Color(255f, 255f, 0f);
     private Color violet = new Color(255f, 0f, 255f);
     private Color orange = new Color(255f, 128f, 0f);
     public  float numerocol=0;
     public bool isIncontact = false;


    // Start is called before the first frame update
    void Start()
    {
        sprite.color = coloreRandom();
        BoardScript boardscript = this.GetComponentInParent<BoardScript>();
        if (boardscript != null )
        {
            if (boardscript.colorcheck > 0)
                boardscript.checkColor();
                
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) { 
        Touch tocco = Input.GetTouch(0);
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(tocco.position);
        touchPosition.z = 0f;
            float dist = Vector3.Distance(touchPosition, gameObject.transform.position);
                /* Debug.Log("posizione Tocco:" + touchPosition);
            Debug.Log("posizione traform" + transform.position);
            Debug.Log("Distance to other: " + dist);*/
         if (dist < 0.5f && isIncontact) {
                destoryCubebyTouch();
                SpawnScript script = GetComponentInParent<SpawnScript>();
                if (script!= null) 
                { script.empty = true; }
            }
        };
        if (isIncontact) {
            trans.Rotate(0f, 0f, 45f);
        }
        
       }
      public Color coloreRandom(){
        float numerorand = Random.Range(1, 6);
        switch (numerorand)
        {
            case 1:
                numerocol = 1;
                return red;
                
            case 2:
                numerocol = 2;
                return blue;
                
            case 3:
                numerocol = 3;
                return green;
                
            case 4:
                numerocol = 4;
                return yellow;
               
            case 5:
                numerocol = 5;
                return violet;
                
            case 6:
                numerocol = 6;
                return orange;
             

            default:
                return red;
        
        }

    }
    public void destoryCubebyTouch()
    {   
        Destroy(gameObject);
        BoardScript boardscript = this.GetComponentInParent<BoardScript>();
        
    }


    

    

}
