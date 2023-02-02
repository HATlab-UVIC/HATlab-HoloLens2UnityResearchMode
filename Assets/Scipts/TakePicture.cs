// using UnityEngine;
// using System.Collections;

// using System.Linq;
// using System;
// using System.IO;


// #if WINDOWS_UWP
// using Windows.Storage;
// #endif 

// public class TakePicture : MonoBehaviour {

//     UnityEngine.Windows.WebCam.PhotoCapture photoCaptureObject = null;

//     // Use this for initialization
//     public void BeginPicture()
//     {
//         UnityEngine.Windows.WebCam.PhotoCapture.CreateAsync(false, OnPhotoCaptureCreated);
//     }

//     void OnPhotoCaptureCreated(UnityEngine.Windows.WebCam.PhotoCapture captureObject)
//     {
//         photoCaptureObject = captureObject;

//         Resolution cameraResolution = UnityEngine.Windows.WebCam.PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();

//         UnityEngine.Windows.WebCam.CameraParameters c = new UnityEngine.Windows.WebCam.CameraParameters();
//         c.hologramOpacity = 0.0f;
//         c.cameraResolutionWidth = cameraResolution.width;
//         c.cameraResolutionHeight = cameraResolution.height;
//         c.pixelFormat = UnityEngine.Windows.WebCam.CapturePixelFormat.BGRA32;

//         captureObject.StartPhotoModeAsync(c, OnPhotoModeStarted);
//     }

//     void OnStoppedPhotoMode(UnityEngine.Windows.WebCam.PhotoCapture.PhotoCaptureResult result)
//     {
//         photoCaptureObject.Dispose();
//         photoCaptureObject = null;
//     }

//     public string getPathPIC()
//     {
//         #if WINDOWS_UWP
//             string path = Application.persistentDataPath + "/PICTURES/";
//             string path1 = Application.persistentDataPath + "/PICTURES";
//             if (!Directory.Exists(path1)) Directory.CreateDirectory(path1);
//             if (!Directory.Exists(path)) Directory.CreateDirectory(path);
//             return path;
//         #endif

//         return null;
//     }

//     private void OnPhotoModeStarted(UnityEngine.Windows.WebCam.PhotoCapture.PhotoCaptureResult result)
//     {
//         if (result.success)
//         {
//             string filename = string.Format(@"CapturedImage{0}_n.jpg", Time.time);
//             string filePath = System.IO.Path.Combine(Application.persistentDataPath, filename);

//             photoCaptureObject.TakePhotoAsync(filePath, UnityEngine.Windows.WebCam.PhotoCaptureFileOutputFormat.JPG, OnCapturedPhotoToDisk);
//         }
//         else
//         {
//             Debug.LogError("Unable to start photo mode!");
//         }
//     }

//     void OnCapturedPhotoToDisk(UnityEngine.Windows.WebCam.PhotoCapture.PhotoCaptureResult result)
//     {
//         if (result.success)
//         {
//             Debug.Log("Saved Photo to disk!");
//             photoCaptureObject.StopPhotoModeAsync(OnStoppedPhotoMode);
//         }
//         else
//         {
//             Debug.Log("Failed to save Photo to disk");
//         }
//     }
// }