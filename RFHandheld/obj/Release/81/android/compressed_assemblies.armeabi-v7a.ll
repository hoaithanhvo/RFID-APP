; ModuleID = 'obj\Release\81\android\compressed_assemblies.armeabi-v7a.ll'
source_filename = "obj\Release\81\android\compressed_assemblies.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.CompressedAssemblyDescriptor = type {
	i32,; uint32_t uncompressed_file_size
	i8,; bool loaded
	i8*; uint8_t* data
}

%struct.CompressedAssemblies = type {
	i32,; uint32_t count
	%struct.CompressedAssemblyDescriptor*; CompressedAssemblyDescriptor* descriptors
}
@__CompressedAssemblyDescriptor_data_0 = internal global [165888 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_1 = internal global [1068032 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_2 = internal global [121856 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_3 = internal global [690176 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_4 = internal global [157696 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_5 = internal global [376320 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_6 = internal global [747008 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_7 = internal global [219648 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_8 = internal global [38912 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_9 = internal global [6144 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_10 = internal global [65024 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_11 = internal global [1318912 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_12 = internal global [837120 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_13 = internal global [14336 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_14 = internal global [116736 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_15 = internal global [36352 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_16 = internal global [32256 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_17 = internal global [151552 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_18 = internal global [301056 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_19 = internal global [2008576 x i8] zeroinitializer, align 1


; Compressed assembly data storage
@compressed_assembly_descriptors = internal global [20 x %struct.CompressedAssemblyDescriptor] [
	; 0
	%struct.CompressedAssemblyDescriptor {
		i32 165888, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([165888 x i8], [165888 x i8]* @__CompressedAssemblyDescriptor_data_0, i32 0, i32 0); data
	}, 
	; 1
	%struct.CompressedAssemblyDescriptor {
		i32 1068032, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1068032 x i8], [1068032 x i8]* @__CompressedAssemblyDescriptor_data_1, i32 0, i32 0); data
	}, 
	; 2
	%struct.CompressedAssemblyDescriptor {
		i32 121856, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([121856 x i8], [121856 x i8]* @__CompressedAssemblyDescriptor_data_2, i32 0, i32 0); data
	}, 
	; 3
	%struct.CompressedAssemblyDescriptor {
		i32 690176, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([690176 x i8], [690176 x i8]* @__CompressedAssemblyDescriptor_data_3, i32 0, i32 0); data
	}, 
	; 4
	%struct.CompressedAssemblyDescriptor {
		i32 157696, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([157696 x i8], [157696 x i8]* @__CompressedAssemblyDescriptor_data_4, i32 0, i32 0); data
	}, 
	; 5
	%struct.CompressedAssemblyDescriptor {
		i32 376320, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([376320 x i8], [376320 x i8]* @__CompressedAssemblyDescriptor_data_5, i32 0, i32 0); data
	}, 
	; 6
	%struct.CompressedAssemblyDescriptor {
		i32 747008, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([747008 x i8], [747008 x i8]* @__CompressedAssemblyDescriptor_data_6, i32 0, i32 0); data
	}, 
	; 7
	%struct.CompressedAssemblyDescriptor {
		i32 219648, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([219648 x i8], [219648 x i8]* @__CompressedAssemblyDescriptor_data_7, i32 0, i32 0); data
	}, 
	; 8
	%struct.CompressedAssemblyDescriptor {
		i32 38912, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([38912 x i8], [38912 x i8]* @__CompressedAssemblyDescriptor_data_8, i32 0, i32 0); data
	}, 
	; 9
	%struct.CompressedAssemblyDescriptor {
		i32 6144, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([6144 x i8], [6144 x i8]* @__CompressedAssemblyDescriptor_data_9, i32 0, i32 0); data
	}, 
	; 10
	%struct.CompressedAssemblyDescriptor {
		i32 65024, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([65024 x i8], [65024 x i8]* @__CompressedAssemblyDescriptor_data_10, i32 0, i32 0); data
	}, 
	; 11
	%struct.CompressedAssemblyDescriptor {
		i32 1318912, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1318912 x i8], [1318912 x i8]* @__CompressedAssemblyDescriptor_data_11, i32 0, i32 0); data
	}, 
	; 12
	%struct.CompressedAssemblyDescriptor {
		i32 837120, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([837120 x i8], [837120 x i8]* @__CompressedAssemblyDescriptor_data_12, i32 0, i32 0); data
	}, 
	; 13
	%struct.CompressedAssemblyDescriptor {
		i32 14336, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14336 x i8], [14336 x i8]* @__CompressedAssemblyDescriptor_data_13, i32 0, i32 0); data
	}, 
	; 14
	%struct.CompressedAssemblyDescriptor {
		i32 116736, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([116736 x i8], [116736 x i8]* @__CompressedAssemblyDescriptor_data_14, i32 0, i32 0); data
	}, 
	; 15
	%struct.CompressedAssemblyDescriptor {
		i32 36352, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([36352 x i8], [36352 x i8]* @__CompressedAssemblyDescriptor_data_15, i32 0, i32 0); data
	}, 
	; 16
	%struct.CompressedAssemblyDescriptor {
		i32 32256, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([32256 x i8], [32256 x i8]* @__CompressedAssemblyDescriptor_data_16, i32 0, i32 0); data
	}, 
	; 17
	%struct.CompressedAssemblyDescriptor {
		i32 151552, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([151552 x i8], [151552 x i8]* @__CompressedAssemblyDescriptor_data_17, i32 0, i32 0); data
	}, 
	; 18
	%struct.CompressedAssemblyDescriptor {
		i32 301056, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([301056 x i8], [301056 x i8]* @__CompressedAssemblyDescriptor_data_18, i32 0, i32 0); data
	}, 
	; 19
	%struct.CompressedAssemblyDescriptor {
		i32 2008576, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([2008576 x i8], [2008576 x i8]* @__CompressedAssemblyDescriptor_data_19, i32 0, i32 0); data
	}
], align 4; end of 'compressed_assembly_descriptors' array


; compressed_assemblies
@compressed_assemblies = local_unnamed_addr global %struct.CompressedAssemblies {
	i32 20, ; count
	%struct.CompressedAssemblyDescriptor* getelementptr inbounds ([20 x %struct.CompressedAssemblyDescriptor], [20 x %struct.CompressedAssemblyDescriptor]* @compressed_assembly_descriptors, i32 0, i32 0); descriptors
}, align 4


!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
