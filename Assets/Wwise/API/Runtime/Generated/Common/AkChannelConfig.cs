#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (https://www.swig.org).
// Version 4.2.1
//
// Do not make changes to this file unless you know what you are doing - modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class AkChannelConfig : global::System.IDisposable {
  private global::System.IntPtr swigCPtr;
  protected bool swigCMemOwn;

  internal AkChannelConfig(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  internal static global::System.IntPtr getCPtr(AkChannelConfig obj) {
    return (obj == null) ? global::System.IntPtr.Zero : obj.swigCPtr;
  }

  internal virtual void setCPtr(global::System.IntPtr cPtr) {
    Dispose();
    swigCPtr = cPtr;
  }

  ~AkChannelConfig() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkUnitySoundEnginePINVOKE.CSharp_delete_AkChannelConfig(swigCPtr);
        }
        swigCPtr = global::System.IntPtr.Zero;
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public uint uNumChannels { set { AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_uNumChannels_set(swigCPtr, value); }  get { return AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_uNumChannels_get(swigCPtr); } 
  }

  public uint eConfigType { set { AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_eConfigType_set(swigCPtr, value); }  get { return AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_eConfigType_get(swigCPtr); } 
  }

  public uint uChannelMask { set { AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_uChannelMask_set(swigCPtr, value); }  get { return AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_uChannelMask_get(swigCPtr); } 
  }

  public static AkChannelConfig Standard(uint in_uChannelMask) {
    AkChannelConfig ret = new AkChannelConfig(AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_Standard(in_uChannelMask), true);
    return ret;
  }

  public static AkChannelConfig Anonymous(uint in_uNumChannels) {
    AkChannelConfig ret = new AkChannelConfig(AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_Anonymous(in_uNumChannels), true);
    return ret;
  }

  public static AkChannelConfig Ambisonic(uint in_uNumChannels) {
    AkChannelConfig ret = new AkChannelConfig(AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_Ambisonic(in_uNumChannels), true);
    return ret;
  }

  public static AkChannelConfig Object() {
    AkChannelConfig ret = new AkChannelConfig(AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_Object(), true);
    return ret;
  }

  public AkChannelConfig() : this(AkUnitySoundEnginePINVOKE.CSharp_new_AkChannelConfig__SWIG_0(), true) {
  }

  public AkChannelConfig(uint in_uNumChannels, uint in_uChannelMask) : this(AkUnitySoundEnginePINVOKE.CSharp_new_AkChannelConfig__SWIG_1(in_uNumChannels, in_uChannelMask), true) {
  }

  public void Clear() { AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_Clear(swigCPtr); }

  public void SetStandard(uint in_uChannelMask) { AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_SetStandard(swigCPtr, in_uChannelMask); }

  public void SetStandardOrAnonymous(uint in_uNumChannels, uint in_uChannelMask) { AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_SetStandardOrAnonymous(swigCPtr, in_uNumChannels, in_uChannelMask); }

  public void SetAnonymous(uint in_uNumChannels) { AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_SetAnonymous(swigCPtr, in_uNumChannels); }

  public void SetAmbisonic(uint in_uNumChannels) { AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_SetAmbisonic(swigCPtr, in_uNumChannels); }

  public void SetObject() { AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_SetObject(swigCPtr); }

  public void SetSameAsMainMix() { AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_SetSameAsMainMix(swigCPtr); }

  public void SetSameAsPassthrough() { AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_SetSameAsPassthrough(swigCPtr); }

  public bool IsValid() { return AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_IsValid(swigCPtr); }

  public uint Serialize() { return AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_Serialize(swigCPtr); }

  public void Deserialize(uint in_uChannelConfig) { AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_Deserialize(swigCPtr, in_uChannelConfig); }

  public AkChannelConfig RemoveLFE() {
    AkChannelConfig ret = new AkChannelConfig(AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_RemoveLFE(swigCPtr), true);
    return ret;
  }

  public AkChannelConfig RemoveCenter() {
    AkChannelConfig ret = new AkChannelConfig(AkUnitySoundEnginePINVOKE.CSharp_AkChannelConfig_RemoveCenter(swigCPtr), true);
    return ret;
  }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.