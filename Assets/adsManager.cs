using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class adsManager : MonoBehaviour {
	private BannerView bannerView;
	// Use this for initialization
	void Start () {
		#if UNITY_ANDROID
		string appId = "ca-app-pub-6758883431877672~7382237208";
		#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
        #else
            string appId = "unexpected_platform";
        #endif

		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize(appId);
		this.RequestBanner(); 
		
	}

	private void RequestBanner()
	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-6758883431877672/8016839638";
		#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
            string adUnitId = "unexpected_platform";
        #endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
		AdRequest request = new AdRequest.Builder().Build();
		bannerView.LoadAd(request);
	}
}
