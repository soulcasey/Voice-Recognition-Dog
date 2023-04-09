Shader "Custom/OutlineShader"
{
	Properties 
	{
		_Color ("Color", Color) = (0.4,0.4,0.4,1)
		_Emission ("Emission", Range (0,1)) = 0.5
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
		_Outline ("Outline width", Range (0.0, 1)) = .002
		_OutlineEnabled ("Outline Enabled", Range (0.0, 1)) = 0
		_MainTex ("Base (RGB)", 2D) = "white" { }
	}
	SubShader 
	{
		Tags { "Queue" = "Transparent" }
		Tags { "RenderType" = "Opaque" }
		LOD 100

		Pass
		{
			Name "OUTLINE"
			Tags { "LightMode" = "Always" }
			Cull Off
			ZWrite Off
			ZTest Always
			ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			struct appdata 
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};
			
			struct v2f 
			{
				float4 pos : POSITION;
				float4 color : COLOR;
			};

			half4 frag(v2f i) : COLOR 
			{
				return i.color;
			};
			
			uniform float _Outline;
			uniform float4 _OutlineColor;
			uniform float _OutlineEnabled;
			
			v2f vert(appdata v) 
			{
				v2f o;

				o.pos = UnityObjectToClipPos(v.vertex);
			
				float3 norm   = mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal);
				float2 offset = TransformViewToProjection(norm.xy);
			
				o.pos.xy += offset * o.pos.z * _Outline;
				o.color = _OutlineColor;

				o.color.a = _OutlineEnabled >= 0.5 ? 1 : 0;

				return o;
			}
			ENDCG
		}
			
		CGPROGRAM
		#pragma surface surf Lambert
		#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		sampler2D _MainTex;
		fixed4 _Color;
		fixed _Emission;

		void surf (Input IN, inout SurfaceOutput o)
		{
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Emission = tex2D (_MainTex, IN.uv_MainTex) * _Emission;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
}