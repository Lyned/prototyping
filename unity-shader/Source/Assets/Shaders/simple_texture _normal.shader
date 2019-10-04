Shader "SAE/Simple Texture Normalmap"
{
    Properties
    {
		_Color ("color", Color) = (1,1,1,1)
		_Alpha ("Alpha", Float) = 1.0
		_MainTex ("Albedo (RGB) Alpha (A)", 2D) = "white" {}
		_NormalTex ("Normalmap (RGB)", 2D) = "bump" {}
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        #pragma target 3.0

        struct Input
        {
			float2 uv_MainTex;
			float2 uv_NormalTex;
			float4 color : COLOR;// Vertex color
        };
		
		sampler2D _MainTex;
		sampler2D _NormalTex;
        fixed4 _Color;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			float3 n = UnpackNormal(tex2D(_NormalTex, IN.uv_NormalTex));
			o.Albedo = c.rgb;
			o.Normal = n;
        }

        ENDCG
    }
    FallBack "Diffuse"
}
