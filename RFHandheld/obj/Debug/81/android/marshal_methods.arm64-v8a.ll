; ModuleID = 'obj\Debug\81\android\marshal_methods.arm64-v8a.ll'
source_filename = "obj\Debug\81\android\marshal_methods.arm64-v8a.ll"
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
@assembly_image_cache_hashes = local_unnamed_addr constant [78 x i64] [
	i64 120698629574877762, ; 0: Mono.Android => 0x1accec39cafe242 => 2
	i64 702024105029695270, ; 1: System.Drawing.Common => 0x9be17343c0e7726 => 25
	i64 940822596282819491, ; 2: System.Transactions => 0xd0e792aa81923a3 => 29
	i64 1000557547492888992, ; 3: Mono.Security.dll => 0xde2b1c9cba651a0 => 38
	i64 1134541750559356471, ; 4: RFHandheld => 0xfbeb3b608f0b637 => 0
	i64 1342439039765371018, ; 5: Xamarin.Android.Support.Fragment => 0x12a14d31b1d4d88a => 19
	i64 1425944114962822056, ; 6: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 34
	i64 1731380447121279447, ; 7: Newtonsoft.Json => 0x18071957e9b889d7 => 4
	i64 1744702963312407042, ; 8: Xamarin.Android.Support.v7.AppCompat => 0x18366e19eeceb202 => 22
	i64 1860886102525309849, ; 9: Xamarin.Android.Support.v7.RecyclerView.dll => 0x19d3320d047b7399 => 23
	i64 2133195048986300728, ; 10: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 4
	i64 2284400282711631002, ; 11: System.Web.Services => 0x1fb3d1f42fd4249a => 36
	i64 2497223385847772520, ; 12: System.Runtime => 0x22a7eb7046413568 => 8
	i64 2592350477072141967, ; 13: System.Xml.dll => 0x23f9e10627330e8f => 9
	i64 2624866290265602282, ; 14: mscorlib.dll => 0x246d65fbde2db8ea => 3
	i64 3022227708164871115, ; 15: Xamarin.Android.Support.Media.Compat.dll => 0x29f11c168f8293cb => 20
	i64 3531994851595924923, ; 16: System.Numerics => 0x31042a9aade235bb => 28
	i64 3571415421602489686, ; 17: System.Runtime.dll => 0x319037675df7e556 => 8
	i64 3716579019761409177, ; 18: netstandard.dll => 0x3393f0ed5c8c5c99 => 26
	i64 4264996749430196783, ; 19: Xamarin.Android.Support.Transition.dll => 0x3b304ff259fb8a2f => 21
	i64 4525561845656915374, ; 20: System.ServiceModel.Internals => 0x3ece06856b710dae => 35
	i64 5439315836349573567, ; 21: Xamarin.Android.Support.Animated.Vector.Drawable.dll => 0x4b7c54ef36c5e9bf => 13
	i64 5507995362134886206, ; 22: System.Core.dll => 0x4c705499688c873e => 5
	i64 5767696078500135884, ; 23: Xamarin.Android.Support.Annotations.dll => 0x500af9065b6a03cc => 14
	i64 6405879832841858445, ; 24: Xamarin.Android.Support.Vector.Drawable.dll => 0x58e641c4a660ad8d => 24
	i64 6563858320129171762, ; 25: RFHandheld.dll => 0x5b17825d874aa132 => 0
	i64 6591024623626361694, ; 26: System.Web.Services.dll => 0x5b7805f9751a1b5e => 36
	i64 6876862101832370452, ; 27: System.Xml.Linq => 0x5f6f85a57d108914 => 37
	i64 7488575175965059935, ; 28: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 37
	i64 7654504624184590948, ; 29: System.Net.Http => 0x6a3a4366801b8264 => 7
	i64 7820441508502274321, ; 30: System.Data => 0x6c87ca1e14ff8111 => 27
	i64 7879037620440914030, ; 31: Xamarin.Android.Support.v7.AppCompat.dll => 0x6d57f6f88a51d86e => 22
	i64 8044118961405839122, ; 32: System.ComponentModel.Composition => 0x6fa2739369944712 => 33
	i64 8101777744205214367, ; 33: Xamarin.Android.Support.Annotations => 0x706f4beeec84729f => 14
	i64 8103644804370223335, ; 34: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 30
	i64 8167236081217502503, ; 35: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 1
	i64 8385935383968044654, ; 36: Xamarin.Android.Arch.Lifecycle.Runtime.dll => 0x7460d3cd16cb566e => 12
	i64 8626175481042262068, ; 37: Java.Interop => 0x77b654e585b55834 => 1
	i64 8684531736582871431, ; 38: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 32
	i64 9475595603812259686, ; 39: Xamarin.Android.Support.Design => 0x838013ff707b9766 => 18
	i64 9662334977499516867, ; 40: System.Numerics.dll => 0x8617827802b0cfc3 => 28
	i64 9808709177481450983, ; 41: Mono.Android.dll => 0x881f890734e555e7 => 2
	i64 9834056768316610435, ; 42: System.Transactions.dll => 0x8879968718899783 => 29
	i64 9866412715007501892, ; 43: Xamarin.Android.Arch.Lifecycle.Common.dll => 0x88ec8a16fd6b6644 => 11
	i64 9998632235833408227, ; 44: Mono.Security => 0x8ac2470b209ebae3 => 38
	i64 10038780035334861115, ; 45: System.Net.Http.dll => 0x8b50e941206af13b => 7
	i64 10850923258212604222, ; 46: Xamarin.Android.Arch.Lifecycle.Runtime => 0x9696393672c9593e => 12
	i64 11023048688141570732, ; 47: System.Core => 0x98f9bc61168392ac => 5
	i64 11037814507248023548, ; 48: System.Xml => 0x992e31d0412bf7fc => 9
	i64 11376461258732682436, ; 49: Xamarin.Android.Support.Compat => 0x9de14f3d5fc13cc4 => 15
	i64 11597940890313164233, ; 50: netstandard => 0xa0f429ca8d1805c9 => 26
	i64 12414299427252656003, ; 51: Xamarin.Android.Support.Compat.dll => 0xac48738e28bad783 => 15
	i64 12550732019250633519, ; 52: System.IO.Compression => 0xae2d28465e8e1b2f => 31
	i64 12952608645614506925, ; 53: Xamarin.Android.Support.Core.Utils => 0xb3c0e8eff48193ad => 17
	i64 12963446364377008305, ; 54: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 25
	i64 13358059602087096138, ; 55: Xamarin.Android.Support.Fragment.dll => 0xb9615c6f1ee5af4a => 19
	i64 13370592475155966277, ; 56: System.Runtime.Serialization => 0xb98de304062ea945 => 34
	i64 13647894001087880694, ; 57: System.Data.dll => 0xbd670f48cb071df6 => 27
	i64 14369828458497533121, ; 58: Xamarin.Android.Support.Vector.Drawable => 0xc76be2d9300b64c1 => 24
	i64 14400856865250966808, ; 59: Xamarin.Android.Support.Core.UI => 0xc7da1f051a877d18 => 16
	i64 14987728460634540364, ; 60: System.IO.Compression.dll => 0xcfff1ba06622494c => 31
	i64 15188640517174936311, ; 61: Xamarin.Android.Arch.Core.Common => 0xd2c8e413d75142f7 => 10
	i64 15246441518555807158, ; 62: Xamarin.Android.Arch.Core.Common.dll => 0xd3963dc832493db6 => 10
	i64 15418891414777631748, ; 63: Xamarin.Android.Support.Transition => 0xd5fae80c88241404 => 21
	i64 15457813392950723921, ; 64: Xamarin.Android.Support.Media.Compat => 0xd6852f61c31a8551 => 20
	i64 15609085926864131306, ; 65: System.dll => 0xd89e9cf3334914ea => 6
	i64 16154507427712707110, ; 66: System => 0xe03056ea4e39aa26 => 6
	i64 16565028646146589191, ; 67: System.ComponentModel.Composition.dll => 0xe5e2cdc9d3bcc207 => 33
	i64 16822611501064131242, ; 68: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 30
	i64 16833383113903931215, ; 69: mscorlib => 0xe99c30c1484d7f4f => 3
	i64 16932527889823454152, ; 70: Xamarin.Android.Support.Core.Utils.dll => 0xeafc6c67465253c8 => 17
	i64 17009591894298689098, ; 71: Xamarin.Android.Support.Animated.Vector.Drawable => 0xec0e35b50a097e4a => 13
	i64 17428701562824544279, ; 72: Xamarin.Android.Support.Core.UI.dll => 0xf1df2fbaec73d017 => 16
	i64 17760961058993581169, ; 73: Xamarin.Android.Arch.Lifecycle.Common => 0xf67b9bfb46dbac71 => 11
	i64 17928294245072900555, ; 74: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 32
	i64 17936749993673010118, ; 75: Xamarin.Android.Support.Design.dll => 0xf8ec231615deabc6 => 18
	i64 18090425465832348288, ; 76: Xamarin.Android.Support.v7.RecyclerView => 0xfb0e1a1d2e9e1a80 => 23
	i64 18129453464017766560 ; 77: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 35
], align 8
@assembly_image_cache_indices = local_unnamed_addr constant [78 x i32] [
	i32 2, i32 25, i32 29, i32 38, i32 0, i32 19, i32 34, i32 4, ; 0..7
	i32 22, i32 23, i32 4, i32 36, i32 8, i32 9, i32 3, i32 20, ; 8..15
	i32 28, i32 8, i32 26, i32 21, i32 35, i32 13, i32 5, i32 14, ; 16..23
	i32 24, i32 0, i32 36, i32 37, i32 37, i32 7, i32 27, i32 22, ; 24..31
	i32 33, i32 14, i32 30, i32 1, i32 12, i32 1, i32 32, i32 18, ; 32..39
	i32 28, i32 2, i32 29, i32 11, i32 38, i32 7, i32 12, i32 5, ; 40..47
	i32 9, i32 15, i32 26, i32 15, i32 31, i32 17, i32 25, i32 19, ; 48..55
	i32 34, i32 27, i32 24, i32 16, i32 31, i32 10, i32 10, i32 21, ; 56..63
	i32 20, i32 6, i32 6, i32 33, i32 30, i32 3, i32 17, i32 13, ; 64..71
	i32 16, i32 11, i32 32, i32 18, i32 23, i32 35 ; 72..77
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
