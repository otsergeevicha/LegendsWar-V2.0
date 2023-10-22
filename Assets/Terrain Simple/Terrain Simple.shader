// Made with Amplify Shader Editor v1.9.2
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Nature/Terrain/Custome"
{
	Properties
	{
		[Toggle(_TERRAIN_INSTANCED_PERPIXEL_NORMAL)] _EnableInstancedPerPixelNormal("Enable Instanced Per-Pixel Normal", Float) = 0
		[HideInInspector]_TerrainHolesTexture("_TerrainHolesTexture", 2D) = "white" {}
		[HideInInspector]_Control("Control", 2D) = "white" {}
		[HideInInspector]_Splat0("Splat0", 2D) = "white" {}
		[HideInInspector]_Normal0("Normal0", 2D) = "bump" {}
		[HideInInspector]_NormalScale0("NormalScale0", Float) = 1
		[HideInInspector]_Mask0("Mask0", 2D) = "white" {}
		[HideInInspector][Gamma]_Metallic0("Metallic0", Range( 0 , 1)) = 0
		[HideInInspector]_Smoothness0("Smoothness0", Range( 0 , 1)) = 0
		[HideInInspector]_Splat1("Splat1", 2D) = "white" {}
		[HideInInspector]_Normal1("Normal1", 2D) = "bump" {}
		[HideInInspector]_NormalScale1("NormalScale1", Float) = 1
		[HideInInspector]_Mask1("Mask1", 2D) = "white" {}
		[HideInInspector][Gamma]_Metallic1("Metallic1", Range( 0 , 1)) = 0
		[HideInInspector]_Smoothness1("Smoothness1", Range( 0 , 1)) = 0
		[HideInInspector]_Splat2("Splat2", 2D) = "white" {}
		[HideInInspector]_Normal2("Normal2", 2D) = "bump" {}
		[HideInInspector]_NormalScale2("NormalScale2", Float) = 1
		[HideInInspector]_Mask2("Mask2", 2D) = "white" {}
		[HideInInspector][Gamma]_Metallic2("Metallic2", Range( 0 , 1)) = 0
		[HideInInspector]_Smoothness2("Smoothness2", Range( 0 , 1)) = 0
		[HideInInspector]_Splat3("Splat3", 2D) = "white" {}
		[HideInInspector]_Normal3("Normal3", 2D) = "bump" {}
		[HideInInspector]_NormalScale3("_NormalScale3", Float) = 1
		[HideInInspector]_Mask3("Mask3", 2D) = "white" {}
		[HideInInspector][Gamma]_Metallic3("Metallic3", Range( 0 , 1)) = 0
		[HideInInspector]_Smoothness3("Smoothness3", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry-100" "TerrainCompatible"="True" }
		Cull Back
		ZTest LEqual
		CGPROGRAM
		#include "UnityStandardUtils.cginc"
		#pragma target 3.5
		#pragma multi_compile_instancing
		#pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap forwardadd
		#pragma shader_feature_local _TERRAIN_INSTANCED_PERPIXEL_NORMAL
		#pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap forwardadd
		#pragma multi_compile_local __ _NORMALMAP
		#pragma shader_feature_local _MASKMAP
		#pragma multi_compile_local_fragment __ _ALPHATEST_ON
		#pragma multi_compile_fog
		#pragma editor_sync_compilation
		#pragma target 3.0
		#pragma exclude_renderers gles
		#define TERRAIN_SPLATMAP_COMMON_CGINC_INCLUDED
		#include "UnityPBSLighting.cginc"
		#include "TerrainSplatmapCommon.cginc"
		#define TERRAIN_STANDARD_SHADER
		#define TERRAIN_SURFACE_OUTPUT SurfaceOutputStandard
		#define ASE_USING_SAMPLING_MACROS 1
		#if defined(SHADER_API_D3D11) || defined(SHADER_API_XBOXONE) || defined(UNITY_COMPILER_HLSLCC) || defined(SHADER_API_PSSL) || (defined(SHADER_TARGET_SURFACE_ANALYSIS) && !defined(SHADER_TARGET_SURFACE_ANALYSIS_MOJOSHADER))//ASE Sampler Macros
		#define SAMPLE_TEXTURE2D(tex,samplerTex,coord) tex.Sample(samplerTex,coord)
		#else//ASE Sampling Macros
		#define SAMPLE_TEXTURE2D(tex,samplerTex,coord) tex2D(tex,coord)
		#endif//ASE Sampling Macros

		#pragma surface surf Standard keepalpha vertex:vertexDataFunc  finalcolor:SplatmapFinalColor
		struct Input
		{
			float2 vertexToFrag286_g13;
			float2 uv_texcoord;
		};

		#ifdef UNITY_INSTANCING_ENABLED//ASE Terrain Instancing
			sampler2D _TerrainHeightmapTexture;//ASE Terrain Instancing
			sampler2D _TerrainNormalmapTexture;//ASE Terrain Instancing
		#endif//ASE Terrain Instancing
		UNITY_INSTANCING_BUFFER_START( Terrain )//ASE Terrain Instancing
			UNITY_DEFINE_INSTANCED_PROP( float4, _TerrainPatchInstanceData )//ASE Terrain Instancing
		UNITY_INSTANCING_BUFFER_END( Terrain)//ASE Terrain Instancing
		CBUFFER_START( UnityTerrain)//ASE Terrain Instancing
			#ifdef UNITY_INSTANCING_ENABLED//ASE Terrain Instancing
				float4 _TerrainHeightmapRecipSize;//ASE Terrain Instancing
				float4 _TerrainHeightmapScale;//ASE Terrain Instancing
			#endif//ASE Terrain Instancing
		CBUFFER_END//ASE Terrain Instancing
		UNITY_DECLARE_TEX2D_NOSAMPLER(_Control);
		uniform float4 _Control_ST;
		SamplerState sampler_Control;
		UNITY_DECLARE_TEX2D_NOSAMPLER(_Normal0);
		UNITY_DECLARE_TEX2D_NOSAMPLER(_Splat0);
		uniform float4 _Splat0_ST;
		SamplerState sampler_Normal0;
		uniform half _NormalScale0;
		UNITY_DECLARE_TEX2D_NOSAMPLER(_Normal1);
		UNITY_DECLARE_TEX2D_NOSAMPLER(_Splat1);
		uniform float4 _Splat1_ST;
		uniform half _NormalScale1;
		UNITY_DECLARE_TEX2D_NOSAMPLER(_Normal2);
		UNITY_DECLARE_TEX2D_NOSAMPLER(_Splat2);
		uniform float4 _Splat2_ST;
		uniform half _NormalScale2;
		UNITY_DECLARE_TEX2D_NOSAMPLER(_Normal3);
		UNITY_DECLARE_TEX2D_NOSAMPLER(_Splat3);
		uniform float4 _Splat3_ST;
		uniform half _NormalScale3;
		SamplerState sampler_Splat0;
		UNITY_DECLARE_TEX2D_NOSAMPLER(_TerrainHolesTexture);
		uniform float4 _TerrainHolesTexture_ST;
		SamplerState sampler_TerrainHolesTexture;
		uniform float _Metallic0;
		UNITY_DECLARE_TEX2D_NOSAMPLER(_Mask0);
		SamplerState sampler_Mask0;
		uniform float _Metallic1;
		UNITY_DECLARE_TEX2D_NOSAMPLER(_Mask1);
		uniform float _Metallic2;
		UNITY_DECLARE_TEX2D_NOSAMPLER(_Mask2);
		uniform float _Metallic3;
		UNITY_DECLARE_TEX2D_NOSAMPLER(_Mask3);
		uniform float _Smoothness0;
		uniform float _Smoothness1;
		uniform float _Smoothness2;
		uniform float _Smoothness3;


		void SplatmapFinalColor( Input SurfaceIn, SurfaceOutputStandard SurfaceOut, inout fixed4 FinalColor )
		{
			FinalColor *= SurfaceOut.Alpha;
		}


		void ApplyMeshModification( inout appdata_full v )
		{
			#if defined(UNITY_INSTANCING_ENABLED) && !defined(SHADER_API_D3D11_9X)
				float2 patchVertex = v.vertex.xy;
				float4 instanceData = UNITY_ACCESS_INSTANCED_PROP(Terrain, _TerrainPatchInstanceData);
				
				float4 uvscale = instanceData.z * _TerrainHeightmapRecipSize;
				float4 uvoffset = instanceData.xyxy * uvscale;
				uvoffset.xy += 0.5f * _TerrainHeightmapRecipSize.xy;
				float2 sampleCoords = (patchVertex.xy * uvscale.xy + uvoffset.xy);
				
				float hm = UnpackHeightmap(tex2Dlod(_TerrainHeightmapTexture, float4(sampleCoords, 0, 0)));
				v.vertex.xz = (patchVertex.xy + instanceData.xy) * _TerrainHeightmapScale.xz * instanceData.z;
				v.vertex.y = hm * _TerrainHeightmapScale.y;
				v.vertex.w = 1.0f;
				
				v.texcoord.xy = (patchVertex.xy * uvscale.zw + uvoffset.zw);
				v.texcoord3 = v.texcoord2 = v.texcoord1 = v.texcoord;
				
				#ifdef TERRAIN_INSTANCED_PERPIXEL_NORMAL
					v.normal = float3(0, 1, 0);
					//data.tc.zw = sampleCoords;
				#else
					float3 nor = tex2Dlod(_TerrainNormalmapTexture, float4(sampleCoords, 0, 0)).xyz;
					v.normal = 2.0f * nor - 1.0f;
				#endif
			#endif
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			ApplyMeshModification(v);
			v.vertex.w = 1;
			float2 break291_g13 = _Control_ST.zw;
			float2 appendResult293_g13 = (float2(( break291_g13.x + 0.001 ) , ( break291_g13.y + 0.0001 )));
			o.vertexToFrag286_g13 = ( ( v.texcoord.xy * _Control_ST.xy ) + appendResult293_g13 );
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float4 tex2DNode283_g13 = SAMPLE_TEXTURE2D( _Control, sampler_Control, i.vertexToFrag286_g13 );
			float dotResult278_g13 = dot( tex2DNode283_g13 , half4(1,1,1,1) );
			float localSplatClip276_g13 = ( dotResult278_g13 );
			float4 Control26_g13 = ( tex2DNode283_g13 / ( localSplatClip276_g13 + 0.001 ) );
			float2 uv_Splat0 = i.uv_texcoord * _Splat0_ST.xy + _Splat0_ST.zw;
			float4 Normal0341_g13 = SAMPLE_TEXTURE2D( _Normal0, sampler_Normal0, uv_Splat0 );
			float2 uv_Splat1 = i.uv_texcoord * _Splat1_ST.xy + _Splat1_ST.zw;
			float4 Normal1378_g13 = SAMPLE_TEXTURE2D( _Normal1, sampler_Normal0, uv_Splat1 );
			float2 uv_Splat2 = i.uv_texcoord * _Splat2_ST.xy + _Splat2_ST.zw;
			float4 Normal2356_g13 = SAMPLE_TEXTURE2D( _Normal2, sampler_Normal0, uv_Splat2 );
			float2 uv_Splat3 = i.uv_texcoord * _Splat3_ST.xy + _Splat3_ST.zw;
			float4 Normal3398_g13 = SAMPLE_TEXTURE2D( _Normal3, sampler_Normal0, uv_Splat3 );
			float4 weightedBlendVar473_g13 = Control26_g13;
			float3 weightedBlend473_g13 = ( weightedBlendVar473_g13.x*UnpackScaleNormal( Normal0341_g13, _NormalScale0 ) + weightedBlendVar473_g13.y*UnpackScaleNormal( Normal1378_g13, _NormalScale1 ) + weightedBlendVar473_g13.z*UnpackScaleNormal( Normal2356_g13, _NormalScale2 ) + weightedBlendVar473_g13.w*UnpackScaleNormal( Normal3398_g13, _NormalScale3 ) );
			float3 break513_g13 = weightedBlend473_g13;
			float3 appendResult514_g13 = (float3(break513_g13.x , break513_g13.y , ( break513_g13.z + 0.001 )));
			#ifdef _TERRAIN_INSTANCED_PERPIXEL_NORMAL
				float3 staticSwitch503_g13 = appendResult514_g13;
			#else
				float3 staticSwitch503_g13 = appendResult514_g13;
			#endif
			o.Normal = staticSwitch503_g13;
			float3 _Vector1 = float3(1,1,1);
			float4 tex2DNode414_g13 = SAMPLE_TEXTURE2D( _Splat0, sampler_Splat0, uv_Splat0 );
			float3 Splat0342_g13 = (tex2DNode414_g13).rgb;
			float3 _Vector2 = float3(1,1,1);
			float4 tex2DNode420_g13 = SAMPLE_TEXTURE2D( _Splat1, sampler_Splat0, uv_Splat1 );
			float3 Splat1379_g13 = (tex2DNode420_g13).rgb;
			float3 _Vector3 = float3(1,1,1);
			float4 tex2DNode417_g13 = SAMPLE_TEXTURE2D( _Splat2, sampler_Splat0, uv_Splat2 );
			float3 Splat2357_g13 = (tex2DNode417_g13).rgb;
			float3 _Vector4 = float3(1,1,1);
			float4 tex2DNode423_g13 = SAMPLE_TEXTURE2D( _Splat3, sampler_Splat0, uv_Splat3 );
			float3 Splat3390_g13 = (tex2DNode423_g13).rgb;
			float4 weightedBlendVar9_g13 = Control26_g13;
			float3 weightedBlend9_g13 = ( weightedBlendVar9_g13.x*( _Vector1 * Splat0342_g13 ) + weightedBlendVar9_g13.y*( _Vector2 * Splat1379_g13 ) + weightedBlendVar9_g13.z*( _Vector3 * Splat2357_g13 ) + weightedBlendVar9_g13.w*( _Vector4 * Splat3390_g13 ) );
			float3 localClipHoles453_g13 = ( weightedBlend9_g13 );
			o.Albedo = localClipHoles453_g13;
			float4 tex2DNode416_g13 = SAMPLE_TEXTURE2D( _Mask0, sampler_Mask0, uv_Splat0 );
			float Mask0R334_g13 = tex2DNode416_g13.r;
			float4 tex2DNode422_g13 = SAMPLE_TEXTURE2D( _Mask1, sampler_Mask0, uv_Splat1 );
			float Mask1R370_g13 = tex2DNode422_g13.r;
			float4 tex2DNode419_g13 = SAMPLE_TEXTURE2D( _Mask2, sampler_Mask0, uv_Splat2 );
			float Mask2R359_g13 = tex2DNode419_g13.r;
			float4 tex2DNode425_g13 = SAMPLE_TEXTURE2D( _Mask3, sampler_Mask0, uv_Splat3 );
			float Mask3R388_g13 = tex2DNode425_g13.r;
			float4 weightedBlendVar536_g13 = Control26_g13;
			float weightedBlend536_g13 = ( weightedBlendVar536_g13.x*( ( 1.0 - _Metallic0 ) * Mask0R334_g13 ) + weightedBlendVar536_g13.y*( ( 1.0 - _Metallic1 ) * Mask1R370_g13 ) + weightedBlendVar536_g13.z*( ( 1.0 - _Metallic2 ) * Mask2R359_g13 ) + weightedBlendVar536_g13.w*( ( 1.0 - _Metallic3 ) * Mask3R388_g13 ) );
			o.Metallic = weightedBlend536_g13;
			float Mask0A335_g13 = tex2DNode416_g13.a;
			float Mask1A369_g13 = tex2DNode422_g13.a;
			float Mask2A360_g13 = tex2DNode419_g13.a;
			float Mask3A391_g13 = tex2DNode425_g13.a;
			float4 weightedBlendVar547_g13 = Control26_g13;
			float weightedBlend547_g13 = ( weightedBlendVar547_g13.x*( ( 1.0 - _Smoothness0 ) * Mask0A335_g13 ) + weightedBlendVar547_g13.y*( ( 1.0 - _Smoothness1 ) * Mask1A369_g13 ) + weightedBlendVar547_g13.z*( ( 1.0 - _Smoothness2 ) * Mask2A360_g13 ) + weightedBlendVar547_g13.w*( ( 1.0 - _Smoothness3 ) * Mask3A391_g13 ) );
			o.Smoothness = weightedBlend547_g13;
			float Mask0G409_g13 = tex2DNode416_g13.g;
			float Mask1G371_g13 = tex2DNode422_g13.g;
			float Mask2G358_g13 = tex2DNode419_g13.g;
			float Mask3G389_g13 = tex2DNode425_g13.g;
			float4 weightedBlendVar602_g13 = Control26_g13;
			float weightedBlend602_g13 = ( weightedBlendVar602_g13.x*saturate( ( ( ( Mask0G409_g13 - 0.5 ) * 0.25 ) + ( 1.0 - 0.25 ) ) ) + weightedBlendVar602_g13.y*saturate( ( ( ( Mask1G371_g13 - 0.5 ) * 0.25 ) + ( 1.0 - 0.25 ) ) ) + weightedBlendVar602_g13.z*saturate( ( ( ( Mask2G358_g13 - 0.5 ) * 0.25 ) + ( 1.0 - 0.25 ) ) ) + weightedBlendVar602_g13.w*saturate( ( ( ( Mask3G389_g13 - 0.5 ) * 0.25 ) + ( 1.0 - 0.25 ) ) ) );
			o.Occlusion = saturate( weightedBlend602_g13 );
			o.Alpha = dotResult278_g13;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=19200
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;645.0565,40.11808;Float;False;True;-1;3;ASEMaterialInspector;0;0;Standard;AmplifyShaderPack/Terrain/Simple;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;;3;False;;False;0;False;;0;False;;False;0;Custom;0.5;True;False;-100;True;Opaque;;Geometry;All;12;all;True;True;True;True;0;False;;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;2;15;10;25;False;0.5;True;0;0;False;;0;False;;0;0;False;;0;False;;0;False;;0;False;;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;Nature/Terrain/Diffuse;0;-1;-1;-1;1;TerrainCompatible=True;False;2;BaseMapShader=Hidden/AmplifyShaderPack/Terrain/Simple BasePass;AddPassShader=Hidden/AmplifyShaderPack/Terrain/Simple AddPass;0;False;;-1;0;False;;13;Pragma;instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap forwardadd;False;;Custom;False;0;0;;Pragma;multi_compile_local __ _NORMALMAP;False;;Custom;False;0;0;;Pragma;shader_feature_local _MASKMAP;False;;Custom;False;0;0;;Pragma;multi_compile_local_fragment __ _ALPHATEST_ON;False;;Custom;False;0;0;;Pragma;multi_compile_fog;False;;Custom;False;0;0;;Pragma;editor_sync_compilation;False;;Custom;False;0;0;;Pragma;target 3.0;False;;Custom;False;0;0;;Pragma;exclude_renderers gles;False;;Custom;False;0;0;;Define;TERRAIN_SPLATMAP_COMMON_CGINC_INCLUDED;False;;Custom;False;0;0;;Include;UnityPBSLighting.cginc;False;;Custom;False;0;0;;Include;TerrainSplatmapCommon.cginc;False;;Custom;False;0;0;;Define;TERRAIN_STANDARD_SHADER;False;;Custom;False;0;0;;Define;TERRAIN_SURFACE_OUTPUT SurfaceOutputStandard;False;;Custom;False;0;0;;1;finalcolor:SplatmapFinalColor;0;True;0.1;False;;0;False;;True;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
Node;AmplifyShaderEditor.FunctionNode;49;336.8021,40.57027;Inherit;False;Terrain 4 Layer;1;;13;a8a57459582f78d4ca5db58f601fb616;4,504,1,102,1,669,0,668,0;0;7;FLOAT3;0;FLOAT3;14;FLOAT;56;FLOAT;45;FLOAT;200;FLOAT;282;FLOAT;17
Node;AmplifyShaderEditor.StickyNoteNode;50;-440.8992,51.2859;Inherit;False;757.9001;428.2;BIRP First Pass;;0,0,0,1;Additional Directives:$$#pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap forwardadd$#pragma multi_compile_local __ _NORMALMAP$#pragma shader_feature_local _MASKMAP$#pragma multi_compile_local_fragment __ _ALPHATEST_ON$#pragma multi_compile_fog$#pragma editor_sync_compilation$#pragma target 3.0$#pragma exclude_renderers gles$#define TERRAIN_SPLATMAP_COMMON_CGINC_INCLUDED$#include UnityPBSLighting.cginc$#include TerrainSplatmapCommon.cginc$#define TERRAIN_STANDARD_SHADER$#define TERRAIN_SURFACE_OUTPUT SurfaceOutputStandard$$$Custom SubShader Tags:$$TerrainCompatible = True$;0;0
Node;AmplifyShaderEditor.StickyNoteNode;52;642.0813,-247.3737;Inherit;False;262;102;SplatmapFinalColor;;0,0,0,1;Additional Surface Options:$finalcolor:SplatmapFinalColor;0;0
Node;AmplifyShaderEditor.CustomExpressionNode;45;643.3015,-133.2568;Float;False;FinalColor *= SurfaceOut.Alpha@;7;Create;3;True;SurfaceIn;OBJECT;0;In;Input;Float;False;True;SurfaceOut;OBJECT;0;In;SurfaceOutputStandard;Float;False;True;FinalColor;OBJECT;0;InOut;fixed4;Float;False;SplatmapFinalColor;False;True;0;;False;4;0;FLOAT;0;False;1;OBJECT;0;False;2;OBJECT;0;False;3;OBJECT;0;False;2;FLOAT;0;OBJECT;4
WireConnection;0;0;49;0
WireConnection;0;1;49;14
WireConnection;0;3;49;56
WireConnection;0;4;49;45
WireConnection;0;5;49;200
WireConnection;0;9;49;282
WireConnection;0;11;49;17
ASEEND*/
//CHKSM=7016CD0DDCA81B381F9F609FA7B74CDCADD6C517