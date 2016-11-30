using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface {


    public Text P1;
    public Text P2;

	private int[] jump, swipeleft, swiperight, swipeup, swipedown, raiseright, raiseleft;

	void Awake(){
		jump = new int[2]; jump [0] = 0; jump [1] = 0;
		swipeleft = new int[2]; swipeleft [0] = 0; swipeleft [1] = 0;
		swiperight = new int[2]; swiperight [0] = 0; swiperight [1] = 0;
		swipeup = new int[2]; swipeup [0] = 0; swipeup [1] = 0;
		swipedown = new int[2]; swipedown [0] = 0; swipedown [1] = 0;
		raiseright = new int[2]; raiseright [0] = 0; raiseright [1] = 0;
		raiseleft = new int[2]; raiseleft [0] = 0; raiseleft [1] = 0;
	}

	public bool IsRaiseRight(int inp){
		if(raiseright[inp]>0){
			raiseright[inp] -= 1;
			return true;
		}
		return false;
	}

	public bool IsRaiseLeft(int inp){
		if(raiseleft[inp]>0){
			raiseleft[inp] -= 1;
			return true;
		}
		return false;
	}

	public bool IsJump(int inp){
		if(jump[inp]>0){
			jump[inp] -= 1;
			return true;
		}
		return false;
	}

	public bool IsSwipeLeft(int inp){
		if(swipeleft[inp]>0){
			swipeleft[inp] -= 1;
			return true;
		}
		return false;
	}

	public bool IsSwipeRight(int inp){
		if(swiperight[inp]>0){
			swiperight[inp] -= 1;
			return true;
		}
		return false;
	}

	public bool IsSwipeUp(int inp){
		if(swipeup[inp]>0){
			swipeup[inp] -= 1;
			return true;
		}
		return false;
	}

	public bool IsSwipeDown(int inp){
		if(swipedown[inp]>0){
			swipedown[inp] -= 1;
			return true;
		}
		return false;
	}

	public void UserDetected(uint userId, int userIndex)
	{
		KinectManager manager = KinectManager.Instance;

		manager.DetectGesture(userId, KinectGestures.Gestures.Jump);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeLeft);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeRight);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeUp);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeDown);
		manager.DetectGesture(userId, KinectGestures.Gestures.RaiseRightHand);
		manager.DetectGesture(userId, KinectGestures.Gestures.RaiseLeftHand);

        if (userIndex == 0)
        {
            P1.text = "Player 1 Detected!";
        }

        if (userIndex == 1)
        {
            P2.text = "Player 2 Detected!";
            StartCoroutine(GoToCharacterSelect());
        }
	}

	public void UserLost(uint userId, int userIndex)
	{
		
	}

	public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture, 
		float progress, KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		
	}

	public bool GestureCompleted (uint userId, int userIndex, KinectGestures.Gestures gesture, 
		KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		if(gesture == KinectGestures.Gestures.Jump){
			jump[userIndex] += 1;
		}else if(gesture == KinectGestures.Gestures.SwipeUp){
			swipeup[userIndex] += 1;
		}else if(gesture == KinectGestures.Gestures.SwipeDown){
			swipedown[userIndex] += 1;
		}else if(gesture == KinectGestures.Gestures.SwipeRight){
			swiperight[userIndex] += 1;
		}else if(gesture == KinectGestures.Gestures.SwipeLeft){
			swipeleft[userIndex] += 1;
		}

		return true;
	}

	public bool GestureCancelled (uint userId, int userIndex, KinectGestures.Gestures gesture, 
		KinectWrapper.NuiSkeletonPositionIndex joint)
	{
		
		return true;
	}


    IEnumerator GoToCharacterSelect() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("CharacterSelect");
    }

}
