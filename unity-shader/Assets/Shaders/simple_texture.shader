Shader "SAE/Simple Texture"
{
    Properties
    {
		_Color ("color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        #pragma target 3.0

        struct Input
        {
			float2 uv_MainTex;
			float4 color : COLOR;// Vertex color
        };
		
		sampler2D _MainTex;
        fixed4 _Color;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c;
        }

        ENDCG
    }
}
