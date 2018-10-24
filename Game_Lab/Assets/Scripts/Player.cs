using UnityEngine;


public class Player : MonoBehaviour
{
    public float speed = 0.3f;



    void Update()
    {
        bool move = false;
        float rotate = 0F;

        //MOVEMENT
        if (Input.GetKey(KeyCode.W))
        {
            move = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rotate += 180F;
            move = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (!move)
                rotate += 90F;
            else if (rotate == 0F)
                rotate += 45F;
            else
                rotate -= 45F;
            move = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (!move)
                rotate -= 90F;
            else if (rotate == 0F)
                rotate -= 45F;
            else
                rotate += 45F;
            move = true;
        }

        if (move)
        {
            transform.position += transform.forward * speed;
            transform.rotation = Quaternion.Euler(new Vector3(0F, rotate, 0F));
        }
    }




}
