; ModuleID = 'obj\Release\81\android\marshal_methods.arm64-v8a.ll'
source_filename = "obj\Release\81\android\marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [40 x i64] [
	i64 120698629574877762, ; 0: Mono.Android => 0x1accec39cafe242 => 2
	i64 1000557547492888992, ; 1: Mono.Security.dll => 0xde2b1c9cba651a0 => 19
	i64 1134541750559356471, ; 2: RFHandheld => 0xfbeb3b608f0b637 => 0
	i64 1342439039765371018, ; 3: Xamarin.Android.Support.Fragment => 0x12a14d31b1d4d88a => 13
	i64 1425944114962822056, ; 4: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 17
	i64 1731380447121279447, ; 5: Newtonsoft.Json => 0x18071957e9b889d7 => 4
	i64 1744702963312407042, ; 6: Xamarin.Android.Support.v7.AppCompat => 0x18366e19eeceb202 => 14
	i64 2133195048986300728, ; 7: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 4
	i64 2592350477072141967, ; 8: System.Xml.dll => 0x23f9e10627330e8f => 8
	i64 2624866290265602282, ; 9: mscorlib.dll => 0x246d65fbde2db8ea => 3
	i64 3531994851595924923, ; 10: System.Numerics => 0x31042a9aade235bb => 16
	i64 5507995362134886206, ; 11: System.Core.dll => 0x4c705499688c873e => 5
	i64 6563858320129171762, ; 12: RFHandheld.dll => 0x5b17825d874aa132 => 0
	i64 6876862101832370452, ; 13: System.Xml.Linq => 0x5f6f85a57d108914 => 18
	i64 7488575175965059935, ; 14: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 18
	i64 7654504624184590948, ; 15: System.Net.Http => 0x6a3a4366801b8264 => 7
	i64 7820441508502274321, ; 16: System.Data => 0x6c87ca1e14ff8111 => 15
	i64 7879037620440914030, ; 17: Xamarin.Android.Support.v7.AppCompat.dll => 0x6d57f6f88a51d86e => 14
	i64 8167236081217502503, ; 18: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 1
	i64 8626175481042262068, ; 19: Java.Interop => 0x77b654e585b55834 => 1
	i64 9662334977499516867, ; 20: System.Numerics.dll => 0x8617827802b0cfc3 => 16
	i64 9808709177481450983, ; 21: Mono.Android.dll => 0x881f890734e555e7 => 2
	i64 9866412715007501892, ; 22: Xamarin.Android.Arch.Lifecycle.Common.dll => 0x88ec8a16fd6b6644 => 9
	i64 9998632235833408227, ; 23: Mono.Security => 0x8ac2470b209ebae3 => 19
	i64 10038780035334861115, ; 24: System.Net.Http.dll => 0x8b50e941206af13b => 7
	i64 11023048688141570732, ; 25: System.Core => 0x98f9bc61168392ac => 5
	i64 11037814507248023548, ; 26: System.Xml => 0x992e31d0412bf7fc => 8
	i64 11376461258732682436, ; 27: Xamarin.Android.Support.Compat => 0x9de14f3d5fc13cc4 => 10
	i64 12414299427252656003, ; 28: Xamarin.Android.Support.Compat.dll => 0xac48738e28bad783 => 10
	i64 12952608645614506925, ; 29: Xamarin.Android.Support.Core.Utils => 0xb3c0e8eff48193ad => 12
	i64 13358059602087096138, ; 30: Xamarin.Android.Support.Fragment.dll => 0xb9615c6f1ee5af4a => 13
	i64 13370592475155966277, ; 31: System.Runtime.Serialization => 0xb98de304062ea945 => 17
	i64 13647894001087880694, ; 32: System.Data.dll => 0xbd670f48cb071df6 => 15
	i64 14400856865250966808, ; 33: Xamarin.Android.Support.Core.UI => 0xc7da1f051a877d18 => 11
	i64 15609085926864131306, ; 34: System.dll => 0xd89e9cf3334914ea => 6
	i64 16154507427712707110, ; 35: System => 0xe03056ea4e39aa26 => 6
	i64 16833383113903931215, ; 36: mscorlib => 0xe99c30c1484d7f4f => 3
	i64 16932527889823454152, ; 37: Xamarin.Android.Support.Core.Utils.dll => 0xeafc6c67465253c8 => 12
	i64 17428701562824544279, ; 38: Xamarin.Android.Support.Core.UI.dll => 0xf1df2fbaec73d017 => 11
	i64 17760961058993581169 ; 39: Xamarin.Android.Arch.Lifecycle.Common => 0xf67b9bfb46dbac71 => 9
], align 8
@assembly_image_cache_indices = local_unnamed_addr constant [40 x i32] [
	i32 2, i32 19, i32 0, i32 13, i32 17, i32 4, i32 14, i32 4, ; 0..7
	i32 8, i32 3, i32 16, i32 5, i32 0, i32 18, i32 18, i32 7, ; 8..15
	i32 15, i32 14, i32 1, i32 1, i32 16, i32 2, i32 9, i32 19, ; 16..23
	i32 7, i32 5, i32 8, i32 10, i32 10, i32 12, i32 13, i32 17, ; 24..31
	i32 15, i32 11, i32 6, i32 6, i32 3, i32 12, i32 11, i32 9 ; 40..39
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="non-leaf" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2, !3, !4, !5}
!llvm.ident = !{!6}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"branch-target-enforcement", i32 0}
!3 = !{i32 1, !"sign-return-address", i32 0}
!4 = !{i32 1, !"sign-return-address-all", i32 0}
!5 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
!6 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
