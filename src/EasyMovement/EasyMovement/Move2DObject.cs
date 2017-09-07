/*
 *                                      Muhand Jumah
 *                                EasyMovement - Move2DObject
 * This is a unity library which controls movements of objects with ease. Check examples folder for demos.
 * Github: https://github.com/Muhand/EasyMovement
 *                                          © 2017
 */
using UnityEngine;

namespace EasyMovement
{
    public class Move2DObject : MonoBehaviour
    {
        private static float slope;
        private static float yintercept;
        private static float nextY;
        private static float nextX;

        public static void translateOverLine(GameObject objectToTransform, Vector3 direction, float step, float speed)
        {
            if ((direction.x - objectToTransform.transform.position.x != 0) && (direction.y - objectToTransform.transform.position.y != 0))
            {
                //Calculate Slope => (y1-y2)/(x1-x2)
                slope = (objectToTransform.transform.position.y - direction.y) / (objectToTransform.transform.position.x - direction.x);
                print("Slope: " + slope);

                //Calculate Y Intercept => y1-x1*m
                yintercept = objectToTransform.transform.position.y - (objectToTransform.transform.position.x * slope);
                print("Y Intercept: " + yintercept);

                //Next X
                if (direction.x > 0)
                    nextX = objectToTransform.transform.position.x + step;
                else
                    nextX = objectToTransform.transform.position.x - step;

                print("Next X is: " + nextX);

                //Calculate next Y
                nextY = (slope * nextX) + yintercept;
                print("Next y is: " + nextY);

                //Move
                objectToTransform.transform.position = Vector3.MoveTowards(objectToTransform.transform.position, new Vector3(nextX, nextY, 0), speed * Time.deltaTime);
            }
            else
            {
                if ((direction.x - objectToTransform.transform.position.x == 0) && (direction.y - objectToTransform.transform.position.y == 0))
                {
                    //We are at the same position as the objective, therefore just return
                    return;
                }
                if (direction.x - objectToTransform.transform.position.x == 0)
                {
                    //If difference in X is 0 then we are at the same x point so we are moving vertically; therefore just move up or down depending on target's Y

                    if (direction.y > 0)
                    {
                        nextY = objectToTransform.transform.position.y + step;

                        objectToTransform.transform.position = Vector3.MoveTowards(objectToTransform.transform.position, new Vector3(objectToTransform.transform.position.x, nextY, 0), speed * Time.deltaTime);
                    }
                    else if (direction.y < 0)
                    {
                        nextY = objectToTransform.transform.position.y - step;

                        objectToTransform.transform.position = Vector3.MoveTowards(objectToTransform.transform.position, new Vector3(objectToTransform.transform.position.x, nextY, 0), speed * Time.deltaTime);
                    }

                }
                else if (direction.y - objectToTransform.transform.position.y == 0)
                {
                    if (direction.x > 0)
                    {
                        nextX = objectToTransform.transform.position.x + step;

                        objectToTransform.transform.position = Vector3.MoveTowards(objectToTransform.transform.position, new Vector3(nextX, objectToTransform.transform.position.y, 0), speed * Time.deltaTime);
                    }
                    else if (direction.y < 0)
                    {
                        nextX = objectToTransform.transform.position.x - step;

                        objectToTransform.transform.position = Vector3.MoveTowards(objectToTransform.transform.position, new Vector3(nextX, objectToTransform.transform.position.y, 0), speed * Time.deltaTime);
                    }

                }
            }
        }
    }
}
