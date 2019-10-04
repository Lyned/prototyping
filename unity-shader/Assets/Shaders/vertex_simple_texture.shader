Shader "SAE/Vertex Simple Texture"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Amplitude("Amplitude", Float) = 1
		_Frequency("Frequency", Float) = 1
		_WobbleStrength("Wobble Strength", Range(0,8)) = 0
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows addshadow vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		float _Amplitude;
		float _Frequency;
		float _WobbleStrength;
		half _Glossiness;
		half _Metallic;

		struct Input
		{
			float2 uv_MainTex;
		};

		void vert(inout appdata_full v)
		{
			float p = v.texcoord.x * _WobbleStrength;
			v.vertex.xyz += v.normal * sin(_Time.y * _Frequency + p) * _Amplitude;
		}

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
}