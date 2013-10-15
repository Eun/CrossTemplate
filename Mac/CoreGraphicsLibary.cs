using System;
using System.Runtime.InteropServices;

namespace CrossTemplate.Mac
{
	// Sample Class for Calling Native Functions in Mac
	public class CoreGraphicsLibary
	{
		public enum CGEventField : uint {
			kCGMouseEventNumber = 0,
			kCGMouseEventClickState = 1,
			kCGMouseEventPressure = 2,
			kCGMouseEventButtonNumber = 3,
			kCGMouseEventDeltaX = 4,
			kCGMouseEventDeltaY = 5,
			kCGMouseEventInstantMouser = 6,
			kCGMouseEventSubtype = 7,
			kCGKeyboardEventAutorepeat = 8,
			kCGKeyboardEventKeycode = 9,
			kCGKeyboardEventKeyboardType = 10,
			kCGScrollWheelEventDeltaAxis1 = 11,
			kCGScrollWheelEventDeltaAxis2 = 12,
			kCGScrollWheelEventDeltaAxis3 = 13,
			kCGScrollWheelEventFixedPtDeltaAxis1 = 93,
			kCGScrollWheelEventFixedPtDeltaAxis2 = 94,
			kCGScrollWheelEventFixedPtDeltaAxis3 = 95,
			kCGScrollWheelEventPointDeltaAxis1 = 96,
			kCGScrollWheelEventPointDeltaAxis2 = 97,
			kCGScrollWheelEventPointDeltaAxis3 = 98,
			kCGScrollWheelEventScrollPhase = 99,
			kCGScrollWheelEventInstantMouser = 14,
			kCGTabletEventPointX = 15,
			kCGTabletEventPointY = 16,
			kCGTabletEventPointZ = 17,
			kCGTabletEventPointButtons = 18,
			kCGTabletEventPointPressure = 19,
			kCGTabletEventTiltX = 20,
			kCGTabletEventTiltY = 21,
			kCGTabletEventRotation = 22,
			kCGTabletEventTangentialPressure = 23,
			kCGTabletEventDeviceID = 24,
			kCGTabletEventVendor1 = 25,
			kCGTabletEventVendor2 = 26,
			kCGTabletEventVendor3 = 27,
			kCGTabletProximityEventVendorID = 28,
			kCGTabletProximityEventTabletID = 29,
			kCGTabletProximityEventPointerID = 30,
			kCGTabletProximityEventDeviceID = 31,
			kCGTabletProximityEventSystemTabletID = 32,
			kCGTabletProximityEventVendorPointerType = 33,
			kCGTabletProximityEventVendorPointerSerialNumber = 34,
			kCGTabletProximityEventVendorUniqueID = 35,
			kCGTabletProximityEventCapabilityMask = 36,
			kCGTabletProximityEventPointerType = 37,
			kCGTabletProximityEventEnterProximity = 38,
			kCGEventTargetProcessSerialNumber = 39,
			kCGEventTargetUnixProcessID = 40,
			kCGEventSourceUnixProcessID = 41,
			kCGEventSourceUserData = 42,
			kCGEventSourceUserID = 43,
			kCGEventSourceGroupID = 44,
			kCGEventSourceStateID = 45,
			kCGScrollWheelEventIsContinuous = 88,
			kCGMouseEventWindowUnderMousePointer = 91,
			kCGMouseEventWindowUnderMousePointerThatCanHandleThisEvent = 92
		};
		
		[DllImport(MonoMac.Constants.CoreGraphicsLibrary)]
		public static extern Int64 CGEventGetIntegerValueField(IntPtr e, CGEventField field);
	}
}

