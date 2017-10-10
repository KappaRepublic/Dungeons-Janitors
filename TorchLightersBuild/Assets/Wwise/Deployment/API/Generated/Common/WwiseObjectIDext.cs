#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.11
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

public class WwiseObjectIDext : IDisposable {
  private IntPtr swigCPtr;
  protected bool swigCMemOwn;

  internal WwiseObjectIDext(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  internal static IntPtr getCPtr(WwiseObjectIDext obj) {
    return (obj == null) ? IntPtr.Zero : obj.swigCPtr;
  }

  ~WwiseObjectIDext() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_WwiseObjectIDext(swigCPtr);
        }
        swigCPtr = IntPtr.Zero;
      }
      GC.SuppressFinalize(this);
    }
  }

  public bool IsEqualTo(WwiseObjectIDext in_rOther) {
    bool ret = AkSoundEnginePINVOKE.CSharp_WwiseObjectIDext_IsEqualTo(swigCPtr, WwiseObjectIDext.getCPtr(in_rOther));

    return ret;
  }

  public AkNodeType GetNodeType() {
    AkNodeType ret = (AkNodeType)AkSoundEnginePINVOKE.CSharp_WwiseObjectIDext_GetNodeType(swigCPtr);
    return ret;
  }

  public uint id {
    set {
      AkSoundEnginePINVOKE.CSharp_WwiseObjectIDext_id_set(swigCPtr, value);
    } 
    get {
      uint ret = AkSoundEnginePINVOKE.CSharp_WwiseObjectIDext_id_get(swigCPtr);
      return ret;
    } 
  }

  public bool bIsBus {
    set {
      AkSoundEnginePINVOKE.CSharp_WwiseObjectIDext_bIsBus_set(swigCPtr, value);
    } 
    get {
      bool ret = AkSoundEnginePINVOKE.CSharp_WwiseObjectIDext_bIsBus_get(swigCPtr);
      return ret;
    } 
  }

  public WwiseObjectIDext() : this(AkSoundEnginePINVOKE.CSharp_new_WwiseObjectIDext(), true) {

  }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.