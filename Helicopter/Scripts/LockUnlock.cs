using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Policy;
using UnityEngine.SceneManagement;

public class LockUnlock : MonoBehaviour
{

    public GUITexture stage1Unlocked;
    public GUITexture stage1Locked;
    public GUITexture stage2Unlocked;
    public GUITexture stage2Locked;
    public GUITexture stage3Unlocked;
    public GUITexture stage3Locked;
    public GUITexture stage4Unlocked;
    public GUITexture stage4Locked;
    public GUITexture stage5Unlocked;
    public GUITexture stage5Locked;
    
    void Update()
    {
        if (gameObject != null)

        {
            Destroy(gameObject);

        }

        if (SingleTon.getInstance.reached1 == 1)
        {
            stage1Unlocked.enabled = true;
            stage1Locked.enabled = false;
            stage1Unlocked.gameObject.SetActive(true);

            stage2Unlocked.enabled = true;
            stage2Locked.enabled = false;
            stage2Unlocked.gameObject.SetActive(true);
        }

        else if (SingleTon.getInstance.reached1 == 0)
        {
            stage1Unlocked.enabled = true;
            stage1Locked.enabled = false;
            stage1Unlocked.gameObject.SetActive(true);

            stage2Unlocked.enabled = false;
            stage2Locked.enabled = true;
            stage2Unlocked.gameObject.SetActive(false);
        }


        if (SingleTon.getInstance.reached2 == 2)
        {
            stage3Unlocked.enabled = true;
            stage3Locked.enabled = false;
            stage3Unlocked.gameObject.SetActive(true);
        }

        else if (SingleTon.getInstance.reached2 == 0)
        {
            stage3Unlocked.enabled = false;
            stage3Locked.enabled = true;
            stage3Unlocked.gameObject.SetActive(false);
        }


        if (SingleTon.getInstance.reached3 == 3)
        {
            stage4Unlocked.enabled = true;
            stage4Locked.enabled = false;
            stage4Unlocked.gameObject.SetActive(true);
        }

        else if (SingleTon.getInstance.reached3 == 0)
        {
            stage4Unlocked.enabled = false;
            stage4Locked.enabled = true;
            stage4Unlocked.gameObject.SetActive(false);
        }


        if (SingleTon.getInstance.reached4 == 4)
        {
            stage5Unlocked.enabled = true;
            stage5Locked.enabled = false;
            stage5Unlocked.gameObject.SetActive(true);
        }

        else if (SingleTon.getInstance.reached4 == 0)
        {
            stage5Unlocked.enabled = false;
            stage5Locked.enabled = true;
            stage5Unlocked.gameObject.SetActive(false);
        }
    }
}


