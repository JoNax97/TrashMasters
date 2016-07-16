Shader "Sprites/Sprite Shadow"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
	_Color("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0
		_Cutoff("Shadow alpha cutoff", Range(0,1)) = 0.5
	}

		SubShader
	{
		Tags
	{
		"Queue" = "Transparent"
		"IgnoreProjector" = "True"
		"RenderType" = "Transparent"
		"PreviewType" = "Plane"
		"CanUseSpriteAtlas" = "True"
	}

		Cull Off
		Lighting Off
		ZWrite On
		Fog{ Mode Off }
		Blend One OneMinusSrcAlpha

		CGPROGRAM
#pragma surface surf Lambert alpha addshadow vertex:vert
#pragma multi_compile DUMMY PIXELSNAP_ON

		sampler2D _MainTex;
	fixed4 _Color;

	struct Input
	{
		float2 uv_MainTex;
		fixed4 color;
	};

	void vert(inout appdata_full v, out Input o)
	{
#if defined(PIXELSNAP_ON) && !defined(SHADER_API_FLASH)
		v.vertex = UnityPixelSnap(v.vertex);
#endif
		v.normal = float3(0,0,-1);

		UNITY_INITIALIZE_OUTPUT(Input, o);
		o.color = v.color * _Color;
	}

	void surf(Input IN, inout SurfaceOutput o)
	{
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
		o.Albedo = c.rgb * c.a;
		o.Alpha = c.a;
	}
	ENDCG
	}

		Fallback "Transparent/Cutout/VertexLit"
}