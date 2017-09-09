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

        /// <summary>
        /// This function translates objects from its current position forever in a specific direction.
        /// </summary>
        /// <param name="objectToTransform">The object you would like to transform</param>
        /// <param name="direction">The direction the object should be moved in</param>
        /// <param name="step">How many steps should the object take</param>
        /// <param name="speed">The travel speed the object should take</param>
        public static void translateOverLine(GameObject objectToTransform, Vector3 direction, float step, float speed)
        {
            if ((direction.x - objectToTransform.transform.position.x != 0) && (direction.y - objectToTransform.transform.position.y != 0))
            {
                //Calculate Slope => (y1-y2)/(x1-x2)
                slope = (objectToTransform.transform.position.y - direction.y) / (objectToTransform.transform.position.x - direction.x);

                //For debug
                //print("Slope: " + slope);

                //Calculate Y Intercept => y1-x1*m
                yintercept = objectToTransform.transform.position.y - (objectToTransform.transform.position.x * slope);

                //For Debug
                //print("Y Intercept: " + yintercept);

                //Next X
                if (direction.x > 0)
                    nextX = objectToTransform.transform.position.x + step;
                else
                    nextX = objectToTransform.transform.position.x - step;

                //For debug
                //print("Next X is: " + nextX);

                //Calculate next Y
                nextY = (slope * nextX) + yintercept;

                //For debug
                //print("Next y is: " + nextY);

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

        /// <summary>
        /// Same as translateOverLine() but this function uses fixedDeltaTime()
        /// </summary>
        /// <param name="objectToTransform">The object you would like to transform</param>
        /// <param name="direction">The direction the object should be moved in</param>
        /// <param name="step">How many steps should the object take</param>
        /// <param name="speed">The travel speed the object should take</param>
        public static void translateOverLine2(GameObject objectToTransform, Vector3 direction, float step, float speed)
        {
            if ((direction.x - objectToTransform.transform.position.x != 0) && (direction.y - objectToTransform.transform.position.y != 0))
            {
                //Calculate Slope => (y1-y2)/(x1-x2)
                slope = (objectToTransform.transform.position.y - direction.y) / (objectToTransform.transform.position.x - direction.x);

                //For debug
                //print("Slope: " + slope);

                //Calculate Y Intercept => y1-x1*m
                yintercept = objectToTransform.transform.position.y - (objectToTransform.transform.position.x * slope);

                //For Debug
                //print("Y Intercept: " + yintercept);

                //Next X
                if (direction.x > 0)
                    nextX = objectToTransform.transform.position.x + step;
                else
                    nextX = objectToTransform.transform.position.x - step;

                //For debug
                //print("Next X is: " + nextX);

                //Calculate next Y
                nextY = (slope * nextX) + yintercept;

                //For debug
                //print("Next y is: " + nextY);

                //Move
                objectToTransform.transform.position = Vector3.MoveTowards(objectToTransform.transform.position, new Vector3(nextX, nextY, 0), speed * Time.fixedDeltaTime);
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

                        objectToTransform.transform.position = Vector3.MoveTowards(objectToTransform.transform.position, new Vector3(objectToTransform.transform.position.x, nextY, 0), speed * Time.fixedDeltaTime);
                    }
                    else if (direction.y < 0)
                    {
                        nextY = objectToTransform.transform.position.y - step;

                        objectToTransform.transform.position = Vector3.MoveTowards(objectToTransform.transform.position, new Vector3(objectToTransform.transform.position.x, nextY, 0), speed * Time.fixedDeltaTime);
                    }

                }
                else if (direction.y - objectToTransform.transform.position.y == 0)
                {
                    if (direction.x > 0)
                    {
                        nextX = objectToTransform.transform.position.x + step;

                        objectToTransform.transform.position = Vector3.MoveTowards(objectToTransform.transform.position, new Vector3(nextX, objectToTransform.transform.position.y, 0), speed * Time.fixedDeltaTime);
                    }
                    else if (direction.y < 0)
                    {
                        nextX = objectToTransform.transform.position.x - step;

                        objectToTransform.transform.position = Vector3.MoveTowards(objectToTransform.transform.position, new Vector3(nextX, objectToTransform.transform.position.y, 0), speed * Time.fixedDeltaTime);
                    }

                }
            }
        }

        /// <summary>
        /// Returns distance between pos1 and pos2 in a float format.
        /// </summary>
        /// <param name="pos1">Distance of the first 2D vector</param>
        /// <param name="pos2">Distance of the second 2D vector</param>
        /// <returns></returns>
        public static float getDistance(Vector2 pos1, Vector2 pos2)
        {
            float result = -1;

            float term1 = pos2.x - pos1.x;
            float term2 = pos2.y - pos1.y;

            result = Mathf.Sqrt(Mathf.Pow(term1, 2) + Mathf.Pow(term2, 2));

            return result;
        }
    }
}
