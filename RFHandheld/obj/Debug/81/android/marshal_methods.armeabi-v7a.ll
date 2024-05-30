; ModuleID = 'obj\Debug\81\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Debug\81\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


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
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [78 x i32] [
	i32 39109920, ; 0: Newtonsoft.Json.dll => 0x254c520 => 4
	i32 160529393, ; 1: Xamarin.Android.Arch.Core.Common => 0x9917bf1 => 10
	i32 166922606, ; 2: Xamarin.Android.Support.Compat.dll => 0x9f3096e => 15
	i32 232815796, ; 3: System.Web.Services => 0xde07cb4 => 36
	i32 293914992, ; 4: Xamarin.Android.Support.Transition => 0x1184c970 => 21
	i32 303321209, ; 5: RFHandheld => 0x12145079 => 0
	i32 321597661, ; 6: System.Numerics => 0x132b30dd => 28
	i32 388313361, ; 7: Xamarin.Android.Support.Animated.Vector.Drawable => 0x17253111 => 13
	i32 389971796, ; 8: Xamarin.Android.Support.Core.UI => 0x173e7f54 => 16
	i32 465846621, ; 9: mscorlib => 0x1bc4415d => 3
	i32 469710990, ; 10: System.dll => 0x1bff388e => 6
	i32 514659665, ; 11: Xamarin.Android.Support.Compat => 0x1ead1551 => 15
	i32 526420162, ; 12: System.Transactions.dll => 0x1f6088c2 => 29
	i32 539750087, ; 13: Xamarin.Android.Support.Design => 0x202beec7 => 18
	i32 571524804, ; 14: Xamarin.Android.Support.v7.RecyclerView => 0x2210c6c4 => 23
	i32 605376203, ; 15: System.IO.Compression.FileSystem => 0x24154ecb => 32
	i32 690569205, ; 16: System.Xml.Linq.dll => 0x29293ff5 => 37
	i32 692692150, ; 17: Xamarin.Android.Support.Annotations => 0x2949a4b6 => 14
	i32 775507847, ; 18: System.IO.Compression => 0x2e394f87 => 31
	i32 809851609, ; 19: System.Drawing.Common.dll => 0x30455ad9 => 25
	i32 955402788, ; 20: Newtonsoft.Json => 0x38f24a24 => 4
	i32 958213972, ; 21: Xamarin.Android.Support.Media.Compat => 0x391d2f54 => 20
	i32 1098259244, ; 22: System => 0x41761b2c => 6
	i32 1359785034, ; 23: Xamarin.Android.Support.Design.dll => 0x510cac4a => 18
	i32 1365406463, ; 24: System.ServiceModel.Internals.dll => 0x516272ff => 35
	i32 1445445088, ; 25: Xamarin.Android.Support.Fragment => 0x5627bde0 => 19
	i32 1462112819, ; 26: System.IO.Compression.dll => 0x57261233 => 31
	i32 1574652163, ; 27: Xamarin.Android.Support.Core.Utils.dll => 0x5ddb4903 => 17
	i32 1587447679, ; 28: Xamarin.Android.Arch.Core.Common.dll => 0x5e9e877f => 10
	i32 1592978981, ; 29: System.Runtime.Serialization.dll => 0x5ef2ee25 => 34
	i32 1639515021, ; 30: System.Net.Http.dll => 0x61b9038d => 7
	i32 1657153582, ; 31: System.Runtime => 0x62c6282e => 8
	i32 1662014763, ; 32: Xamarin.Android.Support.Vector.Drawable => 0x6310552b => 24
	i32 1776026572, ; 33: System.Core.dll => 0x69dc03cc => 5
	i32 1877418711, ; 34: Xamarin.Android.Support.v7.RecyclerView.dll => 0x6fe722d7 => 23
	i32 2079903147, ; 35: System.Runtime.dll => 0x7bf8cdab => 8
	i32 2166116741, ; 36: Xamarin.Android.Support.Core.Utils => 0x811c5185 => 17
	i32 2201231467, ; 37: System.Net.Http => 0x8334206b => 7
	i32 2330457430, ; 38: Xamarin.Android.Support.Core.UI.dll => 0x8ae7f556 => 16
	i32 2373288475, ; 39: Xamarin.Android.Support.Fragment.dll => 0x8d75821b => 19
	i32 2471841756, ; 40: netstandard.dll => 0x93554fdc => 26
	i32 2475788418, ; 41: Java.Interop.dll => 0x93918882 => 1
	i32 2501346920, ; 42: System.Data.DataSetExtensions => 0x95178668 => 30
	i32 2755918238, ; 43: RFHandheld.dll => 0xa443f99e => 0
	i32 2819470561, ; 44: System.Xml.dll => 0xa80db4e1 => 9
	i32 2903344695, ; 45: System.ComponentModel.Composition => 0xad0d8637 => 33
	i32 2905242038, ; 46: mscorlib.dll => 0xad2a79b6 => 3
	i32 2922925221, ; 47: Xamarin.Android.Support.Vector.Drawable.dll => 0xae384ca5 => 24
	i32 3068715062, ; 48: Xamarin.Android.Arch.Lifecycle.Common => 0xb6e8e036 => 11
	i32 3092211740, ; 49: Xamarin.Android.Support.Media.Compat.dll => 0xb84f681c => 20
	i32 3111772706, ; 50: System.Runtime.Serialization => 0xb979e222 => 34
	i32 3204380047, ; 51: System.Data.dll => 0xbefef58f => 27
	i32 3247949154, ; 52: Mono.Security => 0xc197c562 => 38
	i32 3317144872, ; 53: System.Data => 0xc5b79d28 => 27
	i32 3366347497, ; 54: Java.Interop => 0xc8a662e9 => 1
	i32 3404865022, ; 55: System.ServiceModel.Internals => 0xcaf21dfe => 35
	i32 3429136800, ; 56: System.Xml => 0xcc6479a0 => 9
	i32 3430777524, ; 57: netstandard => 0xcc7d82b4 => 26
	i32 3439690031, ; 58: Xamarin.Android.Support.Annotations.dll => 0xcd05812f => 14
	i32 3476120550, ; 59: Mono.Android => 0xcf3163e6 => 2
	i32 3486566296, ; 60: System.Transactions => 0xcfd0c798 => 29
	i32 3509114376, ; 61: System.Xml.Linq => 0xd128d608 => 37
	i32 3567349600, ; 62: System.ComponentModel.Composition.dll => 0xd4a16f60 => 33
	i32 3672681054, ; 63: Mono.Android.dll => 0xdae8aa5e => 2
	i32 3676310014, ; 64: System.Web.Services.dll => 0xdb2009fe => 36
	i32 3678221644, ; 65: Xamarin.Android.Support.v7.AppCompat => 0xdb3d354c => 22
	i32 3681174138, ; 66: Xamarin.Android.Arch.Lifecycle.Common.dll => 0xdb6a427a => 11
	i32 3689375977, ; 67: System.Drawing.Common => 0xdbe768e9 => 25
	i32 3718463572, ; 68: Xamarin.Android.Support.Animated.Vector.Drawable.dll => 0xdda34054 => 13
	i32 3829621856, ; 69: System.Numerics.dll => 0xe4436460 => 28
	i32 3862817207, ; 70: Xamarin.Android.Arch.Lifecycle.Runtime.dll => 0xe63de9b7 => 12
	i32 3874897629, ; 71: Xamarin.Android.Arch.Lifecycle.Runtime => 0xe6f63edd => 12
	i32 3883175360, ; 72: Xamarin.Android.Support.v7.AppCompat.dll => 0xe7748dc0 => 22
	i32 3920810846, ; 73: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 32
	i32 3945713374, ; 74: System.Data.DataSetExtensions.dll => 0xeb2ecede => 30
	i32 4105002889, ; 75: Mono.Security.dll => 0xf4ad5f89 => 38
	i32 4151237749, ; 76: System.Core => 0xf76edc75 => 5
	i32 4216993138 ; 77: Xamarin.Android.Support.Transition.dll => 0xfb5a3572 => 21
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [78 x i32] [
	i32 4, i32 10, i32 15, i32 36, i32 21, i32 0, i32 28, i32 13, ; 0..7
	i32 16, i32 3, i32 6, i32 15, i32 29, i32 18, i32 23, i32 32, ; 8..15
	i32 37, i32 14, i32 31, i32 25, i32 4, i32 20, i32 6, i32 18, ; 16..23
	i32 35, i32 19, i32 31, i32 17, i32 10, i32 34, i32 7, i32 8, ; 24..31
	i32 24, i32 5, i32 23, i32 8, i32 17, i32 7, i32 16, i32 19, ; 32..39
	i32 26, i32 1, i32 30, i32 0, i32 9, i32 33, i32 3, i32 24, ; 40..47
	i32 11, i32 20, i32 34, i32 27, i32 38, i32 27, i32 1, i32 35, ; 48..55
	i32 9, i32 26, i32 14, i32 2, i32 29, i32 37, i32 33, i32 2, ; 56..63
	i32 36, i32 22, i32 11, i32 25, i32 13, i32 28, i32 12, i32 12, ; 64..71
	i32 22, i32 32, i32 30, i32 38, i32 5, i32 21 ; 72..77
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
