using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlBlendmode
{
    private const string NativeLibName = SDL.NativeLibName;

	public enum SDL_BlendOperation
	{
		SDL_BLENDOPERATION_ADD = 1,
		SDL_BLENDOPERATION_SUBTRACT = 2,
		SDL_BLENDOPERATION_REV_SUBTRACT = 3,
		SDL_BLENDOPERATION_MINIMUM = 4,
		SDL_BLENDOPERATION_MAXIMUM = 5,
	}

	public enum SDL_BlendFactor
	{
		SDL_BLENDFACTOR_ZERO = 1,
		SDL_BLENDFACTOR_ONE = 2,
		SDL_BLENDFACTOR_SRC_COLOR = 3,
		SDL_BLENDFACTOR_ONE_MINUS_SRC_COLOR = 4,
		SDL_BLENDFACTOR_SRC_ALPHA = 5,
		SDL_BLENDFACTOR_ONE_MINUS_SRC_ALPHA = 6,
		SDL_BLENDFACTOR_DST_COLOR = 7,
		SDL_BLENDFACTOR_ONE_MINUS_DST_COLOR = 8,
		SDL_BLENDFACTOR_DST_ALPHA = 9,
		SDL_BLENDFACTOR_ONE_MINUS_DST_ALPHA = 10,
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_ComposeCustomBlendMode(SDL_BlendFactor srcColorFactor, SDL_BlendFactor dstColorFactor, SDL_BlendOperation colorOperation, SDL_BlendFactor srcAlphaFactor, SDL_BlendFactor dstAlphaFactor, SDL_BlendOperation alphaOperation);

}
