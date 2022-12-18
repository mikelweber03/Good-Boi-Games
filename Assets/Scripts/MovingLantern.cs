using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLantern : MonoBehaviour
{

    [SerializeField] private float offsetRight = 0, offsetLeft = 0, speed = 1, offsetUp = 0, offsetDown = 0;
    [SerializeField] private bool hasReachedRight = false, hasReachedLeft = false, hasReachedUp = false, hasReachedDown = false, movesHorizontal = false;
    float meshWidth = 0;
    float meshHeight = 0;
    float depthValue;
    Vector3 startPosition = Vector3.zero;


    // Start is called before the first frame update
    void Awake()
    {
        startPosition = transform.position;
        Mesh meshObject = GetComponentsInChildren<MeshFilter>()[0].sharedMesh;
        meshWidth = meshObject.bounds.size.x;
        meshHeight = meshObject.bounds.size.y;
        depthValue = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movesHorizontal)
        {
            MoveHorizontal();
            Debug.Log(offsetRight);
            Debug.Log(offsetLeft);
        }

        if(!movesHorizontal)
        {
            MoveVertical();
            Debug.Log(offsetUp);
            Debug.Log(offsetDown);
        }
    }

    void MoveVertical()
    {
        if (!hasReachedUp)
        {
            if (transform.position.y < startPosition.y + offsetUp)
            {
                MovementVertical(offsetUp);
            }
            else if (transform.position.y >= startPosition.y + offsetUp)
            {
                hasReachedUp = true;
                hasReachedDown = false;
            }
        }
        else if (!hasReachedDown)
        {
            if (transform.position.y > startPosition.y + offsetDown)
            {
                MovementVertical(offsetDown);
            }
            else if (transform.position.y <= startPosition.y + offsetDown)
            {
                hasReachedUp = false;
                hasReachedDown = true;
            }
        }
    }
    void MoveHorizontal()
    {
        if (!hasReachedRight)
        {
            if (transform.position.x < startPosition.x + offsetRight)
            {
                MovementHorizontal(offsetRight);
            }
            else if (transform.position.x >= startPosition.x + offsetRight)
            {
                hasReachedRight = true;
                hasReachedLeft = false;
            }
        }
        else if (!hasReachedLeft)
        {
            if (transform.position.x > startPosition.x + offsetLeft)
            {
                MovementHorizontal(offsetLeft); 
            }
            else if (transform.position.x <= startPosition.x + offsetLeft)
            {
                hasReachedRight = false;
                hasReachedLeft = true;
            }
        }
    }
    void MovementHorizontal(float offset)
    {
        if (!hasReachedRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPosition.x + offset, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }

        if (!hasReachedLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPosition.x + offset, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
    }

    void MovementVertical(float offset)
    {
        if (!hasReachedUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPosition.x, transform.position.y + offset, transform.position.z), speed * Time.deltaTime);
        }

        if (!hasReachedDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPosition.x, transform.position.y + offset, transform.position.z), speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        
        float width = transform.localScale.x * meshWidth;
        float height = transform.localScale.y * meshHeight;

        float offsetNegX = startPosition.x - (width / 2) + offsetLeft;
        float offsetPosX = startPosition.x + (width / 2) + offsetRight;

        float offsetBottomPoint = startPosition.y + (height / 2);
        float offsetTopPoint = startPosition.y - (height / 2);

        float offsetTransformNegX = transform.position.x - (width / 2) + offsetLeft;
        float offsetTransformPosX = transform.position.x + (width / 2) + offsetRight;

        float offsetTransformTopPoint = transform.position.y + (height / 2);
        float offsetTransformBottomPoint = transform.position.y - (height / 2);

        //For Vertical

        float offsetNegY = startPosition.x - (width / 2);
        float offsetPosY = startPosition.x + (width / 2);

        float offsetBottomPointY = startPosition.y + (height / 2) + offsetUp;
        float offsetTopPointY = startPosition.y - (height / 2) + offsetDown;

        //Leftern Boundary
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(offsetNegX, offsetTopPoint, depthValue), 
                        new Vector3(offsetNegX, offsetBottomPoint, depthValue));
        //Rightern Boundary
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(offsetPosX, offsetTopPoint, depthValue), 
                        new Vector3(offsetPosX, offsetBottomPoint, depthValue));
        //Upper BoundaryVertical
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(new Vector3(offsetNegY, offsetBottomPointY, depthValue),
                        new Vector3(offsetPosY, offsetBottomPointY, depthValue));
        //Lower BoundaryVertical
        Gizmos.color = Color.black;
        Gizmos.DrawLine(new Vector3(offsetNegY, offsetTopPointY, depthValue),
                        new Vector3(offsetPosY, offsetTopPointY, depthValue));

        //Boundaries - moving with object
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(offsetTransformNegX, offsetTransformBottomPoint, depthValue), 
                        new Vector3(offsetTransformNegX, offsetTransformTopPoint, depthValue));

        Gizmos.DrawLine(new Vector3(offsetTransformPosX, offsetTransformBottomPoint, depthValue), 
                        new Vector3(offsetTransformPosX, offsetTransformTopPoint, depthValue));

    }
}
