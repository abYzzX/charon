using System.Runtime.InteropServices;

namespace Charon.SDL3;

public unsafe partial struct IMG_Animation
{
    public int w;

    public int h;

    public int count;

    public SdlSurface.SDL_Surface** frames;

    public int* delays;
}

public enum IMG_AnimationDecoderStatus
{
    IMG_DECODER_STATUS_INVALID = -1,
    IMG_DECODER_STATUS_OK,
    IMG_DECODER_STATUS_FAILED,
    IMG_DECODER_STATUS_COMPLETE,
}

public static unsafe class Sdl3Image
{
    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int IMG_Version();

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadTyped_IO(IntPtr src, SDLBool closeio, IntPtr type);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_Load(IntPtr file);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_Load_IO(IntPtr src, SDLBool closeio);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadTexture(IntPtr renderer, IntPtr file);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadTexture_IO(IntPtr renderer, IntPtr src, SDLBool closeio);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadTextureTyped_IO(IntPtr renderer, IntPtr src,
        SDLBool closeio, IntPtr type);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isAVIF(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isICO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isCUR(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isBMP(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isGIF(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isJPG(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isJXL(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isLBM(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isPCX(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isPNG(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isPNM(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isSVG(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isQOI(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isTIF(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isXCF(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isXPM(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isXV(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_isWEBP(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadAVIF_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadICO_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadCUR_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadBMP_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadGIF_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadJPG_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadJXL_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadLBM_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadPCX_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadPNG_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadPNM_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadSVG_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadQOI_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadTGA_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadTIF_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadXCF_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadXPM_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadXV_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadWEBP_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadSizedSVG_IO(IntPtr src, int width, int height);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_ReadXPMFromArray(byte** xpm);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_ReadXPMFromArrayToRGB888(byte** xpm);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_Save(IntPtr surface, IntPtr file);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_SaveTyped_IO(IntPtr surface, IntPtr dst, SDLBool closeio,
        IntPtr type);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_SaveAVIF(IntPtr surface, IntPtr file, int quality);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_SaveAVIF_IO(IntPtr surface, IntPtr dst, SDLBool closeio,
        int quality);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_SaveBMP(IntPtr surface, IntPtr file);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_SaveBMP_IO(IntPtr surface, IntPtr dst, SDLBool closeio);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_SaveGIF(IntPtr surface, IntPtr file);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_SaveGIF_IO(IntPtr surface, IntPtr dst, SDLBool closeio);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_SaveJPG(IntPtr surface, IntPtr file, int quality);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_SaveJPG_IO(IntPtr surface, IntPtr dst, SDLBool closeio,
        int quality);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_SavePNG(IntPtr surface, IntPtr file);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_SavePNG_IO(IntPtr surface, IntPtr dst, SDLBool closeio);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_SaveTGA(IntPtr surface, IntPtr file);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_SaveTGA_IO(IntPtr surface, IntPtr dst, SDLBool closeio);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_SaveWEBP(IntPtr surface, IntPtr file, float quality);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_SaveWEBP_IO(IntPtr surface, IntPtr dst, SDLBool closeio,
        float quality);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadAnimation(IntPtr file);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadAnimation_IO(IntPtr src, SDLBool closeio);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadAnimationTyped_IO(IntPtr src, SDLBool closeio, IntPtr type);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IMG_FreeAnimation(IntPtr anim);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadAPNGAnimation_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadAVIFAnimation_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadGIFAnimation_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_LoadWEBPAnimation_IO(IntPtr src);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_CreateAnimationEncoder(IntPtr file);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_CreateAnimationEncoder_IO(IntPtr dst, SDLBool closeio, IntPtr type);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_CreateAnimationEncoderWithProperties(IntPtr props);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_AddAnimationEncoderFrame(IntPtr encoder,
        IntPtr surface, ulong duration);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_CloseAnimationEncoder(IntPtr encoder);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_CreateAnimationDecoder(IntPtr file);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_CreateAnimationDecoder_IO(IntPtr src, SDLBool closeio, IntPtr type);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_CreateAnimationDecoderWithProperties(IntPtr props);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr IMG_GetAnimationDecoderProperties(IntPtr decoder);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_GetAnimationDecoderFrame(IntPtr decoder, IntPtr frame, IntPtr duration);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IMG_AnimationDecoderStatus IMG_GetAnimationDecoderStatus(IntPtr decoder);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_ResetAnimationDecoder(IntPtr decoder);

    [DllImport("SDL3_image", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern SDLBool IMG_CloseAnimationDecoder(IntPtr decoder);

    public const int SDL_IMAGE_MAJOR_VERSION = 3;

    public const int SDL_IMAGE_MINOR_VERSION = 3;

    public const int SDL_IMAGE_MICRO_VERSION = 0;

    public const int SDL_IMAGE_VERSION = ((3) * 1000000 + (3) * 1000 + (0));

    public static ReadOnlySpan<byte> IMG_PROP_ANIMATION_ENCODER_CREATE_FILENAME_STRING =>
        "SDL_image.animation_encoder.create.filename"u8;

    public static ReadOnlySpan<byte> IMG_PROP_ANIMATION_ENCODER_CREATE_IOSTREAM_POINTER =>
        "SDL_image.animation_encoder.create.iostream"u8;

    public static ReadOnlySpan<byte> IMG_PROP_ANIMATION_ENCODER_CREATE_IOSTREAM_AUTOCLOSE_BOOLEAN =>
        "SDL_image.animation_encoder.create.iostream.autoclose"u8;

    public static ReadOnlySpan<byte> IMG_PROP_ANIMATION_ENCODER_CREATE_TYPE_STRING =>
        "SDL_image.animation_encoder.create.type"u8;

    public static ReadOnlySpan<byte> IMG_PROP_ANIMATION_ENCODER_CREATE_QUALITY_NUMBER =>
        "SDL_image.animation_encoder.create.quality"u8;

    public static ReadOnlySpan<byte> IMG_PROP_ANIMATION_ENCODER_CREATE_TIMEBASE_NUMERATOR_NUMBER =>
        "SDL_image.animation_encoder.create.timebase.numerator"u8;

    public static ReadOnlySpan<byte> IMG_PROP_ANIMATION_ENCODER_CREATE_TIMEBASE_DENOMINATOR_NUMBER =>
        "SDL_image.animation_encoder.create.timebase.denominator"u8;

    public static ReadOnlySpan<byte> IMG_PROP_ANIMATION_DECODER_CREATE_FILENAME_STRING =>
        "SDL_image.animation_decoder.create.filename"u8;

    public static ReadOnlySpan<byte> IMG_PROP_ANIMATION_DECODER_CREATE_IOSTREAM_POINTER =>
        "SDL_image.animation_decoder.create.iostream"u8;

    public static ReadOnlySpan<byte> IMG_PROP_ANIMATION_DECODER_CREATE_IOSTREAM_AUTOCLOSE_BOOLEAN =>
        "SDL_image.animation_decoder.create.iostream.autoclose"u8;

    public static ReadOnlySpan<byte> IMG_PROP_ANIMATION_DECODER_CREATE_TYPE_STRING =>
        "SDL_image.animation_decoder.create.type"u8;

    public static ReadOnlySpan<byte> IMG_PROP_ANIMATION_DECODER_CREATE_TIMEBASE_NUMERATOR_NUMBER =>
        "SDL_image.animation_decoder.create.timebase.numerator"u8;

    public static ReadOnlySpan<byte> IMG_PROP_ANIMATION_DECODER_CREATE_TIMEBASE_DENOMINATOR_NUMBER =>
        "SDL_image.animation_decoder.create.timebase.denominator"u8;

    public static ReadOnlySpan<byte> IMG_PROP_METADATA_IGNORE_PROPS_BOOLEAN => "SDL_image.metadata.ignore_props"u8;

    public static ReadOnlySpan<byte> IMG_PROP_METADATA_DESCRIPTION_STRING => "SDL_image.metadata.description"u8;

    public static ReadOnlySpan<byte> IMG_PROP_METADATA_COPYRIGHT_STRING => "SDL_image.metadata.copyright"u8;

    public static ReadOnlySpan<byte> IMG_PROP_METADATA_TITLE_STRING => "SDL_image.metadata.title"u8;

    public static ReadOnlySpan<byte> IMG_PROP_METADATA_AUTHOR_STRING => "SDL_image.metadata.author"u8;

    public static ReadOnlySpan<byte> IMG_PROP_METADATA_CREATION_TIME_STRING => "SDL_image.metadata.creation_time"u8;

    public static ReadOnlySpan<byte> IMG_PROP_METADATA_LOOP_COUNT_NUMBER => "SDL_image.metadata.loop_count"u8;
}
