using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

public class AdManager : MonoBehaviour {

	public static AdManager instance;

	private const string bannerAndroidID = "ca-app-pub-3195792212242031/8197067106";
	private const string banneriOSID = "ca-app-pub-3195792212242031/3627266707";
	private const string interstitialAndroidID = "ca-app-pub-3195792212242031/9673800304";
	private const string interstitialiOSID = "ca-app-pub-3195792212242031/6580733104";

	void Awake(){
		MakeSingleton();
	}

	void MakeSingleton(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void Start(){
		#if UNITY_ANDROID
		Admob.Instance().initAdmob(bannerAndroidID, interstitialAndroidID);
		Admob.Instance().loadInterstitial();
		#elif UNITY_IOS
		Admob.Instance().initAdmob(banneriOSID, interstitialiOSID);
		Admob.Instance().loadInterstitial();
		#endif
	}

	public void ShowBanner(){
		Admob.Instance ().showBannerRelative (AdSize.Banner, AdPosition.TOP_CENTER, 5);
	}

	public void ShowInterstitial(){
		if (Admob.Instance ().isInterstitialReady ()) {
			Admob.Instance ().showInterstitial ();
		}
	}
}
