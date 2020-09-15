using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

namespace Tests
{
    public class TestSuite
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestSuiteSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        [UnityTest] // Test to see if note's move when spawned
        public IEnumerator NoteMovementTest() // Unit Test Example by James
        {
            var root = new GameObject();
            root.AddComponent<Camera>();

            var Camera = root.GetComponent<Camera>();

            GameObject note1 = Resources.Load<GameObject>("Prefabs/Note1");
            GameObject note2 = Resources.Load<GameObject>("Prefabs/Note2");
            GameObject note3 = Resources.Load<GameObject>("Prefabs/Note3");
            note1 = GameObject.Instantiate(note1, new Vector3(-2, 0, 10), new Quaternion(0, 180, 0, 0));
            note2 = GameObject.Instantiate(note2, new Vector3(0, 0, 10), new Quaternion(0, 180, 0, 0));
            note3 = GameObject.Instantiate(note3, new Vector3(2, 0, 10), new Quaternion(0, 180, 0, 0));

            float initalZPos1 = note1.transform.position.z;
            float initalZPos2 = note2.transform.position.z;
            float initalZPos3 = note3.transform.position.z;

            yield return new WaitForSeconds(0.1f);

            Assert.GreaterOrEqual(note1.transform.position.z, initalZPos1);
            Assert.GreaterOrEqual(note2.transform.position.z, initalZPos2);
            Assert.GreaterOrEqual(note3.transform.position.z, initalZPos3);
            GameObject.Destroy(note1);
            GameObject.Destroy(note2);
            GameObject.Destroy(note3);
            GameObject.Destroy(root);
        }

        [UnityTest]
        public IEnumerator ObstacleSpawnTest() // Unit Test by James 
        {
            var root = new GameObject();
            root.AddComponent<Camera>();

            var Camera = root.GetComponent<Camera>();

            GameObject spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Spawner"));
            bool obstacleSpawns = false;

            yield return new WaitForSeconds(10f);
            
            if (GameObject.FindWithTag("Obstacle"))
            {
                obstacleSpawns = true;
            }

            Assert.IsTrue(obstacleSpawns);

            GameObject.Destroy(spawner);

            GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

            foreach (GameObject note in notes)
            {
                GameObject.Destroy(note);
            }

            foreach (GameObject obstacle in obstacles)
            {
                GameObject.Destroy(obstacle);
            }


        }

       

        [UnityTest]
        public IEnumerator ObstacleCollisionTest() // Unit Test by James
        {

            GameObject player = Resources.Load<GameObject>("Prefabs/player");
            GameObject obstacle = Resources.Load<GameObject>("Prefabs/Spike");
            player = GameObject.Instantiate(player, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            obstacle = GameObject.Instantiate(obstacle, new Vector3(0, 0, 20), new Quaternion(0, 0, 0, 0));

            var expectedNoteStreak = 0;
            var currentNoteStreak = 2;
            yield return new WaitForSeconds(1.2f);

            // On obstacle collision, reset note streak

            Assert.AreEqual(currentNoteStreak, expectedNoteStreak);

            


        }



    }
}
