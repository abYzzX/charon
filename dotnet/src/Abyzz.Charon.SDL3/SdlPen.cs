namespace Charon.SDL3;

public static unsafe partial class SdlPen
{
    private const string NativeLibName = SDL.NativeLibName;

	[Flags]
	public enum SDL_PenInputFlags : uint
	{
		SDL_PEN_INPUT_DOWN = 0x1,
		SDL_PEN_INPUT_BUTTON_1 = 0x2,
		SDL_PEN_INPUT_BUTTON_2 = 0x4,
		SDL_PEN_INPUT_BUTTON_3 = 0x08,
		SDL_PEN_INPUT_BUTTON_4 = 0x10,
		SDL_PEN_INPUT_BUTTON_5 = 0x20,
		SDL_PEN_INPUT_ERASER_TIP = 0x40000000,
	}

	public enum SDL_PenAxis
	{
		SDL_PEN_AXIS_PRESSURE = 0,
		SDL_PEN_AXIS_XTILT = 1,
		SDL_PEN_AXIS_YTILT = 2,
		SDL_PEN_AXIS_DISTANCE = 3,
		SDL_PEN_AXIS_ROTATION = 4,
		SDL_PEN_AXIS_SLIDER = 5,
		SDL_PEN_AXIS_TANGENTIAL_PRESSURE = 6,
		SDL_PEN_AXIS_COUNT = 7,
	}

}
