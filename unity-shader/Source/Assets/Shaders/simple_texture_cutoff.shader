Shader "SAE/Simple Texture Cutoff"
{
    Properties
    {
		_Color ("Color", Color) = (1,1,1,1)
		_Threshold ("Clip Threshold", Range(0,1)) = 0.5
		_MainTex ("Albedo (RGB) Alpha (A)", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alphatest:_Treshold

        #pragma target 3.0

        struct Input
        {
			float2 uv_MainTex;
			float4 color : COLOR;// Vertex color
        };
		
		sampler2D _MainTex;
		float _Alpha;
        fixed4 _Color;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a * _Alpha;
        }

        ENDCG
    }
    FallBack "Diffuse"
}
