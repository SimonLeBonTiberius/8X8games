
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
     public int index;
     public int indey;



    // Start is called before the first frame update
    void Start()
    {
        sprite.color = coloreRandom();
        BoardScript boardscript = this.GetComponentInParent<BoardScript>();
        if (boardscript != null )
        {
            if (boardscript.colorcheck > 0)
                boardscript.Invoke("checkColor",0.2f);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
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
    public bool CubebyTouch(Touch tocco)
    {   
        
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(tocco.position);
        touchPosition.z = 0f;
        float dist = Vector3.Distance(touchPosition, gameObject.transform.position);
        if (dist < 0.5f )
        {
            Debug.Log("cubotoccato"+"("+index+","+indey+")");
           
            return true;
        }
        else{
            return false;
        }

    

    }

    public void destroyCube() {
        Destroy(gameObject);
        SpawnScript script = GetComponentInParent<SpawnScript>();
        if (script != null)
        { script.empty = true; }

    }






}
