// Amplify Shader Editor - Visual Shader Editing Tool
// Copyright (c) Amplify Creations, Lda <info@amplify.pt>

using UnityEngine;
using System;

namespace AmplifyShaderEditor
{
	[Serializable]
	[NodeAttributes( "Multiply", "Operators", "Multiplication of two or more values ( A * B * .. )\nIt also handles Matrices multiplication", null, KeyCode.M )]
	public sealed class SimpleMultiplyOpNode : DynamicTypeNode
	{
		private int m_cachedPropertyId = -1;

		protected override void CommonInit( int uniqueId )
		{
			m_dynamicRestrictions = new WirePortDataType[]
			{
				WirePortDataType.OBJECT,
				WirePortDataType.FLOAT,
				WirePortDataType.FLOAT2,
				WirePortDataType.FLOAT3,
				WirePortDataType.FLOAT4,
				WirePortDataType.COLOR,
				WirePortDataType.FLOAT3x3,
				WirePortDataType.FLOAT4x4,
				WirePortDataType.INT
			};

			base.CommonInit( uniqueId );
			m_extensibleInputPorts = true;
			m_vectorMatrixOps = true;
			m_previewShaderGUID = "1ba1e43e86415ff4bbdf4d81dfcf035b";
		}

		public override void SetPreviewInputs()
		{
			base.SetPreviewInputs();

			if ( m_cachedPropertyId == -1 )
				m_cachedPropertyId = Shader.PropertyToID( "_Count" );

			PreviewMaterial.SetInt( m_cachedPropertyId, m_inputPorts.Count );
		}

		public override string BuildResults( int outputId, ref MasterNodeDataCollector dataCollector, bool ignoreLocalvar )
		{
			if ( m_inputPorts[ 0 ].DataType == WirePortDataType.FLOAT3x3 ||
				m_inputPorts[ 0 ].DataType == WirePortDataType.FLOAT4x4 ||
				m_inputPorts[ 1 ].DataType == WirePortDataType.FLOAT3x3 ||
				m_inputPorts[ 1 ].DataType == WirePortDataType.FLOAT4x4 )
			{
				m_inputA = m_inputPorts[ 0 ].GenerateShaderForOutput( ref dataCollector, m_inputPorts[ 0 ].DataType, ignoreLocalvar );
				m_inputB = m_inputPorts[ 1 ].GenerateShaderForOutput( ref dataCollector, m_inputPorts[ 1 ].DataType, ignoreLocalvar );


				// Check matrix on first input
				if ( m_inputPorts[ 0 ].DataType == WirePortDataType.FLOAT3x3 )
				{
					switch ( m_inputPorts[ 1 ].DataType )
					{
						case WirePortDataType.OBJECT:
						case WirePortDataType.FLOAT:
						case WirePortDataType.INT:
						case WirePortDataType.FLOAT2:
						case WirePortDataType.FLOAT4:
						case WirePortDataType.COLOR:
						{
							m_inputB = UIUtils.CastPortType( ref dataCollector, m_currentPrecisionType, new NodeCastInfo( UniqueId, outputId ), m_inputB, m_inputPorts[ 1 ].DataType, WirePortDataType.FLOAT3, m_inputB );
						}
						break;
						case WirePortDataType.FLOAT4x4:
						{
							m_inputA = UIUtils.CastPortType( ref dataCollector, m_currentPrecisionType, new NodeCastInfo( UniqueId, outputId ), m_inputA, m_inputPorts[ 0 ].DataType, WirePortDataType.FLOAT4x4, m_inputA );
						}
						break;
						case WirePortDataType.FLOAT3:
						case WirePortDataType.FLOAT3x3: break;
					}
				}

				if ( m_inputPorts[ 0 ].DataType == WirePortDataType.FLOAT4x4 )
				{
					switch ( m_inputPorts[ 1 ].DataType )
					{
						case WirePortDataType.OBJECT:
						case WirePortDataType.FLOAT:
						case WirePortDataType.INT:
						case WirePortDataType.FLOAT2:
						case WirePortDataType.FLOAT3:
						{
							m_inputB = UIUtils.CastPortType( ref dataCollector, m_currentPrecisionType, new NodeCastInfo( UniqueId, outputId ), m_inputB, m_inputPorts[ 1 ].DataType, WirePortDataType.FLOAT4, m_inputB );
						}
						break;
						case WirePortDataType.FLOAT3x3:
						{
							m_inputB = UIUtils.CastPortType( ref dataCollector, m_currentPrecisionType, new NodeCastInfo( UniqueId, outputId ), m_inputB, m_inputPorts[ 1 ].DataType, WirePortDataType.FLOAT4x4, m_inputB );
						}
						break;
						case WirePortDataType.FLOAT4x4:
						case WirePortDataType.FLOAT4:
						case WirePortDataType.COLOR: break;
					}
				}

				// Check matrix on second input
				if ( m_inputPorts[ 1 ].DataType == WirePortDataType.FLOAT3x3 )
				{
					switch ( m_inputPorts[ 0 ].DataType )
					{
						case WirePortDataType.OBJECT:
						case WirePortDataType.FLOAT:
						case WirePortDataType.INT:
						case WirePortDataType.FLOAT2:
						case WirePortDataType.FLOAT4:
						case WirePortDataType.COLOR:
						{
							m_inputA = UIUtils.CastPortType( ref dataCollector, m_currentPrecisionType, new NodeCastInfo( UniqueId, outputId ), m_inputA, m_inputPorts[ 0 ].DataType, WirePortDataType.FLOAT3, m_inputA );
						}
						break;
						case WirePortDataType.FLOAT4x4:
						case WirePortDataType.FLOAT3:
						case WirePortDataType.FLOAT3x3: break;
					}
				}

				if ( m_inputPorts[ 1 ].DataType == WirePortDataType.FLOAT4x4 )
				{
					switch ( m_inputPorts[ 0 ].DataType )
					{
						case WirePortDataType.OBJECT:
						case WirePortDataType.FLOAT:
						case WirePortDataType.INT:
						case WirePortDataType.FLOAT2:
						case WirePortDataType.FLOAT3:
						{
							m_inputA = UIUtils.CastPortType( ref dataCollector, m_currentPrecisionType, new NodeCastInfo( UniqueId, outputId ), m_inputA, m_inputPorts[ 0 ].DataType, WirePortDataType.FLOAT4, m_inputA );
						}
						break;
						case WirePortDataType.FLOAT3x3:
						case WirePortDataType.FLOAT4x4:
						case WirePortDataType.FLOAT4:
						case WirePortDataType.COLOR: break;
					}
				}

				return "mul( " + m_inputA + " , " + m_inputB + " )";
			}
			else
			{
				base.BuildResults( outputId, ref dataCollector, ignoreLocalvar );
				string result = "( " + m_extensibleInputResults[ 0 ];
				for ( int i = 1; i < m_extensibleInputResults.Count; i++ )
				{
					result += " * " + m_extensibleInputResults[ i ];
				}
				result += " )";
				return result;
			}
		}
	}
}
