Shader "SAE/Constant Color"
{
    Properties
    {
		_Color ("color", Color) = (1,1,1,1)
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
    }

    SubShader
    {
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        #pragma target 3.0

        struct Input
        {
			float4 color : COLOR;// Vertex color
        };

        fixed4 _Color;
		half _Glossiness;
		half _Metallic;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Albedo = _Color;
        }

        ENDCG
    }
}
