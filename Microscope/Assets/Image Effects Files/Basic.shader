// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Shaders101/Basic"
{
	
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Brightness("Brightness", Range(-1,1)) = 0
		_Saturation("Saturation", Range(1,-1)) = 0
	}
	
	SubShader
	{

		Cull Off ZWrite Off ZTest Always
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXTCOORD0;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;
			float4 _MainTex_TexelSize;
			float _Brightness;
			float _Saturation;

			float4 box(sampler2D tex, float2 uv, float4 size)
			{
				float4 c = tex2D(tex, uv + float2(-size.x, size.y)) + tex2D(tex, uv + float2(0, size.y)) + tex2D(tex, uv + float2(size.x, size.y)) +
					tex2D(tex, uv + float2(-size.x, 0)) + tex2D(tex, uv + float2(0, 0)) + tex2D(tex, uv + float2(size.x, 0)) +
					tex2D(tex, uv + float2(-size.x, -size.y)) + tex2D(tex, uv + float2(0, -size.y)) + tex2D(tex, uv + float2(size.x, -size.y));

				return c / 9;
			}

			float4 frag(v2f i) : SV_Target
			{
				
				float4 col = tex2D(_MainTex, i.uv);
				
				//col *= float4(i.uv.x, i.uv.y, 0, 1); 
				col += fixed4(_Brightness, _Brightness, _Brightness, 0);
				
				fixed4 brightened = col;
				fixed lum = saturate(Luminance(brightened.rgb));
				
				fixed4 desaturated;
				
				desaturated.rgb = lerp(brightened.rgb, fixed3(lum, lum, lum), _Saturation);
				desaturated.a = brightened.a;

				float4 blurred = box(_MainTex, i.uv, _MainTex_TexelSize);
				
				
				
				
				
				return desaturated;
			}
			ENDCG
		}
	}
}
